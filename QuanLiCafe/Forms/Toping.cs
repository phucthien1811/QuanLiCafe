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
    public partial class Toping : Form
    {
        private readonly CafeContext _context;
        public List<string> SelectedToppings { get; private set; } = new List<string>();
        public Dictionary<string, decimal> SelectedToppingPrices { get; private set; } = new Dictionary<string, decimal>();
        public Dictionary<string, int> SelectedToppingQuantities { get; private set; } = new Dictionary<string, int>();
        
        private List<ToppingControl> toppingControls = new List<ToppingControl>();
        
        // Constructor mặc định
        public Toping()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            
            // Đăng ký sự kiện cho các button
            btnThem.Click += BtnThem_Click;
            btnThoat.Click += BtnThoat_Click;
        }
        
        // Constructor nhận dữ liệu đã chọn trước đó
        public Toping(List<string> selectedToppings, Dictionary<string, decimal> selectedPrices, Dictionary<string, int> selectedQuantities) : this()
        {
            // Sao chép dữ liệu đã chọn trước đó
            SelectedToppings = new List<string>(selectedToppings);
            SelectedToppingPrices = new Dictionary<string, decimal>(selectedPrices);
            SelectedToppingQuantities = new Dictionary<string, int>(selectedQuantities);
        }

        private void Toping_Load(object sender, EventArgs e)
        {
            ConfigureFlowPanel();
            LoadToppingsFromDatabase();
        }
        
        private void ConfigureFlowPanel()
        {
            // Cấu hình FlowLayoutPanel
            flpTopingList.AutoScroll = true;
            flpTopingList.FlowDirection = FlowDirection.TopDown;
            flpTopingList.WrapContents = false;
            flpTopingList.Padding = new Padding(5);
        }

        private void LoadToppingsFromDatabase()
        {
            try
            {
                var toppings = _context.Toppings.OrderBy(t => t.Name).ToList();

                if (!toppings.Any())
                {
                    // Hiển thị thông báo nếu chưa có topping
                    Label noDataLabel = new Label
                    {
                        Text = "Chưa có topping nào trong hệ thống.\nVui lòng thêm topping trong phần quản lý.",
                        Font = new Font("Tahoma", 11F, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        Size = new Size(380, 100),
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = false
                    };
                    flpTopingList.Controls.Add(noDataLabel);
                    return;
                }

                // Tạo control cho mỗi topping
                foreach (var topping in toppings)
                {
                    // Kiểm tra xem topping này đã được chọn trước đó chưa
                    bool isSelected = SelectedToppings.Contains(topping.Name);
                    int quantity = isSelected && SelectedToppingQuantities.ContainsKey(topping.Name) 
                        ? SelectedToppingQuantities[topping.Name] 
                        : 1;
                    
                    var toppingControl = new ToppingControl(topping, isSelected, quantity);
                    toppingControl.CheckedChanged += (s, e) => UpdateTotal();
                    toppingControl.QuantityChanged += (s, e) => UpdateTotal();
                    toppingControls.Add(toppingControl);
                    flpTopingList.Controls.Add(toppingControl);
                }
                
                // Cập nhật tổng ban đầu
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách topping:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (var control in toppingControls)
            {
                if (control.IsChecked)
                {
                    total += control.Price * control.Quantity;
                }
            }
            lblTong.Text = $"Tổng: {total.ToString("N0")} ₫";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            SelectedToppings.Clear();
            SelectedToppingPrices.Clear();
            SelectedToppingQuantities.Clear();

            foreach (var control in toppingControls)
            {
                if (control.IsChecked)
                {
                    SelectedToppings.Add(control.ToppingName);
                    SelectedToppingPrices[control.ToppingName] = control.Price;
                    SelectedToppingQuantities[control.ToppingName] = control.Quantity;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    // Custom control cho mỗi topping
    public class ToppingControl : Panel
    {
        private CheckBox checkBox;
        private Label lblName;
        private Label lblPrice;
        private NumericUpDown numQuantity;
        private Topping _topping;

        public event EventHandler CheckedChanged;
        public event EventHandler QuantityChanged;

        public bool IsChecked => checkBox.Checked;
        public string ToppingName => _topping.Name;
        public decimal Price => _topping.Price;
        public int Quantity => (int)numQuantity.Value;

        // Constructor mới có thêm tham số isSelected và quantity
        public ToppingControl(Topping topping, bool isSelected = false, int quantity = 1)
        {
            _topping = topping;

            this.Size = new Size(380, 50);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = isSelected ? Color.LightGreen : Color.WhiteSmoke;
            this.Margin = new Padding(5);

            // CheckBox
            checkBox = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(20, 20),
                Cursor = Cursors.Hand,
                Checked = isSelected // Đánh dấu tích nếu đã chọn trước đó
            };
            checkBox.CheckedChanged += (s, e) => {
                this.BackColor = checkBox.Checked ? Color.LightGreen : Color.WhiteSmoke;
                numQuantity.Enabled = checkBox.Checked;
                if (!checkBox.Checked)
                {
                    numQuantity.Value = 1; // Reset về 1 khi bỏ chọn
                }
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            };

            // Label tên topping
            lblName = new Label
            {
                Text = topping.Name,
                Location = new Point(40, 13),
                Size = new Size(150, 25),
                Font = new Font("Times New Roman", 11F, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Label giá
            lblPrice = new Label
            {
                Text = topping.Price.ToString("N0") + " ₫",
                Location = new Point(195, 13),
                Size = new Size(90, 25),
                Font = new Font("Times New Roman", 10F, FontStyle.Bold),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // NumericUpDown cho số lượng
            numQuantity = new NumericUpDown
            {
                Location = new Point(290, 12),
                Size = new Size(70, 25),
                Minimum = 1,
                Maximum = 10,
                Value = quantity, // Sử dụng số lượng đã chọn trước đó
                Font = new Font("Times New Roman", 10F),
                Enabled = isSelected // Enable nếu đã chọn trước đó
            };
            numQuantity.ValueChanged += (s, e) => {
                QuantityChanged?.Invoke(this, EventArgs.Empty);
            };

            this.Controls.Add(checkBox);
            this.Controls.Add(lblName);
            this.Controls.Add(lblPrice);
            this.Controls.Add(numQuantity);

            // Click vào panel cũng check/uncheck
            this.Click += (s, e) => checkBox.Checked = !checkBox.Checked;
            lblName.Click += (s, e) => checkBox.Checked = !checkBox.Checked;
            lblPrice.Click += (s, e) => checkBox.Checked = !checkBox.Checked;
        }
    }
}
