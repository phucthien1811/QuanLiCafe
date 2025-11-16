using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormEmployee : Form
    {
        private readonly CafeContext _context;
        private readonly AuthService _authService;
        private int _editingUserId = 0;

        public FormEmployee()
        {
            _context = Program.DbContext;
            _authService = new AuthService(_context);

            InitializeComponent();
            this.Load += FormEmployee_Load;
        }

        private void FormEmployee_Load(object? sender, EventArgs e)
        {
            LoadUsers();
            SetupDataGridView();
            ClearForm();
        }

        // ===== SETUP DATAGRIDVIEW =====
        private void SetupDataGridView()
        {
            dtgvData.AutoGenerateColumns = false;
            dtgvData.Columns.Clear();

            dtgvData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dtgvData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Username",
                DataPropertyName = "Username",
                Width = 150
            });

            dtgvData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Role",
                DataPropertyName = "Role",
                Width = 100
            });

            // Event khi click vào row
            dtgvData.SelectionChanged += DtgvData_SelectionChanged;
        }

        // ===== LOAD DANH SÁCH USER =====
        private void LoadUsers(string searchText = "")
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(u => u.Username.Contains(searchText));
            }

            var users = query.OrderBy(u => u.Id).ToList();
            dtgvData.DataSource = users;
        }

        // ===== KHI CHỌN ROW =====
        private void DtgvData_SelectionChanged(object? sender, EventArgs e)
        {
            if (dtgvData.SelectedRows.Count > 0)
            {
                var selectedRow = dtgvData.SelectedRows[0];
                var user = selectedRow.DataBoundItem as User;

                if (user != null)
                {
                    _editingUserId = user.Id;
                    txtMaNV.Text = user.Id.ToString();
                    txtTenNV.Text = user.Username;
                    txtMatKhau.Text = ""; // Không hiển thị password
                    txtSDT.Text = user.Role; // Tạm dùng field này cho Role
                    txtDiaChi.Text = ""; // Để trống vì model không có
                }
            }
        }

        // ===== THÊM USER MỚI =====
        private void MenuThem_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new FormAddEmployee();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thêm nhân viên:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== SỬA USER =====
        private void MenuSua_Click(object sender, EventArgs e)
        {
            if (_editingUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var editForm = new FormAddEmployee(_editingUserId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form sửa nhân viên:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== XÓA USER =====
        private void MenuXoa_Click(object sender, EventArgs e)
        {
            if (_editingUserId == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = _context.Users.Find(_editingUserId);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ✅ CHỈ CẤM XÓA CHÍNH MÌNH (Admin đang đăng nhập)
                var currentUser = Program.CurrentUser;
                if (currentUser != null && _editingUserId == currentUser.Id)
                {
                    MessageBox.Show("Bạn không thể xóa tài khoản của chính mình!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đếm số đơn hàng của nhân viên này
                int orderCount = _context.Orders.Count(o => o.StaffId == _editingUserId);

                // Tạo thông báo xác nhận
                string confirmMessage = $"Xác nhận xóa nhân viên '{user.Username}'?";
                if (orderCount > 0)
                {
                    confirmMessage = $"Nhân viên '{user.Username}' có {orderCount} đơn hàng.\n\n" +
                                   "Bạn có chắc chắn muốn xóa nhân viên này?\n" +
                                   "(Các đơn hàng sẽ vẫn được giữ lại trong hệ thống)";
                }

                var result = MessageBox.Show(confirmMessage, "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // ✅ XÓA NHÂN VIÊN (kể cả khi có đơn hàng)
                    _context.Users.Remove(user);
                    _context.SaveChanges();

                    MessageBox.Show("Xóa nhân viên thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadUsers();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa nhân viên:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== XÓA TRẮNG FORM =====
        private void MenuXoaTrang_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _editingUserId = 0;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtMatKhau.Clear();
            txtSDT.Text = "Staff"; // Default role
            txtDiaChi.Clear();
            txtTenNV.Focus();
        }

        // ===== TÌM KIẾM =====
        private void MenuTimKiem_Click(object sender, EventArgs e)
        {
            LoadUsers(txtSearch.Text);
        }

        // ===== THOÁT =====
        private void MenuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ===== VALIDATE INPUT =====
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập username!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return false;
            }

            // Chỉ check password khi thêm mới
            if (_editingUserId == 0 && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập Role (Admin/Staff)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            // Validate Role
            string role = txtSDT.Text.Trim();
            if (role != "Admin" && role != "Staff")
            {
                MessageBox.Show("Role chỉ được là 'Admin' hoặc 'Staff'!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            return true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormEmployee_Load_1(object sender, EventArgs e)
        {

        }
    }
}
