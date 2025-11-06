using QuanLiCafe.Models;

namespace QuanLiCafe.Services
{
    public interface IInventoryService
    {
        /// <summary>
        /// L?y t?t c? nguyên li?u
        /// </summary>
        List<Inventory> GetAllInventories();

        /// <summary>
        /// L?y nguyên li?u theo ID
        /// </summary>
        Inventory? GetInventoryById(int id);

        /// <summary>
        /// Nh?p kho: C?p nh?t Quantity + Ghi ImportHistory
        /// </summary>
        void ImportStock(int materialId, decimal quantity, decimal cost);

        /// <summary>
        /// L?y l?ch s? nh?p kho theo materialId
        /// </summary>
        List<ImportHistory> GetImportHistory(int materialId);

        /// <summary>
        /// L?y nguyên li?u d??i m?c t?n kho t?i thi?u
        /// </summary>
        List<Inventory> GetLowStockItems();

        /// <summary>
        /// Thêm nguyên li?u m?i
        /// </summary>
        void AddInventory(string materialName, string unit, decimal quantity, decimal reorderLevel);

        /// <summary>
        /// C?p nh?t nguyên li?u
        /// </summary>
        void UpdateInventory(int id, string materialName, string unit, decimal reorderLevel);
    }
}
