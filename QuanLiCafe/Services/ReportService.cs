using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public class ReportService : IReportService
    {
        private readonly CafeContext _context;

        public ReportService(CafeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Doanh thu theo ngày
        /// LINQ: GroupBy, Sum, OrderBy
        /// </summary>
        public Dictionary<DateTime, decimal> GetRevenueByDate(DateTime fromDate, DateTime toDate)
        {
            return _context.Orders
                .Where(o => o.CreatedAt >= fromDate && o.CreatedAt <= toDate)
                .GroupBy(o => o.CreatedAt.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount)
                })
                .OrderBy(x => x.Date)
                .ToDictionary(x => x.Date, x => x.Revenue);
        }

        /// <summary>
        /// Doanh thu theo tháng
        /// LINQ: Where, GroupBy, Sum
        /// </summary>
        public Dictionary<string, decimal> GetRevenueByMonth(int year)
        {
            return _context.Orders
                .Where(o => o.CreatedAt.Year == year)
                .GroupBy(o => o.CreatedAt.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Revenue = g.Sum(o => o.TotalAmount)
                })
                .OrderBy(x => x.Month)
                .ToDictionary(
                    x => $"Tháng {x.Month}/{year}",
                    x => x.Revenue
                );
        }

        /// <summary>
        /// Top N s?n ph?m bán ch?y
        /// LINQ: Include, SelectMany, GroupBy, OrderByDescending, Take
        /// </summary>
        public List<ProductSalesReport> GetTopSellingProducts(int top = 5)
        {
            return _context.OrderDetails
                .Include(od => od.Product)
                .GroupBy(od => new
                {
                    od.ProductId,
                    od.Product.Name
                })
                .Select(g => new ProductSalesReport
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.Name,
                    TotalQuantity = g.Sum(od => od.Quantity),
                    TotalRevenue = g.Sum(od => od.Quantity * od.UnitPrice),
                    OrderCount = g.Select(od => od.OrderId).Distinct().Count()
                })
                .OrderByDescending(p => p.TotalQuantity)
                .Take(top)
                .ToList();
        }

        /// <summary>
        /// Doanh thu theo nhân viên
        /// LINQ: Include, Where, GroupBy, Select
        /// </summary>
        public List<StaffRevenueReport> GetRevenueByStaff(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var query = _context.Orders
                .Include(o => o.Staff)
                .AsQueryable();

            if (fromDate.HasValue)
                query = query.Where(o => o.CreatedAt >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(o => o.CreatedAt <= toDate.Value);

            return query
                .GroupBy(o => new
                {
                    o.StaffId,
                    o.Staff.Username
                })
                .Select(g => new StaffRevenueReport
                {
                    StaffId = g.Key.StaffId,
                    StaffName = g.Key.Username,
                    TotalOrders = g.Count(),
                    TotalRevenue = g.Sum(o => o.TotalAmount),
                    AverageOrderValue = g.Average(o => o.TotalAmount)
                })
                .OrderByDescending(s => s.TotalRevenue)
                .ToList();
        }

        /// <summary>
        /// T?ng doanh thu trong kho?ng th?i gian
        /// LINQ: Where, Sum
        /// </summary>
        public decimal GetTotalRevenue(DateTime fromDate, DateTime toDate)
        {
            return _context.Orders
                .Where(o => o.CreatedAt >= fromDate && o.CreatedAt <= toDate)
                .Sum(o => o.TotalAmount);
        }

        /// <summary>
        /// S? l??ng ??n hàng trong kho?ng th?i gian
        /// LINQ: Where, Count
        /// </summary>
        public int GetTotalOrders(DateTime fromDate, DateTime toDate)
        {
            return _context.Orders
                .Where(o => o.CreatedAt >= fromDate && o.CreatedAt <= toDate)
                .Count();
        }
    }
}
