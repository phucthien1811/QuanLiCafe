using QuanLiCafe.Data;
using QuanLiCafe.Services;
using Microsoft.EntityFrameworkCore;

namespace QuanLiCafe.Demo
{
    /// <summary>
    /// Demo script ?? test OrderService
    /// </summary>
    public class OrderServiceDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("???????????????????????????????????????");
            Console.WriteLine("  ?? ORDER SERVICE DEMO");
            Console.WriteLine("???????????????????????????????????????\n");

            // Setup context
            var context = Program.DbContext;
            var service = new OrderService(context);

            try
            {
                Demo1_CreateOrderAndAddItems(service);
                Console.WriteLine("\n" + new string('?', 50) + "\n");

                Demo2_MergeTables(service);
                Console.WriteLine("\n" + new string('?', 50) + "\n");

                Demo3_MoveTable(service);
                Console.WriteLine("\n" + new string('?', 50) + "\n");

                Demo4_InventoryWarning(service);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n? L?I: {ex.Message}");
            }

            Console.WriteLine("\n???????????????????????????????????????");
            Console.WriteLine("  ? DEMO HOÀN T?T!");
            Console.WriteLine("???????????????????????????????????????");
        }

        static void Demo1_CreateOrderAndAddItems(OrderService service)
        {
            Console.WriteLine("?? DEMO 1: T?o Order và Thêm Món\n");

            // T?o order cho bàn 1
            var order = service.CreateOrder(tableId: 1, staffId: 1);
            Console.WriteLine($"? T?o order #{order.Id} cho Bàn 1");

            // Thêm món
            service.AddItem(order.Id, productId: 1, quantity: 2, note: "Ít ???ng");
            Console.WriteLine("  ? Thêm: Cà phê ?en x2 (Ít ???ng)");

            service.AddItem(order.Id, productId: 2, quantity: 1);
            Console.WriteLine("  ? Thêm: Cà phê s?a x1");

            // Thêm cùng món l?n n?a (c?ng d?n)
            service.AddItem(order.Id, productId: 1, quantity: 1);
            Console.WriteLine("  ? Thêm: Cà phê ?en x1 (c?ng d?n)");

            // Tính t?ng ti?n
            service.RecalcOrderTotals(order.Id, discountPercent: 10, vatPercent: 10);

            // Hi?n th? k?t qu?
            var details = service.GetOrderDetails(order.Id);
            Console.WriteLine("\n?? Chi ti?t ??n hàng:");
            foreach (var detail in details)
            {
                Console.WriteLine($"  - {detail.Product.Name} x{detail.Quantity} = {detail.Quantity * detail.UnitPrice:N0} ?");
            }

            var updatedOrder = Program.DbContext.Orders.Find(order.Id);
            Console.WriteLine($"\n?? T?ng ti?n: {updatedOrder!.TotalAmount:N0} ?");
            Console.WriteLine($"   (Gi?m giá: {updatedOrder.Discount}%, VAT: {updatedOrder.VAT}%)");
        }

        static void Demo2_MergeTables(OrderService service)
        {
            Console.WriteLine("?? DEMO 2: G?p Bàn\n");

            // T?o order cho bàn 2
            var order2 = service.CreateOrder(tableId: 2, staffId: 1);
            service.AddItem(order2.Id, productId: 1, quantity: 2); // Cà phê ?en x2
            service.AddItem(order2.Id, productId: 3, quantity: 1); // B?c x?u x1
            Console.WriteLine($"? Bàn 2 - Order #{order2.Id}:");
            Console.WriteLine("  - Cà phê ?en x2");
            Console.WriteLine("  - B?c x?u x1");

            // T?o order cho bàn 3
            var order3 = service.CreateOrder(tableId: 3, staffId: 1);
            service.AddItem(order3.Id, productId: 1, quantity: 1); // Cà phê ?en x1 (trùng)
            service.AddItem(order3.Id, productId: 4, quantity: 2); // Trà s?a x2
            Console.WriteLine($"\n? Bàn 3 - Order #{order3.Id}:");
            Console.WriteLine("  - Cà phê ?en x1");
            Console.WriteLine("  - Trà s?a trân châu x2");

            // G?p bàn 2 vào bàn 3
            Console.WriteLine($"\n?? G?p Bàn 2 ? Bàn 3...");
            service.MergeTables(fromOrderId: order2.Id, toOrderId: order3.Id);

            // Hi?n th? k?t qu?
            var mergedDetails = service.GetOrderDetails(order3.Id);
            Console.WriteLine($"\n?? K?t qu? Bàn 3 sau khi g?p:");
            foreach (var detail in mergedDetails)
            {
                Console.WriteLine($"  - {detail.Product.Name} x{detail.Quantity}");
            }

            var table2 = Program.DbContext.Tables.Find(2);
            Console.WriteLine($"\n? Bàn 2: {table2!.Status}");
        }

        static void Demo3_MoveTable(OrderService service)
        {
            Console.WriteLine("?? DEMO 3: Chuy?n Bàn\n");

            // T?o order cho bàn 4
            var order4 = service.CreateOrder(tableId: 4, staffId: 1);
            service.AddItem(order4.Id, productId: 1, quantity: 1);
            Console.WriteLine($"? T?o order cho Bàn 4");

            // Chuy?n sang bàn 5
            Console.WriteLine($"?? Chuy?n order t? Bàn 4 ? Bàn 5...");
            service.MoveTable(order4.Id, toTableId: 5);

            var table4 = Program.DbContext.Tables.Find(4);
            var table5 = Program.DbContext.Tables.Find(5);
            Console.WriteLine($"\n? Bàn 4: {table4!.Status}");
            Console.WriteLine($"? Bàn 5: {table5!.Status}");
        }

        static void Demo4_InventoryWarning(OrderService service)
        {
            Console.WriteLine("??  DEMO 4: C?nh Báo T?n Kho\n");

            // Gi?m t?n kho xu?ng th?p
            var inventory = Program.DbContext.Inventories.First();
            inventory.Quantity = 5;
            Program.DbContext.SaveChanges();
            Console.WriteLine($"?? T?n kho hi?n t?i: {inventory.Quantity} {inventory.Unit}");
            Console.WriteLine($"??  M?c t?i thi?u: {inventory.ReorderLevel} {inventory.Unit}\n");

            // T?o order và thêm món (s? c?nh báo)
            var order = service.CreateOrder(tableId: 6, staffId: 1);
            Console.WriteLine("? Thêm món (s? có c?nh báo t?n kho th?p)...");
            service.AddItem(order.Id, productId: 1, quantity: 2);

            var updatedInventory = Program.DbContext.Inventories.First();
            Console.WriteLine($"\n?? T?n kho sau khi thêm món: {updatedInventory.Quantity} {updatedInventory.Unit}");

            // Th? thêm v??t quá t?n kho
            Console.WriteLine("\n? Th? thêm món v??t quá t?n kho...");
            try
            {
                service.AddItem(order.Id, productId: 1, quantity: 10);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"??  Exception: {ex.Message}");
            }
        }
    }
}
