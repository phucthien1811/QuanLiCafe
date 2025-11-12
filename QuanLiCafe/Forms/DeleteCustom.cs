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
    public partial class DeleteCustom : Form
    {
        private readonly CafeContext _context;
        private readonly int _customerId;

        public DeleteCustom(int customerId)
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            _customerId = customerId;
            
            this.Load += DeleteCustom_Load;
            btn_luu.Click += Btn_luu_Click;
            btn_huy.Click += Btn_huy_Click;
            
            // Đổi text nút Lưu thành Xóa
            btn_luu.Text = "Xóa";
            btn_luu.BackColor = Color.Red;
        }

        private void DeleteCustom_Load(object sender, EventArgs e)
        {
            // Load thông tin khách hàng
            LoadCustomerInfo();
            
            // Disable các textbox để không cho sửa
            txb_MaKhachHang.Enabled = false;
            txb_TenKhachHang.Enabled = false;
            txb_SDT.Enabled = false;
            cb_GioiTinh.Enabled = false;
            
            // Load danh sách giới tính
            cb_GioiTinh.Items.Clear();
            cb_GioiTinh.Items.Add("Nam");
            cb_GioiTinh.Items.Add("Nữ");
            cb_GioiTinh.Items.Add("Khác");
        }

        private void LoadCustomerInfo()
        {
            try
            {
                var customer = _context.Customers.Find(_customerId);
                if (customer != null)
                {
                    txb_MaKhachHang.Text = customer.Id.ToString();
                    txb_TenKhachHang.Text = customer.Name;
                    cb_GioiTinh.Text = customer.Gender ?? "Nam";
                    txb_SDT.Text = customer.PhoneNumber;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
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
            // Xác nhận xóa
            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng '{txb_TenKhachHang.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var customer = _context.Customers.Find(_customerId);
                    
                    if (customer == null)
                    {
                        MessageBox.Show("Không tìm thấy khách hàng!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    // Xóa khách hàng
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    
                    MessageBox.Show("Xóa khách hàng thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa khách hàng:\n{ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
