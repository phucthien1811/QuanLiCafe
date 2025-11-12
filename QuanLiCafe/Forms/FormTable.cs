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

namespace TableForm
{
    public partial class TableForm : Form
    {
        private readonly CafeContext _context;

        public TableForm()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            
            // Đăng ký sự kiện
            this.Load += TableForm_Load;
            btn_them.Click += Btn_them_Click;
            btn_xoa.Click += Btn_xoa_Click;
            btn_sua.Click += Btn_sua_Click;
            btn_lamMoi.Click += Btn_lamMoi_Click;
            btn_timKiem.Click += Btn_timKiem_Click;
            btn_xuatExcel.Click += Btn_xuatExcel_Click;
            btn_thoat.Click += Btn_thoat_Click;
            dgv_table.SelectionChanged += Dgv_table_SelectionChanged;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            LoadTables();
        }

        // Load danh sách bàn
        private void LoadTables(string searchText = "")
        {
            try
            {
                dgv_table.Rows.Clear();
                
                var query = _context.Tables.AsQueryable();
                
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query = query.Where(t => t.Name.Contains(searchText));
                }
                
                var tables = query.OrderBy(t => t.Id).ToList();
                
                foreach (var table in tables)
                {
                    int rowIndex = dgv_table.Rows.Add();
                    var row = dgv_table.Rows[rowIndex];
                    
                    row.Cells["Soban"].Value = table.Id;
                    row.Cells["Tenban"].Value = table.Name;
                    row.Cells["Vitri"].Value = "Tầng 1"; // Có thể thêm thuộc tính Location vào model sau
                    row.Cells["Trangthai"].Value = table.Status == "Free";
                    row.Tag = table; // Lưu object table
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách bàn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Thêm - Mở form Add_Table
        private void Btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new Add_Table();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thêm bàn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa - Mở form Delete_Table
        private void Btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_table.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgv_table.SelectedRows[0];
                var table = selectedRow.Tag as Table;
                
                if (table != null)
                {
                    var deleteForm = new Delete_Table(table.Id);
                    if (deleteForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadTables();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form xóa bàn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa
        private void Btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_table.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgv_table.SelectedRows[0];
                var table = selectedRow.Tag as Table;
                
                if (table != null)
                {
                    var editForm = new Add_Table(table.Id); // Dùng lại form Add_Table cho chỉnh sửa
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadTables();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form sửa bàn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Làm mới
        private void Btn_lamMoi_Click(object sender, EventArgs e)
        {
            txb_timKiem.Clear();
            LoadTables();
        }

        // Nút Tìm kiếm
        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            LoadTables(txb_timKiem.Text);
        }

        // Nút Xuất Excel
        private void Btn_xuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Thoát
        private void Btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Khi chọn dòng trong DataGridView
        private void Dgv_table_SelectionChanged(object sender, EventArgs e)
        {
            // Có thể hiển thị thông tin chi tiết ở đây nếu cần
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            Btn_sua_Click(sender, e);
        }
    }
}
