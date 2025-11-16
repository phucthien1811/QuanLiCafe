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

namespace DrinkForm
{
    public partial class TypeDrink : Form
    {
        private readonly CafeContext _context;
        private Category? _selectedCategory;

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
            btnThoat.Click += BtnThoat_Click;
            dtgvtypedrink.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void TypeDrink_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadCategories();
        }

        private void ConfigureDataGridView()
        {
            // Cấu hình DataGridView
            dtgvtypedrink.AutoGenerateColumns = false;
            dtgvtypedrink.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvtypedrink.MultiSelect = false;
            dtgvtypedrink.AllowUserToAddRows = false;
            dtgvtypedrink.ReadOnly = true;

            // Đặt lại header text và width cho columns
            Column1.HeaderText = "Mã loại";
            Column1.Width = 100;
            Column2.HeaderText = "Tên loại";
            Column2.Width = 500;
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
                _selectedCategory = null;

                foreach (var category in categories)
                {
                    int rowIndex = dtgvtypedrink.Rows.Add();
                    var row = dtgvtypedrink.Rows[rowIndex];

                    row.Cells["Column1"].Value = category.Id;
                    row.Cells["Column2"].Value = category.Name;
                    row.Tag = category; // Lưu object category
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách loại đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị thông tin khi chọn row
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvtypedrink.SelectedRows.Count > 0)
            {
                var selectedRow = dtgvtypedrink.SelectedRows[0];
                _selectedCategory = selectedRow.Tag as Category;
            }
            else
            {
                _selectedCategory = null;
            }
        }

        // Nút Thêm - Mở FormAddUpTypeDrink
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new QuanLiCafe.Forms.FormAddUpTypeDrink();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thêm loại đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa - Mở FormAddUpTypeDrink với ID
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("Vui lòng chọn loại đồ uống cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var editForm = new QuanLiCafe.Forms.FormAddUpTypeDrink(_selectedCategory.Id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form sửa loại đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null)
            {
                MessageBox.Show("Vui lòng chọn loại đồ uống cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra có đồ uống nào thuộc loại này không
            int productCount = _context.Products.Count(p => p.CategoryId == _selectedCategory.Id);

            string confirmMessage = $"Bạn có chắc chắn muốn xóa loại '{_selectedCategory.Name}'?";
            if (productCount > 0)
            {
                confirmMessage = $"Loại '{_selectedCategory.Name}' có {productCount} đồ uống.\n\n" +
                               "Không thể xóa loại có đồ uống!\n" +
                               "Vui lòng xóa các đồ uống thuộc loại này trước.";
                
                MessageBox.Show(confirmMessage, "Không thể xóa",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(confirmMessage, "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var categoryToDelete = _context.Categories.Find(_selectedCategory.Id);

                    if (categoryToDelete == null)
                    {
                        MessageBox.Show("Không tìm thấy loại đồ uống!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Nút Thoát
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Empty event handler
        }
    }
}
