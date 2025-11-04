using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public class OrderService : IOrderService
    {
        private readonly CafeContext _context;

        public OrderService(CafeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// L?y order ?ang ho?t ??ng (ch?a thanh toán) c?a bàn
        /// LINQ: Include, Where, OrderByDescending, FirstOrDefault
        /// </summary>
        public Order? GetActiveOrderByTable(int tableId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Table)
                .Include(o => o.Staff)
                .Where(o => o.TableId == tableId)
                .OrderByDescending(o => o.CreatedAt)
                .FirstOrDefault();
        }

        /// <summary>
        /// Thêm món vào order. N?u ?ã có thì t?ng s? l??ng
        /// </summary>
        public void AddItem(int orderId, int productId, int quantity, string? note = null)
        {
            // Ki?m tra order t?n t?i
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                throw new InvalidOperationException($"Order ID {orderId} không t?n t?i");

            // L?y thông tin s?n ph?m
            var product = _context.Products.Find(productId);
            if (product == null)
                throw new InvalidOperationException($"Product ID {productId} không t?n t?i");

            // Ki?m tra xem món ?ã có trong order ch?a
            var existingDetail = order.OrderDetails
                .FirstOrDefault(od => od.ProductId == productId);

            if (existingDetail != null)
            {
                // Món ?ã có ? C?p nh?t s? l??ng
                existingDetail.Quantity += quantity;
                existingDetail.UnitPrice = product.Price; // C?p nh?t giá m?i nh?t
                if (note != null)
                    existingDetail.Note = note;
            }
            else
            {
                // Món m?i ? Thêm vào OrderDetails
                var newDetail = new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                    UnitPrice = product.Price,
                    Note = note
                };
                _context.OrderDetails.Add(newDetail);
            }

            // ?? Tr? t?n kho (gi? ??nh: m?i s?n ph?m tr? 1 ??n v? "Generic")
            UpdateInventory(productId, quantity);

            _context.SaveChanges();
        }

        /// <summary>
        /// C?p nh?t s? l??ng và ghi chú c?a món
        /// </summary>
        public void UpdateItem(int detailId, int quantity, string? note = null)
        {
            var detail = _context.OrderDetails.Find(detailId);
            if (detail == null)
                throw new InvalidOperationException($"OrderDetail ID {detailId} không t?n t?i");

            detail.Quantity = quantity;
            if (note != null)
                detail.Note = note;

            _context.SaveChanges();
        }

        /// <summary>
        /// Xóa món kh?i order
        /// </summary>
        public void RemoveItem(int detailId)
        {
            var detail = _context.OrderDetails.Find(detailId);
            if (detail == null)
                throw new InvalidOperationException($"OrderDetail ID {detailId} không t?n t?i");

            _context.OrderDetails.Remove(detail);
            _context.SaveChanges();
        }

        /// <summary>
        /// Tính l?i t?ng ti?n c?a order
        /// Công th?c: TotalAmount = (sum SubTotal - discount) * (1 + VAT)
        /// </summary>
        public void RecalcOrderTotals(int orderId, decimal discountPercent, decimal vatPercent)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                throw new InvalidOperationException($"Order ID {orderId} không t?n t?i");

            // LINQ: Tính t?ng SubTotal
            decimal subTotal = order.OrderDetails
                .Sum(od => od.Quantity * od.UnitPrice);

            // Tính gi?m giá
            decimal discountAmount = subTotal * (discountPercent / 100);
            decimal afterDiscount = subTotal - discountAmount;

            // Tính VAT
            decimal vatAmount = afterDiscount * (vatPercent / 100);
            decimal total = afterDiscount + vatAmount;

            // C?p nh?t order
            order.Discount = discountPercent;
            order.VAT = vatPercent;
            order.TotalAmount = total;

            _context.SaveChanges();
        }

        /// <summary>
        /// Chuy?n order sang bàn khác (ch? khi bàn ?ích ?ang Free)
        /// </summary>
        public void MoveTable(int orderId, int toTableId)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null)
                throw new InvalidOperationException($"Order ID {orderId} không t?n t?i");

            var toTable = _context.Tables.Find(toTableId);
            if (toTable == null)
                throw new InvalidOperationException($"Table ID {toTableId} không t?n t?i");

            if (toTable.Status != "Free")
                throw new InvalidOperationException($"Bàn {toTable.Name} không tr?ng!");

            // L?y bàn c?
            var fromTable = _context.Tables.Find(order.TableId);

            // C?p nh?t order sang bàn m?i
            order.TableId = toTableId;

            // C?p nh?t tr?ng thái bàn
            if (fromTable != null)
                fromTable.Status = "Free";

            toTable.Status = "Serving";

            _context.SaveChanges();
        }

        /// <summary>
        /// G?p 2 order l?i v?i nhau
        /// LINQ: Include, Where, GroupBy, Sum
        /// </summary>
        public void MergeTables(int fromOrderId, int toOrderId)
        {
            // L?y c? 2 orders v?i OrderDetails
            var fromOrder = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == fromOrderId);

            var toOrder = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == toOrderId);

            if (fromOrder == null)
                throw new InvalidOperationException($"Order ID {fromOrderId} không t?n t?i");

            if (toOrder == null)
                throw new InvalidOperationException($"Order ID {toOrderId} không t?n t?i");

            // G?p OrderDetails
            foreach (var fromDetail in fromOrder.OrderDetails.ToList())
            {
                // Ki?m tra xem món ?ã có trong toOrder ch?a
                var existingDetail = toOrder.OrderDetails
                    .FirstOrDefault(od => od.ProductId == fromDetail.ProductId);

                if (existingDetail != null)
                {
                    // C?ng d?n s? l??ng
                    existingDetail.Quantity += fromDetail.Quantity;
                }
                else
                {
                    // Thêm món m?i vào toOrder
                    var newDetail = new OrderDetail
                    {
                        OrderId = toOrderId,
                        ProductId = fromDetail.ProductId,
                        Quantity = fromDetail.Quantity,
                        UnitPrice = fromDetail.UnitPrice,
                        Note = fromDetail.Note
                    };
                    _context.OrderDetails.Add(newDetail);
                }
            }

            // C?p nh?t tr?ng thái bàn c?
            var fromTable = _context.Tables.Find(fromOrder.TableId);
            if (fromTable != null)
                fromTable.Status = "Free";

            // Xóa fromOrder
            _context.Orders.Remove(fromOrder);

            _context.SaveChanges();

            // Tính l?i t?ng ti?n c?a toOrder
            RecalcOrderTotals(toOrderId, toOrder.Discount, toOrder.VAT);
        }

        /// <summary>
        /// L?y danh sách món trong order
        /// </summary>
        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return _context.OrderDetails
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .Where(od => od.OrderId == orderId)
                .OrderBy(od => od.Id)
                .ToList();
        }

        /// <summary>
        /// T?o order m?i cho bàn
        /// </summary>
        public Order CreateOrder(int tableId, int staffId)
        {
            var table = _context.Tables.Find(tableId);
            if (table == null)
                throw new InvalidOperationException($"Table ID {tableId} không t?n t?i");

            // Ki?m tra bàn ?ang tr?ng
            if (table.Status != "Free")
                throw new InvalidOperationException($"Bàn {table.Name} ?ang ???c s? d?ng!");

            var order = new Order
            {
                TableId = tableId,
                StaffId = staffId,
                CreatedAt = DateTime.Now,
                Discount = 0,
                VAT = 10,
                TotalAmount = 0
            };

            _context.Orders.Add(order);

            // C?p nh?t tr?ng thái bàn
            table.Status = "Serving";

            _context.SaveChanges();

            return order;
        }

        /// <summary>
        /// Tr? t?n kho (gi? ??nh: m?i s?n ph?m tr? 1 ??n v? "Generic")
        /// </summary>
        private void UpdateInventory(int productId, int quantity)
        {
            // Gi? ??nh: Tìm nguyên li?u "Generic" (ho?c t?o n?u ch?a có)
            var genericMaterial = _context.Inventories
                .FirstOrDefault(i => i.MaterialName == "Generic");

            if (genericMaterial == null)
            {
                // T?o nguyên li?u Generic
                genericMaterial = new Inventory
                {
                    MaterialName = "Generic",
                    Unit = "??n v?",
                    Quantity = 1000,
                    ReorderLevel = 100
                };
                _context.Inventories.Add(genericMaterial);
                _context.SaveChanges();
            }

            // Tr? t?n kho
            genericMaterial.Quantity -= quantity;

            // C?nh báo n?u t?n kho < 0
            if (genericMaterial.Quantity < 0)
            {
                throw new InvalidOperationException(
                    $"?? C?NH BÁO: T?n kho nguyên li?u '{genericMaterial.MaterialName}' " +
                    $"không ??! Hi?n t?i: {genericMaterial.Quantity} {genericMaterial.Unit}");
            }

            // C?nh báo n?u d??i m?c t?i thi?u
            if (genericMaterial.Quantity < genericMaterial.ReorderLevel)
            {
                Console.WriteLine(
                    $"?? C?NH BÁO: Nguyên li?u '{genericMaterial.MaterialName}' " +
                    $"d??i m?c t?n kho t?i thi?u! " +
                    $"({genericMaterial.Quantity}/{genericMaterial.ReorderLevel} {genericMaterial.Unit})");
            }
        }
    }
}
