using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuanLiCafe.Data;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCafe.Services
{
    /// <summary>
    /// Service x? lý thanh toán qua MoMo Sandbox
    /// </summary>
    public class MoMoPaymentService : IMoMoPaymentService
    {
        private readonly CafeContext _context;
        private readonly string _endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
        private readonly string _partnerCode = "MOMO";
        private readonly string _accessKey = "F8BBA842ECF85";
        private readonly string _secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";
        private readonly string _returnUrl = "https://momo.vn/return";
        private readonly string _notifyUrl = "https://momo.vn/notify";

        public MoMoPaymentService(CafeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// T?o link thanh toán MoMo cho Order
        /// </summary>
        public async Task<string> CreatePaymentUrl(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.Table)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new Exception($"Không tìm th?y Order #{orderId}");

            // Tính t?ng ti?n
            decimal subTotal = 0;
            foreach (var detail in order.OrderDetails)
            {
                subTotal += detail.Quantity * detail.UnitPrice;
            }

            decimal discountAmount = subTotal * order.Discount / 100;
            decimal afterDiscount = subTotal - discountAmount;
            decimal vatAmount = afterDiscount * order.VAT / 100;
            decimal totalAmount = afterDiscount + vatAmount;

            // Làm tròn và chuy?n sang VND (không có ph?n th?p phân)
            long amountInVND = (long)Math.Round(totalAmount);

            string orderInfo = $"Thanh toán {order.Table.Name} - Order #{orderId}";

            return await CreatePaymentUrl(amountInVND, orderInfo);
        }

        /// <summary>
        /// T?o link thanh toán MoMo v?i s? ti?n tùy ch?nh
        /// </summary>
        public async Task<string> CreatePaymentUrl(decimal amount, string orderInfo)
        {
            long amountInVND = (long)Math.Round(amount);
            string orderId = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string amountStr = amountInVND.ToString();

            // T?o signature theo MoMo API v2
            string rawHash = $"accessKey={_accessKey}&amount={amountStr}&extraData=&ipnUrl={_notifyUrl}&orderId={orderId}&orderInfo={orderInfo}&partnerCode={_partnerCode}&redirectUrl={_returnUrl}&requestId={requestId}&requestType=captureWallet";
            string signature = CreateSignature(rawHash, _secretKey);

            // T?o request body
            var requestBody = new
            {
                partnerCode = _partnerCode,
                accessKey = _accessKey,
                requestId = requestId,
                amount = amountStr,
                orderId = orderId,
                orderInfo = orderInfo,
                redirectUrl = _returnUrl,
                ipnUrl = _notifyUrl,
                extraData = "",
                requestType = "captureWallet",
                signature = signature,
                lang = "vi"
            };

            // G?i request ??n MoMo
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(
                    JsonConvert.SerializeObject(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await httpClient.PostAsync(_endpoint, content);
                var responseString = await response.Content.ReadAsStringAsync();

                // Parse response
                dynamic? jsonResponse = JsonConvert.DeserializeObject(responseString);
                
                if (jsonResponse == null)
                    throw new Exception("Không nh?n ???c ph?n h?i t? MoMo");

                int resultCode = jsonResponse.resultCode;
                
                if (resultCode == 0)
                {
                    string payUrl = jsonResponse.payUrl;
                    return payUrl;
                }
                else
                {
                    string message = jsonResponse.message;
                    throw new Exception($"MoMo API Error: {message} (Code: {resultCode})");
                }
            }
        }

        /// <summary>
        /// T?o HMAC-SHA256 signature
        /// </summary>
        private string CreateSignature(string text, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashValue).Replace("-", "").ToLower();
            }
        }
    }
}
