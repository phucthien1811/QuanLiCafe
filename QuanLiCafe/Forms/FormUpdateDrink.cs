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
    public partial class SuaLoaiDoUongForm : Form
    {
        private readonly CafeContext _context;

        public SuaLoaiDoUongForm()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            
            // Đăng ký sự kiện
            this.Load += SuaLoaiDoUongForm_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            btnThoat.Click += BtnThoat_Click;
        }

        private void SuaLoaiDoUongForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Cấu hình DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            
            // Map columns
            colMaLoai.DataPropertyName = "Id";
            colTenLoai.DataPropertyName = "Name";
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
                
                dataGridView1.Rows.Clear();
                
                foreach (var category in categories)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[rowIndex];
                    
                    row.Cells["colMaLoai"].Value = category.Id;
                    row.Cells["colTenLoai"].Value = category.Name;
                    row.Tag = category; // Lưu object category
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách loại đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Thêm
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string tenLoai = InputDialog.ShowDialog(
                "Nhập tên loại đồ uống mới:", 
                "Thêm loại đồ uống", 
                "");
            
            if (string.IsNullOrWhiteSpace(tenLoai))
            {
                return;
            }

            try
            {
                // Kiểm tra trùng tên
                if (_context.Categories.Any(c => c.Name == tenLoai.Trim()))
                {
                    MessageBox.Show("Loại đồ uống này đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newCategory = new Category
                {
                    Name = tenLoai.Trim()
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại đồ uống cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var category = selectedRow.Tag as Category;
                
                if (category == null) return;

                string tenLoaiMoi = InputDialog.ShowDialog(
                    "Nhập tên loại đồ uống mới:", 
                    "Sửa loại đồ uống", 
                    category.Name);
                
                if (string.IsNullOrWhiteSpace(tenLoaiMoi) || tenLoaiMoi == category.Name)
                {
                    return;
                }

                // Kiểm tra trùng tên
                if (_context.Categories.Any(c => c.Name == tenLoaiMoi.Trim() && c.Id != category.Id))
                {
                    MessageBox.Show("Loại đồ uống này đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var categoryToUpdate = _context.Categories.Find(category.Id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.Name = tenLoaiMoi.Trim();
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại đồ uống cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
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
    }
}
