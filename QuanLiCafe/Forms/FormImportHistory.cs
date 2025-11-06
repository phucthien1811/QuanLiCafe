using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormImportHistory : Form
    {
        private readonly Inventory _inventory;
        private readonly IInventoryService _inventoryService;
        private DataGridView dgvHistory = null!;

        public FormImportHistory(Inventory inventory, IInventoryService inventoryService)
        {
            _inventory = inventory;
            _inventoryService = inventoryService;
            InitializeComponent();
            LoadHistory();
        }

        private void InitializeComponent()
        {
            this.Text = $"L?ch S? Nh?p Kho - {_inventory.MaterialName}";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            var lblTitle = new Label
            {
                Text = $"?? L?CH S? NH?P KHO - {_inventory.MaterialName}",
                Location = new Point(20, 20),
                Size = new Size(850, 35),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            dgvHistory = new DataGridView
            {
                Location = new Point(20, 70),
                Size = new Size(850, 470),
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

            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);

            dgvHistory.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn {
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "Th?i Gian",
                    DataPropertyName = "ImportedAt",
                    Width = 180,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm:ss" }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "S? L??ng",
                    DataPropertyName = "Quantity",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N2"
                    }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "??n V?",
                    Name = "Unit",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "Giá Nh?p",
                    DataPropertyName = "Cost",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N0"
                    }
                },
                new DataGridViewTextBoxColumn {
                    HeaderText = "T?ng Ti?n",
                    Name = "TotalCost",
                    Width = 150,
                    DefaultCellStyle = new DataGridViewCellStyle {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N0",
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    }
                }
            });

            dgvHistory.CellFormatting += DgvHistory_CellFormatting;

            var btnClose = new Button
            {
                Text = "?? ?óng",
                Location = new Point(770, 550),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { lblTitle, dgvHistory, btnClose });
        }

        private void LoadHistory()
        {
            var history = _inventoryService.GetImportHistory(_inventory.Id);
            dgvHistory.DataSource = history;
        }

        private void DgvHistory_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHistory.Rows[e.RowIndex].DataBoundItem is ImportHistory import)
            {
                if (dgvHistory.Columns[e.ColumnIndex].Name == "Unit")
                {
                    e.Value = _inventory.Unit;
                }
                else if (dgvHistory.Columns[e.ColumnIndex].Name == "TotalCost")
                {
                    e.Value = import.Quantity * import.Cost;
                }
            }
        }
    }
}
