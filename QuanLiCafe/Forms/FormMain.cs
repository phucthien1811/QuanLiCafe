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

            // Đăng ký sự kiện FormClosing để kiểm tra trước khi đóng
            this.FormClosing += FormMain_FormClosing;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // ===== XÓA TẤT CẢ BÀN ĐANG PHỤC VỤ KHI MỞ APP =====
            ResetAllServingTables();

            // Load dữ liệu ban đầu
            LoadTables();
            LoadProducts();
            UpdateUserInfo();

            // Set ngày hiện tại
            dtNgayOrder.Value = DateTime.Now;
            txtMaNV.Text = $"{_currentUser.Id} - {_currentUser.Username}";

            // Đặt mặc định là "Tất cả"
            rbTatCa.Checked = true;

            // Đăng ký sự kiện cho các radio button
            rbTatCa.CheckedChanged += RbFilter_CheckedChanged;
            rdDangphucvu.CheckedChanged += RbFilter_CheckedChanged;
            rbControng.CheckedChanged += RbFilter_CheckedChanged;

            // Đăng ký sự kiện click vào cell của DataGridView
            dtgvDoUong.CellClick += DtgvDoUong_CellClick;
        }

        // ===== RESET TẤT CẢ BÀN ĐANG PHỤC VỤ =====
        private void ResetAllServingTables()
        {
            try
            {
                // Tìm tất cả các bàn đang phục vụ
                var servingTables = _context.Tables
                    .Where(t => t.Status == "Serving")
                    .ToList();

                if (servingTables.Any())
                {
                    // Reset trạng thái bàn về Free
                    foreach (var table in servingTables)
                    {
                        table.Status = "Free";
                    }

                    // Xóa tất cả order details của các orders chưa thanh toán
                    var unpaidOrders = _context.Orders
                        .Include(o => o.OrderDetails)
                        .Where(o => servingTables.Select(t => t.Id).Contains(o.TableId))
                        .ToList();

                    foreach (var order in unpaidOrders)
                    {
                        _context.OrderDetails.RemoveRange(order.OrderDetails);
                        _context.Orders.Remove(order);
                    }

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi reset bàn khi khởi động:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== KIỂM TRA TRƯỚC KHI ĐÓNG FORM =====
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Kiểm tra có bàn nào đang phục vụ không
                var servingTables = _context.Tables
                    .Where(t => t.Status == "Serving")
                    .ToList();

                if (servingTables.Any())
                {
                    var tableNames = string.Join(", ", servingTables.Select(t => t.Name));
                    var result = MessageBox.Show(
                        $"Còn {servingTables.Count} bàn chưa thanh toán:\n{tableNames}\n\n" +
                        "Bạn có muốn xóa các đơn hàng này và reset bàn về trạng thái trống không?",
                        "Cảnh báo",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Cancel)
                    {
                        // Hủy đóng form
                        e.Cancel = true;
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        // Xóa tất cả orders và reset bàn
                        ResetAllServingTables();
                    }
                    // DialogResult.No: Đóng app mà không xóa (giữ nguyên dữ liệu)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra trước khi đóng:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== XỬ LÝ CLICK VÀO PRODUCT CARD =====
        private void DtgvDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dtgvDoUong.Rows[e.RowIndex];
                var product = row.Tag as Product;

                if (product == null) return;

                // Nếu click vào cột hình ảnh -> mở FormDetails
                if (e.ColumnIndex == dtgvDoUong.Columns["HinhAnh"].Index)
                {
                    OpenProductDetails(product);
                }
                else
                {
                    // Chọn row
                    row.Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý sự kiện click:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== MỞ FORM DETAILS CHỌN SIZE / TOPPING =====
        private void OpenProductDetails(Product product)
        {
            if (_selectedTableId == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var detailsForm = new Details(product);

                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    int quantity = detailsForm.Quantity;
                    decimal finalPrice = detailsForm.FinalPrice;
                    string note = detailsForm.Note;

                    // Nếu chưa có order -> tạo mới
                    if (_currentOrder == null)
                    {
                        var table = _context.Tables.Find(_selectedTableId);
                        if (table != null)
                        {
                            _currentOrder = new Order
                            {
                                TableId = _selectedTableId,
                                StaffId = _currentUser.Id,
                                CreatedAt = DateTime.Now,
                                Discount = 0,
                                TotalAmount = 0
                            };

                            table.Status = "Serving";
                            _context.Orders.Add(_currentOrder);
                            _context.SaveChanges();

                            RefreshTablesWithCurrentFilter();
                        }
                    }

                    // Thêm món vào order
                    var newDetail = new OrderDetail
                    {
                        OrderId = _currentOrder!.Id,
                        ProductId = product.Id,
                        Quantity = quantity,
                        UnitPrice = finalPrice / quantity,
                        Note = note
                    };

                    _context.OrderDetails.Add(newDetail);
                    // REMOVED: _currentOrder.OrderDetails.Add(newDetail);
                    // EF Core tự động cập nhật collection khi SaveChanges()
                    _context.SaveChanges();

                    // Reload order từ database để đảm bảo dữ liệu đồng bộ
                    LoadOrderForTable(_selectedTableId);

                    MessageBox.Show($"Đã thêm {quantity} x {product.Name}!",
                        "Thành công", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm món:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== LOAD DANH SÁCH BÀN =====
        private void LoadTables(string statusFilter = "")
        {
            listViewBan.Clear();
            listViewBan.View = View.LargeIcon;

            var query = _context.Tables.AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter))
            {
                query = query.Where(t => t.Status == statusFilter);
            }

            var tables = query.OrderBy(t => t.Id).ToList();

            foreach (var table in tables)
            {
                var item = new ListViewItem
                {
                    Text = table.Name,
                    Tag = table.Id,
                    ImageIndex = table.Status == "Free" ? 0 : 1
                };

                listViewBan.Items.Add(item);
            }

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

        // ===== XỬ LÝ RADIO FILTER =====
        private void RbFilter_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null || !rb.Checked) return;

            if (rb == rbTatCa)
            {
                LoadTables();
            }
            else if (rb == rdDangphucvu)
            {
                LoadTables("Serving");
            }
            else if (rb == rbControng)
            {
                LoadTables("Free");
            }
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

                dtgvDoUong.Rows.Clear();

                // Tăng chiều cao row cho giống card
                dtgvDoUong.RowTemplate.Height = 180;
                dtgvDoUong.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                // Cột ảnh
                HinhAnh.Width = 150;
                HinhAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;

                // Cột tên
                TenDoUong.Width = 250;
                TenDoUong.DefaultCellStyle.Font = new Font("Tahoma", 11F, FontStyle.Bold);

                // Cột giá
                GiaTien.Width = 150;
                GiaTien.DefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
                GiaTien.DefaultCellStyle.ForeColor = Color.Red;

                MaDoUong.Visible = false;

                foreach (var product in products)
                {
                    int rowIndex = dtgvDoUong.Rows.Add();
                    var row = dtgvDoUong.Rows[rowIndex];

                    // Load ảnh
                    if (!string.IsNullOrEmpty(product.ImageUrl) &&
                        System.IO.File.Exists(product.ImageUrl))
                    {
                        try
                        {
                            Image img = Image.FromFile(product.ImageUrl);
                            Image resized = new Bitmap(img, new Size(150, 150));
                            row.Cells["HinhAnh"].Value = resized;
                        }
                        catch
                        {
                            row.Cells["HinhAnh"].Value = null;
                        }
                    }

                    row.Cells["MaDoUong"].Value = product.Id;
                    row.Cells["TenDoUong"].Value = product.Name;
                    row.Cells["GiaTien"].Value = product.Price.ToString("N0") + " ₫";
                    row.Tag = product;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách đồ uống:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== LOAD ĐƠN HÀNG CỦA BÀN =====
        private void LoadOrderForTable(int tableId)
        {
            _currentOrder = _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Table)
                .Where(o => o.TableId == tableId && o.Table.Status == "Serving")
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefault();

            if (_currentOrder != null)
            {
                LoadOrderDetails();
                CalculateTotal();
            }
            else
            {
                dtgvHoaDon.Rows.Clear();
                lblTongTien.Text = "0 VNĐ";
            }
        }

        // ===== LOAD CHI TIẾT ĐƠN =====
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

                row.Tag = detail;
            }
        }

        // ===== REFRESH DANH SÁCH BÀN =====
        private void RefreshTablesWithCurrentFilter()
        {
            if (rbTatCa.Checked)
                LoadTables();
            else if (rdDangphucvu.Checked)
                LoadTables("Serving");
            else if (rbControng.Checked)
                LoadTables("Free");
        }

        // ===== THÊM MÓN =====
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

            // Nếu chưa có order → tạo và set Serving
            if (_currentOrder == null)
            {
                var table = _context.Tables.Find(_selectedTableId);
                if (table != null)
                {
                    _currentOrder = new Order
                    {
                        TableId = _selectedTableId,
                        StaffId = _currentUser.Id,
                        CreatedAt = DateTime.Now,
                        Discount = 0,
                        TotalAmount = 0
                    };

                    table.Status = "Serving";
                    _context.Orders.Add(_currentOrder);
                    _context.SaveChanges();

                    RefreshTablesWithCurrentFilter();
                }
            }

            // Kiểm tra món đã có chưa
            var existing = _currentOrder?.OrderDetails
                .FirstOrDefault(od => od.ProductId == product.Id);

            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                var newDetail = new OrderDetail
                {
                    OrderId = _currentOrder!.Id,
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Note = ""
                };

                _context.OrderDetails.Add(newDetail);
                // REMOVED: _currentOrder.OrderDetails.Add(newDetail);
                // EF Core tự động cập nhật collection khi SaveChanges()
            }

            _context.SaveChanges();

            // Reload order từ database để đảm bảo dữ liệu đồng bộ
            LoadOrderForTable(_selectedTableId);

            nmSoLuong.Value = 1;
        }

        // ===== XÓA MÓN =====
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Xác nhận xóa món này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            var selectedRow = dtgvHoaDon.SelectedRows[0];
            var detail = selectedRow.Tag as OrderDetail;

            if (detail != null)
            {
                _context.OrderDetails.Remove(detail);
                _currentOrder?.OrderDetails.Remove(detail);
                _context.SaveChanges();

                // Nếu hết món → bàn trở lại Free
                if (_currentOrder != null && !_currentOrder.OrderDetails.Any())
                {
                    var table = _context.Tables.Find(_selectedTableId);
                    if (table != null)
                    {
                        table.Status = "Free";

                        _context.Orders.Remove(_currentOrder);
                        _context.SaveChanges();

                        _currentOrder = null;
                        RefreshTablesWithCurrentFilter();
                    }
                }

                LoadOrderDetails();
                CalculateTotal();
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
            decimal total = subTotal - discountAmount;

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

            try
            {
                // Tính tổng tiền trước khi giảm giá
                decimal subtotal = _currentOrder.OrderDetails.Sum(od => od.Quantity * od.UnitPrice);

                // Mở form PaymentT để chọn phương thức thanh toán
                var paymentForm = new win.PaymentT(_currentOrder, subtotal);
                
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    // Thanh toán thành công
                    MessageBox.Show("Thanh toán thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    _selectedTableId = 0;
                    _currentOrder = null;
                    btnBanDaChon.Text = "Chưa chọn bàn";
                    dtgvHoaDon.Rows.Clear();
                    lblTongTien.Text = "0 VNĐ";

                    // Refresh danh sách bàn
                    RefreshTablesWithCurrentFilter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán:\n{ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== TÌM KIẾM SẢN PHẨM =====
        private void BtnTim_Click(object sender, EventArgs e)
        {
            LoadProducts(txtTenDoUong.Text);
        }

        // ===== ĐĂNG XUẤT =====
        private void BtnDX_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

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

        // ===== CẬP NHẬT THÔNG TIN USER =====
        private void UpdateUserInfo()
        {
            this.Text = $"Phần mềm quản lý cafe - {_currentUser.Username} ({_currentUser.Role})";
        }

        // ====== CÁC MENU ITEM ======

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới được quản lý nhân viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formEmployee = new FormEmployee();
            formEmployee.ShowDialog();
        }

        private void menuLDU_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới được quản lý loại đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var typeDrinkForm = new DrinkForm.TypeDrink();
                typeDrinkForm.ShowDialog();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý loại đồ uống:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDoUong_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới được quản lý đồ uống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var formDrink = new DrinkForm.FormMain();
                formDrink.ShowDialog();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý đồ uống:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuBan_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới được quản lý bàn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var formTable = new TableForm.TableForm();
                formTable.ShowDialog();
                RefreshTablesWithCurrentFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý bàn:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuKho_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng quản lý kho đang phát triển!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuToping_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới được quản lý topping!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var formToping = new FormToping();
                formToping.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý topping:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuThongTinCaNhan_Click(object sender, EventArgs e)
        {
            try
            {
                var formInformation = new FormInformation();
                formInformation.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở thông tin cá nhân:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuKH_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new MemberForm.CustomerForm();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở quản lý khách hàng:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuDoanhThuNgay_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new ReportForm.RevenueEDay();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở báo cáo doanh thu ngày:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuThongKeDoanhThuNV_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new ReportForm.RevenueEmployee();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở báo cáo doanh thu nhân viên:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuLichSuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new ReportForm.ReportForm();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở lịch sử hóa đơn:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gioiThieuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var formIntro = new Introduct();
                formIntro.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form giới thiệu:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Missing event handlers referenced in Designer
        private void listViewBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Already handled inline in LoadTables method
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Empty event handler for label2
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {
            // Empty event handler for lblTongTien
        }

        private void dtgvDoUong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Empty event handler - actual logic is in DtgvDoUong_CellClick
        }

        private void danhMucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Empty event handler for menu item
        }

        private void rbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            // Already handled in RbFilter_CheckedChanged
            RbFilter_CheckedChanged(sender, e);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_currentOrder == null || !_currentOrder.OrderDetails.Any())
            {
                MessageBox.Show("Chưa có hóa đơn để in!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Print logic here - for now just show message
                MessageBox.Show("Chức năng in hóa đơn đang được phát triển!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi in hóa đơn:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuTKSP_Click(object sender, EventArgs e)
        {
            try
            {
                var chartProductForm = new FormChartProduct();
                chartProductForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở biểu đồ thống kê sản phẩm:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
