using QuanLiCafe.Data;
using QuanLiCafe.Models;
using BCrypt.Net;

namespace QuanLiCafe.Helpers
{
    public static class DatabaseSeeder
    {
        public static void SeedDemoData(CafeContext context)
        {
            // 1. Update passwords to BCrypt
            UpdatePasswordsToBCrypt(context);

            // 2. Seed 50 random orders
            Seed50RandomOrders(context);

            context.SaveChanges();
        }

        private static void UpdatePasswordsToBCrypt(CafeContext context)
        {
            var admin = context.Users.FirstOrDefault(u => u.Username == "admin");
            if (admin != null)
            {
                admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123", workFactor: 12);
            }

            var staff = context.Users.FirstOrDefault(u => u.Username == "staff01");
            if (staff != null)
            {
                staff.PasswordHash = BCrypt.Net.BCrypt.HashPassword("staff123", workFactor: 12);
            }

            // Thêm thêm 2 staff ?? demo
            if (!context.Users.Any(u => u.Username == "staff02"))
            {
                context.Users.Add(new User
                {
                    Username = "staff02",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("staff123", workFactor: 12),
                    Role = "Staff"
                });
            }

            if (!context.Users.Any(u => u.Username == "staff03"))
            {
                context.Users.Add(new User
                {
                    Username = "staff03",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("staff123", workFactor: 12),
                    Role = "Staff"
                });
            }

            context.SaveChanges();
        }

        private static void Seed50RandomOrders(CafeContext context)
        {
            var random = new Random(42); // Fixed seed ?? reproducible

            var products = context.Products.ToList();
            var tables = context.Tables.ToList();
            var staffIds = context.Users.Select(u => u.Id).ToList();

            // L?y tháng hi?n t?i
            var today = DateTime.Now;
            var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

            // Xóa orders c? n?u có (?? ch?y l?i nhi?u l?n)
            var existingOrders = context.Orders
                .Where(o => o.CreatedAt >= firstDayOfMonth)
                .ToList();

            if (existingOrders.Count >= 50)
            {
                Console.WriteLine("?ã có 50+ orders trong tháng này. B? qua seed.");
                return;
            }

            Console.WriteLine($"Seeding {50 - existingOrders.Count} orders...");

            for (int i = existingOrders.Count; i < 50; i++)
            {
                // Random ngày trong tháng (1-30)
                var randomDay = random.Next(1, Math.Min(31, DateTime.DaysInMonth(today.Year, today.Month) + 1));
                var randomHour = random.Next(8, 22); // 8AM - 10PM
                var randomMinute = random.Next(0, 60);

                var orderDate = new DateTime(today.Year, today.Month, randomDay, randomHour, randomMinute, 0);

                // Random table và staff
                var tableId = tables[random.Next(tables.Count)].Id;
                var staffId = staffIds[random.Next(staffIds.Count)];

                // T?o order
                var order = new Order
                {
                    TableId = tableId,
                    StaffId = staffId,
                    CreatedAt = orderDate,
                    Discount = random.Next(0, 3) * 5, // 0%, 5%, 10%, 15%
                    TotalAmount = 0 // S? tính sau
                };

                context.Orders.Add(order);
                context.SaveChanges(); // Save ?? có Id

                // Random 1-4 món cho m?i order
                var numItems = random.Next(1, 5);
                decimal subTotal = 0;

                for (int j = 0; j < numItems; j++)
                {
                    var product = products[random.Next(products.Count)];
                    var quantity = random.Next(1, 4); // 1-3 món

                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = quantity,
                        UnitPrice = product.Price,
                        Note = random.Next(10) > 7 ? "Ít ???ng" : null
                    };

                    context.OrderDetails.Add(orderDetail);
                    subTotal += quantity * product.Price;
                }

                // Tính t?ng ti?n
                var discountAmount = subTotal * (order.Discount / 100);
                order.TotalAmount = subTotal - discountAmount;

                context.SaveChanges();
            }

            Console.WriteLine("? ?ã seed 50 orders ng?u nhiên trong tháng!");
        }
    }
}
