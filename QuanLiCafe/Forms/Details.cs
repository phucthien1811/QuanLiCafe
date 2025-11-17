using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCafe.Models;

namespace QuanLiCafe.Forms
{
    public partial class Details : Form
    {
        private Product _product;
        private string _selectedSize = "Vừa"; // Default
        private List<string> _selectedToppings = new List<string>();
        private Dictionary<string, decimal> _selectedToppingPrices = new Dictionary<string, decimal>();
        private Dictionary<string, int> _selectedToppingQuantities = new Dictionary<string, int>();
        private decimal _sizePrice = 0; // Giá cộng thêm theo size
        
        public int Quantity { get; private set; }
        public string Note { get; private set; }
        public decimal FinalPrice { get; private set; }
        public string SelectedSize => _selectedSize;
        public List<string> SelectedToppings => _selectedToppings;

        public Details(Product product)
        {
            InitializeComponent();
            _product = product;
            
            // Đăng ký events
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            button1.Click += BtnChonTopping_Click;
            button2.Click += BtnThem_Click;
            nmSoLuong.ValueChanged += NmSoLuong_ValueChanged;
            
            LoadProductInfo();
        }

        private void LoadProductInfo()
        {
            // Load thông tin sản phẩm
            label1.Text = $"Tên: {_product.Name}";
            
            // Load hình ảnh
            if (!string.IsNullOrEmpty(_product.ImageUrl) && System.IO.File.Exists(_product.ImageUrl))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(_product.ImageUrl);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
            
            // Mặc định chọn size Vừa
            radioButton2.Checked = true;
            _selectedSize = "Vừa";
            _sizePrice = 0;
            
            // Hiển thị mô tả
            textBox2.Text = $"Danh mục: {_product.Category?.Name ?? "N/A"}\r\n" +
                           $"Giá gốc: {_product.Price.ToString("N0")} ₫";
            textBox2.ReadOnly = true;
            
            // Cấu hình textbox topping
            tbxToping.ReadOnly = true;
            tbxToping.Text = "";
            tbxToping.ForeColor = Color.Black;
            
            // Cấu hình label loại
            lblloai.Text = "";
            lblloai.ForeColor = Color.Black;
            
            // Hiển thị giá
            UpdatePrice();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null || !rb.Checked) return;
            
            if (rb == radioButton1) // Nhỏ
            {
                _selectedSize = "Nhỏ";
                _sizePrice = -5000; // Giảm 5k
            }
            else if (rb == radioButton2) // Vừa
            {
                _selectedSize = "Vừa";
                _sizePrice = 0; // Giá gốc
            }
            else if (rb == radioButton3) // Lớn
            {
                _selectedSize = "Lớn";
                _sizePrice = 10000; // Tăng 10k
            }
            
            UpdatePrice();
        }

        private void BtnChonTopping_Click(object sender, EventArgs e)
        {
            // Mở form chọn topping và truyền danh sách đã chọn trước đó
            var toppingForm = new Toping(_selectedToppings, _selectedToppingPrices, _selectedToppingQuantities);
            
            if (toppingForm.ShowDialog() == DialogResult.OK)
            {
                _selectedToppings = toppingForm.SelectedToppings;
                _selectedToppingPrices = toppingForm.SelectedToppingPrices;
                _selectedToppingQuantities = toppingForm.SelectedToppingQuantities;
                
                // Hiển thị topping đã chọn trong textbox
                if (_selectedToppings.Any())
                {
                    // Tạo danh sách topping kèm giá và số lượng
                    var toppingWithDetails = _selectedToppings.Select(t =>
                    {
                        int qty = _selectedToppingQuantities[t];
                        decimal price = _selectedToppingPrices[t];
                        decimal total = price * qty;
                        return qty > 1 
                            ? $"{t} x{qty} ({total.ToString("N0")} ₫)"
                            : $"{t} ({price.ToString("N0")} ₫)";
                    });
                    
                    tbxToping.Text = string.Join(", ", toppingWithDetails);
                    tbxToping.ForeColor = Color.Black;
                    
                    // Hiển thị số loại trong lblloai
                    lblloai.Text = $"({_selectedToppings.Count} loại)";
                    lblloai.ForeColor = Color.Black;
                }
                else
                {
                    tbxToping.Text = "";
                    tbxToping.ForeColor = Color.Black;
                    
                    lblloai.Text = "";
                    lblloai.ForeColor = Color.Black;
                }
                
                UpdatePrice();
            }
        }

        private void NmSoLuong_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            // Tính giá: Giá gốc + Size + Topping
            decimal basePrice = _product.Price + _sizePrice;
            
            // Giá topping (tính theo giá thực tế và số lượng từ database)
            decimal toppingPrice = 0;
            foreach (var topping in _selectedToppings)
            {
                decimal price = _selectedToppingPrices[topping];
                int qty = _selectedToppingQuantities[topping];
                toppingPrice += price * qty;
            }
            
            decimal pricePerItem = basePrice + toppingPrice;
            int quantity = (int)nmSoLuong.Value;
            
            FinalPrice = pricePerItem * quantity;
            
            // Hiển thị
            label3.Text = $"Giá: {pricePerItem.ToString("N0")} ₫/ly";
            label8.Text = $"Tổng: {FinalPrice.ToString("N0")} ₫";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin
            Quantity = (int)nmSoLuong.Value;
            Note = textBox1.Text.Trim();
            
            // Tạo note chi tiết: Size + Topping + Note
            var noteDetails = new List<string>();
            noteDetails.Add($"Size: {_selectedSize}");
            
            if (_selectedToppings.Any())
            {
                // Hiển thị topping kèm giá và số lượng
                var toppingDetails = _selectedToppings.Select(t =>
                {
                    int qty = _selectedToppingQuantities[t];
                    decimal price = _selectedToppingPrices[t];
                    return qty > 1
                        ? $"{t} x{qty} ({(price * qty).ToString("N0")}₫)"
                        : $"{t} ({price.ToString("N0")}₫)";
                });
                noteDetails.Add($"Topping: {string.Join(", ", toppingDetails)}");
            }
            
            if (!string.IsNullOrWhiteSpace(Note))
            {
                noteDetails.Add($"Ghi chú: {Note}");
            }
            
            Note = string.Join(" | ", noteDetails);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Event đã có sẵn từ Designer
        }
    }
}
