using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
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

        private int _selectedTableId = 0;
        private Order? _currentOrder = null;

        public FormMain()
        {
            _context = Program.DbContext;
            _currentUser = Program.CurrentUser!;
            _authService = new AuthService(_context);

            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Load dữ liệu ban đầu
            LoadTables();
            LoadProducts();
            UpdateUserInfo();

            // Set ngày hiện tại
            dtNgayOrder.Value = DateTime.Now;
            txtMaNV.Text = $"{_currentUser.Id} - {_currentUser.Username}";
        }

        // ===== LOAD DANH SÁCH BÀN =====
        private void LoadTables()
        {
            listViewBan.Clear();
            listViewBan.View = View.LargeIcon;

            var tables = _context.Tables.OrderBy(t => t.Id).ToList();

            foreach (var table in tables)
            {
                var item = new ListViewItem
                {
                    Text = table.Name,
                    Tag = table.Id,
                    // ImageIndex: 0 = bàn trống, 1 = bàn đang phục vụ
                    ImageIndex = table.Status == "Free" ? 0 : 1
                };

                listViewBan.Items.Add(item);
            }

            // Event click bàn
            listViewBan.SelectedIndexChanged += (s, e) =>
            {
                if (listViewBan.SelectedItems.Count > 0)
                {
                    var selectedItem = listViewBan.SelectedItems[0];
                    _selectedTableId = (int)selectedItem.Tag;

                    var table = _context.Tables.Find(_selectedTableId);
                    btnBanDaChon.Text = table?.Name ?? "Chưa chọn bàn";

                    LoadOrderForTable(_selectedTableId);
                }
            };
        }

        // ===== LOAD SẢN PHẨM =====
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

                // Clear rows only, keep columns from Designer
                dtgvDoUong.Rows.Clear();

                foreach (var product in products)
                {
                    int rowIndex = dtgvDoUong.Rows.Add();
                    var row = dtgvDoUong.Rows[rowIndex];

                    // Load hình ảnh nếu có
                    if (!string.IsNullOrEmpty(product.ImageUrl) && System.IO.File.Exists(product.ImageUrl))
                    {
                        try
                        {
                            row.Cells["HinhAnh"].Value = Image.FromFile(product.ImageUrl);
                        }
                        catch
                        {
                            row.Cells["HinhAnh"].Value = null;
                        }
                    }

                    row.Cells["MaDoUong"].Value = product.Id;
                    row.Cells["TenDoUong"].Value = product.Name;
                    row.Cells["GiaTien"].Value = product.Price.ToString("N0") + " ₫";
                    row.Tag = product; // Lưu object product
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách đồ uống:\n{ex.Message}\n\nStack trace: {ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== LOAD ĐƠN HÀNG CỦA BÀN =====
        private void LoadOrderForTable(int tableId)
        {
            // Tìm order đang phục vụ của bàn
            _currentOrder = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.TableId == tableId && o.Table.Status == "Serving")
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefault();

            if (_currentOrder == null)
            {
                // Tạo order mới
                var table = _context.Tables.Find(tableId);
                if (table != null)
                {
                    _currentOrder = new Order
                    {
                        TableId = tableId,
                        StaffId = _currentUser.Id,
                        CreatedAt = DateTime.Now,
                        Discount = 0,
                        VAT = 10,
                        TotalAmount = 0
                    };

                    table.Status = "Serving";
                    _context.Orders.Add(_currentOrder);
                    _context.SaveChanges();
                }
            }

            LoadOrderDetails();
            CalculateTotal();
        }

        // ===== LOAD CHI TIẾT ĐƠN HÀNG =====
        private void LoadOrderDetails()
        {
            dtgvHoaDon.Rows.Clear();

            if (_currentOrder == null) return;

            dtgvHoaDon.Columns.Clear();
            dtgvHoaDon.Columns.Add("ProductName", "Tên món");
            dtgvHoaDon.Columns.Add("Quantity", "SL");
            dtgvHoaDon.Columns.Add("UnitPrice", "Đơn giá");
            dtgvHoaDon.Columns.Add("Total", "Thành tiền");
            dtgvHoaDon.Columns[1].Width = 50;

            foreach (var detail in _currentOrder.OrderDetails)
            {
                int rowIndex = dtgvHoaDon.Rows.Add();
                var row = dtgvHoaDon.Rows[rowIndex];

                row.Cells["ProductName"].Value = detail.Product.Name;
                row.Cells["Quantity"].Value = detail.Quantity;
                row.Cells["UnitPrice"].Value = detail.UnitPrice.ToString("N0") + " ₫";
                row.Cells["Total"].Value = (detail.Quantity * detail.UnitPrice).ToString("N0") + " ₫";
                row.Tag = detail; // Lưu object OrderDetail
            }
        }

        // ===== THÊM MÓN VÀO ĐƠN =====
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (_selectedTableId == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtgvDoUong.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dtgvDoUong.SelectedRows[0];
            var product = selectedRow.Tag as Product;

            if (product == null) return;

            int quantity = (int)nmSoLuong.Value;

            // Kiểm tra món đã có trong order chưa
            var existingDetail = _currentOrder?.OrderDetails
                .FirstOrDefault(od => od.ProductId == product.Id);

            if (existingDetail != null)
            {
                // Cộng thêm số lượng
                existingDetail.Quantity += quantity;
            }
            else
            {
                // Thêm món mới
                var newDetail = new OrderDetail
                {
                    OrderId = _currentOrder!.Id,
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Note = ""
                };

                _context.OrderDetails.Add(newDetail);
                _currentOrder.OrderDetails.Add(newDetail);
            }

            _context.SaveChanges();
            LoadOrderDetails();
            CalculateTotal();

            // Reset số lượng
            nmSoLuong.Value = 1;
        }

        // ===== XÓA MÓN KHỎI ĐƠN =====
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Xác nhận xóa món này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedRow = dtgvHoaDon.SelectedRows[0];
                var detail = selectedRow.Tag as OrderDetail;

                if (detail != null)
                {
                    _context.OrderDetails.Remove(detail);
                    _currentOrder?.OrderDetails.Remove(detail);
                    _context.SaveChanges();

                    LoadOrderDetails();
                    CalculateTotal();
                }
            }
        }

        // ===== TÍNH TỔNG TIỀN =====
        private void CalculateTotal()
        {
            if (_currentOrder == null)
            {
                lblTongTien.Text = "0 VNĐ";
                return;
            }

            decimal subTotal = _currentOrder.OrderDetails.Sum(od => od.Quantity * od.UnitPrice);
            decimal discountAmount = subTotal * _currentOrder.Discount / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * _currentOrder.VAT / 100;
            decimal total = afterDiscount + vatAmount;

            _currentOrder.TotalAmount = total;
            _context.SaveChanges();

            lblTongTien.Text = total.ToString("N0") + " VNĐ";
        }

        // ===== THANH TOÁN =====
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (_currentOrder == null || !_currentOrder.OrderDetails.Any())
            {
                MessageBox.Show("Chưa có món nào trong đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmMsg = $"Xác nhận thanh toán?\n\n" +
                            $"Bàn: {btnBanDaChon.Text}\n" +
                            $"Tổng tiền: {lblTongTien.Text}\n" +
                            $"Ngày: {dtNgayOrder.Value:dd/MM/yyyy HH:mm}";

            var result = MessageBox.Show(confirmMsg, "Thanh toán",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Cập nhật trạng thái bàn
                var table = _context.Tables.Find(_selectedTableId);
                if (table != null)
                {
                    table.Status = "Closed";
                }

                _context.SaveChanges();

                MessageBox.Show("Thanh toán thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                _selectedTableId = 0;
                _currentOrder = null;
                btnBanDaChon.Text = "Chưa chọn bàn";
                dtgvHoaDon.Rows.Clear();
                lblTongTien.Text = "0 VNĐ";

                LoadTables(); // Refresh danh sách bàn
            }
        }

        // ===== TÌM KIẾM ĐỒ UỐNG =====
        private void BtnTim_Click(object sender, EventArgs e)
        {
            LoadProducts(txtTenDoUong.Text);
        }

        // ===== ĐĂNG XUẤT =====
        private void BtnDX_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
                var loginForm = new FormLogin();
                loginForm.ShowDialog();

                if (loginForm.LoggedInUser != null)
                {
                    Program.CurrentUser = loginForm.LoggedInUser;
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // ===== CẬP NHẬT THÔNG TIN USER =====
        private void UpdateUserInfo()
        {
            this.Text = $"Phần mềm quản lý quán cafe - {_currentUser.Username} ({_currentUser.Role})";
        }

        // ===== EVENT HANDLERS TỪ DESIGNER =====

        // Quản lý nhân viên
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền Admin
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới có quyền quản lý nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formEmployee = new FormEmployee();
            formEmployee.ShowDialog();
            UpdateUserInfo();
        }

        // Menu Danh mục
        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Empty - menu cha
        }

        // Menu Loại đồ uống
        private void menuLDU_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới có quyền quản lý loại đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var typeDrinkForm = new DrinkForm.TypeDrink();
                typeDrinkForm.ShowDialog();
                LoadProducts(); // Refresh danh sách đồ uống sau khi đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý loại đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Đồ uống - Mở FormProductManagement
        private void menuDoUong_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới có quyền quản lý đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var formDrink = new DrinkForm.FormMain();
                formDrink.ShowDialog();
                LoadProducts(); // Refresh danh sách đồ uống sau khi đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý đồ uống:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Bàn
        private void menuBan_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới có quyền quản lý bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var formTable = new TableForm.TableForm();
                formTable.ShowDialog();
                LoadTables(); // Refresh danh sách bàn sau khi đóng form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý bàn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Quản lý kho
        private void menuKho_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement FormInventory
                MessageBox.Show("Form quản lý kho đang được phát triển!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // var formInventory = new FormInventory();
                // formInventory.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý kho:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Thông tin cá nhân
        private void menuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            try
            {
                var formInformation = new FormInformation();
                formInformation.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở thông tin cá nhân:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Khách hàng
        private void menuKH_Click(object sender, EventArgs e)
        {
            try
            {
                var formCustomer = new MemberForm.CustomerForm();
                formCustomer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý khách hàng:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Thống kê doanh thu theo ngày
        private void menuDoanhThuNgay_Click(object sender, EventArgs e)
        {
            try
            {
                var formRevenue = new ReportForm.RevenueEDay();
                formRevenue.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở báo cáo:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Thống kê doanh thu theo nhân viên
        private void menuThongKeDoanhThuNV_Click(object sender, EventArgs e)
        {
            try
            {
                var formRevenueEmployee = new ReportForm.RevenueEmployee();
                formRevenueEmployee.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở báo cáo:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Menu Lịch sử hóa đơn
        private void menuLichSuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                var formHistory = new ReportForm.ReportForm();
                formHistory.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở lịch sử hóa đơn:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvDoUong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void listViewBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
