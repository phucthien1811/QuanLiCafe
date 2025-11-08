using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormReport : Form
    {
        private readonly CafeContext _context;
        private readonly ReportService _reportService;
        private readonly User _currentUser;

        private TabControl tabControl = null!;
        private Panel panelRevenueByDate = null!;
        private Panel panelTopProducts = null!;
        private Panel panelRevenueByStaff = null!;
        private DataGridView dgvRevenueByDate = null!;
        private DataGridView dgvTopProducts = null!;
        private DataGridView dgvRevenueByStaff = null!;
        private DateTimePicker dtpFrom = null!;
        private DateTimePicker dtpTo = null!;
        private Button btnRefresh = null!;
        private Label lblTotalRevenue = null!;
        private Label lblTotalOrders = null!;

        public FormReport(User currentUser)
        {
            _context = Program.DbContext;
            _reportService = new ReportService(_context);
            _currentUser = currentUser;
            InitializeComponent();
            LoadReports();
        }

        private void InitializeComponent()
        {
            this.Text = "?? Reports - Cafe Management";
            this.Size = new Size(1400, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // Header Panel
            var panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(52, 73, 94)
            };

            var lblTitle = new Label
            {
                Text = "?? REVENUE REPORTS",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 10),
                Size = new Size(500, 40)
            };

            var lblUser = new Label
            {
                Text = $"?? {_currentUser.Username} ({_currentUser.Role})",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                Location = new Point(20, 55),
                Size = new Size(300, 25)
            };

            // Date pickers
            var lblFrom = new Label
            {
                Text = "From:",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 85),
                Size = new Size(60, 25)
            };

            dtpFrom = new DateTimePicker
            {
                Location = new Point(90, 85),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 11),
                Value = DateTime.Now.AddDays(-30)
            };

            var lblTo = new Label
            {
                Text = "To:",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(310, 85),
                Size = new Size(40, 25)
            };

            dtpTo = new DateTimePicker
            {
                Location = new Point(360, 85),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 11),
                Value = DateTime.Now
            };

            btnRefresh = new Button
            {
                Text = "?? Reload",
                Location = new Point(580, 80),
                Size = new Size(150, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => LoadReports();

            // Summary labels
            lblTotalRevenue = new Label
            {
                Text = "?? Total Revenue: $0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(900, 40),
                Size = new Size(450, 30),
                TextAlign = ContentAlignment.MiddleRight
            };

            lblTotalOrders = new Label
            {
                Text = "?? Total Orders: 0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(900, 75),
                Size = new Size(450, 30),
                TextAlign = ContentAlignment.MiddleRight
            };

            panelHeader.Controls.AddRange(new Control[] {
                lblTitle, lblUser, lblFrom, dtpFrom, lblTo, dtpTo, btnRefresh,
                lblTotalRevenue, lblTotalOrders
            });

            // TabControl
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12),
                Padding = new Point(10, 10)
            };

            // Tab 1: Revenue by Date
            var tabRevenue = new TabPage("?? Revenue by Date");
            dgvRevenueByDate = CreateDataGridView();
            dgvRevenueByDate.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } },
                new DataGridViewTextBoxColumn { HeaderText = "Revenue", DataPropertyName = "Revenue", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { HeaderText = "Revenue (Formatted)", DataPropertyName = "RevenueFormatted", Width = 250 }
            });

            panelRevenueByDate = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            panelRevenueByDate.Controls.Add(dgvRevenueByDate);
            tabRevenue.Controls.Add(panelRevenueByDate);

            // Tab 2: Top Products
            var tabProducts = new TabPage("?? Top Selling Products");
            dgvTopProducts = CreateDataGridView();
            dgvTopProducts.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "No.", Width = 70, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { HeaderText = "Product Name", DataPropertyName = "ProductName", Width = 300 },
                new DataGridViewTextBoxColumn { HeaderText = "Quantity Sold", DataPropertyName = "TotalQuantity", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { HeaderText = "Revenue", DataPropertyName = "TotalRevenue", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { HeaderText = "Orders", DataPropertyName = "OrderCount", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } }
            });

            panelTopProducts = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            panelTopProducts.Controls.Add(dgvTopProducts);
            tabProducts.Controls.Add(panelTopProducts);

            // Tab 3: Revenue by Staff
            var tabStaff = new TabPage("?? Revenue by Staff");
            dgvRevenueByStaff = CreateDataGridView();
            dgvRevenueByStaff.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { HeaderText = "No.", Width = 70, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { HeaderText = "Staff Name", DataPropertyName = "StaffName", Width = 250 },
                new DataGridViewTextBoxColumn { HeaderText = "Orders", DataPropertyName = "TotalOrders", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } },
                new DataGridViewTextBoxColumn { HeaderText = "Total Revenue", DataPropertyName = "TotalRevenue", Width = 200, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } },
                new DataGridViewTextBoxColumn { HeaderText = "Avg/Order", DataPropertyName = "AverageOrderValue", Width = 180, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } }
            });

            panelRevenueByStaff = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            panelRevenueByStaff.Controls.Add(dgvRevenueByStaff);
            tabStaff.Controls.Add(panelRevenueByStaff);

            tabControl.TabPages.AddRange(new TabPage[] { tabRevenue, tabProducts, tabStaff });

            this.Controls.Add(tabControl);
            this.Controls.Add(panelHeader);
        }

        private DataGridView CreateDataGridView()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11),
                RowHeadersVisible = false,
                AllowUserToResizeRows = false,
                ColumnHeadersHeight = 45
            };

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);

            return dgv;
        }

        private void LoadReports()
        {
            try
            {
                var fromDate = dtpFrom.Value.Date;
                var toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                // Summary
                var totalRevenue = _reportService.GetTotalRevenue(fromDate, toDate);
                var totalOrders = _reportService.GetTotalOrders(fromDate, toDate);

                lblTotalRevenue.Text = $"?? Total Revenue: ${totalRevenue:N0}";
                lblTotalOrders.Text = $"?? Total Orders: {totalOrders}";

                // Tab 1: Revenue by Date
                var revenueByDate = _reportService.GetRevenueByDate(fromDate, toDate);
                var revenueData = revenueByDate.Select((kvp, index) => new
                {
                    STT = index + 1,
                    Date = kvp.Key,
                    Revenue = kvp.Value,
                    RevenueFormatted = $"${kvp.Value:N0}"
                }).ToList();
                dgvRevenueByDate.DataSource = revenueData;

                // Tab 2: Top Products
                var topProducts = _reportService.GetTopSellingProducts(5);
                var productsData = topProducts.Select((p, index) => new
                {
                    STT = index + 1,
                    p.ProductName,
                    p.TotalQuantity,
                    p.TotalRevenue,
                    p.OrderCount
                }).ToList();
                dgvTopProducts.DataSource = productsData;

                // Tab 3: Revenue by Staff
                var revenueByStaff = _reportService.GetRevenueByStaff(fromDate, toDate);
                var staffData = revenueByStaff.Select((s, index) => new
                {
                    STT = index + 1,
                    s.StaffName,
                    s.TotalOrders,
                    s.TotalRevenue,
                    s.AverageOrderValue
                }).ToList();
                dgvRevenueByStaff.DataSource = staffData;

                // Add STT column at beginning
                if (dgvRevenueByDate.Columns["STT"] == null && revenueData.Any())
                {
                    dgvRevenueByDate.Columns.Insert(0, new DataGridViewTextBoxColumn
                    {
                        Name = "STT",
                        HeaderText = "No.",
                        DataPropertyName = "STT",
                        Width = 70,
                        DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports:\n{ex.Message}", "? Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
