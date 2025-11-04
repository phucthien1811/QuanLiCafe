# ?? TÓM T?T MÃ NGU?N QUAN TR?NG

## ?? HELPER - TableStatusHelper.cs

**Ch?c n?ng:** X? lý màu s?c và text tr?ng thái bàn

```csharp
public static class TableStatusHelper
{
    // Tr? v? màu theo tr?ng thái
    public static Color GetColorByStatus(string status)
    {
        return status switch
        {
            "Free" => Color.LightGray,        // Xám nh?t
            "Serving" => Color.LightGreen,    // Xanh lá
            "Closed" => Color.DarkGray,       // Xám ??m
            _ => Color.White
        };
    }

    // Chuy?n status sang ti?ng Vi?t
    public static string GetStatusText(string status)
    {
        return status switch
        {
            "Free" => "Tr?ng",
            "Serving" => "?ang ph?c v?",
            "Closed" => "?óng",
            _ => status
        };
    }
}
```

---

## ?? FORM MAIN - FormMain.cs

### **Kh?i T?o Giao Di?n (Designer Code)**

```csharp
private void InitializeComponent()
{
    // Form settings
    this.Text = "Qu?n Lý Quán Cafe - S? ?? Bàn";
    this.Size = new Size(1000, 700);
    this.StartPosition = FormStartPosition.CenterScreen;

    // Header Panel (Màu xanh ??m)
    panelHeader = new Panel
    {
        Dock = DockStyle.Top,
        Height = 80,
        BackColor = Color.FromArgb(52, 73, 94)
    };

    // Label Title
    lblTitle = new Label
    {
        Text = "S? ?? BÀN",
        Font = new Font("Segoe UI", 20, FontStyle.Bold),
        ForeColor = Color.White,
        Location = new Point(20, 15)
    };

    // Button Reload
    btnReload = new Button
    {
        Text = "?? T?i L?i",
        Size = new Size(120, 50),
        BackColor = Color.FromArgb(46, 204, 113),
        FlatStyle = FlatStyle.Flat
    };
    btnReload.Click += BtnReload_Click;

    // TableLayoutPanel (L??i 5x4)
    tableLayoutPanel = new TableLayoutPanel
    {
        Dock = DockStyle.Fill,
        ColumnCount = 5,
        RowCount = 4,
        Padding = new Padding(20)
    };

    // C?u hình c?t và hàng ??ng ??u
    for (int i = 0; i < 5; i++)
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
    for (int i = 0; i < 4; i++)
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
}
```

### **Load Bàn t? Database (LINQ)**

```csharp
private void LoadTables()
{
    tableLayoutPanel.Controls.Clear();

    // ? LINQ: L?y 20 bàn ??u tiên
    var tables = _context.Tables
        .OrderBy(t => t.Id)
        .Take(20)
        .ToList();

    // N?u ch?a ?? 20 bàn, thêm m?i
    if (tables.Count < 20)
    {
        for (int i = tables.Count + 1; i <= 20; i++)
        {
            _context.Tables.Add(new Table
            {
                Name = $"Bàn {i}",
                Status = "Free"
            });
        }
        _context.SaveChanges();
        tables = _context.Tables.OrderBy(t => t.Id).Take(20).ToList();
    }

    // T?o button ??ng cho m?i bàn
    int row = 0, col = 0;
    foreach (var table in tables)
    {
        var btnTable = CreateTableButton(table);
        tableLayoutPanel.Controls.Add(btnTable, col, row);

        col++;
        if (col >= 5) { col = 0; row++; }
    }
}
```

### **T?o Button ??ng Cho Bàn**

```csharp
private Button CreateTableButton(Table table)
{
    var btn = new Button
    {
        Text = $"{table.Name}\n{TableStatusHelper.GetStatusText(table.Status)}",
        Tag = table.Id,  // L?u ID bàn
        Dock = DockStyle.Fill,
        Font = new Font("Segoe UI", 12, FontStyle.Bold),
        BackColor = TableStatusHelper.GetColorByStatus(table.Status),  // Màu theo tr?ng thái
        FlatStyle = FlatStyle.Flat,
        Cursor = Cursors.Hand
    };

    btn.Click += BtnTable_Click;  // S? ki?n click

    // Hover effect
    btn.MouseEnter += (s, e) =>
    {
        btn.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
        btn.FlatAppearance.BorderSize = 3;
    };

    return btn;
}
```

### **S? Ki?n Click Bàn**

```csharp
private void BtnTable_Click(object? sender, EventArgs e)
{
    if (sender is Button btn && btn.Tag is int tableId)
    {
        // M? FormOrder
        var formOrder = new FormOrder(tableId);
        formOrder.ShowDialog();

        // Reload sau khi ?óng FormOrder
        LoadTables();
    }
}
```

---

