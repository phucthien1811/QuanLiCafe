using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormOrder : Form
    {
        private readonly CafeContext _context;
        private readonly int _tableId;
        private Order? _currentOrder;
        private BindingList<OrderDetailViewModel> _orderDetails = new();
        
        // Services
        private readonly IPaymentService _paymentService;
        private readonly IMoMoPaymentService _momoService;

        // Controls
        private Label lblTableName = null!;
        private ComboBox cboCategory = null!;
        private ListBox lstProducts = null!;
        private DataGridView dgvOrderDetails = null!;
        private TextBox txtNote = null!;
        private NumericUpDown nudQuantity = null!;
        private TextBox txtDiscount = null!;
        private TextBox txtVAT = null!;
        private Label lblSubTotal = null!;
        private Label lblDiscountAmount = null!;
        private Label lblVATAmount = null!;
        private Label lblTotal = null!;
        private Button btnAddProduct = null!;
        private Button btnRemoveProduct = null!;
        private Button btnPayment = null!;
        private Button btnPayWithMoMo = null!;
        private Button btnCancel = null!;

        public FormOrder(int tableId)
        {
            _context = Program.DbContext;
            _tableId = tableId;
            
            // Khởi tạo services
            var orderService = new OrderService(_context);
            _paymentService = new PaymentService(_context, orderService);
            _momoService = new MoMoPaymentService(_context);
            
            InitializeComponent();
            this.Load += FormOrder_Load;
        }

        private void FormOrder_Load(object? sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void InitializeComponent()
        {
            this.Text = "Đặt Món - Quán Cà Phê";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // ========== HEADER PANEL ==========
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(52, 73, 94)
            };

            lblTableName = new Label
            {
                Text = "BÀN ?",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(500, 60),
                Location = new Point(20, 5),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panelHeader.Controls.Add(lblTableName);

            // ========== LEFT PANEL - CHỌN MÓN ==========
            var panelLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 400,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            var lblCategoryTitle = new Label
            {
                Text = "📋 DANH MỤC",
                Location = new Point(15, 15),
                Size = new Size(370, 35),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            cboCategory = new ComboBox
            {
                Location = new Point(15, 55),
                Size = new Size(370, 35),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 12),
                FlatStyle = FlatStyle.Flat
            };
            cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged;

            var lblProductsTitle = new Label
            {
                Text = "☕ SẢN PHẨM",
                Location = new Point(15, 105),
                Size = new Size(370, 35),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            lstProducts = new ListBox
            {
                Location = new Point(15, 145),
                Size = new Size(370, 380),
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(236, 240, 241)
            };
            lstProducts.DoubleClick += LstProducts_DoubleClick;

            var lblQuantityTitle = new Label
            {
                Text = "Số Lượng:",
                Location = new Point(15, 540),
                Size = new Size(100, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            nudQuantity = new NumericUpDown
            {
                Location = new Point(120, 538),
                Size = new Size(100, 35),
                Minimum = 1,
                Maximum = 100,
                Value = 1,
                Font = new Font("Segoe UI", 12),
                TextAlign = HorizontalAlignment.Center
            };

            var lblNoteTitle = new Label
            {
                Text = "📝 Ghi Chú:",
                Location = new Point(15, 585),
                Size = new Size(370, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            txtNote = new TextBox
            {
                Location = new Point(15, 620),
                Size = new Size(370, 70),
                Multiline = true,
                Font = new Font("Segoe UI", 10),
                BorderStyle = BorderStyle.FixedSingle
            };

            btnAddProduct = new Button
            {
                Text = "➕ THÊM MÓN",
                Location = new Point(15, 705),
                Size = new Size(370, 50),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAddProduct.FlatAppearance.BorderSize = 0;
            btnAddProduct.Click += BtnAddProduct_Click;
            btnAddProduct.MouseEnter += (s, e) => btnAddProduct.BackColor = Color.FromArgb(39, 174, 96);
            btnAddProduct.MouseLeave += (s, e) => btnAddProduct.BackColor = Color.FromArgb(46, 204, 113);

            panelLeft.Controls.AddRange(new Control[] {
                lblCategoryTitle, cboCategory, lblProductsTitle, lstProducts,
                lblQuantityTitle, nudQuantity, lblNoteTitle, txtNote, btnAddProduct
            });

            // ========== RIGHT PANEL - CHI TIẾT ĐƠN ==========
            var panelRight = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var lblOrderTitle = new Label
            {
                Text = "🛒 CHI TIẾT ĐƠN HÀNG",
                Location = new Point(20, 15),
                Size = new Size(900, 35),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            dgvOrderDetails = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(920, 420),
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

            dgvOrderDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvOrderDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrderDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvOrderDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetails.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvOrderDetails.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvOrderDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);

            dgvOrderDetails.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { 
                    HeaderText = "Tên Món", 
                    DataPropertyName = "ProductName", 
                    Width = 300,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
                },
                new DataGridViewTextBoxColumn { 
                    HeaderText = "Số Lượng", 
                    DataPropertyName = "Quantity", 
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn { 
                    HeaderText = "Đơn Giá", 
                    DataPropertyName = "UnitPriceFormatted", 
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn { 
                    HeaderText = "Thành Tiền", 
                    DataPropertyName = "SubTotalFormatted", 
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 10, FontStyle.Bold) }
                },
                new DataGridViewTextBoxColumn { 
                    HeaderText = "Ghi Chú", 
                    DataPropertyName = "Note", 
                    Width = 200,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
                }
            });

            btnRemoveProduct = new Button
            {
                Text = "🗑️ XÓA MÓN ĐÃ CHỌN",
                Location = new Point(20, 490),
                Size = new Size(200, 45),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRemoveProduct.FlatAppearance.BorderSize = 0;
            btnRemoveProduct.Click += BtnRemoveProduct_Click;
            btnRemoveProduct.MouseEnter += (s, e) => btnRemoveProduct.BackColor = Color.FromArgb(192, 57, 43);
            btnRemoveProduct.MouseLeave += (s, e) => btnRemoveProduct.BackColor = Color.FromArgb(231, 76, 60);

            // ========== PAYMENT PANEL ==========
            var panelPayment = new Panel
            {
                Location = new Point(20, 550),
                Size = new Size(920, 160),
                BackColor = Color.FromArgb(236, 240, 241),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblPaymentTitle = new Label
            {
                Text = "💰 THANH TOÁN",
                Location = new Point(15, 10),
                Size = new Size(250, 35),
                Font = new Font("Segoe UI", 15, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            var lblDiscountLabel = new Label
            {
                Text = "Giảm Giá (%):",
                Location = new Point(30, 55),
                Size = new Size(130, 30),
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleLeft
            };

            txtDiscount = new TextBox
            {
                Location = new Point(165, 55),
                Size = new Size(100, 30),
                Text = "0",
                Font = new Font("Segoe UI", 11),
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.FixedSingle
            };
            txtDiscount.TextChanged += CalculateTotal;

            var lblVATLabel = new Label
            {
                Text = "VAT (%):",
                Location = new Point(30, 95),
                Size = new Size(130, 30),
                Font = new Font("Segoe UI", 11),
                TextAlign = ContentAlignment.MiddleLeft
            };

            txtVAT = new TextBox
            {
                Location = new Point(165, 95),
                Size = new Size(100, 30),
                Text = "10",
                Font = new Font("Segoe UI", 11),
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.FixedSingle
            };
            txtVAT.TextChanged += CalculateTotal;

            lblSubTotal = new Label
            {
                Text = "Tạm Tính: 0 ₫",
                Location = new Point(600, 55),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 12),
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            lblDiscountAmount = new Label
            {
                Text = "Giảm Giá: 0 ₫",
                Location = new Point(600, 85),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(231, 76, 60),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblVATAmount = new Label
            {
                Text = "VAT: 0 ₫",
                Location = new Point(600, 115),
                Size = new Size(300, 25),
                Font = new Font("Segoe UI", 12),
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            lblTotal = new Label
            {
                Text = "TỔNG CỘNG: 0 ₫",
                Location = new Point(530, 130),
                Size = new Size(370, 30),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113),
                TextAlign = ContentAlignment.MiddleRight
            };

            panelPayment.Controls.AddRange(new Control[] {
                lblPaymentTitle, lblDiscountLabel, txtDiscount,
                lblVATLabel, txtVAT, lblSubTotal, lblDiscountAmount,
                lblVATAmount, lblTotal
            });

            btnPayment = new Button
            {
                Text = "💵 THANH TOÁN TIỀN MẶT",
                Location = new Point(520, 720),
                Size = new Size(200, 55),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.Click += BtnPayment_Click;
            btnPayment.MouseEnter += (s, e) => btnPayment.BackColor = Color.FromArgb(41, 128, 185);
            btnPayment.MouseLeave += (s, e) => btnPayment.BackColor = Color.FromArgb(52, 152, 219);

            btnPayWithMoMo = new Button
            {
                Text = "💳 THANH TOÁN MOMO",
                Location = new Point(740, 720),
                Size = new Size(200, 55),
                BackColor = Color.FromArgb(168, 50, 121), // MoMo Pink
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnPayWithMoMo.FlatAppearance.BorderSize = 0;
            btnPayWithMoMo.Click += BtnPayWithMoMo_Click;
            btnPayWithMoMo.MouseEnter += (s, e) => btnPayWithMoMo.BackColor = Color.FromArgb(140, 40, 100);
            btnPayWithMoMo.MouseLeave += (s, e) => btnPayWithMoMo.BackColor = Color.FromArgb(168, 50, 121);

            btnCancel = new Button
            {
                Text = "✖️ HỦY",
                Location = new Point(300, 720),
                Size = new Size(200, 55),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => this.Close();
            btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = Color.FromArgb(127, 140, 141);
            btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = Color.FromArgb(149, 165, 166);

            panelRight.Controls.AddRange(new Control[] {
                lblOrderTitle, dgvOrderDetails, btnRemoveProduct,
                panelPayment, btnPayment, btnPayWithMoMo, btnCancel
            });

            this.Controls.Add(panelRight);
            this.Controls.Add(panelLeft);
            this.Controls.Add(panelHeader);
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadOrderData()
        {
            // Load table info
            var table = _context.Tables.Find(_tableId);
            if (table != null)
            {
                lblTableName.Text = $"🍽️ {table.Name} - {GetStatusIcon(table.Status)} {table.Status}";
            }

            // Load categories
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            // Kiểm tra xem bàn có order đang phục vụ không
            _currentOrder = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Where(o => o.TableId == _tableId)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefault();

            if (_currentOrder != null)
            {
                LoadExistingOrderDetails();
            }
            else
            {
                CreateNewOrder();
            }
        }

        private string GetStatusIcon(string status)
        {
            return status switch
            {
                "Free" => "⚪",
                "Serving" => "🟢",
                "Closed" => "🔴",
                _ => "⚫"
            };
        }

        private void CreateNewOrder()
        {
            _currentOrder = new Order
            {
                TableId = _tableId,
                StaffId = 1, // Giả sử staff ID = 1 (admin)
                CreatedAt = DateTime.Now,
                Discount = 0,
                VAT = 10,
                TotalAmount = 0
            };
            _context.Orders.Add(_currentOrder);

            var table = _context.Tables.Find(_tableId);
            if (table != null)
            {
                table.Status = "Serving";
            }

            _context.SaveChanges();
            dgvOrderDetails.DataSource = _orderDetails;
        }

        private void LoadExistingOrderDetails()
        {
            if (_currentOrder == null) return;

            _orderDetails.Clear();
            foreach (var detail in _currentOrder.OrderDetails)
            {
                _orderDetails.Add(new OrderDetailViewModel
                {
                    Id = detail.Id,
                    ProductId = detail.ProductId,
                    ProductName = detail.Product.Name,
                    Quantity = detail.Quantity,
                    UnitPrice = detail.UnitPrice,
                    Note = detail.Note ?? ""
                });
            }

            dgvOrderDetails.DataSource = _orderDetails;
            txtDiscount.Text = _currentOrder.Discount.ToString();
            txtVAT.Text = _currentOrder.VAT.ToString();
            CalculateTotal(null, EventArgs.Empty);
        }

        private void CboCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboCategory.SelectedValue is int categoryId)
            {
                LoadProducts(categoryId);
            }
        }

        private void LoadProducts(int categoryId)
        {
            var products = _context.Products
                .Where(p => p.CategoryId == categoryId)
                .OrderBy(p => p.Name)
                .Select(p => new { p.Id, DisplayText = $"{p.Name} - {p.Price:N0}₫" })
                .ToList();

            lstProducts.DataSource = products;
            lstProducts.DisplayMember = "DisplayText";
            lstProducts.ValueMember = "Id";
        }

        private void LstProducts_DoubleClick(object? sender, EventArgs e)
        {
            BtnAddProduct_Click(sender, e);
        }

        private void BtnAddProduct_Click(object? sender, EventArgs e)
        {
            if (lstProducts.SelectedValue is int productId)
            {
                var product = _context.Products.Find(productId);
                if (product == null) return;

                var existingItem = _orderDetails.FirstOrDefault(od => od.ProductId == product.Id);

                if (existingItem != null)
                {
                    existingItem.Quantity += (int)nudQuantity.Value;
                }
                else
                {
                    _orderDetails.Add(new OrderDetailViewModel
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Quantity = (int)nudQuantity.Value,
                        UnitPrice = product.Price,
                        Note = txtNote.Text
                    });
                }

                dgvOrderDetails.DataSource = null;
                dgvOrderDetails.DataSource = _orderDetails;
                CalculateTotal(null, EventArgs.Empty);

                txtNote.Clear();
                nudQuantity.Value = 1;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "⚠️ Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRemoveProduct_Click(object? sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvOrderDetails.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < _orderDetails.Count)
                {
                    var result = MessageBox.Show("Xóa món này khỏi đơn?", "⚠️ Xác Nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        _orderDetails.RemoveAt(selectedIndex);
                        dgvOrderDetails.DataSource = null;
                        dgvOrderDetails.DataSource = _orderDetails;
                        CalculateTotal(null, EventArgs.Empty);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "⚠️ Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalculateTotal(object? sender, EventArgs e)
        {
            decimal subTotal = _orderDetails.Sum(od => od.SubTotal);

            decimal discountPercent = decimal.TryParse(txtDiscount.Text, out var d) ? d : 0;
            decimal vatPercent = decimal.TryParse(txtVAT.Text, out var v) ? v : 0;

            decimal discountAmount = subTotal * discountPercent / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * vatPercent / 100;
            decimal total = afterDiscount + vatAmount;

            lblSubTotal.Text = $"Tạm Tính: {subTotal:N0} ₫";
            lblDiscountAmount.Text = $"Giảm Giá: -{discountAmount:N0} ₫";
            lblVATAmount.Text = $"VAT: +{vatAmount:N0} ₫";
            lblTotal.Text = $"TỔNG CỘNG: {total:N0} ₫";
        }

        private void BtnPayment_Click(object? sender, EventArgs e)
        {
            if (_currentOrder == null || !_orderDetails.Any())
            {
                MessageBox.Show("Chưa có món nào trong đơn hàng!", "⚠️ Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subTotal = _orderDetails.Sum(od => od.SubTotal);
            decimal discountPercent = decimal.TryParse(txtDiscount.Text, out var d) ? d : 0;
            decimal vatPercent = decimal.TryParse(txtVAT.Text, out var v) ? v : 0;
            decimal discountAmount = subTotal * discountPercent / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * vatPercent / 100;
            decimal total = afterDiscount + vatAmount;

            var confirmMsg = $"══════════════════════════\n" +
                            $"📋 XÁC NHẬN THANH TOÁN\n" +
                            $"══════════════════════════\n\n" +
                            $"Tạm tính:        {subTotal:N0} ₫\n" +
                            $"Giảm giá ({discountPercent}%):  -{discountAmount:N0} ₫\n" +
                            $"VAT ({vatPercent}%):       +{vatAmount:N0} ₫\n" +
                            $"──────────────────────────\n" +
                            $"💰 TỔNG CỘNG:  {total:N0} ₫\n\n" +
                            $"Xác nhận thanh toán?";

            var result = MessageBox.Show(confirmMsg, "💳 Thanh Toán",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Lưu OrderDetails vào database
                    var existingDetails = _context.OrderDetails
                        .Where(od => od.OrderId == _currentOrder.Id)
                        .ToList();
                    _context.OrderDetails.RemoveRange(existingDetails);

                    foreach (var item in _orderDetails)
                    {
                        _context.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = _currentOrder.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                            Note = item.Note
                        });
                    }
                    _context.SaveChanges();

                    // ✅ Xử lý thanh toán bằng PaymentService
                    // (Tính tổng + Cập nhật trạng thái bàn = Closed)
                    _paymentService.ProcessPayment(_currentOrder.Id, discountPercent, vatPercent);

                    // ✅ Hỏi xuất hóa đơn
                    var exportResult = MessageBox.Show(
                        "Thanh toán thành công!\n\n" +
                        "Bạn có muốn xuất hóa đơn không?\n\n" +
                        "Yes = PDF\n" +
                        "No = Excel\n" +
                        "Cancel = Không xuất",
                        "📄 Xuất Hóa Đơn",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);

                    if (exportResult != DialogResult.Cancel)
                    {
                        // Chọn thư mục lưu
                        using (var folderDialog = new FolderBrowserDialog())
                        {
                            folderDialog.Description = "Chọn thư mục lưu hóa đơn";
                            folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                            if (folderDialog.ShowDialog() == DialogResult.OK)
                            {
                                string outputFile = "";

                                if (exportResult == DialogResult.Yes)
                                {
                                    // Xuất PDF
                                    outputFile = _paymentService.ExportInvoiceToPDF(_currentOrder.Id, folderDialog.SelectedPath);
                                    MessageBox.Show($"✅ Đã xuất hóa đơn PDF!\n\n{outputFile}",
                                        "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (exportResult == DialogResult.No)
                                {
                                    // Xuất Excel
                                    outputFile = _paymentService.ExportInvoiceToExcel(_currentOrder.Id, folderDialog.SelectedPath);
                                    MessageBox.Show($"✅ Đã xuất hóa đơn Excel!\n\n{outputFile}",
                                        "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                // Mở file vừa xuất
                                if (!string.IsNullOrEmpty(outputFile) && File.Exists(outputFile))
                                {
                                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                    {
                                        FileName = outputFile,
                                        UseShellExecute = true
                                    });
                                }
                            }
                        }
                    }

                    MessageBox.Show($"✅ THANH TOÁN THÀNH CÔNG!\n\n" +
                                  $"Tổng tiền: {total:N0} ₫\n" +
                                  $"Ngày giờ: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n" +
                                  $"Cảm ơn quý khách!",
                        "🎉 Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Lỗi thanh toán:\n{ex.Message}\n\n{ex.StackTrace}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnPayWithMoMo_Click(object? sender, EventArgs e)
        {
            if (_currentOrder == null || !_orderDetails.Any())
            {
                MessageBox.Show("Chưa có món nào trong đơn hàng!", "⚠️ Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subTotal = _orderDetails.Sum(od => od.SubTotal);
            decimal discountPercent = decimal.TryParse(txtDiscount.Text, out var d) ? d : 0;
            decimal vatPercent = decimal.TryParse(txtVAT.Text, out var v) ? v : 0;
            decimal discountAmount = subTotal * discountPercent / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * vatPercent / 100;
            decimal total = afterDiscount + vatAmount;

            var confirmMsg = $"══════════════════════════\n" +
                            $"💳 XÁC NHẬN THANH TOÁN MOMO\n" +
                            $"══════════════════════════\n\n" +
                            $"Tạm tính:        {subTotal:N0} ₫\n" +
                            $"Giảm giá ({discountPercent}%):  -{discountAmount:N0} ₫\n" +
                            $"VAT ({vatPercent}%):       +{vatAmount:N0} ₫\n" +
                            $"──────────────────────────\n" +
                            $"💰 TỔNG CỘNG:  {total:N0} ₫\n\n" +
                            $"Thanh toán qua MoMo?";

            var result = MessageBox.Show(confirmMsg, "💳 Thanh Toán MoMo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    btnPayWithMoMo.Enabled = false;
                    btnPayWithMoMo.Text = "⏳ Đang tạo link...";

                    // Lưu OrderDetails vào database trước
                    var existingDetails = _context.OrderDetails
                        .Where(od => od.OrderId == _currentOrder.Id)
                        .ToList();
                    _context.OrderDetails.RemoveRange(existingDetails);

                    foreach (var item in _orderDetails)
                    {
                        _context.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = _currentOrder.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                            Note = item.Note
                        });
                    }

                    // Cập nhật Order
                    _currentOrder.Discount = discountPercent;
                    _currentOrder.VAT = vatPercent;
                    _currentOrder.TotalAmount = total;
                    _context.SaveChanges();

                    // Tạo link MoMo
                    string payUrl = await _momoService.CreatePaymentUrl(_currentOrder.Id);

                    MessageBox.Show(
                        "✅ ĐÃ TẠO LINK THANH TOÁN MOMO!\n\n" +
                        "🌐 Trình duyệt sẽ tự động mở.\n" +
                        "📱 Quét mã QR bằng app MoMo.\n\n" +
                        $"💰 Số tiền: {total:N0} ₫",
                        "✅ Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Mở link MoMo
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = payUrl,
                        UseShellExecute = true
                    });

                    // Cập nhật trạng thái bàn về Closed
                    var table = _context.Tables.Find(_tableId);
                    if (table != null)
                    {
                        table.Status = "Closed";
                        _context.SaveChanges();
                    }

                    MessageBox.Show(
                        "🎉 THANH TOÁN MOMO HOÀN TẤT!\n\n" +
                        "ℹ️ Đây là môi trường test MoMo Sandbox.\n" +
                        "Bạn có thể dùng app MoMo test để quét mã.\n\n" +
                        "Cảm ơn quý khách!",
                        "🎉 Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"❌ LỖI THANH TOÁN MOMO:\n\n{ex.Message}",
                        "❌ Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    btnPayWithMoMo.Enabled = true;
                    btnPayWithMoMo.Text = "💳 THANH TOÁN MOMO";
                }
            }
        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // ViewModel cho DataGridView
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Note { get; set; } = string.Empty;

        public decimal SubTotal => Quantity * UnitPrice;
        public string UnitPriceFormatted => $"{UnitPrice:N0} ₫";
        public string SubTotalFormatted => $"{SubTotal:N0} ₫";
    }
}
