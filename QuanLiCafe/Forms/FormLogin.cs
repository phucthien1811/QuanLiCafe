using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormLogin : Form
    {
        private readonly CafeContext _context;
        private readonly AuthService _authService;

        public User? LoggedInUser { get; private set; }

        public FormLogin()
        {
            _context = Program.DbContext;
            _authService = new AuthService(_context);
            InitializeComponent();
            
            // Gán event handlers
            btnDangNhap.Click += BtnDangNhap_Click;
            btnThoat.Click += BtnThoat_Click;
        }

        private void BtnDangNhap_Click(object? sender, EventArgs e)
        {
            var username = txtMaDangNhap.Text.Trim();
            var password = txtMatKhau.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nh?p ??y ?? thông tin!", "?? C?nh Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = _authService.Login(username, password);

                if (user == null)
                {
                    MessageBox.Show("Tên ??ng nh?p ho?c m?t kh?u không ?úng!", "? ??ng Nh?p Th?t B?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                    return;
                }

                LoggedInUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i ??ng nh?p:\n{ex.Message}", "? L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThoat_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
