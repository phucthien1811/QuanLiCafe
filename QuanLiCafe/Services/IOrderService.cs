using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// L?y order ?ang ho?t ??ng (ch?a thanh toán) c?a bàn
        /// </summary>
        Order? GetActiveOrderByTable(int tableId);

        /// <summary>
        /// Thêm món vào order. N?u ?ã có thì t?ng s? l??ng
        /// </summary>
        void AddItem(int orderId, int productId, int quantity, string? note = null);

        /// <summary>
        /// C?p nh?t s? l??ng và ghi chú c?a món
        /// </summary>
        void UpdateItem(int detailId, int quantity, string? note = null);

        /// <summary>
        /// Xóa món kh?i order
        /// </summary>
        void RemoveItem(int detailId);

        /// <summary>
        /// Tính l?i t?ng ti?n c?a order
        /// </summary>
        void RecalcOrderTotals(int orderId, decimal discountPercent, decimal vatPercent);

        /// <summary>
        /// Chuy?n order sang bàn khác
        /// </summary>
        void MoveTable(int orderId, int toTableId);

        /// <summary>
        /// G?p 2 order l?i v?i nhau
        /// </summary>
        void MergeTables(int fromOrderId, int toOrderId);

        /// <summary>
        /// L?y danh sách món trong order
        /// </summary>
        List<OrderDetail> GetOrderDetails(int orderId);

        /// <summary>
        /// T?o order m?i cho bàn
        /// </summary>
        Order CreateOrder(int tableId, int staffId);
    }
}
