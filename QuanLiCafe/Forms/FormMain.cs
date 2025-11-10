using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Helpers;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormMain : Form
    {
        private readonly CafeContext _context;
        private readonly User _currentUser;
        private readonly AuthService _authService;

        public FormMain()
        {
            _context = Program.DbContext;
            _currentUser = Program.CurrentUser!;
            _authService = new AuthService(_context);

            InitializeComponent();
        }

        // ========== EVENT HANDLERS - TỰ TẠO TRONG DESIGNER ==========

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Gọi khi form load - tạo 20 buttons tự động
            LoadTables();

            // Set user info nếu có label
            if (this.Controls.Find("lblUserInfo", true).FirstOrDefault() is Label lbl)
            {
                lbl.Text = $"👤 {_currentUser.Username} ({_currentUser.Role})";
            }

            // Ẩn/hiện buttons theo role
            if (this.Controls.Find("btnReport", true).FirstOrDefault() is Button btnRpt)
            {
                btnRpt.Visible = _authService.IsAdmin(_currentUser);
            }

            if (this.Controls.Find("btnInventory", true).FirstOrDefault() is Button btnInv)
            {
                btnInv.Visible = _authService.IsAdmin(_currentUser);
            }
        }

        // ========== LOGIC CODE - TẠO 20 BUTTONS TỰ ĐỘNG ==========

        public void LoadTables()
        {
            // Tìm TableLayoutPanel trong form (phải có tên = "tableLayoutPanel")
            if (this.Controls.Find("tableLayoutPanel", true).FirstOrDefault() is TableLayoutPanel tlp)
            {
                tlp.Controls.Clear();

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
                            Name = $"Table {i}",
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

                // Thêm 20 buttons vào TableLayoutPanel (5 cột x 4 hàng)
                int row = 0, col = 0;
                foreach (var table in tables)
                {
                    var btnTable = CreateTableButton(table);
                    tlp.Controls.Add(btnTable, col, row);

                    col++;
                    if (col >= 5)
                    {
                        col = 0;
                        row++;
                    }
                }
            }
        }

        public Button CreateTableButton(Table table)
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

            // Hover effect
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

        private void BtnTable_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int tableId)
            {
                var formOrder = new FormOrder(tableId);
                formOrder.ShowDialog();
                LoadTables(); // Reload sau khi đóng FormOrder
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
