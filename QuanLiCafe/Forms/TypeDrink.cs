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
using QuanLiCafe.Helpers;

namespace DrinkForm
{
    public partial class TypeDrink : Form
    {
        private readonly CafeContext _context;

        public TypeDrink()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;

            // Đăng ký sự kiện
            this.Load += TypeDrink_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            btnThoat.Click += BtnThoat_Click;
            dtgvtypedrink.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void TypeDrink_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadCategories();
            ClearInputs();
        }

        private void ConfigureDataGridView()
        {
            // Cấu hình DataGridView - SỬ DỤNG COLUMNS TỪ DESIGNER
            dtgvtypedrink.AutoGenerateColumns = false;
            dtgvtypedrink.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvtypedrink.MultiSelect = false;
            dtgvtypedrink.AllowUserToAddRows = false;
            dtgvtypedrink.ReadOnly = true;

            // Đặt lại header text cho columns có sẵn từ Designer
            Column1.HeaderText = "Mã loại";
            Column1.Width = 100;
            Column2.HeaderText = "Tên loại";
            Column2.Width = 300;
        }

        // Load danh sách loại đồ uống
        private void LoadCategories(string searchText = "")
        {
            try
            {
                var query = _context.Categories.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query = query.Where(c => c.Name.Contains(searchText));
                }

                var categories = query.OrderBy(c => c.Name).ToList();

                dtgvtypedrink.Rows.Clear();

                foreach (var category in categories)
                {
                    int rowIndex = dtgvtypedrink.Rows.Add();
                    var row = dtgvtypedrink.Rows[rowIndex];

                    // Sử dụng tên columns từ Designer: Column1, Column2
                    row.Cells["Column1"].Value = category.Id;
                    row.Cells["Column2"].Value = category.Name;
                    row.Tag = category; // Lưu object category
                }

                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách loại đồ uống:\n{ex.Message}\n\nStack: {ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị thông tin khi chọn row
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvtypedrink.SelectedRows.Count > 0)
            {
                var selectedRow = dtgvtypedrink.SelectedRows[0];
                var category = selectedRow.Tag as Category;

                if (category != null)
                {
                    textBox1.Text = category.Id.ToString();
                    textBox2.Text = category.Name;

                    textBox1.Enabled = false; // Không cho sửa mã
                }
            }
        }

        // Clear inputs
        private void ClearInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Enabled = false;
            textBox2.Focus();
        }

        // Nút Thêm
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string tenLoai = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập tên loại đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            try
            {
                // Kiểm tra trùng tên
                if (_context.Categories.Any(c => c.Name == tenLoai))
                {
                    MessageBox.Show("Loại đồ uống này đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newCategory = new Category
                {
                    Name = tenLoai
                };

                _context.Categories.Add(newCategory);
                _context.SaveChanges();

                MessageBox.Show("Thêm loại đồ uống thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm loại đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dtgvtypedrink.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại đồ uống cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenLoaiMoi = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenLoaiMoi))
            {
                MessageBox.Show("Vui lòng nhập tên loại đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            try
            {
                var selectedRow = dtgvtypedrink.SelectedRows[0];
                var category = selectedRow.Tag as Category;

                if (category == null) return;

                // Kiểm tra trùng tên (ngoại trừ chính nó)
                if (_context.Categories.Any(c => c.Name == tenLoaiMoi && c.Id != category.Id))
                {
                    MessageBox.Show("Loại đồ uống này đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoryToUpdate = _context.Categories.Find(category.Id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.Name = tenLoaiMoi;
                    _context.SaveChanges();

                    MessageBox.Show("Cập nhật loại đồ uống thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa loại đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvtypedrink.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại đồ uống cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dtgvtypedrink.SelectedRows[0];
            var category = selectedRow.Tag as Category;

            if (category == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa loại '{category.Name}'?\n\nLưu ý: Không thể xóa loại có đồ uống!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var categoryToDelete = _context.Categories.Find(category.Id);

                    if (categoryToDelete == null)
                    {
                        MessageBox.Show("Không tìm thấy loại đồ uống!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra có đồ uống nào thuộc loại này không
                    if (_context.Products.Any(p => p.CategoryId == category.Id))
                    {
                        MessageBox.Show("Không thể xóa loại có đồ uống!\nVui lòng xóa các đồ uống trước.",
                            "Không thể xóa",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _context.Categories.Remove(categoryToDelete);
                    _context.SaveChanges();

                    MessageBox.Show("Xóa loại đồ uống thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa loại đồ uống:\n{ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Làm mới
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadCategories();
        }

        // Nút Tìm kiếm
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            LoadCategories(txtTimKiem.Text);
        }

        // Nút Xuất Excel
        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Thoát
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
