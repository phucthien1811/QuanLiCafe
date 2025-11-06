using QuanLiCafe.Data;
using QuanLiCafe.Models;
using QuanLiCafe.Services;

namespace QuanLiCafe.Services
{
    public interface IPaymentService
    {
        /// <summary>
        /// X? lý thanh toán: Tính t?ng, l?u DB, c?p nh?t tr?ng thái bàn
        /// </summary>
        void ProcessPayment(int orderId, decimal discountPercent, decimal vatPercent);

        /// <summary>
        /// Xu?t hóa ??n PDF
        /// </summary>
        string ExportInvoiceToPDF(int orderId, string outputPath);

        /// <summary>
        /// Xu?t hóa ??n Excel
        /// </summary>
        string ExportInvoiceToExcel(int orderId, string outputPath);
    }
}
