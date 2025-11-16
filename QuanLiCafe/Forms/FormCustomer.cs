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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace MemberForm
{
    public partial class CustomerForm : Form
    {
        private readonly CafeContext _context;

        public CustomerForm()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;

            // Đăng ký sự kiện
            this.Load += CustomerForm_Load;
            btn_them.Click += Btn_them_Click;
            btn_sua.Click += Btn_sua_Click;
            btn_xoa.Click += Btn_xoa_Click;
            btn_lamMoi.Click += Btn_lamMoi_Click;
            btn_timKiem.Click += Btn_timKiem_Click;
            btn_xuatExcel.Click += Btn_xuatExcel_Click;
            btn_thoat.Click += Btn_thoat_Click;
            
            // Set license context cho EPPlus
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        // Load danh sách khách hàng
        private void LoadCustomers(string searchPhone = "")
        {
            try
            {
                dgv_customer.Rows.Clear();

                var query = _context.Customers.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchPhone))
                {
                    query = query.Where(c => c.PhoneNumber.Contains(searchPhone));
                }

                var customers = query.OrderBy(c => c.Name).ToList();

                foreach (var customer in customers)
                {
                    int rowIndex = dgv_customer.Rows.Add();
                    var row = dgv_customer.Rows[rowIndex];

                    row.Cells["MaKH"].Value = customer.Id;
                    row.Cells["TenKH"].Value = customer.Name;
                    row.Cells["GioiTinh"].Value = customer.Gender ?? "";
                    row.Cells["SDT"].Value = customer.PhoneNumber;
                    row.Tag = customer; // Lưu object customer
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách khách hàng:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Thêm - Mở form AddCustomer
        private void Btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new AddCustomer();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thêm khách hàng:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa
        private void Btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_customer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgv_customer.SelectedRows[0];
                var customer = selectedRow.Tag as Customer;

                if (customer != null)
                {
                    var editForm = new AddCustomer(customer.Id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCustomers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form sửa khách hàng:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa - Mở form DeleteCustom
        private void Btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_customer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgv_customer.SelectedRows[0];
                var customer = selectedRow.Tag as Customer;

                if (customer != null)
                {
                    var deleteForm = new DeleteCustom(customer.Id);
                    if (deleteForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadCustomers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form xóa khách hàng:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Làm mới
        private void Btn_lamMoi_Click(object sender, EventArgs e)
        {
            txb_timKiem.Clear();
            LoadCustomers();
        }

        // Nút Tìm kiếm
        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            LoadCustomers(txb_timKiem.Text);
        }

        // Nút Xuất Excel
        private void Btn_xuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_customer.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất danh sách khách hàng";
                    saveFileDialog.FileName = $"DanhSachKhachHang_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

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

        // Xuất dữ liệu ra Excel sử dụng EPPlus
        private void ExportToExcel(string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách khách hàng");

                // Tiêu đề
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = "DANH SÁCH KHÁCH HÀNG";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Ngày xuất
                worksheet.Cells["A2"].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                worksheet.Cells["A2"].Style.Font.Italic = true;

                // Header
                int headerRow = 4;
                worksheet.Cells[headerRow, 1].Value = "Mã KH";
                worksheet.Cells[headerRow, 2].Value = "Tên khách hàng";
                worksheet.Cells[headerRow, 3].Value = "Giới tính";
                worksheet.Cells[headerRow, 4].Value = "Số điện thoại";

                // Format header
                using (var range = worksheet.Cells[headerRow, 1, headerRow, 4])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Data
                int row = headerRow + 1;
                foreach (DataGridViewRow dgvRow in dgv_customer.Rows)
                {
                    worksheet.Cells[row, 1].Value = dgvRow.Cells["MaKH"].Value;
                    worksheet.Cells[row, 2].Value = dgvRow.Cells["TenKH"].Value;
                    worksheet.Cells[row, 3].Value = dgvRow.Cells["GioiTinh"].Value;
                    worksheet.Cells[row, 4].Value = dgvRow.Cells["SDT"].Value;
                    row++;
                }

                // Tổng cộng
                worksheet.Cells[row + 1, 3].Value = "Tổng số khách hàng:";
                worksheet.Cells[row + 1, 3].Style.Font.Bold = true;
                worksheet.Cells[row + 1, 4].Value = dgv_customer.Rows.Count;
                worksheet.Cells[row + 1, 4].Style.Font.Bold = true;

                // Border cho toàn bộ bảng dữ liệu
                using (var range = worksheet.Cells[headerRow, 1, row, 4])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                
                // Set column widths
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 30;
                worksheet.Column(3).Width = 15;
                worksheet.Column(4).Width = 20;

                // Lưu file
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        // Nút Thoát
        private void Btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Btn_them_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void btn_xuatExcel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
