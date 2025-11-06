using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text;
using SystemFont = System.Drawing.Font;
using PdfFont = iTextSharp.text.Font;

namespace QuanLiCafe.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly CafeContext _context;
        private readonly IOrderService _orderService;

        public PaymentService(CafeContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        /// <summary>
        /// X? lý thanh toán: Tính t?ng + L?u DB + C?p nh?t tr?ng thái bàn = Closed
        /// </summary>
        public void ProcessPayment(int orderId, decimal discountPercent, decimal vatPercent)
        {
            // 1. Tính l?i t?ng ti?n b?ng OrderService
            _orderService.RecalcOrderTotals(orderId, discountPercent, vatPercent);

            // 2. L?y order và c?p nh?t tr?ng thái bàn = Closed
            var order = _context.Orders
                .Include(o => o.Table)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                throw new InvalidOperationException($"Order ID {orderId} không t?n t?i");

            // C?p nh?t tr?ng thái bàn
            if (order.Table != null)
            {
                order.Table.Status = "Closed";
            }

            _context.SaveChanges();
        }

        /// <summary>
        /// Xu?t hóa ??n PDF s? d?ng iTextSharp
        /// </summary>
        public string ExportInvoiceToPDF(int orderId, string outputPath)
        {
            // ??ng ký encoding ?? hi?n th? ti?ng Vi?t
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // L?y order v?i ??y ?? thông tin
            var order = _context.Orders
                .Include(o => o.Table)
                .Include(o => o.Staff)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                throw new InvalidOperationException($"Order ID {orderId} không t?n t?i");

            // T?o document PDF
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var outputFile = Path.Combine(outputPath, $"HoaDon_{orderId}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            using (var writer = PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create)))
            {
                document.Open();

                // Font ti?ng Vi?t
                var fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                var baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                var titleFont = new PdfFont(baseFont, 18, PdfFont.BOLD);
                var headerFont = new PdfFont(baseFont, 12, PdfFont.BOLD);
                var normalFont = new PdfFont(baseFont, 10, PdfFont.NORMAL);

                // ===== HEADER =====
                var title = new Paragraph("HÓA ??N THANH TOÁN", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 10f;
                document.Add(title);

                var shopInfo = new Paragraph("QUÁN CÀ PHÊ ABC\n??a ch?: 123 Nguy?n V?n Linh, TP.HCM\n?T: 0123.456.789", normalFont);
                shopInfo.Alignment = Element.ALIGN_CENTER;
                shopInfo.SpacingAfter = 20f;
                document.Add(shopInfo);

                // ===== THÔNG TIN ??N HÀNG =====
                document.Add(new Paragraph($"Mã hóa ??n: #{order.Id}", headerFont));
                document.Add(new Paragraph($"Bàn: {order.Table?.Name ?? "N/A"}", normalFont));
                document.Add(new Paragraph($"Nhân viên: {order.Staff?.Username ?? "N/A"}", normalFont));
                document.Add(new Paragraph($"Th?i gian: {order.CreatedAt:dd/MM/yyyy HH:mm:ss}", normalFont));
                document.Add(new Paragraph(" ", normalFont)); // Spacing

                // ===== B?NG CHI TI?T MÓN =====
                var table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 5f, 30f, 15f, 20f, 30f });
                table.SpacingBefore = 10f;
                table.SpacingAfter = 20f;

                // Header
                table.AddCell(CreateCell("STT", headerFont, Element.ALIGN_CENTER));
                table.AddCell(CreateCell("Tên món", headerFont, Element.ALIGN_LEFT));
                table.AddCell(CreateCell("SL", headerFont, Element.ALIGN_CENTER));
                table.AddCell(CreateCell("??n giá", headerFont, Element.ALIGN_RIGHT));
                table.AddCell(CreateCell("Thành ti?n", headerFont, Element.ALIGN_RIGHT));

                // Rows
                int stt = 1;
                decimal subTotal = 0;
                foreach (var detail in order.OrderDetails)
                {
                    var itemTotal = detail.Quantity * detail.UnitPrice;
                    subTotal += itemTotal;

                    table.AddCell(CreateCell(stt.ToString(), normalFont, Element.ALIGN_CENTER));
                    table.AddCell(CreateCell(detail.Product.Name, normalFont, Element.ALIGN_LEFT));
                    table.AddCell(CreateCell(detail.Quantity.ToString(), normalFont, Element.ALIGN_CENTER));
                    table.AddCell(CreateCell($"{detail.UnitPrice:N0} ?", normalFont, Element.ALIGN_RIGHT));
                    table.AddCell(CreateCell($"{itemTotal:N0} ?", normalFont, Element.ALIGN_RIGHT));
                    stt++;
                }

                document.Add(table);

                // ===== T?NG TI?N =====
                var discountAmount = subTotal * order.Discount / 100;
                var afterDiscount = subTotal - discountAmount;
                var vatAmount = afterDiscount * order.VAT / 100;

                document.Add(new Paragraph($"T?m tính: {subTotal:N0} ?", normalFont) { Alignment = Element.ALIGN_RIGHT });
                document.Add(new Paragraph($"Gi?m giá ({order.Discount}%): -{discountAmount:N0} ?", normalFont) { Alignment = Element.ALIGN_RIGHT });
                document.Add(new Paragraph($"VAT ({order.VAT}%): +{vatAmount:N0} ?", normalFont) { Alignment = Element.ALIGN_RIGHT });
                
                var totalPara = new Paragraph($"T?NG C?NG: {order.TotalAmount:N0} ?", headerFont);
                totalPara.Alignment = Element.ALIGN_RIGHT;
                totalPara.SpacingBefore = 10f;
                document.Add(totalPara);

                // ===== FOOTER =====
                var footer = new Paragraph("\nC?m ?n quý khách! H?n g?p l?i!", normalFont);
                footer.Alignment = Element.ALIGN_CENTER;
                footer.SpacingBefore = 30f;
                document.Add(footer);

                document.Close();
            }

            return outputFile;
        }

        /// <summary>
        /// Xu?t hóa ??n Excel s? d?ng EPPlus
        /// </summary>
        public string ExportInvoiceToExcel(int orderId, string outputPath)
        {
            // Set EPPlus license (NonCommercial)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // L?y order v?i ??y ?? thông tin
            var order = _context.Orders
                .Include(o => o.Table)
                .Include(o => o.Staff)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                throw new InvalidOperationException($"Order ID {orderId} không t?n t?i");

            var outputFile = Path.Combine(outputPath, $"HoaDon_{orderId}_{DateTime.Now:yyyyMMddHHmmss}.xlsx");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Hóa ??n");

                // ===== HEADER =====
                worksheet.Cells["A1:E1"].Merge = true;
                worksheet.Cells["A1"].Value = "HÓA ??N THANH TOÁN";
                worksheet.Cells["A1"].Style.Font.Size = 18;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A2:E2"].Merge = true;
                worksheet.Cells["A2"].Value = "QUÁN CÀ PHÊ ABC";
                worksheet.Cells["A2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3:E3"].Merge = true;
                worksheet.Cells["A3"].Value = "??a ch?: 123 Nguy?n V?n Linh, TP.HCM | ?T: 0123.456.789";
                worksheet.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // ===== THÔNG TIN ??N HÀNG =====
                int row = 5;
                worksheet.Cells[$"A{row}"].Value = $"Mã hóa ??n:";
                worksheet.Cells[$"B{row}"].Value = $"#{order.Id}";
                worksheet.Cells[$"B{row}"].Style.Font.Bold = true;

                row++;
                worksheet.Cells[$"A{row}"].Value = "Bàn:";
                worksheet.Cells[$"B{row}"].Value = order.Table?.Name ?? "N/A";

                row++;
                worksheet.Cells[$"A{row}"].Value = "Nhân viên:";
                worksheet.Cells[$"B{row}"].Value = order.Staff?.Username ?? "N/A";

                row++;
                worksheet.Cells[$"A{row}"].Value = "Th?i gian:";
                worksheet.Cells[$"B{row}"].Value = order.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");

                // ===== B?NG CHI TI?T =====
                row += 2;
                int headerRow = row;
                worksheet.Cells[$"A{headerRow}"].Value = "STT";
                worksheet.Cells[$"B{headerRow}"].Value = "Tên món";
                worksheet.Cells[$"C{headerRow}"].Value = "S? l??ng";
                worksheet.Cells[$"D{headerRow}"].Value = "??n giá";
                worksheet.Cells[$"E{headerRow}"].Value = "Thành ti?n";

                // Style header
                var headerRange = worksheet.Cells[$"A{headerRow}:E{headerRow}"];
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                headerRange.Style.Border.BorderAround(ExcelBorderStyle.Thin);

                // Data rows
                int stt = 1;
                decimal subTotal = 0;
                foreach (var detail in order.OrderDetails)
                {
                    row++;
                    var itemTotal = detail.Quantity * detail.UnitPrice;
                    subTotal += itemTotal;

                    worksheet.Cells[$"A{row}"].Value = stt;
                    worksheet.Cells[$"B{row}"].Value = detail.Product.Name;
                    worksheet.Cells[$"C{row}"].Value = detail.Quantity;
                    worksheet.Cells[$"D{row}"].Value = detail.UnitPrice;
                    worksheet.Cells[$"E{row}"].Value = itemTotal;

                    // Format currency
                    worksheet.Cells[$"D{row}"].Style.Numberformat.Format = "#,##0 ?";
                    worksheet.Cells[$"E{row}"].Style.Numberformat.Format = "#,##0 ?";

                    stt++;
                }

                // Border cho b?ng
                var tableRange = worksheet.Cells[$"A{headerRow}:E{row}"];
                tableRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                tableRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                tableRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                tableRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                // ===== T?NG TI?N =====
                row += 2;
                var discountAmount = subTotal * order.Discount / 100;
                var afterDiscount = subTotal - discountAmount;
                var vatAmount = afterDiscount * order.VAT / 100;

                worksheet.Cells[$"D{row}"].Value = "T?m tính:";
                worksheet.Cells[$"E{row}"].Value = subTotal;
                worksheet.Cells[$"E{row}"].Style.Numberformat.Format = "#,##0 ?";

                row++;
                worksheet.Cells[$"D{row}"].Value = $"Gi?m giá ({order.Discount}%):";
                worksheet.Cells[$"E{row}"].Value = -discountAmount;
                worksheet.Cells[$"E{row}"].Style.Numberformat.Format = "#,##0 ?";
                worksheet.Cells[$"E{row}"].Style.Font.Color.SetColor(System.Drawing.Color.Red);

                row++;
                worksheet.Cells[$"D{row}"].Value = $"VAT ({order.VAT}%):";
                worksheet.Cells[$"E{row}"].Value = vatAmount;
                worksheet.Cells[$"E{row}"].Style.Numberformat.Format = "#,##0 ?";

                row++;
                worksheet.Cells[$"D{row}"].Value = "T?NG C?NG:";
                worksheet.Cells[$"E{row}"].Value = order.TotalAmount;
                worksheet.Cells[$"D{row}:E{row}"].Style.Font.Bold = true;
                worksheet.Cells[$"D{row}:E{row}"].Style.Font.Size = 14;
                worksheet.Cells[$"E{row}"].Style.Numberformat.Format = "#,##0 ?";
                worksheet.Cells[$"D{row}:E{row}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[$"D{row}:E{row}"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);

                // ===== FOOTER =====
                row += 2;
                worksheet.Cells[$"A{row}:E{row}"].Merge = true;
                worksheet.Cells[$"A{row}"].Value = "C?m ?n quý khách! H?n g?p l?i!";
                worksheet.Cells[$"A{row}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[$"A{row}"].Style.Font.Italic = true;

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Save
                package.SaveAs(new FileInfo(outputFile));
            }

            return outputFile;
        }

        /// <summary>
        /// Helper: T?o cell cho PdfPTable
        /// </summary>
        private PdfPCell CreateCell(string text, PdfFont font, int alignment)
        {
            var cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = alignment;
            cell.Padding = 5;
            cell.BorderWidth = 0.5f;
            return cell;
        }
    }
}
