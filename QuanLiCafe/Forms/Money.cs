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

namespace win
{
    public partial class Money : Form
    {
        private readonly CafeContext _context;
        private readonly Order _currentOrder;
        private decimal _finalAmount;
        private readonly List<OrderDetail> _orderDetails;
        private decimal _discountPercent;

        public Money(Order order, decimal finalAmount, List<OrderDetail> orderDetails)
        {
            InitializeComponent();
            
            _context = QuanLiCafe.Program.DbContext;
            _currentOrder = order;
            _finalAmount = finalAmount;
            _orderDetails = orderDetails;
            _discountPercent = order.Discount;

            // Đăng ký sự kiện
            this.Load += Money_Load;
            button1.Click += BtnDaThanhToan_Click;
            txbTienKHDua.TextChanged += TxbTienKHDua_TextChanged;
            txbGiamgia.TextChanged += TxbGiamgia_TextChanged;
            txbGiamgia.Leave += TxbGiamgia_Leave; // Thêm sự kiện khi rời khỏi textbox
        }

        private void Money_Load(object sender, EventArgs e)
        {
            // Hiển thị chi tiết sản phẩm
            StringBuilder productDetails = new StringBuilder();
            foreach (var detail in _orderDetails)
            {
                productDetails.AppendLine($"{detail.Product.Name} x{detail.Quantity}");
            }
            txbchitietsanpham.Text = productDetails.ToString();
            txbchitietsanpham.ReadOnly = true;

            // Hiển thị giảm giá
            txbGiamgia.Text = _discountPercent.ToString("0.##");
            txbGiamgia.ReadOnly = true; // Không cho sửa giảm giá tại đây (đã set ở PaymentT)

            // Hiển thị tổng tiền
            txbTong.Text = _finalAmount.ToString("N0");
            txbTong.ReadOnly = true;

            // Mặc định tiền thối = 0
            txbTienThoi.ReadOnly = true;
            txbTienThoi.Text = "0";
            
            // Focus vào ô tiền khách đưa
            txbTienKHDua.Focus();
        }

        // Xử lý khi thay đổi tiền khách đưa - Tính tiền thối tự động
        private void TxbTienKHDua_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        // Xử lý khi rời khỏi ô giảm giá
        private void TxbGiamgia_Leave(object sender, EventArgs e)
        {
            // Đảm bảo giá trị hợp lệ khi rời khỏi textbox
            if (!decimal.TryParse(txbGiamgia.Text, out decimal discount) || discount < 0 || discount > 100)
            {
                txbGiamgia.Text = _discountPercent.ToString("0.##");
            }
        }

        // Xử lý khi thay đổi giảm giá
        private void TxbGiamgia_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txbGiamgia.Text, out decimal discount))
            {
                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show("Giảm giá phải từ 0% đến 100%!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbGiamgia.Text = _discountPercent.ToString("0.##");
                    return;
                }
                
                _discountPercent = discount;
                
                // Tính lại tổng tiền
                decimal subtotal = _orderDetails.Sum(od => od.Quantity * od.UnitPrice);
                decimal discountAmount = subtotal * _discountPercent / 100;
                _finalAmount = subtotal - discountAmount;
                
                txbTong.Text = _finalAmount.ToString("N0");
                
                // Tính lại tiền thối
                CalculateChange();
            }
        }

        // Tính tiền thối tự động
        private void CalculateChange()
        {
            // Xóa dấu phân cách để parse được số
            string receivedText = txbTienKHDua.Text.Replace(",", "").Replace(".", "").Trim();
            
            if (string.IsNullOrEmpty(receivedText))
            {
                txbTienThoi.Text = "0";
                txbTienThoi.ForeColor = Color.Black;
                return;
            }

            if (decimal.TryParse(receivedText, out decimal received))
            {
                // Tính tiền thối = Tiền khách đưa - Tổng tiền
                decimal change = received - _finalAmount;
                
                if (change < 0)
                {
                    // Nếu tiền khách đưa chưa đủ, hiển thị số âm bằng màu đỏ
                    txbTienThoi.Text = change.ToString("N0");
                    txbTienThoi.ForeColor = Color.Red;
                }
                else
                {
                    // Nếu đủ, hiển thị tiền thối bằng màu xanh
                    txbTienThoi.Text = change.ToString("N0");
                    txbTienThoi.ForeColor = Color.Green;
                }
            }
            else
            {
                txbTienThoi.Text = "0";
                txbTienThoi.ForeColor = Color.Black;
            }
        }

        // Xử lý khi click nút Đã thanh toán
        private void BtnDaThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate tiền khách đưa
                string receivedText = txbTienKHDua.Text.Replace(",", "").Replace(".", "").Trim();
                
                if (string.IsNullOrEmpty(receivedText) || !decimal.TryParse(receivedText, out decimal received))
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbTienKHDua.Focus();
                    return;
                }

                if (received < _finalAmount)
                {
                    MessageBox.Show($"Số tiền khách đưa không đủ!\n\n" +
                        $"Cần thanh toán: {_finalAmount:N0} VNĐ\n" +
                        $"Khách đưa: {received:N0} VNĐ\n" +
                        $"Thiếu: {(_finalAmount - received):N0} VNĐ",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txbTienKHDua.Focus();
                    return;
                }

                decimal change = received - _finalAmount;

                var result = MessageBox.Show(
                    $"Xác nhận thanh toán?\n\n" +
                    $"Tổng tiền: {_finalAmount:N0} VNĐ\n" +
                    $"Tiền khách đưa: {received:N0} VNĐ\n" +
                    $"Tiền thối: {change:N0} VNĐ",
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                // Cập nhật thông tin thanh toán vào Order
                _currentOrder.Discount = _discountPercent;
                _currentOrder.TotalAmount = _finalAmount;
                _currentOrder.PaymentMethod = "Tiền mặt";
                _currentOrder.ReceivedAmount = received;
                _currentOrder.ChangeAmount = change;

                // Lưu vào database
                _context.SaveChanges();

                // Cập nhật trạng thái bàn về Free
                var table = _context.Tables.Find(_currentOrder.TableId);
                if (table != null)
                {
                    table.Status = "Free";
                    _context.SaveChanges();
                }

                MessageBox.Show(
                    $"Thanh toán thành công!\n\n" +
                    $"Tiền thối lại khách: {change:N0} VNĐ",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
