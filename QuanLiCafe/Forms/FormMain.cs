using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Helpers;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormMain : Form
    {
        private readonly CafeContext _context;
        private readonly User _currentUser; // ✅ Current user
        private readonly AuthService _authService;
        
        private TableLayoutPanel tableLayoutPanel = null!;
        private Button btnReload = null!;
        private Button btnInventory = null!;
        private Button btnReport = null!; // ✅ Nút báo cáo
        private Label lblTitle = null!;
        private Label lblUserInfo = null!; // ✅ Hiển thị user
        private Panel panelHeader = null!;

        public FormMain()
        {
            _context = Program.DbContext;
            _currentUser = Program.CurrentUser!;
            _authService = new AuthService(_context);
            
            InitializeComponent();
            this.Load += FormMain_Load; // 🔹 Gắn sự kiện Load
        }

        private void InitializeComponent()
        {
            this.Text = "Quản Lý Quán Cafe - Sơ Đồ Bàn";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // 🔹 Header Panel
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100, // Tăng chiều cao để chứa thêm user info
                BackColor = Color.FromArgb(52, 73, 94)
            };

            lblTitle = new Label
            {
                Text = "SƠ ĐỒ BÀN",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(400, 40),
                Location = new Point(20, 10),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // ✅ Hiển thị thông tin user
            lblUserInfo = new Label
            {
                Text = $"👤 {_currentUser.Username} ({_currentUser.Role})",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(400, 25),
                Location = new Point(20, 55),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // ✅ Nút Báo Cáo (chỉ hiện với Admin)
            btnReport = new Button
            {
                Text = "📊 Báo Cáo",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(120, 50),
                Location = new Point(590, 25),
                BackColor = Color.FromArgb(155, 89, 182),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Visible = _authService.IsAdmin(_currentUser) // ✅ Chỉ Admin mới thấy
            };
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.Click += BtnReport_Click;

            // 🆕 Button Kho (chỉ hiện với Admin)
            btnInventory = new Button
            {
                Text = "📦 Kho",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(120, 50),
                Location = new Point(720, 25),
                BackColor = Color.FromArgb(243, 156, 18),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Visible = _authService.IsAdmin(_currentUser) // ✅ Chỉ Admin mới thấy
            };
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.Click += BtnInventory_Click;

            btnReload = new Button
            {
                Text = "🔄 Tải Lại",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(120, 50),
                Location = new Point(850, 25),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.Click += BtnReload_Click;

            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblUserInfo);
            panelHeader.Controls.Add(btnReport);
            panelHeader.Controls.Add(btnInventory);
            panelHeader.Controls.Add(btnReload);

            // 🔹 TableLayoutPanel (5 cột x 4 hàng = 20 bàn)
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                RowCount = 4,
                Padding = new Padding(20),
                BackColor = Color.WhiteSmoke
            };

            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(panelHeader);
        }

        // 🔹 Gọi khi Form load
        private void FormMain_Load(object? sender, EventArgs e)
        {
            // Cấu hình cột và hàng có kích thước đồng đều
            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();

            for (int i = 0; i < 5; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            }
            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }

            LoadTables(); // 🔹 Load danh sách bàn
        }

        private void LoadTables()
        {
            tableLayoutPanel.Controls.Clear();

            var tables = _context.Tables
                .OrderBy(t => t.Id)
                .Take(20)
                .ToList();

            // Nếu chưa đủ 20 bàn, tạo thêm
            if (tables.Count < 20)
            {
                for (int i = tables.Count + 1; i <= 20; i++)
                {
                    var newTable = new Table
                    {
                        Name = $"Bàn {i}",
                        Status = "Free"
                    };
                    _context.Tables.Add(newTable);
                }
                _context.SaveChanges();

                tables = _context.Tables
                    .OrderBy(t => t.Id)
                    .Take(20)
                    .ToList();
            }

            int row = 0, col = 0;
            foreach (var table in tables)
            {
                var btnTable = CreateTableButton(table);
                tableLayoutPanel.Controls.Add(btnTable, col, row);

                col++;
                if (col >= 5)
                {
                    col = 0;
                    row++;
                }
            }
        }

        private Button CreateTableButton(Table table)
        {
            var btn = new Button
            {
                Text = $"{table.Name}\n{TableStatusHelper.GetStatusText(table.Status)}",
                Tag = table.Id,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = TableStatusHelper.GetColorByStatus(table.Status),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(5)
            };

            btn.FlatAppearance.BorderSize = 2;
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.Click += BtnTable_Click;

            // Hiệu ứng hover
            btn.MouseEnter += (s, e) =>
            {
                btn.FlatAppearance.BorderColor = Color.FromArgb(52, 152, 219);
                btn.FlatAppearance.BorderSize = 3;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.FlatAppearance.BorderColor = Color.Gray;
                btn.FlatAppearance.BorderSize = 2;
            };

            return btn;
        }

        private void BtnTable_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int tableId)
            {
                var formOrder = new FormOrder(tableId);
                formOrder.ShowDialog();
                LoadTables(); // Reload lại sau khi đóng FormOrder
            }
        }

        private void BtnReload_Click(object? sender, EventArgs e)
        {
            _context.ChangeTracker.Clear();
            LoadTables();
            MessageBox.Show("Đã tải lại trạng thái bàn!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ✅ Nút báo cáo
        private void BtnReport_Click(object? sender, EventArgs e)
        {
            var formReport = new FormReport(_currentUser);
            formReport.ShowDialog();
        }

        private void BtnInventory_Click(object? sender, EventArgs e)
        {
            if (!_authService.IsAdmin(_currentUser))
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "⚠️ Từ Chối",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formInventory = new FormInventory();
            formInventory.ShowDialog();
        }
    }
}
