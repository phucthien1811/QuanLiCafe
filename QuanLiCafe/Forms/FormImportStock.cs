using QuanLiCafe.Models;
using QuanLiCafe.Services;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class FormImportStock : Form
    {
        private readonly Inventory _inventory;
        private readonly IInventoryService _inventoryService;

        private NumericUpDown nudQuantity = null!;
        private NumericUpDown nudCost = null!;
        private Button btnSave = null!;
        private Button btnCancel = null!;

        public FormImportStock(Inventory inventory, IInventoryService inventoryService)
        {
            _inventory = inventory;
            _inventoryService = inventoryService;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Nh?p Kho";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblTitle = new Label
            {
                Text = "?? NH?P KHO",
                Location = new Point(20, 20),
                Size = new Size(460, 35),
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            var lblInfo = new Label
            {
                Text = $"Nguyên li?u: {_inventory.MaterialName}\n" +
                       $"T?n kho hi?n t?i: {_inventory.Quantity:N2} {_inventory.Unit}",
                Location = new Point(20, 65),
                Size = new Size(460, 50),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            var lblQuantity = new Label
            {
                Text = $"S? L??ng Nh?p ({_inventory.Unit}):",
                Location = new Point(20, 130),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            nudQuantity = new NumericUpDown
            {
                Location = new Point(230, 130),
                Size = new Size(240, 25),
                Font = new Font("Segoe UI", 12),
                Minimum = 0.01m,
                Maximum = 999999,
                DecimalPlaces = 2,
                Value = 1,
                TextAlign = HorizontalAlignment.Center
            };

            var lblCost = new Label
            {
                Text = "Giá Nh?p (?):",
                Location = new Point(20, 175),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            nudCost = new NumericUpDown
            {
                Location = new Point(230, 175),
                Size = new Size(240, 25),
                Font = new Font("Segoe UI", 12),
                Minimum = 0,
                Maximum = 999999999,
                DecimalPlaces = 0,
                Value = 0,
                TextAlign = HorizontalAlignment.Right,
                ThousandsSeparator = true
            };

            btnSave = new Button
            {
                Text = "? Nh?p Kho",
                Location = new Point(270, 240),
                Size = new Size(100, 45),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "? H?y",
                Location = new Point(380, 240),
                Size = new Size(90, 45),
                BackColor = Color.FromArgb(149, 165, 166),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] {
                lblTitle, lblInfo, lblQuantity, nudQuantity,
                lblCost, nudCost, btnSave, btnCancel
            });
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (nudQuantity.Value <= 0)
                {
                    MessageBox.Show("S? l??ng nh?p ph?i l?n h?n 0!", "?? L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"Xác nh?n nh?p kho?\n\n" +
                    $"Nguyên li?u: {_inventory.MaterialName}\n" +
                    $"S? l??ng: {nudQuantity.Value:N2} {_inventory.Unit}\n" +
                    $"Giá nh?p: {nudCost.Value:N0} ?",
                    "Xác Nh?n",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _inventoryService.ImportStock(_inventory.Id, nudQuantity.Value, nudCost.Value);

                    MessageBox.Show(
                        $"? Nh?p kho thành công!\n\n" +
                        $"T?n kho m?i: {_inventory.Quantity + nudQuantity.Value:N2} {_inventory.Unit}",
                        "Thành Công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"? L?i: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
