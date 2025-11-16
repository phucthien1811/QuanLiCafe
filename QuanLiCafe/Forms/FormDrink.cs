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
using Microsoft.EntityFrameworkCore;

namespace DrinkForm
{
    public partial class FormMain : Form
    {
        private readonly CafeContext _context;

        public FormMain()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            
            // Đăng ký sự kiện
            this.Load += FormMain_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            btnThoat.Click += BtnThoat_Click;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadProducts();
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            // Cấu hình DataGridView
            DanhMucDoUong.AutoGenerateColumns = false;
            DanhMucDoUong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DanhMucDoUong.MultiSelect = false;
            DanhMucDoUong.AllowUserToAddRows = false;
            DanhMucDoUong.ReadOnly = true;
            
            // Map columns
            colMaDoUong.DataPropertyName = "Id";
            colTenDoUong.DataPropertyName = "Name";
            colGiaTien.DataPropertyName = "Price";
            colMaDanhMuc.DataPropertyName = "CategoryId";
        }

        // Load danh sách đồ uống
        private void LoadProducts(string searchText = "")
        {
            try
            {
                var query = _context.Products
                    .Include(p => p.Category)
                    .AsQueryable();
                
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    query = query.Where(p => p.Name.Contains(searchText));
                }
                
                var products = query.OrderBy(p => p.Name).ToList();
                
                DanhMucDoUong.Rows.Clear();
                
                foreach (var product in products)
                {
                    int rowIndex = DanhMucDoUong.Rows.Add();
                    var row = DanhMucDoUong.Rows[rowIndex];
                    
                    // Load hình ảnh nếu có
                    if (!string.IsNullOrEmpty(product.ImageUrl) && System.IO.File.Exists(product.ImageUrl))
                    {
                        try
                        {
                            row.Cells["colHinh"].Value = Image.FromFile(product.ImageUrl);
                        }
                        catch
                        {
                            row.Cells["colHinh"].Value = null;
                        }
                    }
                    
                    row.Cells["colMaDoUong"].Value = product.Id;
                    row.Cells["colTenDoUong"].Value = product.Name;
                    row.Cells["colMoTa"].Value = ""; // Có thể thêm thuộc tính Description vào model
                    row.Cells["colGiaTien"].Value = product.Price.ToString("N0") + " ₫";
                    row.Cells["colMaDanhMuc"].Value = product.CategoryId;
                    row.Cells["colTenDanhMuc"].Value = product.Category?.Name ?? "";
                    row.Tag = product; // Lưu object product
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Thêm - Mở form EditDrinkForm
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new EditDrinkForm();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thêm đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (DanhMucDoUong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đồ uống cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = DanhMucDoUong.SelectedRows[0];
                var product = selectedRow.Tag as Product;
                
                if (product != null)
                {
                    var editForm = new EditDrinkForm(product.Id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form sửa đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa - Xóa đồ uống đã chọn
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (DanhMucDoUong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đồ uống cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = DanhMucDoUong.SelectedRows[0];
                var product = selectedRow.Tag as Product;
                
                if (product != null)
                {
                    // Hiển thị hộp thoại xác nhận
                    var result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa đồ uống '{product.Name}' không?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    
                    if (result == DialogResult.Yes)
                    {
                        // Xóa đồ uống khỏi database
                        _context.Products.Remove(product);
                        _context.SaveChanges();
                        
                        MessageBox.Show("Xóa đồ uống thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Refresh danh sách
                        LoadProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Làm mới
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadProducts();
        }

        // Nút Tìm kiếm
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            LoadProducts(txtTimKiem.Text);
        }

        // Nút Xuất Excel
        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang phát triển!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Nút Thoát
        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BtnSua_Click(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event handler đã có sẵn
        }
    }
}
