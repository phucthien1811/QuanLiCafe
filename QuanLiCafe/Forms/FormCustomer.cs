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
            MessageBox.Show("Chức năng xuất Excel đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
