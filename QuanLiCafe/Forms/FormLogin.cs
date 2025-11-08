using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormLogin : Form
    {
        private readonly CafeContext _context;
        private readonly AuthService _authService;
        
        private TextBox txtUsername = null!;
        private TextBox txtPassword = null!;
        private Button btnLogin = null!;
        private Button btnExit = null!;
        private CheckBox chkShowPassword = null!;

        public User? LoggedInUser { get; private set; }

        public FormLogin()
        {
            _context = Program.DbContext;
            _authService = new AuthService(_context);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Login - Cafe Management";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Header Panel
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(52, 73, 94)
            };

            var lblTitle = new Label
            {
                Text = "? LOGIN",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(480, 80),
                Location = new Point(10, 10),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelHeader.Controls.Add(lblTitle);

            // Main Panel
            var panelMain = new Panel
            {
                Location = new Point(50, 130),
                Size = new Size(400, 200),
                BackColor = Color.White
            };

            var lblUsername = new Label
            {
                Text = "?? Username:",
                Location = new Point(0, 0),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            txtUsername = new TextBox
            {
                Location = new Point(0, 35),
                Size = new Size(400, 35),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblPassword = new Label
            {
                Text = "?? Password:",
                Location = new Point(0, 80),
                Size = new Size(400, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            txtPassword = new TextBox
            {
                Location = new Point(0, 115),
                Size = new Size(400, 35),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                UseSystemPasswordChar = true
            };

            chkShowPassword = new CheckBox
            {
                Text = "Show password",
                Location = new Point(0, 155),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10)
            };
            chkShowPassword.CheckedChanged += (s, e) =>
            {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            };

            panelMain.Controls.AddRange(new Control[] {
                lblUsername, txtUsername, lblPassword, txtPassword, chkShowPassword
            });

            // Buttons
            btnLogin = new Button
            {
                Text = "?? LOGIN",
                Location = new Point(50, 300),
                Size = new Size(180, 50),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;
            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = Color.FromArgb(39, 174, 96);
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = Color.FromArgb(46, 204, 113);

            btnExit = new Button
            {
                Text = "?? EXIT",
                Location = new Point(270, 300),
                Size = new Size(180, 50),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Click += (s, e) => Application.Exit();
            btnExit.MouseEnter += (s, e) => btnExit.BackColor = Color.FromArgb(192, 57, 43);
            btnExit.MouseLeave += (s, e) => btnExit.BackColor = Color.FromArgb(231, 76, 60);

            this.Controls.Add(panelHeader);
            this.Controls.Add(panelMain);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnExit);

            // Enter key to login
            this.AcceptButton = btnLogin;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all information!", "?? Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = _authService.Login(username, password);

                if (user == null)
                {
                    MessageBox.Show("Invalid username or password!", "? Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                LoggedInUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error:\n{ex.Message}", "? Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
