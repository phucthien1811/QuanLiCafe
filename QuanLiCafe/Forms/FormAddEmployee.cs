using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormAddEmployee : Form
    {
        private readonly CafeContext _context;
        private int? _employeeId; // null = thêm mới, có giá trị = chỉnh sửa
        private bool _isEditMode;

        // Constructor cho thêm mới
        public FormAddEmployee()
        {
            InitializeComponent();
            _context = Program.DbContext;
            _employeeId = null;
            _isEditMode = false;

            this.Load += FormAddEmployee_Load;
            btnThem.Click += BtnThem_Click;
            btnExit.Click += BtnExit_Click;

            this.Text = "Thêm nhân viên mới";
            btnThem.Text = "Thêm";
            label8.Text = "Thêm mật khẩu";
        }

        // Constructor cho chỉnh sửa
        public FormAddEmployee(int employeeId) : this()
        {
            _employeeId = employeeId;
            _isEditMode = true;

            this.Text = "Sửa thông tin nhân viên";
            btnThem.Text = "Cập nhật";
            label8.Text = "Đổi mật khẩu (để trống nếu không đổi)";
        }

        private void FormAddEmployee_Load(object sender, EventArgs e)
        {
            SetupPasswordFields();
            dtpngayvaolam.Value = DateTime.Now;

            if (_isEditMode && _employeeId.HasValue)
            {
                LoadEmployeeInfo(_employeeId.Value);
            }
            else
            {
                // Tự động sinh mã nhân viên
                var maxId = _context.Users.Any() ? _context.Users.Max(u => u.Id) : 0;
                txbmanv.Text = (maxId + 1).ToString();
                txbmanv.ReadOnly = true;
            }
        }

        // ===== SETUP PASSWORD FIELDS =====
        private void SetupPasswordFields()
        {
            txbmk.PasswordChar = '•';
            txbnhaplaimk.PasswordChar = '•';
        }

        // ===== LOAD THÔNG TIN NHÂN VIÊN =====
        private void LoadEmployeeInfo(int userId)
        {
            try
            {
                var user = _context.Users.Find(userId);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Load thông tin user
                txbmanv.Text = user.Id.ToString();
                txbmanv.ReadOnly = true;
                txbusername.Text = user.Username;

                // Load thông tin nhân viên từ EmployeeInformation
                var empInfo = _context.EmployeeInformations
                    .FirstOrDefault(e => e.UserId == userId);

                if (empInfo != null)
                {
                    txbnvten.Text = empInfo.FullName;
                    txbmale.Text = empInfo.Gender ?? "";
                    txbsdt.Text = empInfo.PhoneNumber ?? "";

                    if (empInfo.StartDate.HasValue)
                    {
                        dtpngayvaolam.Value = empInfo.StartDate.Value;
                    }
                }
                else
                {
                    txbnvten.Text = user.Username;
                }

                // Không bắt buộc nhập mật khẩu khi sửa
                lblMk.Text = "Mật khẩu mới (để trống nếu không đổi)";
                lblNhapLaiMk.Text = "Nhập lại mật khẩu mới";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== NÚT THÊM/CẬP NHẬT =====
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (_isEditMode)
            {
                UpdateEmployee();
            }
            else
            {
                AddEmployee();
            }
        }

        // ===== THÊM NHÂN VIÊN MỚI =====
        private void AddEmployee()
        {
            try
            {
                // Kiểm tra username đã tồn tại
                if (_context.Users.Any(u => u.Username == txbusername.Text.Trim()))
                {
                    MessageBox.Show("Username đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbusername.Focus();
                    return;
                }

                // Tạo user mới
                var newUser = new User
                {
                    Username = txbusername.Text.Trim(),
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(txbmk.Text),
                    Role = "Staff"
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                // Tạo thông tin nhân viên
                var empInfo = new EmployeeInformation
                {
                    UserId = newUser.Id,
                    FullName = txbnvten.Text.Trim(),
                    Gender = txbmale.Text.Trim(),
                    PhoneNumber = txbsdt.Text.Trim(),
                    StartDate = dtpngayvaolam.Value
                };

                _context.EmployeeInformations.Add(empInfo);
                _context.SaveChanges();

                MessageBox.Show("Thêm nhân viên thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm nhân viên:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== CẬP NHẬT NHÂN VIÊN =====
        private void UpdateEmployee()
        {
            try
            {
                var user = _context.Users.Find(_employeeId!.Value);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra username trùng (trừ chính nó)
                if (_context.Users.Any(u => u.Username == txbusername.Text.Trim() && u.Id != _employeeId.Value))
                {
                    MessageBox.Show("Username đã tồn tại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbusername.Focus();
                    return;
                }

                // Cập nhật username
                user.Username = txbusername.Text.Trim();

                // Cập nhật password nếu có nhập
                if (!string.IsNullOrWhiteSpace(txbmk.Text))
                {
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(txbmk.Text);
                }

                // Cập nhật hoặc tạo mới EmployeeInformation
                var empInfo = _context.EmployeeInformations
                    .FirstOrDefault(e => e.UserId == _employeeId.Value);

                if (empInfo == null)
                {
                    empInfo = new EmployeeInformation
                    {
                        UserId = _employeeId.Value,
                        FullName = txbnvten.Text.Trim(),
                        Gender = txbmale.Text.Trim(),
                        PhoneNumber = txbsdt.Text.Trim(),
                        StartDate = dtpngayvaolam.Value
                    };
                    _context.EmployeeInformations.Add(empInfo);
                }
                else
                {
                    empInfo.FullName = txbnvten.Text.Trim();
                    empInfo.Gender = txbmale.Text.Trim();
                    empInfo.PhoneNumber = txbsdt.Text.Trim();
                    empInfo.StartDate = dtpngayvaolam.Value;
                }

                _context.SaveChanges();

                MessageBox.Show("Cập nhật thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== VALIDATE INPUT =====
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txbnvten.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbnvten.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txbusername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbusername.Focus();
                return false;
            }

            // Chỉ check password khi thêm mới
            if (!_isEditMode)
            {
                if (string.IsNullOrWhiteSpace(txbmk.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbmk.Focus();
                    return false;
                }

                if (txbmk.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbmk.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txbnhaplaimk.Text))
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbnhaplaimk.Focus();
                    return false;
                }

                if (txbmk.Text != txbnhaplaimk.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbnhaplaimk.Focus();
                    return false;
                }
            }
            else
            {
                // Khi sửa, nếu có nhập password thì phải check
                if (!string.IsNullOrWhiteSpace(txbmk.Text))
                {
                    if (txbmk.Text.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbmk.Focus();
                        return false;
                    }

                    if (txbmk.Text != txbnhaplaimk.Text)
                    {
                        MessageBox.Show("Mật khẩu không khớp!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txbnhaplaimk.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        // ===== NÚT THOÁT =====
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
