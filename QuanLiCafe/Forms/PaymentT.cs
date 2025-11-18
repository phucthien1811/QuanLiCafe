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

namespace win
{
    public partial class PaymentT : Form
    {
        private readonly CafeContext _context;
        private readonly User _currentUser;
        private readonly Order _currentOrder;
        private decimal _totalAmount;
        private decimal _discountPercent;

        public PaymentT(Order order, decimal totalAmount)
        {
            InitializeComponent();
            
            _context = QuanLiCafe.Program.DbContext;
            _currentUser = QuanLiCafe.Program.CurrentUser!;
            _currentOrder = order;
            _totalAmount = totalAmount;

            // Đăng ký sự kiện
            this.Load += PaymentT_Load;
            button1.Click += BtnChuyenKhoan_Click; // Nút Chuyển khoản
            button2.Click += BtnTienMat_Click; // Nút Tiền mặt
            textBox2.TextChanged += TxtGiamGia_TextChanged;
        }

        private void PaymentT_Load(object sender, EventArgs e)
        {
            // Điền thông tin nhân viên thực hiện
            lblNgThucHIen.Text = $"{_currentUser.Id} - {_currentUser.Username}";
            lblNgThucHIen.ReadOnly = true;

            // Mặc định giảm giá = 0
            textBox2.Text = "0";
            
            // Disable controls để không cho sửa
            lblNgThucHIen.ReadOnly = true;
        }

        // Xử lý khi thay đổi giảm giá
        private void TxtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox2.Text, out decimal discount))
            {
                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show("Giảm giá phải từ 0% đến 100%!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Text = "0";
                }
                _discountPercent = discount;
            }
        }

        // Xử lý khi click nút Chuyển khoản
        private void BtnChuyenKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate giảm giá
                if (!decimal.TryParse(textBox2.Text, out _discountPercent) || _discountPercent < 0 || _discountPercent > 100)
                {
                    MessageBox.Show("Giảm giá không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật discount vào order
                _currentOrder.Discount = _discountPercent;
                
                // Tính lại tổng tiền sau giảm giá
                decimal discountAmount = _totalAmount * _discountPercent / 100;
                decimal finalAmount = _totalAmount - discountAmount;
                _currentOrder.TotalAmount = finalAmount;

                // Mở form BankQR
                var bankQRForm = new WindowsForms.formThanhToan(_currentOrder, finalAmount);
                
                if (bankQRForm.ShowDialog() == DialogResult.OK)
                {
                    // Đóng form hiện tại và trả về OK
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form chuyển khoản:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý khi click nút Tiền mặt
        private void BtnTienMat_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate giảm giá
                if (!decimal.TryParse(textBox2.Text, out _discountPercent) || _discountPercent < 0 || _discountPercent > 100)
                {
                    MessageBox.Show("Giảm giá không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật discount vào order
                _currentOrder.Discount = _discountPercent;
                
                // Tính lại tổng tiền sau giảm giá
                decimal discountAmount = _totalAmount * _discountPercent / 100;
                decimal finalAmount = _totalAmount - discountAmount;
                _currentOrder.TotalAmount = finalAmount;

                // Lấy danh sách chi tiết sản phẩm
                var orderDetails = _context.OrderDetails
                    .Include(od => od.Product)
                    .Where(od => od.OrderId == _currentOrder.Id)
                    .ToList();

                // Mở form Money
                var moneyForm = new Money(_currentOrder, finalAmount, orderDetails);
                
                if (moneyForm.ShowDialog() == DialogResult.OK)
                {
                    // Đóng form hiện tại và trả về OK
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form tiền mặt:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
