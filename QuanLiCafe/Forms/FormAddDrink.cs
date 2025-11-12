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
    public partial class EditDrinkForm : Form
    {
        private readonly CafeContext _context;
        private int? _productId; // null = thêm mới, có giá trị = chỉnh sửa
        private string _selectedImagePath = "";

        // Constructor cho thêm mới
        public EditDrinkForm()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            _productId = null;
            
            this.Load += EditDrinkForm_Load;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            llChonHinh.LinkClicked += LlChonHinh_LinkClicked;
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            
            this.Text = "Thêm mới đồ uống";
        }

        // Constructor cho chỉnh sửa
        public EditDrinkForm(int productId) : this()
        {
            _productId = productId;
            this.Text = "Chỉnh sửa đồ uống";
        }

        private void EditDrinkForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            
            // Cấu hình PictureBox
            picHinh.SizeMode = PictureBoxSizeMode.Zoom;
            
            // Nếu là chỉnh sửa, load thông tin đồ uống
            if (_productId.HasValue)
            {
                LoadProductInfo(_productId.Value);
                MaDoUong.Enabled = false; // Không cho sửa mã
            }
            else
            {
                // Tự động sinh mã đồ uống tiếp theo
                var maxId = _context.Products.Any() ? _context.Products.Max(p => p.Id) : 0;
                MaDoUong.Text = (maxId + 1).ToString();
                MaDoUong.Enabled = false;
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _context.Categories.OrderBy(c => c.Name).ToList();
                comboBox1.DataSource = categories;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh mục:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductInfo(int productId)
        {
            try
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    MaDoUong.Text = product.Id.ToString();
                    textBox2.Text = product.Name;
                    textBox3.Text = ""; // Mô tả nếu có thêm vào model
                    textBox4.Text = product.Price.ToString();
                    comboBox1.SelectedValue = product.CategoryId;
                    
                    // Load hình ảnh
                    if (!string.IsNullOrEmpty(product.ImageUrl) && System.IO.File.Exists(product.ImageUrl))
                    {
                        picHinh.Image = Image.FromFile(product.ImageUrl);
                        _selectedImagePath = product.ImageUrl;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlChonHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                    openFileDialog.Title = "Chọn hình ảnh đồ uống";
                    
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        _selectedImagePath = openFileDialog.FileName;
                        picHinh.Image = Image.FromFile(_selectedImagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn hình:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picHinh.Image = null;
            _selectedImagePath = "";
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập giá tiền!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (!decimal.TryParse(textBox4.Text, out decimal price))
            {
                MessageBox.Show("Giá tiền không hợp lệ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_productId.HasValue)
                {
                    // Cập nhật đồ uống hiện có
                    var product = _context.Products.Find(_productId.Value);
                    if (product != null)
                    {
                        product.Name = textBox2.Text.Trim();
                        product.Price = price;
                        product.CategoryId = (int)comboBox1.SelectedValue;
                        product.ImageUrl = _selectedImagePath;
                        
                        _context.SaveChanges();
                        
                        MessageBox.Show("Cập nhật đồ uống thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Thêm đồ uống mới
                    var newProduct = new Product
                    {
                        Name = textBox2.Text.Trim(),
                        Price = price,
                        CategoryId = (int)comboBox1.SelectedValue,
                        ImageUrl = _selectedImagePath
                    };
                    
                    _context.Products.Add(newProduct);
                    _context.SaveChanges();
                    
                    MessageBox.Show("Thêm đồ uống mới thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu thông tin đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BtnHuy_Click(sender, e);
        }
    }
}
