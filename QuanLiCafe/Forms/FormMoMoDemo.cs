using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    /// <summary>
    /// Form Demo thanh toán MoMo v?i s?n ph?m m?u
    /// </summary>
    public partial class FormMoMoDemo : Form
    {
        private readonly CafeContext _context;
        private readonly IMoMoPaymentService _momoService;
        private BindingList<DemoOrderItem> _demoItems = new();

        // Demo products
        private List<Product> _demoProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Cà Phê ?en", Price = 25000, CategoryId = 1 },
            new Product { Id = 2, Name = "Cà Phê S?a", Price = 30000, CategoryId = 1 },
            new Product { Id = 3, Name = "Trà S?a Truy?n Th?ng", Price = 35000, CategoryId = 2 },
            new Product { Id = 4, Name = "Sinh T? B?", Price = 40000, CategoryId = 3 },
            new Product { Id = 5, Name = "Bánh Mì Tr?ng", Price = 20000, CategoryId = 4 }
        };

        // Controls
        private ListBox lstDemoProducts = null!;
        private DataGridView dgvCart = null!;
        private NumericUpDown nudQuantity = null!;
        private Label lblSubTotal = null!;
        private Label lblDiscount = null!;
        private Label lblVAT = null!;
        private Label lblTotal = null!;
        private TextBox txtDiscountPercent = null!;
        private TextBox txtVATPercent = null!;
        private Button btnAddToCart = null!;
        private Button btnRemoveFromCart = null!;
        private Button btnPayWithMoMo = null!;
        private Button btnClear = null!;

        public FormMoMoDemo()
        {
            _context = Program.DbContext;
            _momoService = new MoMoPaymentService(_context);
            
            InitializeComponent();
            this.Load += FormMoMoDemo_Load;
        }

        private void FormMoMoDemo_Load(object? sender, EventArgs e)
        {
            LoadDemoProducts();
        }

        private void InitializeComponent()
        {
            this.Text = "?? DEMO Thanh Toán MoMo - Quán Cà Phê";
            this.Size = new Size(1200, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // ========== HEADER ==========
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(142, 68, 173) // Purple
            };

            var lblTitle = new Label
            {
                Text = "?? DEMO THANH TOÁN MOMO",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(1200, 80),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panelHeader.Controls.Add(lblTitle);

            // ========== LEFT PANEL - Danh Sách S?n Ph?m ==========
            var panelLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 400,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblProductTitle = new Label
            {
                Text = "??? S?N PH?M M?U",
                Location = new Point(20, 20),
                Size = new Size(360, 35),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            lstDemoProducts = new ListBox
            {
                Location = new Point(20, 65),
                Size = new Size(360, 350),
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(236, 240, 241)
            };
            lstDemoProducts.DoubleClick += LstDemoProducts_DoubleClick;

            var lblQtyTitle = new Label
            {
                Text = "S? L??ng:",
                Location = new Point(20, 430),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            nudQuantity = new NumericUpDown
            {
                Location = new Point(130, 428),
                Size = new Size(100, 35),
                Minimum = 1,
                Maximum = 50,
                Value = 1,
                Font = new Font("Segoe UI", 12),
                TextAlign = HorizontalAlignment.Center
            };

            btnAddToCart = new Button
            {
                Text = "? THÊM VÀO GI?",
                Location = new Point(20, 480),
                Size = new Size(360, 50),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAddToCart.FlatAppearance.BorderSize = 0;
            btnAddToCart.Click += BtnAddToCart_Click;

            btnRemoveFromCart = new Button
            {
                Text = "??? XÓA KH?I GI?",
                Location = new Point(20, 540),
                Size = new Size(360, 45),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRemoveFromCart.FlatAppearance.BorderSize = 0;
            btnRemoveFromCart.Click += BtnRemoveFromCart_Click;

            btnClear = new Button
            {
                Text = "?? XÓA T?T C?",
                Location = new Point(20, 595),
                Size = new Size(360, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += BtnClear_Click;

            panelLeft.Controls.AddRange(new Control[] {
                lblProductTitle, lstDemoProducts, lblQtyTitle, nudQuantity,
                btnAddToCart, btnRemoveFromCart, btnClear
            });

            // ========== RIGHT PANEL - Gi? Hàng & Thanh Toán ==========
            var panelRight = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblCartTitle = new Label
            {
                Text = "?? GI? HÀNG",
                Location = new Point(20, 20),
                Size = new Size(700, 35),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            dgvCart = new DataGridView
            {
                Location = new Point(20, 65),
                Size = new Size(720, 320),
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10),
                RowHeadersVisible = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeight = 40
            };

            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(142, 68, 173);
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvCart.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCart.DefaultCellStyle.SelectionBackColor = Color.FromArgb(155, 89, 182);
            dgvCart.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);

            dgvCart.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { 
                    HeaderText = "S?n Ph?m", 
                    DataPropertyName = "ProductName", 
                    Width = 280 
                },
                new DataGridViewTextBoxColumn { 
                    HeaderText = "SL", 
                    DataPropertyName = "Quantity", 
                    Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn { 
                    HeaderText = "??n Giá", 
                    DataPropertyName = "UnitPriceFormatted", 
                    Width = 140,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn { 
                    HeaderText = "Thành Ti?n", 
                    DataPropertyName = "SubTotalFormatted", 
                    Width = 200,
                    DefaultCellStyle = new DataGridViewCellStyle { 
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.FromArgb(46, 204, 113)
                    }
                }
            });

            // Payment Panel
            var panelPayment = new Panel
            {
                Location = new Point(20, 400),
                Size = new Size(720, 180),
                BackColor = Color.FromArgb(236, 240, 241),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblDiscountLabel = new Label
            {
                Text = "Gi?m Giá (%):",
                Location = new Point(20, 20),
                Size = new Size(130, 30),
                Font = new Font("Segoe UI", 11)
            };

            txtDiscountPercent = new TextBox
            {
                Location = new Point(155, 20),
                Size = new Size(80, 30),
                Text = "0",
                Font = new Font("Segoe UI", 11),
                TextAlign = HorizontalAlignment.Center
            };
            txtDiscountPercent.TextChanged += CalculateTotal;

            var lblVATLabel = new Label
            {
                Text = "VAT (%):",
                Location = new Point(20, 60),
                Size = new Size(130, 30),
                Font = new Font("Segoe UI", 11)
            };

            txtVATPercent = new TextBox
            {
                Location = new Point(155, 60),
                Size = new Size(80, 30),
                Text = "10",
                Font = new Font("Segoe UI", 11),
                TextAlign = HorizontalAlignment.Center
            };
            txtVATPercent.TextChanged += CalculateTotal;

            lblSubTotal = new Label
            {
                Text = "T?m tính: 0 ?",
                Location = new Point(400, 20),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblDiscount = new Label
            {
                Text = "Gi?m giá: 0 ?",
                Location = new Point(400, 50),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(231, 76, 60),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblVAT = new Label
            {
                Text = "VAT: 0 ?",
                Location = new Point(400, 80),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblTotal = new Label
            {
                Text = "T?NG C?NG: 0 ?",
                Location = new Point(350, 120),
                Size = new Size(350, 40),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(142, 68, 173),
                TextAlign = ContentAlignment.MiddleRight
            };

            panelPayment.Controls.AddRange(new Control[] {
                lblDiscountLabel, txtDiscountPercent, lblVATLabel, txtVATPercent,
                lblSubTotal, lblDiscount, lblVAT, lblTotal
            });

            btnPayWithMoMo = new Button
            {
                Text = "?? THANH TOÁN QUA MOMO",
                Location = new Point(400, 595),
                Size = new Size(340, 60),
                BackColor = Color.FromArgb(168, 50, 121), // MoMo Pink
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPayWithMoMo.FlatAppearance.BorderSize = 0;
            btnPayWithMoMo.Click += BtnPayWithMoMo_Click;

            panelRight.Controls.AddRange(new Control[] {
                lblCartTitle, dgvCart, panelPayment, btnPayWithMoMo
            });

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
            this.Controls.Add(panelHeader);
        }

        private void LoadDemoProducts()
        {
            lstDemoProducts.Items.Clear();
            foreach (var product in _demoProducts)
            {
                lstDemoProducts.Items.Add($"{product.Name} - {product.Price:N0} ?");
            }

            dgvCart.DataSource = _demoItems;
        }

        private void LstDemoProducts_DoubleClick(object? sender, EventArgs e)
        {
            BtnAddToCart_Click(sender, e);
        }

        private void BtnAddToCart_Click(object? sender, EventArgs e)
        {
            if (lstDemoProducts.SelectedIndex >= 0)
            {
                var selectedProduct = _demoProducts[lstDemoProducts.SelectedIndex];
                var existingItem = _demoItems.FirstOrDefault(i => i.ProductId == selectedProduct.Id);

                if (existingItem != null)
                {
                    existingItem.Quantity += (int)nudQuantity.Value;
                    dgvCart.Refresh();
                }
                else
                {
                    _demoItems.Add(new DemoOrderItem
                    {
                        ProductId = selectedProduct.Id,
                        ProductName = selectedProduct.Name,
                        Quantity = (int)nudQuantity.Value,
                        UnitPrice = selectedProduct.Price
                    });
                }

                CalculateTotal(null, EventArgs.Empty);
                nudQuantity.Value = 1;
            }
            else
            {
                MessageBox.Show("Vui lòng ch?n s?n ph?m!", "?? Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRemoveFromCart_Click(object? sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvCart.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < _demoItems.Count)
                {
                    _demoItems.RemoveAt(selectedIndex);
                    CalculateTotal(null, EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng ch?n s?n ph?m c?n xóa!", "?? Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            if (_demoItems.Any())
            {
                var result = MessageBox.Show("Xóa t?t c? s?n ph?m trong gi??", "?? Xác Nh?n",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _demoItems.Clear();
                    CalculateTotal(null, EventArgs.Empty);
                }
            }
        }

        private void CalculateTotal(object? sender, EventArgs e)
        {
            decimal subTotal = _demoItems.Sum(i => i.SubTotal);
            decimal discountPercent = decimal.TryParse(txtDiscountPercent.Text, out var d) ? d : 0;
            decimal vatPercent = decimal.TryParse(txtVATPercent.Text, out var v) ? v : 0;

            decimal discountAmount = subTotal * discountPercent / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * vatPercent / 100;
            decimal total = afterDiscount + vatAmount;

            lblSubTotal.Text = $"T?m tính: {subTotal:N0} ?";
            lblDiscount.Text = $"Gi?m giá: -{discountAmount:N0} ?";
            lblVAT.Text = $"VAT: +{vatAmount:N0} ?";
            lblTotal.Text = $"T?NG C?NG: {total:N0} ?";
        }

        private async void BtnPayWithMoMo_Click(object? sender, EventArgs e)
        {
            if (!_demoItems.Any())
            {
                MessageBox.Show("Gi? hàng tr?ng!\nVui lòng thêm s?n ph?m tr??c khi thanh toán.",
                    "?? Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subTotal = _demoItems.Sum(i => i.SubTotal);
            decimal discountPercent = decimal.TryParse(txtDiscountPercent.Text, out var d) ? d : 0;
            decimal vatPercent = decimal.TryParse(txtVATPercent.Text, out var v) ? v : 0;
            decimal discountAmount = subTotal * discountPercent / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * vatPercent / 100;
            decimal total = afterDiscount + vatAmount;

            var confirmMsg = $"??????????????????????????????\n" +
                            $"   ?? XÁC NH?N THANH TOÁN MOMO\n" +
                            $"??????????????????????????????\n\n" +
                            $"?? S?n ph?m: {_demoItems.Count} món\n" +
                            $"????????????????????????????\n";

            foreach (var item in _demoItems)
            {
                confirmMsg += $"• {item.ProductName} x{item.Quantity}\n";
            }

            confirmMsg += $"????????????????????????????\n" +
                         $"T?m tính:     {subTotal:N0} ?\n" +
                         $"Gi?m giá ({discountPercent}%): -{discountAmount:N0} ?\n" +
                         $"VAT ({vatPercent}%):      +{vatAmount:N0} ?\n" +
                         $"????????????????????????????\n" +
                         $"?? T?NG C?NG: {total:N0} ?\n\n" +
                         $"Xác nh?n thanh toán qua MoMo?";

            var result = MessageBox.Show(confirmMsg, "?? Thanh Toán MoMo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    btnPayWithMoMo.Enabled = false;
                    btnPayWithMoMo.Text = "? ?ang t?o link thanh toán...";

                    // T?o orderInfo chi ti?t
                    string orderInfo = $"Demo QuanLiCafe - {_demoItems.Count} món";

                    // G?i MoMo API
                    string payUrl = await _momoService.CreatePaymentUrl(total, orderInfo);

                    MessageBox.Show(
                        "? ?Ã T?O LINK THANH TOÁN MOMO THÀNH CÔNG!\n\n" +
                        "?? Trình duy?t s? t? ??ng m? trang thanh toán MoMo.\n\n" +
                        "?? Quét mã QR b?ng app MoMo ?? thanh toán test.\n\n" +
                        $"?? S? ti?n: {total:N0} ?",
                        "? Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // M? link MoMo trong trình duy?t
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = payUrl,
                        UseShellExecute = true
                    });

                    // Reset form sau 2 giây
                    await System.Threading.Tasks.Task.Delay(2000);
                    _demoItems.Clear();
                    txtDiscountPercent.Text = "0";
                    txtVATPercent.Text = "10";
                    CalculateTotal(null, EventArgs.Empty);

                    MessageBox.Show(
                        "?? DEMO HOÀN T?T!\n\n" +
                        "?? L?u ý: ?ây là môi tr??ng test MoMo Sandbox.\n" +
                        "B?n có th? dùng app MoMo test ?? quét mã QR.\n\n" +
                        "Gi? hàng ?ã ???c reset ?? demo ti?p.",
                        "?? Thông Tin",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"? L?I K?T N?I MOMO API:\n\n{ex.Message}\n\n" +
                        $"Chi ti?t:\n{ex.StackTrace}",
                        "? L?i",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    btnPayWithMoMo.Enabled = true;
                    btnPayWithMoMo.Text = "?? THANH TOÁN QUA MOMO";
                }
            }
        }
    }

    // ViewModel cho demo items
    public class DemoOrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal SubTotal => Quantity * UnitPrice;
        public string UnitPriceFormatted => $"{UnitPrice:N0} ?";
        public string SubTotalFormatted => $"{SubTotal:N0} ?";
    }
}
