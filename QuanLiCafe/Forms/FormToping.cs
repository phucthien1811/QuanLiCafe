using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiCafe.Data;
using QuanLiCafe.Models;

namespace QuanLiCafe.Forms
{
    public partial class FormToping : Form
    {
        private readonly CafeContext _context;
        private Topping? _selectedTopping;

        public FormToping()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;

            // Đăng ký sự kiện
            this.Load += FormToping_Load;
            btn_them.Click += Btn_them_Click;
            btn_sua.Click += Btn_sua_Click;
            btn_xoa.Click += Btn_xoa_Click;
            btn_lamMoi.Click += Btn_lamMoi_Click;
            btn_thoat.Click += Btn_thoat_Click;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void FormToping_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadToppings();
        }

        private void ConfigureDataGridView()
        {
            // Cấu hình DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            // Đặt lại header text và width cho columns
            Column1.HeaderText = "Mã Topping";
            Column1.Width = 100;
            Column2.HeaderText = "Tên Topping";
            Column2.Width = 200;
            Column3.HeaderText = "Giá";
            Column3.Width = 150;
        }

        // Load danh sách topping
        private void LoadToppings()
        {
            try
            {
                var toppings = _context.Toppings.OrderBy(t => t.Name).ToList();

                dataGridView1.Rows.Clear();
                _selectedTopping = null;

                foreach (var topping in toppings)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[rowIndex];

                    row.Cells["Column1"].Value = topping.Id;
                    row.Cells["Column2"].Value = topping.Name;
                    row.Cells["Column3"].Value = topping.Price.ToString("N0") + " ₫";
                    row.Tag = topping; // Lưu object topping
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách topping:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị thông tin khi chọn row
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                _selectedTopping = selectedRow.Tag as Topping;
            }
            else
            {
                _selectedTopping = null;
            }
        }

        // Nút Thêm - Mở FormAddUpToping
        private void Btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new FormAddUpToping();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadToppings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thêm topping:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa - Mở FormAddUpToping với ID
        private void Btn_sua_Click(object sender, EventArgs e)
        {
            if (_selectedTopping == null)
            {
                MessageBox.Show("Vui lòng chọn topping cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var editForm = new FormAddUpToping(_selectedTopping.Id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadToppings();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form sửa topping:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa
        private void Btn_xoa_Click(object sender, EventArgs e)
        {
            if (_selectedTopping == null)
            {
                MessageBox.Show("Vui lòng chọn topping cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa topping '{_selectedTopping.Name}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var toppingToDelete = _context.Toppings.Find(_selectedTopping.Id);

                    if (toppingToDelete == null)
                    {
                        MessageBox.Show("Không tìm thấy topping!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _context.Toppings.Remove(toppingToDelete);
                    _context.SaveChanges();

                    MessageBox.Show("Xóa topping thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadToppings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi xóa topping:\n{ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Nút Làm mới
        private void Btn_lamMoi_Click(object sender, EventArgs e)
        {
            LoadToppings();
        }

        // Nút Thoát
        private void Btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
