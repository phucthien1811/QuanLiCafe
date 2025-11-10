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
        }

        // ========== EVENT HANDLERS FROM DESIGNER ==========

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Empty event handler
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Empty event handler
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Empty event handler
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ??NG NH?P button
            var username = txbUserName.Text.Trim();
            var password = txbPassword.Text;

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
                    txbPassword.Clear();
                    txbPassword.Focus();
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

        private void button2_Click(object sender, EventArgs e)
        {
            // THOÁT button
            Application.Exit();
        }
    }
}
