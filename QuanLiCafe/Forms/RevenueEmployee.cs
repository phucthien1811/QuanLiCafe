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
    public partial class RevenueEmployee : Form
    {
        private readonly CafeContext _context;

        public RevenueEmployee()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            
            // Đăng ký sự kiện
            this.Load += RevenueEmployee_Load;
            btn_LocDuLieu.Click += Btn_LocDuLieu_Click;
            btn_InBaoCao.Click += Btn_InBaoCao_Click;
            btn_XuatExcel.Click += Btn_XuatExcel_Click;
        }

        private void RevenueEmployee_Load(object sender, EventArgs e)
        {
            // Thiết lập ngày mặc định
            dtp_TuNgay.Value = DateTime.Today; // Ngày hôm nay
            dtp_DenNgay.Value = DateTime.Today; // Ngày hôm nay
            
            // Load logo (nếu có)
            LoadLogo();
            
            // Load dữ liệu ngày hôm nay
            LoadRevenueByStaff(DateTime.Today, DateTime.Today);
        }

        private void LoadLogo()
        {
            try
            {
                // Có thể load logo từ file nếu có
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {
                // Nếu không có logo thì bỏ qua
            }
        }

        // Load dữ liệu doanh thu theo nhân viên
        private void LoadRevenueByStaff(DateTime fromDate, DateTime toDate)
        {
            try
            {
                dgv_HoaDon.Rows.Clear();
                
                // Thiết lập thời gian bắt đầu và kết thúc của ngày
                DateTime startDate = fromDate.Date; // 00:00:00
                DateTime endDate = toDate.Date.AddDays(1).AddSeconds(-1); // 23:59:59
                
                // Bước 1: Lấy tất cả đơn hàng trong khoảng thời gian
                var orders = _context.Orders
                    .Include(o => o.OrderDetails)
                    .Include(o => o.Staff)
                    .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate 
                                && o.TotalAmount > 0
                                && o.OrderDetails.Any())
                    .ToList(); // Execute query và load vào memory
                
                // Bước 2: Group và aggregate trong memory (LINQ to Objects)
                var staffRevenue = orders
                    .GroupBy(o => new { o.StaffId, o.Staff.Username })
                    .Select(g => new
                    {
                        StaffId = g.Key.StaffId,
                        StaffName = g.Key.Username,
                        TotalOrders = g.Count(),
                        TotalQuantity = g.Sum(o => o.OrderDetails.Sum(od => od.Quantity)),
                        TotalRevenue = g.Sum(o => o.TotalAmount)
                    })
                    .OrderByDescending(s => s.TotalRevenue)
                    .ToList();
                
                int stt = 1;
                decimal tongDoanhThu = 0;
                
                foreach (var staff in staffRevenue)
                {
                    int rowIndex = dgv_HoaDon.Rows.Add();
                    var row = dgv_HoaDon.Rows[rowIndex];
                    
                    row.Cells["STT"].Value = stt++;
                    row.Cells["MaNV"].Value = staff.StaffId;
                    row.Cells["TenNV"].Value = staff.StaffName;
                    row.Cells["SoLuong"].Value = $"{staff.TotalOrders} đơn - {staff.TotalQuantity} món";
                    row.Cells["ThanhTien"].Value = staff.TotalRevenue.ToString("N0") + " ₫";
                    row.Tag = staff; // Lưu object staff
                    
                    tongDoanhThu += staff.TotalRevenue;
                }
                
                // Hiển thị tổng doanh thu
                lb_TongTien.Text = tongDoanhThu.ToString("N0") + " ₫";
                
                // Hiển thị thông báo nếu không có dữ liệu
                if (staffRevenue.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này!", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu doanh thu:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Lỗi",
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
            LoadRevenueByStaff(fromDate, toDate);
        }

        // Nút In báo cáo
        private void Btn_InBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo báo cáo in
                string reportContent = GenerateReport();
                
                // Hiển thị dialog in
                MessageBox.Show("Chức năng in báo cáo đang được phát triển!\n\n" + 
                    "Báo cáo sẽ được xuất ra file hoặc máy in.", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // TODO: Implement print functionality
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
                    saveFileDialog.Filter = "CSV Files|*.csv|Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất báo cáo doanh thu theo nhân viên";
                    saveFileDialog.FileName = $"DoanhThuNhanVien_{DateTime.Now:ddMMyyyy_HHmmss}.csv";
                    
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(saveFileDialog.FileName);
                        MessageBox.Show($"Xuất file thành công!\n\nĐường dẫn: {saveFileDialog.FileName}", 
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
            report.AppendLine("=== BÁO CÁO DOANH THU THEO NHÂN VIÊN ===");
            report.AppendLine($"Từ ngày: {dtp_TuNgay.Value:dd/MM/yyyy}");
            report.AppendLine($"Đến ngày: {dtp_DenNgay.Value:dd/MM/yyyy}");
            report.AppendLine($"Tổng doanh thu: {lb_TongTien.Text}");
            report.AppendLine($"Số nhân viên: {dgv_HoaDon.Rows.Count}");
            report.AppendLine();
            report.AppendLine("Chi tiết:");
            report.AppendLine();
            
            foreach (DataGridViewRow row in dgv_HoaDon.Rows)
            {
                report.AppendLine($"#{row.Cells["STT"].Value}");
                report.AppendLine($"Mã NV: {row.Cells["MaNV"].Value}");
                report.AppendLine($"Tên NV: {row.Cells["TenNV"].Value}");
                report.AppendLine($"Số lượng: {row.Cells["SoLuong"].Value}");
                report.AppendLine($"Doanh thu: {row.Cells["ThanhTien"].Value}");
                report.AppendLine();
            }
            
            return report.ToString();
        }

        // Xuất dữ liệu ra Excel/CSV
        private void ExportToExcel(string filePath)
        {
            StringBuilder csv = new StringBuilder();
            
            // Header
            csv.AppendLine("STT,Mã nhân viên,Tên nhân viên,Số lượng,Thành tiền");
            
            // Data
            foreach (DataGridViewRow row in dgv_HoaDon.Rows)
            {
                string soLuong = row.Cells["SoLuong"].Value?.ToString()?.Replace(",", " -") ?? "";
                csv.AppendLine($"{row.Cells["STT"].Value}," +
                    $"{row.Cells["MaNV"].Value}," +
                    $"\"{row.Cells["TenNV"].Value}\"," +
                    $"\"{soLuong}\"," +
                    $"\"{row.Cells["ThanhTien"].Value}\"");
            }
            
            // Footer
            csv.AppendLine();
            csv.AppendLine($",,,,");
            csv.AppendLine($",,,Tổng doanh thu:,\"{lb_TongTien.Text}\"");
            csv.AppendLine($",,,Số nhân viên:,{dgv_HoaDon.Rows.Count}");
            
            // Ghi file
            System.IO.File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
        }
    }
}