## ??? FORM ORDER - FormOrder.cs

### **Kh?i T?o Giao Di?n**

**Panel Trái - Ch?n Món:**

```csharp
// ComboBox Categories
cboCategory = new ComboBox
{
    Location = new Point(10, 40),
    Size = new Size(320, 30),
    DropDownStyle = ComboBoxStyle.DropDownList
};
cboCategory.SelectedIndexChanged += CboCategory_SelectedIndexChanged;

// ListBox Products
lstProducts = new ListBox
{
    Location = new Point(10, 110),
    Size = new Size(320, 350)
};
lstProducts.DoubleClick += LstProducts_DoubleClick;  // Double click = Thêm món

// NumericUpDown S? l??ng
nudQuantity = new NumericUpDown
{
    Minimum = 1,
    Maximum = 100,
    Value = 1
};

// Button Thêm Món
btnAddProduct = new Button
{
    Text = "? Thêm Món",
    BackColor = Color.FromArgb(46, 204, 113),
    FlatStyle = FlatStyle.Flat
};
btnAddProduct.Click += BtnAddProduct_Click;
```

**Panel Ph?i - Chi Ti?t Order:**

```csharp
// DataGridView Chi ti?t ??n hàng
dgvOrderDetails = new DataGridView
{
    AutoGenerateColumns = false,
    AllowUserToAddRows = false,
    SelectionMode = DataGridViewSelectionMode.FullRowSelect
};

// C?u hình columns
dgvOrderDetails.Columns.AddRange(new DataGridViewColumn[]
{
    new DataGridViewTextBoxColumn { HeaderText = "Tên Món", DataPropertyName = "ProductName", Width = 250 },
    new DataGridViewTextBoxColumn { HeaderText = "S? L??ng", DataPropertyName = "Quantity", Width = 100 },
    new DataGridViewTextBoxColumn { HeaderText = "??n Giá", DataPropertyName = "UnitPriceFormatted", Width = 150 },
    new DataGridViewTextBoxColumn { HeaderText = "Thành Ti?n", DataPropertyName = "SubTotalFormatted", Width = 150 }
});

// TextBox Discount & VAT
txtDiscount = new TextBox { Text = "0" };
txtVAT = new TextBox { Text = "10" };
txtDiscount.TextChanged += CalculateTotal;
txtVAT.TextChanged += CalculateTotal;

// Labels hi?n th? ti?n
lblSubTotal = new Label { Text = "T?m Tính: 0 ?" };
lblDiscountAmount = new Label { Text = "Gi?m Giá: 0 ?" };
lblVATAmount = new Label { Text = "VAT: 0 ?" };
lblTotal = new Label { Text = "T?NG C?NG: 0 ?", Font = new Font("Segoe UI", 13, FontStyle.Bold) };
```

### **Load Order Data (LINQ)**

```csharp
private void LoadOrderData()
{
    // Load table info
    var table = _context.Tables.Find(_tableId);
    lblTableName.Text = $"{table.Name} - {table.Status}";

    // ? LINQ: Load categories
    var categories = _context.Categories
        .OrderBy(c => c.Name)
        .ToList();
    cboCategory.DataSource = categories;

    // ? LINQ: Ki?m tra order ?ang ph?c v?
    _currentOrder = _context.Orders
        .Include(o => o.OrderDetails)
        .ThenInclude(od => od.Product)
        .Where(o => o.TableId == _tableId)
        .OrderByDescending(o => o.CreatedAt)
        .FirstOrDefault();

    if (_currentOrder != null)
        LoadExistingOrderDetails();  // Load order c?
    else
        CreateNewOrder();  // T?o order m?i
}
```

### **T?o Order M?i**

```csharp
private void CreateNewOrder()
{
    _currentOrder = new Order
    {
        TableId = _tableId,
        StaffId = 1,  // Gi? s? user ID = 1
        CreatedAt = DateTime.Now,
        Discount = 0,
        VAT = 10,
        TotalAmount = 0
    };
    _context.Orders.Add(_currentOrder);

    // ? C?p nh?t tr?ng thái bàn ? "Serving"
    var table = _context.Tables.Find(_tableId);
    if (table != null)
        table.Status = "Serving";

    _context.SaveChanges();
}
```

### **Load Products Theo Category**

```csharp
private void CboCategory_SelectedIndexChanged(object? sender, EventArgs e)
{
    if (cboCategory.SelectedValue is int categoryId)
        LoadProducts(categoryId);
}

private void LoadProducts(int categoryId)
{
    // ? LINQ: L?y products theo category
    var products = _context.Products
        .Where(p => p.CategoryId == categoryId)
        .OrderBy(p => p.Name)
        .ToList();

    lstProducts.DataSource = products;
    lstProducts.DisplayMember = "Name";
    lstProducts.ValueMember = "Id";
}
```

