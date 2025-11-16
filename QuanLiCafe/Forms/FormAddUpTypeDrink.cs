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

namespace QuanLiCafe.Forms
{
    public partial class FormAddUpTypeDrink : Form
    {
        private readonly CafeContext _context;
        private int? _categoryId; // null = thêm mới, có giá trị = chỉnh sửa

        // Constructor cho thêm mới
        public FormAddUpTypeDrink()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            _categoryId = null;

            this.Load += FormAddUpTypeDrink_Load;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;

            this.Text = "Thêm loại đồ uống mới";
            btnLuu.Text = "Thêm"; // Đổi text nút thành "Thêm"
        }

        // Constructor cho chỉnh sửa
        public FormAddUpTypeDrink(int categoryId) : this()
        {
            _categoryId = categoryId;
            this.Text = "Sửa loại đồ uống";
            btnLuu.Text = "Sửa"; // Đổi text nút thành "Sửa"
        }

        private void FormAddUpTypeDrink_Load(object sender, EventArgs e)
        {
            // Nếu là chỉnh sửa, load thông tin loại đồ uống
            if (_categoryId.HasValue)
            {
                LoadCategoryInfo(_categoryId.Value);
                MaDoUong.ReadOnly = true; // Không cho sửa mã
            }
            else
            {
                // Tự động sinh mã loại tiếp theo
                var maxId = _context.Categories.Any() ? _context.Categories.Max(c => c.Id) : 0;
                MaDoUong.Text = (maxId + 1).ToString();
                MaDoUong.ReadOnly = true;
                textBox2.Focus();
            }
        }

        // Load thông tin loại đồ uống
        private void LoadCategoryInfo(int categoryId)
        {
            try
            {
                var category = _context.Categories.Find(categoryId);
                if (category != null)
                {
                    MaDoUong.Text = category.Id.ToString();
                    textBox2.Text = category.Name;
                    textBox2.SelectAll();
                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy loại đồ uống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Lưu
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            try
            {
                string tenLoai = textBox2.Text.Trim();

                if (_categoryId.HasValue)
                {
                    // Cập nhật loại đã có
                    UpdateCategory(tenLoai);
                }
                else
                {
                    // Thêm loại mới
                    AddCategory(tenLoai);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu thông tin:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm loại mới
        private void AddCategory(string tenLoai)
        {
            // Kiểm tra trùng tên
            if (_context.Categories.Any(c => c.Name.Trim().ToLower() == tenLoai.ToLower()))
            {
                MessageBox.Show("Loại đồ uống này đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
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

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cập nhật loại
        private void UpdateCategory(string tenLoai)
        {
            // Kiểm tra trùng tên (ngoại trừ chính nó)
            if (_context.Categories.Any(c => c.Name.Trim().ToLower() == tenLoai.ToLower() 
                && c.Id != _categoryId.Value))
            {
                MessageBox.Show("Loại đồ uống này đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            var category = _context.Categories.Find(_categoryId.Value);
            if (category != null)
            {
                category.Name = tenLoai;
                _context.SaveChanges();

                MessageBox.Show("Cập nhật loại đồ uống thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy loại đồ uống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Hủy
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
