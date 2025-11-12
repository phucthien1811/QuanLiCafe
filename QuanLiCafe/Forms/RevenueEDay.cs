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
                // Có thể load logo từ file nếu có
                // pb_Avatar.Image = Image.FromFile("path/to/logo.png");
                pb_Avatar.SizeMode = PictureBoxSizeMode.Zoom;
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
                // Tạo báo cáo in
                string reportContent = GenerateReport();
                
                // Hiển thị dialog in (có thể sử dụng PrintDialog)
                MessageBox.Show("Chức năng in báo cáo đang được phát triển!\n\n" + 
                    "Báo cáo sẽ được xuất ra file hoặc máy in.", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // TODO: Implement print functionality
                // PrintDocument printDoc = new PrintDocument();
                // printDoc.PrintPage += PrintDoc_PrintPage;
                // printDoc.Print();
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
                // Kiểm tra có dữ liệu không
                if (dgv_HoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Tạo SaveFileDialog
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

        // Xuất dữ liệu ra Excel
        private void ExportToExcel(string filePath)
        {
            // Sử dụng EPPlus hoặc thư viện khác để xuất Excel
            // Đơn giản hóa: Xuất dưới dạng CSV
            StringBuilder csv = new StringBuilder();
            
            // Header
            csv.AppendLine("STT,Ngày thanh toán,Số lượng,Tổng tiền");
            
            // Data
            foreach (DataGridViewRow row in dgv_HoaDon.Rows)
            {
                csv.AppendLine($"{row.Cells["STT"].Value}," +
                    $"{row.Cells["NgayThanhToan"].Value}," +
                    $"{row.Cells["SoLuong"].Value}," +
                    $"{row.Cells["TongTien"].Value}");
            }
            
            // Footer
            csv.AppendLine();
            csv.AppendLine($",,Tổng doanh thu,{lb_TongTien.Text}");
            
            // Ghi file
            System.IO.File.WriteAllText(filePath.Replace(".xlsx", ".csv"), csv.ToString(), Encoding.UTF8);
            
            // Nếu cần xuất đúng định dạng Excel, sử dụng EPPlus:
            // using (var package = new ExcelPackage(new FileInfo(filePath)))
            // {
            //     var worksheet = package.Workbook.Worksheets.Add("Doanh Thu");
            //     // ... thêm dữ liệu vào worksheet
            //     package.Save();
            // }
        }
    }
}