### **Thêm Món Vào Order**

```csharp
private void BtnAddProduct_Click(object? sender, EventArgs e)
{
    if (lstProducts.SelectedItem is Product product)
    {
        // Ki?m tra món ?ã có ch?a
        var existingItem = _orderDetails.FirstOrDefault(od => od.ProductId == product.Id);
        
        if (existingItem != null)
        {
            // Món ?ã có ? C?ng s? l??ng
            existingItem.Quantity += (int)nudQuantity.Value;
        }
        else
        {
            // Món m?i ? Thêm vào BindingList
            _orderDetails.Add(new OrderDetailViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = (int)nudQuantity.Value,
                UnitPrice = product.Price,
                Note = txtNote.Text
            });
        }

        // Refresh DataGridView
        dgvOrderDetails.DataSource = null;
        dgvOrderDetails.DataSource = _orderDetails;
        CalculateTotal(null, EventArgs.Empty);
    }
}
```

### **Tính Toán T?ng Ti?n**

```csharp
private void CalculateTotal(object? sender, EventArgs e)
{
    // T?ng ti?n ch?a gi?m
    decimal subTotal = _orderDetails.Sum(od => od.SubTotal);
    
    // Parse discount & VAT
    decimal discountPercent = decimal.TryParse(txtDiscount.Text, out var d) ? d : 0;
    decimal vatPercent = decimal.TryParse(txtVAT.Text, out var v) ? v : 0;

    // Tính toán
    decimal discountAmount = subTotal * discountPercent / 100;
    decimal afterDiscount = subTotal - discountAmount;
    decimal vatAmount = afterDiscount * vatPercent / 100;
    decimal total = afterDiscount + vatAmount;

    // Hi?n th?
    lblSubTotal.Text = $"T?m Tính: {subTotal:N0} ?";
    lblDiscountAmount.Text = $"Gi?m Giá: -{discountAmount:N0} ?";
    lblVATAmount.Text = $"VAT: {vatAmount:N0} ?";
    lblTotal.Text = $"T?NG C?NG: {total:N0} ?";
}
```

### **Thanh Toán**

```csharp
private void BtnPayment_Click(object? sender, EventArgs e)
{
    if (!_orderDetails.Any())
    {
        MessageBox.Show("Ch?a có món nào!", "Thông báo");
        return;
    }

    var result = MessageBox.Show("Xác nh?n thanh toán?", "Xác nh?n", 
        MessageBoxButtons.YesNo);

    if (result == DialogResult.Yes)
    {
        try
        {
            // ? Xóa order details c? (n?u có)
            var existingDetails = _context.OrderDetails
                .Where(od => od.OrderId == _currentOrder.Id)
                .ToList();
            _context.OrderDetails.RemoveRange(existingDetails);

            // ? Thêm order details m?i
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

            // ? C?p nh?t Order
            decimal subTotal = _orderDetails.Sum(od => od.SubTotal);
            decimal discountPercent = decimal.Parse(txtDiscount.Text);
            decimal vatPercent = decimal.Parse(txtVAT.Text);
            decimal discountAmount = subTotal * discountPercent / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * vatPercent / 100;

            _currentOrder.Discount = discountPercent;
            _currentOrder.VAT = vatPercent;
            _currentOrder.TotalAmount = afterDiscount + vatAmount;

            // ? C?p nh?t tr?ng thái bàn ? "Free"
            var table = _context.Tables.Find(_tableId);
            if (table != null)
                table.Status = "Free";

            _context.SaveChanges();

            MessageBox.Show($"Thanh toán thành công!\nT?ng: {_currentOrder.TotalAmount:N0} ?");
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"L?i: {ex.Message}", "L?i");
        }
    }
}
```

---

## ?? ORDER DETAIL VIEW MODEL

```csharp
public class OrderDetailViewModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string Note { get; set; } = string.Empty;

    // Calculated properties
    public decimal SubTotal => Quantity * UnitPrice;
    public string UnitPriceFormatted => $"{UnitPrice:N0} ?";
    public string SubTotalFormatted => $"{SubTotal:N0} ?";
}
```

---

## ?? PROGRAM.CS - ENTRY POINT

```csharp
internal static class Program
{
    public static IConfiguration Configuration { get; private set; } = null!;
    public static CafeContext DbContext { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        // ? Load appsettings.json
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        
        Configuration = builder.Build();

        // ? Initialize DbContext
        var optionsBuilder = new DbContextOptionsBuilder<CafeContext>();
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        DbContext = new CafeContext(optionsBuilder.Options);

        // ? Run FormMain
        ApplicationConfiguration.Initialize();
        Application.Run(new FormMain());
    }
}
```

---

**? HOÀN T?T! T?t c? mã ngu?n quan tr?ng ?ã ???c tóm t?t.**
