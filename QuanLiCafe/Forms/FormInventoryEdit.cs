using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormInventoryEdit : Form
    {
        private readonly Inventory? _inventory;
        private readonly IInventoryService _inventoryService;

        private TextBox txtMaterialName = null!;
        private TextBox txtUnit = null!;
        private NumericUpDown nudQuantity = null!;
        private NumericUpDown nudReorderLevel = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public FormInventoryEdit(Inventory? inventory, IInventoryService inventoryService)
        {
            _inventory = inventory;
            _inventoryService = inventoryService;
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = _inventory == null ? "Thêm Nguyên Li?u" : "S?a Nguyên Li?u";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblTitle = new Label
            {
                Text = _inventory == null ? "? THÊM NGUYÊN LI?U M?I" : "?? S?A NGUYÊN LI?U",
                Location = new Point(20, 20),
                Size = new Size(460, 35),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            var lblMaterialName = new Label
            {
                Text = "Tên Nguyên Li?u:",
                Location = new Point(20, 70),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10)
            };

            txtMaterialName = new TextBox
            {
                Location = new Point(180, 70),
                Size = new Size(290, 25),
                Font = new Font("Segoe UI", 10)
            };

            var lblUnit = new Label
            {
                Text = "??n V?:",
                Location = new Point(20, 110),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10)
            };

            txtUnit = new TextBox
            {
                Location = new Point(180, 110),
                Size = new Size(290, 25),
                Font = new Font("Segoe UI", 10)
            };

            var lblQuantity = new Label
            {
                Text = "S? L??ng Ban ??u:",
                Location = new Point(20, 150),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10)
            };

            nudQuantity = new NumericUpDown
            {
                Location = new Point(180, 150),
                Size = new Size(290, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 0,
                Maximum = 999999,
                DecimalPlaces = 2,
                Enabled = _inventory == null // Ch? cho phép nh?p khi thêm m?i
            };

            var lblReorderLevel = new Label
            {
                Text = "M?c T?n T?i Thi?u:",
                Location = new Point(20, 190),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10)
            };

            nudReorderLevel = new NumericUpDown
            {
                Location = new Point(180, 190),
                Size = new Size(290, 25),
                Font = new Font("Segoe UI", 10),
                Minimum = 0,
                Maximum = 999999,
                DecimalPlaces = 2
            };

            btnSave = new Button
            {
                Text = "?? L?u",
                Location = new Point(270, 270),
                Size = new Size(100, 45),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "? H?y",
                Location = new Point(380, 270),
                Size = new Size(100, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] {
                lblTitle, lblMaterialName, txtMaterialName, lblUnit, txtUnit,
                lblQuantity, nudQuantity, lblReorderLevel, nudReorderLevel,
                btnSave, btnCancel
            });
        }

        private void LoadData()
        {
            if (_inventory != null)
            {
                txtMaterialName.Text = _inventory.MaterialName;
                txtUnit.Text = _inventory.Unit;
                nudQuantity.Value = _inventory.Quantity;
                nudReorderLevel.Value = _inventory.ReorderLevel;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
                {
                    MessageBox.Show("Vui lòng nh?p tên nguyên li?u!", "?? L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUnit.Text))
                {
                    MessageBox.Show("Vui lòng nh?p ??n v?!", "?? L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_inventory == null)
                {
                    // Thêm m?i
                    _inventoryService.AddInventory(
                        txtMaterialName.Text.Trim(),
                        txtUnit.Text.Trim(),
                        nudQuantity.Value,
                        nudReorderLevel.Value
                    );
                    MessageBox.Show("? Thêm nguyên li?u thành công!", "Thành Công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // C?p nh?t
                    _inventoryService.UpdateInventory(
                        _inventory.Id,
                        txtMaterialName.Text.Trim(),
                        txtUnit.Text.Trim(),
                        nudReorderLevel.Value
                    );
                    MessageBox.Show("? C?p nh?t nguyên li?u thành công!", "Thành Công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"? L?i: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
