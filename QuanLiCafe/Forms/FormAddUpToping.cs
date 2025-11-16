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
    public partial class FormAddUpToping : Form
    {
        private readonly CafeContext _context;
        private int? _toppingId; // null = thêm mới, có giá trị = chỉnh sửa

        // Constructor cho thêm mới
        public FormAddUpToping()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            _toppingId = null;

            this.Load += FormAddUpToping_Load;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;

            this.Text = "Thêm topping mới";
            btnLuu.Text = "Thêm"; // Đổi text nút thành "Thêm"
        }

        // Constructor cho chỉnh sửa
        public FormAddUpToping(int toppingId) : this()
        {
            _toppingId = toppingId;
            this.Text = "Sửa topping";
            btnLuu.Text = "Sửa"; // Đổi text nút thành "Sửa"
        }

        private void FormAddUpToping_Load(object sender, EventArgs e)
        {
            // Nếu là chỉnh sửa, load thông tin topping
            if (_toppingId.HasValue)
            {
                LoadToppingInfo(_toppingId.Value);
                MaDoUong.ReadOnly = true; // Không cho sửa mã
            }
            else
            {
                // Tự động sinh mã topping tiếp theo
                var maxId = _context.Toppings.Any() ? _context.Toppings.Max(t => t.Id) : 0;
                MaDoUong.Text = (maxId + 1).ToString();
                MaDoUong.ReadOnly = true;
                textBox2.Focus();
            }
        }

        // Load thông tin topping
        private void LoadToppingInfo(int toppingId)
        {
            try
            {
                var topping = _context.Toppings.Find(toppingId);
                if (topping != null)
                {
                    MaDoUong.Text = topping.Id.ToString();
                    textBox2.Text = topping.Name;
                    textBox4.Text = topping.Price.ToString();
                    textBox2.SelectAll();
                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy topping!", "Lỗi",
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
                MessageBox.Show("Vui lòng nhập tên topping!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Vui lòng nhập giá topping!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            if (!decimal.TryParse(textBox4.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Giá không hợp lệ! Vui lòng nhập số dương.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return;
            }

            try
            {
                string tenTopping = textBox2.Text.Trim();

                if (_toppingId.HasValue)
                {
                    // Cập nhật topping đã có
                    UpdateTopping(tenTopping, price);
                }
                else
                {
                    // Thêm topping mới
                    AddTopping(tenTopping, price);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu thông tin:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm topping mới
        private void AddTopping(string tenTopping, decimal price)
        {
            // Kiểm tra trùng tên
            if (_context.Toppings.Any(t => t.Name.Trim().ToLower() == tenTopping.ToLower()))
            {
                MessageBox.Show("Topping này đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            var newTopping = new Topping
            {
                Name = tenTopping,
                Price = price
            };

            _context.Toppings.Add(newTopping);
            _context.SaveChanges();

            MessageBox.Show("Thêm topping thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cập nhật topping
        private void UpdateTopping(string tenTopping, decimal price)
        {
            // Kiểm tra trùng tên (ngoại trừ chính nó)
            if (_context.Toppings.Any(t => t.Name.Trim().ToLower() == tenTopping.ToLower() 
                && t.Id != _toppingId.Value))
            {
                MessageBox.Show("Topping này đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            var topping = _context.Toppings.Find(_toppingId.Value);
            if (topping != null)
            {
                topping.Name = tenTopping;
                topping.Price = price;
                _context.SaveChanges();

                MessageBox.Show("Cập nhật topping thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy topping!", "Lỗi",
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
