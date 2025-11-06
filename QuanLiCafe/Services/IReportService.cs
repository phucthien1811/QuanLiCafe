using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public interface IReportService
    {
        /// <summary>
        /// Doanh thu theo ngày
        /// </summary>
        Dictionary<DateTime, decimal> GetRevenueByDate(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// Doanh thu theo tháng
        /// </summary>
        Dictionary<string, decimal> GetRevenueByMonth(int year);

        /// <summary>
        /// Top N s?n ph?m bán ch?y
        /// </summary>
        List<ProductSalesReport> GetTopSellingProducts(int top = 5);

        /// <summary>
        /// Doanh thu theo nhân viên
        /// </summary>
        List<StaffRevenueReport> GetRevenueByStaff(DateTime? fromDate = null, DateTime? toDate = null);

        /// <summary>
        /// T?ng doanh thu trong kho?ng th?i gian
        /// </summary>
        decimal GetTotalRevenue(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// S? l??ng ??n hàng trong kho?ng th?i gian
        /// </summary>
        int GetTotalOrders(DateTime fromDate, DateTime toDate);
    }

    // DTOs cho báo cáo
    public class ProductSalesReport
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int TotalQuantity { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; }
    }

    public class StaffRevenueReport
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageOrderValue { get; set; }
    }
}
