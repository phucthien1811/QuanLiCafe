using Microsoft.EntityFrameworkCore;
using QuanLiCafe.Data;
using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly CafeContext _context;

        public InventoryService(CafeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// L?y t?t c? nguyên li?u - LINQ
        /// </summary>
        public List<Inventory> GetAllInventories()
        {
            return _context.Inventories
                .OrderBy(i => i.MaterialName)
                .ToList();
        }

        /// <summary>
        /// L?y nguyên li?u theo ID - LINQ
        /// </summary>
        public Inventory? GetInventoryById(int id)
        {
            return _context.Inventories.Find(id);
        }

        /// <summary>
        /// Nh?p kho: C?p nh?t Quantity + Ghi ImportHistory
        /// LINQ: FirstOrDefault, Add, SaveChanges
        /// </summary>
        public void ImportStock(int materialId, decimal quantity, decimal cost)
        {
            if (quantity <= 0)
                throw new ArgumentException("S? l??ng nh?p ph?i l?n h?n 0");

            if (cost < 0)
                throw new ArgumentException("Giá nh?p không ???c âm");

            // L?y nguyên li?u
            var inventory = _context.Inventories.Find(materialId);
            if (inventory == null)
                throw new InvalidOperationException($"Nguyên li?u ID {materialId} không t?n t?i");

            // C?ng s? l??ng
            inventory.Quantity += quantity;

            // Ghi l?ch s? nh?p kho
            var importHistory = new ImportHistory
            {
                MaterialId = materialId,
                Quantity = quantity,
                Cost = cost,
                ImportedAt = DateTime.Now
            };
            _context.ImportHistories.Add(importHistory);

            _context.SaveChanges();

            // Log
            Console.WriteLine($"? Nh?p kho thành công: {inventory.MaterialName} +{quantity} {inventory.Unit}");
            Console.WriteLine($"   T?n kho hi?n t?i: {inventory.Quantity} {inventory.Unit}");
        }

        /// <summary>
        /// L?y l?ch s? nh?p kho theo materialId - LINQ
        /// </summary>
        public List<ImportHistory> GetImportHistory(int materialId)
        {
            return _context.ImportHistories
                .Include(ih => ih.Material)
                .Where(ih => ih.MaterialId == materialId)
                .OrderByDescending(ih => ih.ImportedAt)
                .ToList();
        }

        /// <summary>
        /// L?y nguyên li?u d??i m?c t?n kho t?i thi?u - LINQ
        /// </summary>
        public List<Inventory> GetLowStockItems()
        {
            return _context.Inventories
                .Where(i => i.Quantity < i.ReorderLevel)
                .OrderBy(i => i.Quantity)
                .ToList();
        }

        /// <summary>
        /// Thêm nguyên li?u m?i - LINQ
        /// </summary>
        public void AddInventory(string materialName, string unit, decimal quantity, decimal reorderLevel)
        {
            if (string.IsNullOrWhiteSpace(materialName))
                throw new ArgumentException("Tên nguyên li?u không ???c ?? tr?ng");

            if (string.IsNullOrWhiteSpace(unit))
                throw new ArgumentException("??n v? không ???c ?? tr?ng");

            // Ki?m tra trùng tên
            var existing = _context.Inventories
                .FirstOrDefault(i => i.MaterialName.ToLower() == materialName.ToLower());

            if (existing != null)
                throw new InvalidOperationException($"Nguyên li?u '{materialName}' ?ã t?n t?i");

            var inventory = new Inventory
            {
                MaterialName = materialName,
                Unit = unit,
                Quantity = quantity,
                ReorderLevel = reorderLevel
            };

            _context.Inventories.Add(inventory);
            _context.SaveChanges();
        }

        /// <summary>
        /// C?p nh?t nguyên li?u - LINQ
        /// </summary>
        public void UpdateInventory(int id, string materialName, string unit, decimal reorderLevel)
        {
            var inventory = _context.Inventories.Find(id);
            if (inventory == null)
                throw new InvalidOperationException($"Nguyên li?u ID {id} không t?n t?i");

            inventory.MaterialName = materialName;
            inventory.Unit = unit;
            inventory.ReorderLevel = reorderLevel;

            _context.SaveChanges();
        }
    }
}
