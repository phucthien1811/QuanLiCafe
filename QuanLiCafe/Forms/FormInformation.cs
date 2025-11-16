using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormInformation : Form
    {
        private readonly CafeContext _context;
        private readonly AuthService _authService;
        private readonly User _currentUser;
        private EmployeeInformation? _employeeInfo;

        public FormInformation()
        {
            InitializeComponent();
            
            _context = Program.DbContext;
            _authService = new AuthService(_context);
            _currentUser = Program.CurrentUser!;

            this.Load += FormInformation_Load;
            btndmk.Click += BtnDmk_Click;
            btnExit.Click += BtnExit_Click;
        }

        private void FormInformation_Load(object sender, EventArgs e)
        {
            LoadUserInformation();
            SetupPasswordFields();
            SetReadOnlyFields();
        }

        // ===== SETUP PASSWORD FIELDS =====
        private void SetupPasswordFields()
        {
            txbmkht.PasswordChar = '•';
            txbmkmoi.PasswordChar = '•';
            txbnhaplaimk.PasswordChar = '•';
        }

        // ===== SET READ-ONLY FIELDS =====
        private void SetReadOnlyFields()
        {
            // Tất cả thông tin cá nhân chỉ hiển thị, không cho sửa
            txbmanv.ReadOnly = true;
            txbnvten.ReadOnly = true;
            txbmale.ReadOnly = true;
            txbsdt.ReadOnly = true;
            txbusername.ReadOnly = true;
            dtpngayvaolam.Enabled = false;
        }

        // ===== LOAD THÔNG TIN USER =====
        private void LoadUserInformation()
        {
            try
            {
                // Load thông tin user
                txbmanv.Text = _currentUser.Id.ToString();
                txbusername.Text = _currentUser.Username;

                // Load thông tin nhân viên từ EmployeeInformation
                _employeeInfo = _context.EmployeeInformations
                    .FirstOrDefault(e => e.UserId == _currentUser.Id);

                if (_employeeInfo != null)
                {
                    txbnvten.Text = _employeeInfo.FullName;
                    txbmale.Text = _employeeInfo.Gender ?? "";
                    txbsdt.Text = _employeeInfo.PhoneNumber ?? "";
                    
                    if (_employeeInfo.StartDate.HasValue)
                    {
                        dtpngayvaolam.Value = _employeeInfo.StartDate.Value;
                    }
                }
                else
                {
                    // Nếu chưa có thông tin nhân viên
                    txbnvten.Text = _currentUser.Username;
                    txbmale.Text = "";
                    txbsdt.Text = "";
                    dtpngayvaolam.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== ĐỔI MẬT KHẨU =====
        private void BtnDmk_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(txbmkht.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbmkht.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txbmkmoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbmkmoi.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txbnhaplaimk.Text))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbnhaplaimk.Focus();
                return;
            }

            // Kiểm tra mật khẩu mới khớp nhau
            if (txbmkmoi.Text != txbnhaplaimk.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbnhaplaimk.Focus();
                return;
            }

            // Kiểm tra độ dài mật khẩu
            if (txbmkmoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbmkmoi.Focus();
                return;
            }

            try
            {
                // Verify mật khẩu hiện tại
                if (!BCrypt.Net.BCrypt.Verify(txbmkht.Text, _currentUser.PasswordHash))
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbmkht.Focus();
                    return;
                }

                // Đổi mật khẩu
                _authService.ChangePassword(_currentUser.Id, txbmkht.Text, txbmkmoi.Text);

                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear password fields
                txbmkht.Clear();
                txbmkmoi.Clear();
                txbnhaplaimk.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đổi mật khẩu:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== THOÁT =====
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Empty event handlers for designer
        private void label1_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
    }
}
