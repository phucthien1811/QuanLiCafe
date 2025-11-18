using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ReportForm
{
    public partial class ReportForm : Form
    {
        private readonly CafeContext _context;

        public ReportForm()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;

            // Đăng ký sự kiện
            this.Load += ReportForm_Load;
            btn_LocDuLieu.Click += Btn_LocDuLieu_Click;
            btn_InBaoCao.Click += Btn_InBaoCao_Click;
            btn_XuatExcel.Click += Btn_XuatExcel_Click;
            
            // Set license context cho EPPlus
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định
            dtp_TuNgay.Value = DateTime.Today; // Ngày hôm nay
            dtp_DenNgay.Value = DateTime.Today; // Ngày hôm nay

            // Load logo (nếu có)
            LoadLogo();

            // Load dữ liệu ngày hôm nay
            LoadOrderHistory(DateTime.Today, DateTime.Today);
        }

        private void LoadLogo()
        {
            try
            {
                // Logo có thể được thêm vào form nếu cần
                // pb_Avatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                // Nếu không có logo thì bỏ qua
            }
        }

        // Load lịch sử hóa đơn chi tiết
        private void LoadOrderHistory(DateTime fromDate, DateTime toDate)
        {
            try
            {
                dgv_HoaDon.Rows.Clear();

                // Thiết lập thời gian bắt đầu và kết thúc
                DateTime startDate = fromDate.Date; // 00:00:00
                DateTime endDate = toDate.Date.AddDays(1).AddSeconds(-1); // 23:59:59

                // Lấy tất cả OrderDetails trong khoảng thời gian
                var orderDetails = _context.OrderDetails
                    .Include(od => od.Order)
                        .ThenInclude(o => o.Staff)
                    .Include(od => od.Product)
                    .Where(od => od.Order.CreatedAt >= startDate
                                && od.Order.CreatedAt <= endDate
                                && od.Order.TotalAmount > 0)
                    .OrderByDescending(od => od.Order.CreatedAt)
                    .ToList();

                int stt = 1;
                decimal tongTien = 0;

                foreach (var detail in orderDetails)
                {
                    int rowIndex = dgv_HoaDon.Rows.Add();
                    var row = dgv_HoaDon.Rows[rowIndex];

                    row.Cells["STT"].Value = stt++;
                    row.Cells["Ngay"].Value = detail.Order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
                    row.Cells["MaPhieu"].Value = detail.Order.Id;
                    row.Cells["MaPhieuChiTiet"].Value = detail.Id;
                    
                    // ✅ FIX: Kiểm tra null trước khi truy cập Staff
                    if (detail.Order.Staff != null)
                    {
                        row.Cells["MaNV"].Value = detail.Order.StaffId + " - " + detail.Order.Staff.Username;
                    }
                    else
                    {
                        row.Cells["MaNV"].Value = detail.Order.StaffId?.ToString() ?? "N/A" + " - Nhân viên đã xóa";
                    }
                    
                    row.Cells["MaKH"].Value = "N/A"; // Nếu có bảng Customer thì map vào
                    row.Cells["MaDoUong"].Value = detail.ProductId;
                    row.Cells["TenDoUong"].Value = detail.Product.Name;
                    row.Tag = detail; // Lưu object detail

                    // Tính tổng tiền của từng dòng
                    decimal lineTotal = detail.Quantity * detail.UnitPrice;
                    tongTien += lineTotal;
                }

                // Hiển thị tổng tiền
                lb_TongTien.Text = tongTien.ToString("N0") + " ₫";

                // Hiển thị số lượng record
                lb_Tong.Text = $"Tổng ({dgv_HoaDon.Rows.Count} dòng)";

                // Thông báo nếu không có dữ liệu
                if (orderDetails.Count == 0)
                {
                    MessageBox.Show("Không có lịch sử hóa đơn trong khoảng thời gian này!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch sử hóa đơn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Lọc dữ liệu
        private void Btn_LocDuLieu_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtp_TuNgay.Value.Date;
            DateTime toDate = dtp_DenNgay.Value.Date;

            // Kiểm tra ngày hợp lệ
            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Load dữ liệu theo khoảng thời gian đã chọn
            LoadOrderHistory(fromDate, toDate);
        }

        // Nút In báo cáo
        private void Btn_InBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_HoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để in!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "In báo cáo lịch sử hóa đơn";
                    saveFileDialog.FileName = $"BaoCaoLichSu_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToPDF(saveFileDialog.FileName);
                        MessageBox.Show($"In báo cáo thành công!\n\nĐường dẫn: {saveFileDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Mở file PDF
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveFileDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi in báo cáo:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xuất Excel
        private void Btn_XuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_HoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất lịch sử hóa đơn";
                    saveFileDialog.FileName = $"LichSuHoaDon_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(saveFileDialog.FileName);
                        MessageBox.Show($"Xuất file thành công!\n\nĐường dẫn: {saveFileDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Mở file Excel
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = saveFileDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo nội dung báo cáo
        private string GenerateReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("=== LỊCH SỬ HÓA ĐƠN BÁN HÀNG ===");
            report.AppendLine($"Từ ngày: {dtp_TuNgay.Value:dd/MM/yyyy}");
            report.AppendLine($"Đến ngày: {dtp_DenNgay.Value:dd/MM/yyyy}");
            report.AppendLine($"Tổng số dòng: {dgv_HoaDon.Rows.Count}");
            report.AppendLine($"Tổng tiền: {lb_TongTien.Text}");
            report.AppendLine();
            report.AppendLine("Chi tiết:");
            report.AppendLine();

            foreach (DataGridViewRow row in dgv_HoaDon.Rows)
            {
                report.AppendLine($"#{row.Cells["STT"].Value}");
                report.AppendLine($"Ngày: {row.Cells["Ngay"].Value}");
                report.AppendLine($"Mã phiếu: {row.Cells["MaPhieu"].Value}");
                report.AppendLine($"Mã chi tiết: {row.Cells["MaPhieuChiTiet"].Value}");
                report.AppendLine($"Nhân viên: {row.Cells["MaNV"].Value}");
                report.AppendLine($"Đồ uống: {row.Cells["TenDoUong"].Value} (Mã: {row.Cells["MaDoUong"].Value})");
                report.AppendLine();
            }

            return report.ToString();
        }

        // Xuất dữ liệu ra Excel sử dụng EPPlus
        private void ExportToExcel(string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Lịch sử hóa đơn");

                // Tiêu đề
                worksheet.Cells["A1:H1"].Merge = true;
                worksheet.Cells["A1"].Value = "LỊCH SỬ HÓA ĐƠN BÁN HÀNG";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Thông tin khoảng thời gian
                worksheet.Cells["A2"].Value = $"Từ ngày: {dtp_TuNgay.Value:dd/MM/yyyy} - Đến ngày: {dtp_DenNgay.Value:dd/MM/yyyy}";
                worksheet.Cells["A2"].Style.Font.Italic = true;

                // Header
                int headerRow = 4;
                worksheet.Cells[headerRow, 1].Value = "STT";
                worksheet.Cells[headerRow, 2].Value = "Ngày";
                worksheet.Cells[headerRow, 3].Value = "Mã Phiếu";
                worksheet.Cells[headerRow, 4].Value = "Mã Chi Tiết";
                worksheet.Cells[headerRow, 5].Value = "Nhân viên";
                worksheet.Cells[headerRow, 6].Value = "Khách hàng";
                worksheet.Cells[headerRow, 7].Value = "Mã Đồ Uống";
                worksheet.Cells[headerRow, 8].Value = "Tên Đồ Uống";

                // Format header
                using (var range = worksheet.Cells[headerRow, 1, headerRow, 8])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }

                // Data
                int row = headerRow + 1;
                foreach (DataGridViewRow dgvRow in dgv_HoaDon.Rows)
                {
                    worksheet.Cells[row, 1].Value = dgvRow.Cells["STT"].Value;
                    worksheet.Cells[row, 2].Value = dgvRow.Cells["Ngay"].Value;
                    worksheet.Cells[row, 3].Value = dgvRow.Cells["MaPhieu"].Value;
                    worksheet.Cells[row, 4].Value = dgvRow.Cells["MaPhieuChiTiet"].Value;
                    worksheet.Cells[row, 5].Value = dgvRow.Cells["MaNV"].Value;
                    worksheet.Cells[row, 6].Value = dgvRow.Cells["MaKH"].Value;
                    worksheet.Cells[row, 7].Value = dgvRow.Cells["MaDoUong"].Value;
                    worksheet.Cells[row, 8].Value = dgvRow.Cells["TenDoUong"].Value;
                    row++;
                }

                // Tổng cộng
                worksheet.Cells[row + 1, 7].Value = "Tổng số dòng:";
                worksheet.Cells[row + 1, 7].Style.Font.Bold = true;
                worksheet.Cells[row + 1, 8].Value = dgv_HoaDon.Rows.Count;

                worksheet.Cells[row + 2, 7].Value = "Tổng tiền:";
                worksheet.Cells[row + 2, 7].Style.Font.Bold = true;
                worksheet.Cells[row + 2, 8].Value = lb_TongTien.Text;
                worksheet.Cells[row + 2, 8].Style.Font.Bold = true;

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Lưu file
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        // Xuất PDF để in báo cáo
        private void ExportToPDF(string filePath)
        {
            Document document = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
            
            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Font cho tiếng Việt
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);

                // Tiêu đề
                Paragraph title = new Paragraph("LỊCH SỬ HÓA ĐƠN BÁN HÀNG", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Thông tin khoảng thời gian
                Paragraph dateRange = new Paragraph(
                    $"Từ ngày: {dtp_TuNgay.Value:dd/MM/yyyy} - Đến ngày: {dtp_DenNgay.Value:dd/MM/yyyy}", 
                    normalFont);
                dateRange.Alignment = Element.ALIGN_CENTER;
                dateRange.SpacingAfter = 10;
                document.Add(dateRange);

                // Tạo bảng
                PdfPTable table = new PdfPTable(8);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 5, 12, 8, 10, 15, 10, 10, 20 });

                // Header
                string[] headers = { "STT", "Ngày", "Mã Phiếu", "Mã CT", "Nhân viên", "Khách hàng", "Mã ĐU", "Tên Đồ Uống" };
                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, headerFont));
                    cell.BackgroundColor = new BaseColor(211, 211, 211); // Light gray
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    table.AddCell(cell);
                }

                // Data
                foreach (DataGridViewRow dgvRow in dgv_HoaDon.Rows)
                {
                    table.AddCell(new Phrase(dgvRow.Cells["STT"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["Ngay"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["MaPhieu"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["MaPhieuChiTiet"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["MaNV"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["MaKH"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["MaDoUong"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["TenDoUong"].Value?.ToString() ?? "", normalFont));
                }

                document.Add(table);

                // Tổng cộng
                Paragraph summary = new Paragraph(
                    $"\nTổng số dòng: {dgv_HoaDon.Rows.Count}\nTổng tiền: {lb_TongTien.Text}", 
                    headerFont);
                summary.SpacingBefore = 10;
                document.Add(summary);
            }
            finally
            {
                document.Close();
            }
        }

        private void lb_tieude_Click(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void btn_InBaoCao_Click(object sender, EventArgs e)
        {
            Btn_InBaoCao_Click(sender, e);
        }

        private void ReportForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
