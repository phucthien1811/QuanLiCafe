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

namespace WindowsForms
{
    public partial class formThanhToan : Form
    {
        private readonly CafeContext _context;
        private readonly Order _currentOrder;
        private readonly decimal _finalAmount;

        public formThanhToan(Order order, decimal finalAmount)
        {
            InitializeComponent();
            
            _context = QuanLiCafe.Program.DbContext;
            _currentOrder = order;
            _finalAmount = finalAmount;

            // Đăng ký sự kiện
            this.Load += FormThanhToan_Load;
            button1.Click += BtnDaThanhToan_Click;
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            // Thông tin tài khoản ngân hàng (có thể lưu trong config hoặc database)
            txtTenTK.Text = "NGUYEN HUU DUY";
            txtSoTK.Text = "0123456789";
            
            // Disable controls
            txtTenTK.ReadOnly = true;
            txtSoTK.ReadOnly = true;
        }

        private void BtnDaThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    $"Xác nhận khách hàng đã thanh toán qua chuyển khoản?\n\nSố tiền: {_finalAmount:N0} VNĐ",
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                // Cập nhật thông tin thanh toán vào Order
                _currentOrder.PaymentMethod = "Chuyển khoản";
                _currentOrder.ReceivedAmount = _finalAmount;
                _currentOrder.ChangeAmount = 0; // Chuyển khoản không có tiền thối

                // Lưu vào database
                _context.SaveChanges();

                // Cập nhật trạng thái bàn về Free
                var table = _context.Tables.Find(_currentOrder.TableId);
                if (table != null)
                {
                    table.Status = "Free";
                    _context.SaveChanges();
                }

                MessageBox.Show("Thanh toán thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void txtSoTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
