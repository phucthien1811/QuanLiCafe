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
    public partial class AddCustomer : Form
    {
        private readonly CafeContext _context;
        private int? _customerId; // null = thêm mới, có giá trị = chỉnh sửa

        // Constructor cho thêm mới
        public AddCustomer()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            _customerId = null;

            this.Load += AddCustomer_Load;
            btn_luu.Click += Btn_luu_Click;
            btn_huy.Click += Btn_huy_Click;

            this.Text = "Thêm khách hàng";
        }

        // Constructor cho chỉnh sửa
        public AddCustomer(int customerId) : this()
        {
            _customerId = customerId;
            this.Text = "Chỉnh sửa khách hàng";
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            // Load danh sách giới tính
            cb_GioiTinh.Items.Clear();
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            cb_GioiTinh.Items.Add("Khác");
            cb_GioiTinh.SelectedIndex = 0;

            // Nếu là chỉnh sửa, load thông tin khách hàng
            if (_customerId.HasValue)
            {
                LoadCustomerInfo(_customerId.Value);
            }
            else
            {
                // Tự động sinh mã khách hàng tiếp theo
                var maxId = _context.Customers.Any() ? _context.Customers.Max(c => c.Id) : 0;
                txb_MaKhachHang.Text = (maxId + 1).ToString();
                txb_MaKhachHang.Enabled = false;
            }
        }

        private void LoadCustomerInfo(int customerId)
        {
            try
            {
                var customer = _context.Customers.Find(customerId);
                if (customer != null)
                {
                    txb_MaKhachHang.Text = customer.Id.ToString();
                    txb_MaKhachHang.Enabled = false; // Không cho sửa mã
                    txb_TenKhachHang.Text = customer.Name;
                    cb_GioiTinh.Text = customer.Gender ?? "Nam";
                    txb_SDT.Text = customer.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin khách hàng:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_luu_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txb_TenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txb_TenKhachHang.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txb_SDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txb_SDT.Focus();
                return;
            }

            // Validate số điện thoại (chỉ số và độ dài 10-11 ký tự)
            if (!txb_SDT.Text.All(char.IsDigit) || txb_SDT.Text.Length < 10 || txb_SDT.Text.Length > 11)
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (10-11 số)", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txb_SDT.Focus();
                return;
            }

            try
            {
                if (_customerId.HasValue)
                {
                    // Cập nhật khách hàng hiện có
                    var customer = _context.Customers.Find(_customerId.Value);
                    if (customer != null)
                    {
                        // Kiểm tra trùng số điện thoại (ngoại trừ chính nó)
                        if (_context.Customers.Any(c => c.PhoneNumber == txb_SDT.Text.Trim() && c.Id != _customerId.Value))
                        {
                            MessageBox.Show("Số điện thoại này đã được sử dụng!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        customer.Name = txb_TenKhachHang.Text.Trim();
                        customer.Gender = cb_GioiTinh.Text;
                        customer.PhoneNumber = txb_SDT.Text.Trim();
                        _context.SaveChanges();

                        MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Kiểm tra trùng số điện thoại
                    if (_context.Customers.Any(c => c.PhoneNumber == txb_SDT.Text.Trim()))
                    {
                        MessageBox.Show("Số điện thoại này đã được sử dụng!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm khách hàng mới
                    var newCustomer = new Customer
                    {
                        Name = txb_TenKhachHang.Text.Trim(),
                        Gender = cb_GioiTinh.Text,
                        PhoneNumber = txb_SDT.Text.Trim()
                    };

                    _context.Customers.Add(newCustomer);
                    _context.SaveChanges();

                    MessageBox.Show("Thêm khách hàng mới thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu thông tin khách hàng:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txb_SDT_TextChanged(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void label_SDT_Click(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void label_TenKhachHang_Click(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void label_ThongTin_Click(object sender, EventArgs e)
        {

        }

        private void btn_huy_Click_1(object sender, EventArgs e)
        {

        }
    }
}
