using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;
using Xunit;

namespace QuanLiCafe.Tests
{
    public class OrderServiceTests : IDisposable
    {
        private readonly CafeContext _context;
        private readonly OrderService _service;

        public OrderServiceTests()
        {
            // T?o In-Memory database cho m?i test
            var options = new DbContextOptionsBuilder<CafeContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new CafeContext(options);
            _service = new OrderService(_context);

            // Seed d? li?u test
            SeedTestData();
        }

        private void SeedTestData()
        {
            // Users
            _context.Users.AddRange(
                new User { Id = 1, Username = "admin", PasswordHash = "hash1", Role = "Admin" },
                new User { Id = 2, Username = "staff", PasswordHash = "hash2", Role = "Staff" }
            );

            // Tables
            _context.Tables.AddRange(
                new Table { Id = 1, Name = "Bàn 1", Status = "Free" },
                new Table { Id = 2, Name = "Bàn 2", Status = "Free" },
                new Table { Id = 3, Name = "Bàn 3", Status = "Serving" }
            );

            // Categories
            _context.Categories.AddRange(
                new Category { Id = 1, Name = "Cà phê" },
                new Category { Id = 2, Name = "Trà s?a" }
            );

            // Products
            _context.Products.AddRange(
                new Product { Id = 1, Name = "Cà phê ?en", Price = 25000, CategoryId = 1 },
                new Product { Id = 2, Name = "Cà phê s?a", Price = 30000, CategoryId = 1 },
                new Product { Id = 3, Name = "B?c x?u", Price = 28000, CategoryId = 1 },
                new Product { Id = 4, Name = "Trà s?a trân châu", Price = 35000, CategoryId = 2 }
            );

            // Inventory (Nguyên li?u Generic)
            _context.Inventories.Add(
                new Inventory
                {
                    Id = 1,
                    MaterialName = "Generic",
                    Unit = "??n v?",
                    Quantity = 1000,
                    ReorderLevel = 100
                }
            );

            _context.SaveChanges();
        }

        [Fact]
        public void AddItem_NewProduct_ShouldAddToOrder()
        {
            // Arrange: T?o order m?i
            var order = _service.CreateOrder(tableId: 1, staffId: 1);

            // Act: Thêm món vào order
            _service.AddItem(order.Id, productId: 1, quantity: 2, note: "Ít ???ng");

            // Assert: Ki?m tra món ?ã ???c thêm
            var details = _service.GetOrderDetails(order.Id);
            Assert.Single(details);
            Assert.Equal(1, details[0].ProductId);
            Assert.Equal(2, details[0].Quantity);
            Assert.Equal(25000, details[0].UnitPrice);
            Assert.Equal("Ít ???ng", details[0].Note);

            // Ki?m tra t?n kho ?ã gi?m
            var inventory = _context.Inventories.First();
            Assert.Equal(998, inventory.Quantity); // 1000 - 2
        }

        [Fact]
        public void AddItem_ExistingProduct_ShouldIncreaseQuantity()
        {
            // Arrange
            var order = _service.CreateOrder(tableId: 1, staffId: 1);
            _service.AddItem(order.Id, productId: 1, quantity: 2);

            // Act: Thêm cùng món l?n n?a
            _service.AddItem(order.Id, productId: 1, quantity: 3);

            // Assert: S? l??ng ph?i c?ng d?n
            var details = _service.GetOrderDetails(order.Id);
            Assert.Single(details);
            Assert.Equal(5, details[0].Quantity); // 2 + 3

            // T?n kho: 1000 - 2 - 3 = 995
            var inventory = _context.Inventories.First();
            Assert.Equal(995, inventory.Quantity);
        }

        [Fact]
        public void AddItem_InsufficientInventory_ShouldThrowException()
        {
            // Arrange: Gi?m t?n kho xu?ng g?n h?t
            var inventory = _context.Inventories.First();
            inventory.Quantity = 5;
            _context.SaveChanges();

            var order = _service.CreateOrder(tableId: 1, staffId: 1);

            // Act & Assert: Thêm món v??t quá t?n kho ph?i báo l?i
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                _service.AddItem(order.Id, productId: 1, quantity: 10);
            });

