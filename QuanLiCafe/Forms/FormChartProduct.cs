using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using QuanLiCafe.Data;
using Microsoft.EntityFrameworkCore;

namespace QuanLiCafe.Forms
{
    public partial class FormChartProduct : Form
    {
        private readonly CafeContext _context;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProduct;

        public FormChartProduct()
        {
            InitializeComponent();
            _context = QuanLiCafe.Program.DbContext;
            
            // Tạo Chart control
            InitializeChart();
            
            // Đăng ký sự kiện
            this.Load += FormChartProduct_Load;
            dtpNam.ValueChanged += DtpNam_ValueChanged;
        }

        private void InitializeChart()
        {
            // Tạo Chart control mới với kích thước lớn hơn
            chartProduct = new System.Windows.Forms.DataVisualization.Charting.Chart
            {
                Location = new Point(20, 120),
                Size = new Size(760, 370),
                BackColor = Color.White
            };
            
            // Thêm Chart vào form
            this.Controls.Add(chartProduct);
            this.Controls.SetChildIndex(chartProduct, 0);
            
            // Ẩn FlowLayoutPanel
            flpbieudol1.Visible = false;
            
            // Tạo ChartArea
            var chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Sản phẩm";
            chartArea.AxisY.Title = "Số lượng bán";
            chartArea.AxisX.LabelStyle.Angle = -45; // Nghiêng label
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Font = new Font("Times New Roman", 9F);
            chartArea.AxisY.LabelStyle.Font = new Font("Times New Roman", 9F);
            
            // Tắt lưới dọc
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            
            // QUAN TRỌNG: Thiết lập để mỗi cột có vị trí riêng biệt
            chartArea.AxisX.IsMarginVisible = true;
            
            chartProduct.ChartAreas.Add(chartArea);
            
            // Tạo Series
            var series = new Series("Sản phẩm bán chạy")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "N0", // Format: 100, 200, 300...
                Font = new Font("Times New Roman", 10F, FontStyle.Bold),
                IsVisibleInLegend = false
            };
            
            // ĐIỀU CHỈNH ĐỘ RỘNG CỘT ĐỂ TRÁNH CHỒNG LẤP
            series["PointWidth"] = "0.5"; // 50% chiều rộng
            series["PixelPointWidth"] = "30"; // Tối đa 30 pixels
            
            chartProduct.Series.Add(series);
            
            // XÓA LEGEND
            chartProduct.Legends.Clear();
            
            // Tạo Title
            var title = new Title
            {
                Text = "TOP SẢN PHẨM BÁN CHẠY NHẤT",
                Font = new Font("Times New Roman", 14F, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };
            chartProduct.Titles.Add(title);
        }

        private void FormChartProduct_Load(object sender, EventArgs e)
        {
            dtpNam.Value = DateTime.Today;
            LoadProductData(dtpNam.Value.Year);
        }

        private void DtpNam_ValueChanged(object sender, EventArgs e)
        {
            LoadProductData(dtpNam.Value.Year);
        }

        private void LoadProductData(int year)
        {
            try
            {
                // Xóa dữ liệu cũ
                chartProduct.Series[0].Points.Clear();
                
                // LẤY TOP SẢN PHẨM BÁN CHẠY NHẤT TRONG NĂM
                var productSales = _context.OrderDetails
                    .Include(od => od.Order)
                    .Include(od => od.Product)
                    .Where(od => od.Order.CreatedAt.Year == year && od.Order.TotalAmount > 0)
                    .AsEnumerable() // Chuyển sang LINQ to Objects
                    .GroupBy(od => od.Product.Name) // GROUP BY tên sản phẩm
                    .Select(g => new
                    {
                        ProductName = g.Key,
                        TotalQuantity = g.Sum(od => od.Quantity)
                    })
                    .OrderByDescending(x => x.TotalQuantity)
                    .Take(5) // CHỈ LẤY TOP 5 ĐỂ CHART GỌN HƠN
                    .ToList();
                
                // Kiểm tra có dữ liệu không
                if (!productSales.Any())
                {
                    MessageBox.Show($"Không có dữ liệu bán hàng trong năm {year}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chartProduct.Titles[0].Text = $"KHÔNG CÓ DỮ LIỆU NĂM {year}";
                    return;
                }
                
                // Cập nhật tiêu đề
                chartProduct.Titles[0].Text = $"TOP 5 SẢN PHẨM BÁN CHẠY NHẤT NĂM {year}";
                
                // Cập nhật label2
                var totalQuantity = productSales.Sum(p => p.TotalQuantity);
                label2.Text = $"Biểu đồ thống kê sản phẩm bán chạy nhất năm {year} - Tổng: {totalQuantity} sản phẩm";
                
                // Màu sắc cho các cột (mỗi cột 1 màu)
                Color[] colors = new Color[]
                {
                    Color.FromArgb(255, 99, 132),   // Đỏ
                    Color.FromArgb(54, 162, 235),   // Xanh dương
                    Color.FromArgb(255, 206, 86),   // Vàng
                    Color.FromArgb(75, 192, 192),   // Xanh lá
                    Color.FromArgb(153, 102, 255)   // Tím
                };
                
                // THÊM DỮ LIỆU VÀO CHART - SỬ DỤNG INDEX ĐỂ TRÁNH TRÙNG LẶP
                int index = 0;
                foreach (var item in productSales)
                {
                    // Rút ngắn tên nếu quá dài
                    string displayName = item.ProductName.Length > 12 
                        ? item.ProductName.Substring(0, 10) + "..." 
                        : item.ProductName;
                    
                    // SỬ DỤNG INDEX THAY VÌ TÊN ĐỂ TRÁNH TRÙNG LẶP
                    int pointIndex = chartProduct.Series[0].Points.AddXY(
                        index, // Sử dụng index số: 0, 1, 2, 3, 4
                        item.TotalQuantity // Số lượng bán
                    );
                    
                    // Gán tên sản phẩm vào label
                    chartProduct.Series[0].Points[pointIndex].AxisLabel = displayName;
                    
                    // Gán màu cho mỗi cột
                    chartProduct.Series[0].Points[pointIndex].Color = colors[index % colors.Length];
                    
                    // Tooltip
                    chartProduct.Series[0].Points[pointIndex].ToolTip = 
                        $"Sản phẩm: {item.ProductName}\nSố lượng: {item.TotalQuantity}";
                    
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu biểu đồ:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
