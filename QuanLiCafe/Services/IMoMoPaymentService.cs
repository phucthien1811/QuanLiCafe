using System.Threading.Tasks;

namespace QuanLiCafe.Services
{
    /// <summary>
    /// Interface cho MoMo Payment Service
    /// </summary>
    public interface IMoMoPaymentService
    {
        /// <summary>
        /// T?o link thanh toán MoMo cho Order
        /// </summary>
        /// <param name="orderId">ID c?a Order</param>
        /// <returns>URL thanh toán MoMo</returns>
        Task<string> CreatePaymentUrl(int orderId);

        /// <summary>
        /// T?o link thanh toán MoMo v?i s? ti?n tùy ch?nh
        /// </summary>
        /// <param name="amount">S? ti?n thanh toán</param>
        /// <param name="orderInfo">Thông tin ??n hàng</param>
        /// <returns>URL thanh toán MoMo</returns>
        Task<string> CreatePaymentUrl(decimal amount, string orderInfo);
    }
}