            Assert.Contains("T?n kho", exception.Message);
            Assert.Contains("không ??", exception.Message);
        }

        [Fact]
        public void RecalcOrderTotals_ShouldCalculateCorrectly()
        {
            // Arrange: T?o order v?i 2 món
            var order = _service.CreateOrder(tableId: 1, staffId: 1);
            _service.AddItem(order.Id, productId: 1, quantity: 2); // 2 x 25,000 = 50,000
            _service.AddItem(order.Id, productId: 2, quantity: 1); // 1 x 30,000 = 30,000
                                                                   // SubTotal = 80,000

            // Act: Tính t?ng v?i gi?m giá 10% và VAT 10%
            _service.RecalcOrderTotals(order.Id, discountPercent: 10, vatPercent: 10);

            // Assert
            var updatedOrder = _context.Orders.Find(order.Id);
            Assert.NotNull(updatedOrder);
            Assert.Equal(10, updatedOrder.Discount);
            Assert.Equal(10, updatedOrder.VAT);

            // TotalAmount = (80,000 - 8,000) * 1.1 = 79,200
            Assert.Equal(79200, updatedOrder.TotalAmount);
        }

        [Fact]
        public void RecalcOrderTotals_NoDiscount_NoVAT()
        {
            // Arrange
            var order = _service.CreateOrder(tableId: 1, staffId: 1);
            _service.AddItem(order.Id, productId: 1, quantity: 2); // 50,000

            // Act
            _service.RecalcOrderTotals(order.Id, discountPercent: 0, vatPercent: 0);

            // Assert
            var updatedOrder = _context.Orders.Find(order.Id);
            Assert.Equal(50000, updatedOrder.TotalAmount);
        }

        [Fact]
        public void MergeTables_ShouldCombineOrders()
        {
            // Arrange: T?o 2 orders ? 2 bàn khác nhau
            var order1 = _service.CreateOrder(tableId: 1, staffId: 1);
            _service.AddItem(order1.Id, productId: 1, quantity: 2); // Cà phê ?en x2
            _service.AddItem(order1.Id, productId: 2, quantity: 1); // Cà phê s?a x1

            var order2 = _service.CreateOrder(tableId: 2, staffId: 1);
            _service.AddItem(order2.Id, productId: 1, quantity: 3); // Cà phê ?en x3 (trùng)
            _service.AddItem(order2.Id, productId: 3, quantity: 1); // B?c x?u x1 (m?i)

            // Act: G?p order1 vào order2
            _service.MergeTables(fromOrderId: order1.Id, toOrderId: order2.Id);

            // Assert
            // Order1 ph?i b? xóa
            var deletedOrder = _context.Orders.Find(order1.Id);
            Assert.Null(deletedOrder);

            // Bàn 1 ph?i v? Free
            var table1 = _context.Tables.Find(1);
            Assert.Equal("Free", table1!.Status);

            // Order2 ph?i có 3 món
            var details = _service.GetOrderDetails(order2.Id);
            Assert.Equal(3, details.Count);

            // Cà phê ?en ph?i c?ng d?n: 2 + 3 = 5
            var cafeDen = details.First(d => d.ProductId == 1);
            Assert.Equal(5, cafeDen.Quantity);

            // Cà phê s?a ph?i có: 1
            var cafeSua = details.First(d => d.ProductId == 2);
            Assert.Equal(1, cafeSua.Quantity);

            // B?c x?u ph?i có: 1
            var bacXiu = details.First(d => d.ProductId == 3);
            Assert.Equal(1, bacXiu.Quantity);
        }

        [Fact]
        public void MergeTables_ShouldRecalculateTotal()
        {
            // Arrange
            var order1 = _service.CreateOrder(tableId: 1, staffId: 1);
            _service.AddItem(order1.Id, productId: 1, quantity: 2); // 50,000

            var order2 = _service.CreateOrder(tableId: 2, staffId: 1);
            _service.AddItem(order2.Id, productId: 2, quantity: 1); // 30,000
            _service.RecalcOrderTotals(order2.Id, discountPercent: 10, vatPercent: 10);

            // Act: G?p
            _service.MergeTables(fromOrderId: order1.Id, toOrderId: order2.Id);

            // Assert: T?ng ti?n ph?i ???c tính l?i
            var mergedOrder = _context.Orders.Find(order2.Id);
            Assert.NotNull(mergedOrder);

            // SubTotal = 50,000 + 30,000 = 80,000
            // Discount 10% = -8,000
            // AfterDiscount = 72,000
            // VAT 10% = +7,200
            // Total = 79,200
            Assert.Equal(79200, mergedOrder.TotalAmount);
        }

        [Fact]
        public void MoveTable_ShouldUpdateTableStatus()
        {
            // Arrange
            var order = _service.CreateOrder(tableId: 1, staffId: 1);

            // Act: Chuy?n t? bàn 1 sang bàn 2
            _service.MoveTable(order.Id, toTableId: 2);

            // Assert
            var updatedOrder = _context.Orders.Find(order.Id);
            Assert.Equal(2, updatedOrder!.TableId);

            // Bàn 1 ph?i Free
            var table1 = _context.Tables.Find(1);
            Assert.Equal("Free", table1!.Status);

            // Bàn 2 ph?i Serving
            var table2 = _context.Tables.Find(2);
            Assert.Equal("Serving", table2!.Status);
        }

        [Fact]
        public void MoveTable_ToOccupiedTable_ShouldThrowException()
        {
            // Arrange: Bàn 3 ?ang Serving
            var order = _service.CreateOrder(tableId: 1, staffId: 1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                _service.MoveTable(order.Id, toTableId: 3);
            });

            Assert.Contains("không tr?ng", exception.Message);
        }

        [Fact]
        public void UpdateItem_ShouldChangeQuantityAndNote()
        {
            // Arrange
            var order = _service.CreateOrder(tableId: 1, staffId: 1);
            _service.AddItem(order.Id, productId: 1, quantity: 2, note: "Ghi chú c?");
            var details = _service.GetOrderDetails(order.Id);
            var detailId = details[0].Id;

            // Act
            _service.UpdateItem(detailId, quantity: 5, note: "Ghi chú m?i");

            // Assert
            var updatedDetail = _context.OrderDetails.Find(detailId);
            Assert.Equal(5, updatedDetail!.Quantity);
            Assert.Equal("Ghi chú m?i", updatedDetail.Note);
        }

        [Fact]
        public void RemoveItem_ShouldDeleteFromOrder()
        {
            // Arrange
            var order = _service.CreateOrder(tableId: 1, staffId: 1);
            _service.AddItem(order.Id, productId: 1, quantity: 2);
            _service.AddItem(order.Id, productId: 2, quantity: 1);
            var details = _service.GetOrderDetails(order.Id);
            var firstDetailId = details[0].Id;

            // Act
            _service.RemoveItem(firstDetailId);

            // Assert
            var remainingDetails = _service.GetOrderDetails(order.Id);
            Assert.Single(remainingDetails);
            Assert.NotEqual(firstDetailId, remainingDetails[0].Id);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
