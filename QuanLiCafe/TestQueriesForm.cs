using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;

namespace QuanLiCafe
{
    public partial class TestQueriesForm : Form
    {
        private readonly CafeContext _context;
        private TextBox txtResults;
        private Button btnQuery1;
        private Button btnQuery2;
        private Button btnQuery3;
        private Button btnAllQueries;

        public TestQueriesForm()
        {
            _context = Program.DbContext;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Test LINQ Queries - Qu?n Lý Cafe";
            this.Width = 800;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterScreen;

            // TextBox to display results
            txtResults = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10F),
                ReadOnly = true
            };

            // Buttons
            var panelButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Padding = new Padding(10)
            };

            btnQuery1 = new Button { Text = "Query 1: Top 3 s?n ph?m giá cao", Width = 180, Height = 30 };
            btnQuery1.Click += BtnQuery1_Click;

            btnQuery2 = new Button { Text = "Query 2: Bàn ?ang Free", Width = 180, Height = 30 };
            btnQuery2.Click += BtnQuery2_Click;

            btnQuery3 = new Button { Text = "Query 3: Nguyên li?u c?n ??t", Width = 180, Height = 30 };
            btnQuery3.Click += BtnQuery3_Click;

            btnAllQueries = new Button { Text = "Ch?y t?t c?", Width = 150, Height = 30 };
            btnAllQueries.Click += BtnAllQueries_Click;

            panelButtons.Controls.AddRange(new Control[] { btnQuery1, btnQuery2, btnQuery3, btnAllQueries });

            this.Controls.Add(txtResults);
            this.Controls.Add(panelButtons);
        }

        private void BtnQuery1_Click(object? sender, EventArgs e)
        {
            txtResults.Clear();
            txtResults.AppendText("=== QUERY 1: TOP 3 MÓN GIÁ CAO NH?T ===\r\n\r\n");

            var topProducts = _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Price)
                .Take(3)
                .ToList();

            foreach (var product in topProducts)
            {
                txtResults.AppendText($"Tên: {product.Name}\r\n");
                txtResults.AppendText($"Giá: {product.Price:N0} VN?\r\n");
                txtResults.AppendText($"Danh m?c: {product.Category.Name}\r\n");
                txtResults.AppendText("-------------------\r\n");
            }
        }

        private void BtnQuery2_Click(object? sender, EventArgs e)
        {
            txtResults.Clear();
            txtResults.AppendText("=== QUERY 2: BÀN ?ANG FREE ===\r\n\r\n");

            var freeTables = _context.Tables
                .Where(t => t.Status == "Free")
                .ToList();

            txtResults.AppendText($"T?ng s? bàn tr?ng: {freeTables.Count}\r\n\r\n");

            foreach (var table in freeTables)
            {
                txtResults.AppendText($"- {table.Name} (Tr?ng thái: {table.Status})\r\n");
            }
        }

        private void BtnQuery3_Click(object? sender, EventArgs e)
        {
            txtResults.Clear();
            txtResults.AppendText("=== QUERY 3: NGUYÊN LI?U D??I M?C T?N KHO T?I THI?U ===\r\n\r\n");

            var lowStockMaterials = _context.Inventories
                .Where(i => i.Quantity < i.ReorderLevel)
                .ToList();

            txtResults.AppendText($"T?ng s? nguyên li?u c?n ??t thêm: {lowStockMaterials.Count}\r\n\r\n");

            foreach (var material in lowStockMaterials)
            {
                txtResults.AppendText($"Nguyên li?u: {material.MaterialName}\r\n");
                txtResults.AppendText($"S? l??ng còn: {material.Quantity} {material.Unit}\r\n");
                txtResults.AppendText($"M?c t?i thi?u: {material.ReorderLevel} {material.Unit}\r\n");
                txtResults.AppendText($"C?n ??t thêm: {material.ReorderLevel - material.Quantity} {material.Unit}\r\n");
                txtResults.AppendText("-------------------\r\n");
            }
        }

        private void BtnAllQueries_Click(object? sender, EventArgs e)
        {
            txtResults.Clear();

            // Query 1
            txtResults.AppendText("=== QUERY 1: TOP 3 MÓN GIÁ CAO NH?T ===\r\n\r\n");
            var topProducts = _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Price)
                .Take(3)
                .ToList();

            foreach (var product in topProducts)
            {
                txtResults.AppendText($"Tên: {product.Name}, Giá: {product.Price:N0} VN?, Danh m?c: {product.Category.Name}\r\n");
            }

            txtResults.AppendText("\r\n\r\n");

            // Query 2
            txtResults.AppendText("=== QUERY 2: BÀN ?ANG FREE ===\r\n\r\n");
            var freeTables = _context.Tables
                .Where(t => t.Status == "Free")
                .ToList();

            txtResults.AppendText($"T?ng s? bàn tr?ng: {freeTables.Count}\r\n");
            foreach (var table in freeTables)
            {
                txtResults.AppendText($"- {table.Name}\r\n");
            }

            txtResults.AppendText("\r\n\r\n");

            // Query 3
            txtResults.AppendText("=== QUERY 3: NGUYÊN LI?U D??I M?C T?N KHO ===\r\n\r\n");
            var lowStockMaterials = _context.Inventories
                .Where(i => i.Quantity < i.ReorderLevel)
                .ToList();

            txtResults.AppendText($"T?ng s? nguyên li?u c?n ??t: {lowStockMaterials.Count}\r\n");
            foreach (var material in lowStockMaterials)
            {
                txtResults.AppendText($"- {material.MaterialName}: {material.Quantity}/{material.ReorderLevel} {material.Unit}\r\n");
            }
        }
    }
}
