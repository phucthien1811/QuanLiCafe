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
    public partial class RevenueEDay : Form
    {
        private readonly CafeContext _context;

        public RevenueEDay()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            
            // Đăng ký sự kiện
            this.Load += RevenueEDay_Load;
            btn_LocDuLieu.Click += Btn_LocDuLieu_Click;
            btn_InBaoCao.Click += Btn_InBaoCao_Click;
            btn_XuatExcel.Click += Btn_XuatExcel_Click;
            
            // Set license context cho EPPlus
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void RevenueEDay_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định
            dtp_TuNgay.Value = DateTime.Today; // Ngày hôm nay
            dtp_DenNgay.Value = DateTime.Today; // Ngày hôm nay
            
            // Load logo (nếu có)
            LoadLogo();
            
            // Load dữ liệu ngày hôm nay
            LoadRevenueData(DateTime.Today, DateTime.Today);
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

        // Load dữ liệu doanh thu theo khoảng thời gian
        private void LoadRevenueData(DateTime fromDate, DateTime toDate)
        {
            try
            {
                dgv_HoaDon.Rows.Clear();
                
                // Thiết lập thời gian bắt đầu và kết thúc của ngày
                DateTime startDate = fromDate.Date; // 00:00:00
                DateTime endDate = toDate.Date.AddDays(1).AddSeconds(-1); // 23:59:59
                
                // Lấy các đơn hàng trong khoảng thời gian
                // Giả định: Các đơn có CreatedAt trong khoảng thời gian và đã được thanh toán
                // (có TotalAmount > 0 và có OrderDetails)
                var orders = _context.Orders
                    .Include(o => o.OrderDetails)
                    .Include(o => o.Table)
                    .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate 
                                && o.TotalAmount > 0
                                && o.OrderDetails.Any())
                    .OrderByDescending(o => o.CreatedAt)
                    .ToList();
                
                int stt = 1;
                decimal tongDoanhThu = 0;
                
                foreach (var order in orders)
                {
                    int rowIndex = dgv_HoaDon.Rows.Add();
                    var row = dgv_HoaDon.Rows[rowIndex];
                    
                    // Tính tổng số lượng món trong đơn
                    int soLuong = order.OrderDetails.Sum(od => od.Quantity);
                    
                    row.Cells["STT"].Value = stt++;
                    row.Cells["NgayThanhToan"].Value = order.CreatedAt.ToString("dd/MM/yyyy HH:mm");
                    row.Cells["SoLuong"].Value = soLuong;
                    row.Cells["TongTien"].Value = order.TotalAmount.ToString("N0") + " ₫";
                    row.Tag = order; // Lưu object order
                    
                    tongDoanhThu += order.TotalAmount;
                }
                
                // Hiển thị tổng doanh thu
                lb_TongTien.Text = tongDoanhThu.ToString("N0") + " ₫";
                
                // Hiển thị thông báo nếu không có dữ liệu
                if (orders.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu doanh thu:\n{ex.Message}", "Lỗi",
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
            LoadRevenueData(fromDate, toDate);
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
                    saveFileDialog.Title = "In báo cáo doanh thu theo ngày";
                    saveFileDialog.FileName = $"BaoCaoDoanhThu_{DateTime.Now:ddMMyyyy_HHmmss}.pdf";

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
                    saveFileDialog.Title = "Xuất báo cáo doanh thu";
                    saveFileDialog.FileName = $"DoanhThu_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(saveFileDialog.FileName);
                        MessageBox.Show($"Xuất file Excel thành công!\n\nĐường dẫn: {saveFileDialog.FileName}",
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
            report.AppendLine("=== BÁO CÁO DOANH THU THEO NGÀY ===");
            report.AppendLine($"Từ ngày: {dtp_TuNgay.Value:dd/MM/yyyy}");
            report.AppendLine($"Đến ngày: {dtp_DenNgay.Value:dd/MM/yyyy}");
            report.AppendLine($"Tổng doanh thu: {lb_TongTien.Text}");
            report.AppendLine($"Số hóa đơn: {dgv_HoaDon.Rows.Count}");
            report.AppendLine();
            report.AppendLine("Chi tiết:");
            
            foreach (DataGridViewRow row in dgv_HoaDon.Rows)
            {
                report.AppendLine($"- {row.Cells["NgayThanhToan"].Value} | " +
                    $"SL: {row.Cells["SoLuong"].Value} | " +
                    $"Tổng: {row.Cells["TongTien"].Value}");
            }
            
            return report.ToString();
        }

        // Xuất dữ liệu ra Excel sử dụng EPPlus
        private void ExportToExcel(string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Doanh thu theo ngày");

                // Tiêu đề
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = "BÁO CÁO DOANH THU THEO NGÀY";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Thông tin khoảng thời gian
                worksheet.Cells["A2"].Value = $"Từ ngày: {dtp_TuNgay.Value:dd/MM/yyyy} - Đến ngày: {dtp_DenNgay.Value:dd/MM/yyyy}";
                worksheet.Cells["A2"].Style.Font.Italic = true;

                // Header
                int headerRow = 4;
                worksheet.Cells[headerRow, 1].Value = "STT";
                worksheet.Cells[headerRow, 2].Value = "Ngày thanh toán";
                worksheet.Cells[headerRow, 3].Value = "Số lượng";
                worksheet.Cells[headerRow, 4].Value = "Tổng tiền";

                // Format header
                using (var range = worksheet.Cells[headerRow, 1, headerRow, 4])
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
                    worksheet.Cells[row, 2].Value = dgvRow.Cells["NgayThanhToan"].Value;
                    worksheet.Cells[row, 3].Value = dgvRow.Cells["SoLuong"].Value;
                    worksheet.Cells[row, 4].Value = dgvRow.Cells["TongTien"].Value;
                    row++;
                }

                // Tổng cộng
                worksheet.Cells[row + 1, 3].Value = "Tổng doanh thu:";
                worksheet.Cells[row + 1, 3].Style.Font.Bold = true;
                worksheet.Cells[row + 1, 4].Value = lb_TongTien.Text;
                worksheet.Cells[row + 1, 4].Style.Font.Bold = true;

                worksheet.Cells[row + 2, 3].Value = "Số hóa đơn:";
                worksheet.Cells[row + 2, 3].Style.Font.Bold = true;
                worksheet.Cells[row + 2, 4].Value = dgv_HoaDon.Rows.Count;

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
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            
            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Font cho tiếng Việt
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                // Tiêu đề
                Paragraph title = new Paragraph("BÁO CÁO DOANH THU THEO NGÀY", titleFont);
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
                PdfPTable table = new PdfPTable(4);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 10, 40, 20, 30 });

                // Header
                string[] headers = { "STT", "Ngày thanh toán", "Số lượng", "Tổng tiền" };
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
                    table.AddCell(new Phrase(dgvRow.Cells["NgayThanhToan"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["SoLuong"].Value?.ToString() ?? "", normalFont));
                    table.AddCell(new Phrase(dgvRow.Cells["TongTien"].Value?.ToString() ?? "", normalFont));
                }

                document.Add(table);

                // Tổng cộng
                Paragraph summary = new Paragraph(
                    $"\nTổng doanh thu: {lb_TongTien.Text}\nSố hóa đơn: {dgv_HoaDon.Rows.Count}", 
                    headerFont);
                summary.SpacingBefore = 10;
                document.Add(summary);
            }
            finally
            {
                document.Close();
            }
        }
    }
}
