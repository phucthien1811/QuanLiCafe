using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormInventory : Form
    {
        private readonly CafeContext _context;
        private readonly IInventoryService _inventoryService;
        
        // Controls
        private DataGridView dgvInventory = null!;
        private Button btnImport = null!;
        private Button btnAdd = null!;
        private Button btnEdit = null!;
        private Button btnRefresh = null!;
        private Button btnLowStock = null!;
        private Button btnHistory = null!;
        private Label lblTitle = null!;
        private Panel panelHeader = null!;

        public FormInventory()
        {
            _context = Program.DbContext;
            _inventoryService = new InventoryService(_context);
            
            InitializeComponent();
            LoadInventories();
        }

        private void InitializeComponent()
        {
            this.Text = "Qu?n Lý Kho - Inventory";
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            // ========== HEADER PANEL ==========
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(52, 73, 94)
            };

            lblTitle = new Label
            {
                Text = "?? QU?N LÝ KHO",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                Size = new Size(400, 50),
                Location = new Point(20, 15),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panelHeader.Controls.Add(lblTitle);

            // ========== TOOLBAR ==========
            var panelToolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            btnAdd = CreateButton("? Thêm NVL", 15, 15, Color.FromArgb(46, 204, 113));
            btnAdd.Click += BtnAdd_Click;

            btnImport = CreateButton("?? Nh?p Kho", 200, 15, Color.FromArgb(52, 152, 219));
            btnImport.Click += BtnImport_Click;

            btnEdit = CreateButton("?? S?a", 385, 15, Color.FromArgb(243, 156, 18));
            btnEdit.Click += BtnEdit_Click;

            btnRefresh = CreateButton("?? T?i L?i", 570, 15, Color.FromArgb(149, 165, 166));
            btnRefresh.Click += (s, e) => LoadInventories();

            btnLowStock = CreateButton("?? T?n Kho Th?p", 755, 15, Color.FromArgb(231, 76, 60));
            btnLowStock.Click += BtnLowStock_Click;

            btnHistory = CreateButton("?? L?ch S?", 980, 15, Color.FromArgb(155, 89, 182));
            btnHistory.Click += BtnHistory_Click;

            panelToolbar.Controls.AddRange(new Control[] {
                btnAdd, btnImport, btnEdit, btnRefresh, btnLowStock, btnHistory
            });

            // ========== DATAGRIDVIEW ==========
            dgvInventory = new DataGridView
            {
                Dock = DockStyle.Fill,
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

            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvInventory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvInventory.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);

            dgvInventory.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 50,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "Tên Nguyên Li?u",
                    DataPropertyName = "MaterialName",
                    Width = 300
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "??n V?",
                    DataPropertyName = "Unit",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "S? L??ng",
                    DataPropertyName = "Quantity",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "M?c T?i Thi?u",
                    DataPropertyName = "ReorderLevel",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "Tr?ng Thái",
                    Name = "Status",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                }
            });

            // Row formatting
            dgvInventory.CellFormatting += DgvInventory_CellFormatting;

            this.Controls.Add(dgvInventory);
            this.Controls.Add(panelToolbar);
            this.Controls.Add(panelHeader);
        }

        private Button CreateButton(string text, int x, int y, Color bgColor)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(170, 45),
                BackColor = bgColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private void LoadInventories()
        {
            var inventories = _inventoryService.GetAllInventories();
            dgvInventory.DataSource = inventories;
        }

        private void DgvInventory_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInventory.Columns[e.ColumnIndex].Name == "Status")
            {
                if (dgvInventory.Rows[e.RowIndex].DataBoundItem is Inventory inventory)
                {
                    if (inventory.Quantity < inventory.ReorderLevel)
                    {
                        e.Value = "?? Th?p";
                        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }
                    else
                    {
                        e.Value = "? ??";
                        dgvInventory.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            using (var dialog = new FormInventoryEdit(null, _inventoryService))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadInventories();
                }
            }
        }

        private void BtnImport_Click(object? sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n nguyên li?u c?n nh?p kho!", "?? Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var inventory = dgvInventory.SelectedRows[0].DataBoundItem as Inventory;
            if (inventory == null) return;

            using (var dialog = new FormImportStock(inventory, _inventoryService))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadInventories();
                }
            }
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n nguyên li?u c?n s?a!", "?? Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var inventory = dgvInventory.SelectedRows[0].DataBoundItem as Inventory;
            if (inventory == null) return;

            using (var dialog = new FormInventoryEdit(inventory, _inventoryService))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    LoadInventories();
                }
            }
        }

        private void BtnLowStock_Click(object? sender, EventArgs e)
        {
            var lowStockItems = _inventoryService.GetLowStockItems();
            
            if (!lowStockItems.Any())
            {
                MessageBox.Show("? T?t c? nguyên li?u ??u ?? t?n kho!",
                    "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvInventory.DataSource = lowStockItems;
            MessageBox.Show($"?? Có {lowStockItems.Count} nguyên li?u d??i m?c t?n kho t?i thi?u!",
                "C?nh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnHistory_Click(object? sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng ch?n nguyên li?u ?? xem l?ch s?!", "?? Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var inventory = dgvInventory.SelectedRows[0].DataBoundItem as Inventory;
            if (inventory == null) return;

            using (var dialog = new FormImportHistory(inventory, _inventoryService))
            {
                dialog.ShowDialog();
            }
        }
    }
}
