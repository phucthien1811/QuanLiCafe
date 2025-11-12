# ?? H??NG D?N TÍCH H?P THANH TOÁN MOMO

## ?? M?C L?C
1. [T?ng Quan](#t?ng-quan)
2. [Cài ??t](#cài-??t)
3. [C?u Trúc Code](#c?u-trúc-code)
4. [S? D?ng](#s?-d?ng)
5. [Demo](#demo)
6. [L?u Ý](#l?u-ý)

---

## ?? T?NG QUAN

### Ch?c N?ng ?ã Tích H?p:
? **MoMo Sandbox API** - Môi tr??ng test thanh toán  
? **FormMoMoDemo** - Form demo v?i s?n ph?m m?u  
? **Tích h?p vào FormOrder** - Thanh toán MoMo cho ??n hàng th?c  
? **T? ??ng t?o QR Code** - MoMo API tr? v? link có QR  
? **T? ??ng m? trình duy?t** - Hi?n th? trang thanh toán  

### Thông Tin MoMo Sandbox:
```csharp
Endpoint    : https://test-payment.momo.vn/v2/gateway/api/create
PartnerCode : MOMO
AccessKey   : F8BBA842ECF85
SecretKey   : K951B6PE1waDMi640xX08PD3vg6EkVlz
```

?? **L?u ý:** ?ây là thông tin test công khai c?a MoMo, không c?n ??ng ký tài kho?n.

---

## ?? CÀI ??T

### 1. Package ?ã cài:
```bash
dotnet add package Newtonsoft.Json
```

### 2. Files ?ã t?o:
```
QuanLiCafe/
??? Services/
?   ??? IMoMoPaymentService.cs        # Interface
?   ??? MoMoPaymentService.cs         # Implementation
?
??? Forms/
    ??? FormMoMoDemo.cs               # Form demo ??c l?p
    ??? FormOrder.cs                  # Updated - thêm nút MoMo
    ??? FormMain.cs                   # Updated - thêm button demo
```

---

## ??? C?U TRÚC CODE

### A. **IMoMoPaymentService.cs**
```csharp
public interface IMoMoPaymentService
{
    /// <summary>
    /// T?o link thanh toán MoMo cho Order
    /// </summary>
    Task<string> CreatePaymentUrl(int orderId);

    /// <summary>
    /// T?o link thanh toán v?i s? ti?n tùy ch?nh
    /// </summary>
    Task<string> CreatePaymentUrl(decimal amount, string orderInfo);
}
```

### B. **MoMoPaymentService.cs**

**Lu?ng x? lý:**
1. Nh?n `orderId` ho?c `amount` + `orderInfo`
2. Tính t?ng ti?n (SubTotal - Discount + VAT)
3. T?o `signature` b?ng HMAC-SHA256
4. G?i POST request ??n MoMo API
5. Parse JSON response
6. Tr? v? `payUrl` (ch?a QR code)

**Code chính:**
```csharp
public async Task<string> CreatePaymentUrl(int orderId)
{
    var order = await _context.Orders
        .Include(o => o.Table)
        .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
        .FirstOrDefaultAsync(o => o.Id == orderId);

    // Tính t?ng ti?n
    decimal total = /* công th?c tính */;
    long amountInVND = (long)Math.Round(total);
    
    string orderInfo = $"Thanh toán {order.Table.Name} - Order #{orderId}";
    return await CreatePaymentUrl(amountInVND, orderInfo);
}

public async Task<string> CreatePaymentUrl(decimal amount, string orderInfo)
{
    // T?o signature
    string rawHash = $"accessKey={_accessKey}&amount={amount}&...";
    string signature = CreateSignature(rawHash, _secretKey);
    
    // Request body
    var requestBody = new {
        partnerCode = _partnerCode,
        accessKey = _accessKey,
        amount = amount.ToString(),
        orderId = DateTime.Now.Ticks.ToString(),
        orderInfo = orderInfo,
        signature = signature,
        // ...
    };
    
    // G?i request
    var response = await httpClient.PostAsync(_endpoint, content);
    dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
    
    if (jsonResponse.resultCode == 0)
        return jsonResponse.payUrl;
    else
        throw new Exception($"MoMo API Error: {jsonResponse.message}");
}

private string CreateSignature(string text, string key)
{
    using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
    {
        byte[] hashValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
        return BitConverter.ToString(hashValue).Replace("-", "").ToLower();
    }
}
```

---

## ?? S? D?NG

### 1. **Demo Form (FormMoMoDemo)**

**Cách m?:**
- Trong `FormMain`, click nút **"Thanh Toán v?i MOMO"** (button1)

**Ch?c n?ng:**
- 5 s?n ph?m demo có s?n:
  - Cà Phê ?en - 25,000 ?
  - Cà Phê S?a - 30,000 ?
  - Trà S?a Truy?n Th?ng - 35,000 ?
  - Sinh T? B? - 40,000 ?
  - Bánh Mì Tr?ng - 20,000 ?

**Các b??c:**
1. Click s?n ph?m trong danh sách
2. Nh?p s? l??ng
3. Click **"? THÊM VÀO GI?"**
4. L?p l?i cho các s?n ph?m khác
5. Nh?p % Gi?m giá, % VAT (m?c ??nh 0% và 10%)
6. Click **"?? THANH TOÁN QUA MOMO"**
7. Xác nh?n ? Trình duy?t t? m?
8. Quét QR b?ng app MoMo test

**Giao di?n:**
```
??????????????????????????????????????????????????????????????
?          ?? DEMO THANH TOÁN MOMO                          ?
??????????????????????????????????????????????????????????????
?  ?? S?N PH?M M?U    ?      ?? GI? HÀNG                    ?
?  ???????????????    ?  ???????????????????????????????   ?
?  ? Cà Phê ?en  ?    ?  ? S?n Ph?m ? SL ? ??n Giá ?...?   ?
?  ? Cà Phê S?a  ?    ?  ???????????????????????????????   ?
?  ? Trà S?a     ?    ?  ? Cà Phê   ?  2 ? 25,000  ?...?   ?
?  ? Sinh T? B?  ?    ?  ???????????????????????????????   ?
?  ? Bánh Mì     ?    ?                                     ?
?  ???????????????    ?  ?? THANH TOÁN                     ?
?                     ?  Gi?m Giá: [ 0 ] %                 ?
?  S? L??ng: [1]      ?  VAT:      [10] %                  ?
?  ? THÊM VÀO GI?   ?                                     ?
?  ??? XÓA KH?I GI?   ?  T?m tính:     80,000 ?            ?
?  ?? XÓA T?T C?      ?  Gi?m giá:      -8,000 ?           ?
?                     ?  VAT:           +7,200 ?           ?
?                     ?  ??????????????????????            ?
?                     ?  T?NG C?NG: 79,200 ?               ?
?                     ?                                     ?
?                     ?  [?? THANH TOÁN QUA MOMO]          ?
??????????????????????????????????????????????????????????????
```

---

### 2. **Tích H?p Trong FormOrder**

**V? trí nút:**
- D??i cùng c?a FormOrder, bên ph?i nút "?? THANH TOÁN TI?N M?T"

**Lu?ng ho?t ??ng:**
```
1. Nhân viên ch?n bàn ? FormOrder m?
2. Thêm món vào ??n
3. Nh?p Gi?m giá, VAT
4. Click "?? THANH TOÁN MOMO"
   ?
5. Xác nh?n dialog
   ?
6. L?u OrderDetails vào DB
   ?
7. G?i _momoService.CreatePaymentUrl(orderId)
   ?
8. MoMo API tr? v? payUrl
   ?
9. M? trình duy?t ? Hi?n th? QR
   ?
10. C?p nh?t Table.Status = "Closed"
   ?
11. ?óng FormOrder
```

**Code handler:**
```csharp
private async void BtnPayWithMoMo_Click(object? sender, EventArgs e)
{
    // Validate gi? hàng
    if (!_orderDetails.Any()) { ... return; }
    
    // Tính t?ng
    decimal total = /* công th?c */;
    
    // Xác nh?n
    var result = MessageBox.Show(confirmMsg, ...);
    if (result == DialogResult.Yes)
    {
        try
        {
            // L?u OrderDetails
            _context.OrderDetails.Add(...);
            _context.SaveChanges();
            
            // G?i MoMo API
            string payUrl = await _momoService.CreatePaymentUrl(_currentOrder.Id);
            
            // M? trình duy?t
            Process.Start(new ProcessStartInfo { FileName = payUrl, ... });
            
            // C?p nh?t bàn
            table.Status = "Closed";
            _context.SaveChanges();
            
            this.Close();
        }
        catch (Exception ex) { ... }
    }
}
```

---

## ?? DEMO - K?CH B?N S? D?NG

### **Scenario 1: Demo Form**

**B??c 1:** Ch?y ?ng d?ng ? Login
```
Username: admin
Password: admin123
```

**B??c 2:** Click nút "Thanh Toán v?i MOMO" trong FormMain

**B??c 3:** Thêm s?n ph?m vào gi?
- Double-click "Cà Phê ?en" ? T? ??ng thêm x1
- Ch?n "Sinh T? B?", s? l??ng = 2 ? Click "? THÊM VÀO GI?"
- Gi? hàng: 2 s?n ph?m, t?ng = 105,000 ?

**B??c 4:** ?i?u ch?nh gi?m giá
- Nh?p Gi?m giá: 10%
- VAT: 10% (m?c ??nh)
- T?ng c?ng: 103,950 ?

**B??c 5:** Click "?? THANH TOÁN QUA MOMO"

**B??c 6:** Dialog xác nh?n hi?n ra:
```
??????????????????????????????
   ?? XÁC NH?N THANH TOÁN MOMO
??????????????????????????????

?? S?n ph?m: 2 món
????????????????????????????
• Cà Phê ?en x1
• Sinh T? B? x2
????????????????????????????
T?m tính:     105,000 ?
Gi?m giá (10%): -10,500 ?
VAT (10%):      +9,450 ?
????????????????????????????
?? T?NG C?NG: 103,950 ?

Xác nh?n thanh toán qua MoMo?
[Yes] [No]
```

**B??c 7:** Click Yes ? Trình duy?t t? m?

**B??c 8:** Trang MoMo hi?n th?:
- Thông tin ??n hàng
- QR Code
- S? ti?n: 103,950 ?
- H??ng d?n quét mã

**B??c 9:** Dialog thông báo:
```
? ?Ã T?O LINK THANH TOÁN MOMO THÀNH CÔNG!

?? Trình duy?t s? t? ??ng m? trang thanh toán MoMo.

?? Quét mã QR b?ng app MoMo ?? thanh toán test.

?? S? ti?n: 103,950 ?
[OK]
```

**B??c 10:** Gi? hàng t? ??ng reset

---

### **Scenario 2: Thanh Toán Order Th?c**

**B??c 1:** FormMain ? Click bàn "Table 5"

**B??c 2:** FormOrder m? ? Thêm món
- Ch?n Category "Cà Phê"
- Double-click "Cappuccino" x2
- Ch?n Category "Bánh"
- Thêm "Tiramisu" x1

**B??c 3:** Nh?p Gi?m giá 5%, VAT 10%

**B??c 4:** Click "?? THANH TOÁN MOMO" (thay vì Ti?n M?t)

**B??c 5:** Xác nh?n ? MoMo API ???c g?i

**B??c 6:** Trình duy?t m? ? Quét QR

**B??c 7:** Bàn 5 chuy?n sang "Closed"

**B??c 8:** FormOrder ?óng ? FormMain refresh

---

## ?? L?U Ý QUAN TR?NG

### 1. **Môi Tr??ng Test**
- ?ây là **MoMo Sandbox**, không ph?i production
- Không giao d?ch ti?n th?t
- Ch? dùng ?? test tích h?p API

### 2. **App MoMo Test**
- C?n cài app MoMo test ?? quét mã
- Link download: https://developers.momo.vn/docs/sdk/test-app/
- Ho?c dùng trình duy?t ?? xem QR

### 3. **X? Lý Callback**
- Hi?n t?i ch?a x? lý IPN (Instant Payment Notification)
- returnUrl và notifyUrl ?ang dùng dummy: "https://momo.vn"
- Trong production c?n implement endpoint nh?n callback

### 4. **Security**
- SecretKey hi?n ?ang hardcode trong code
- Production nên l?u trong:
  - `appsettings.json` (Development)
  - Azure Key Vault (Production)
  - Environment Variables

### 5. **Error Handling**
```csharp
try
{
    string payUrl = await _momoService.CreatePaymentUrl(orderId);
}
catch (HttpRequestException ex)
{
    // L?i k?t n?i m?ng
}
catch (JsonException ex)
{
    // L?i parse JSON
}
catch (Exception ex)
{
    // L?i chung
}
```

### 6. **Testing Checklist**
- [ ] Internet connection working?
- [ ] MoMo API endpoint reachable?
- [ ] Signature calculation correct?
- [ ] Amount > 0 and valid?
- [ ] OrderInfo không quá dài?
- [ ] Browser can open payUrl?

---

## ?? SECURITY BEST PRACTICES

### 1. **Không Hardcode Credentials**
```csharp
// ? BAD
private readonly string _secretKey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";

// ? GOOD
private readonly string _secretKey = Configuration["MoMo:SecretKey"];
```

### 2. **Validate Input**
```csharp
if (amount <= 0)
    throw new ArgumentException("Amount must be greater than 0");

if (string.IsNullOrWhiteSpace(orderInfo))
    throw new ArgumentException("OrderInfo is required");
```

### 3. **Log Transactions**
```csharp
_logger.LogInformation($"MoMo Payment Created: OrderId={orderId}, Amount={amount}");
```

---

## ?? K?T QU? DEMO

### **Console Log (ví d?):**
```
[INFO] ?ang t?o link thanh toán MoMo...
[INFO] OrderId: 638734812345678900
[INFO] Amount: 103950
[INFO] Signature: a7b3c9d8e2f1...
[INFO] Sending request to MoMo API...
[INFO] Response: {"resultCode":0,"message":"Success","payUrl":"https://..."}
[INFO] PayUrl created successfully
[INFO] Opening browser...
```

### **MoMo API Response:**
```json
{
  "partnerCode": "MOMO",
  "orderId": "638734812345678900",
  "requestId": "638734812345678900",
  "amount": 103950,
  "responseTime": 1699999999999,
  "message": "Success",
  "resultCode": 0,
  "payUrl": "https://test-payment.momo.vn/gw_payment/qr/...",
  "deeplink": "momo://app...",
  "qrCodeUrl": "https://test-payment.momo.vn/qr/..."
}
```

---

## ?? TÀI LI?U THAM KH?O

1. **MoMo Developer Docs:**  
   https://developers.momo.vn/docs/payment/api/wallet

2. **Newtonsoft.Json Docs:**  
   https://www.newtonsoft.com/json/help/html/Introduction.htm

3. **HMAC-SHA256 Algorithm:**  
   https://en.wikipedia.org/wiki/HMAC

4. **C# HttpClient Best Practices:**  
   https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines

---

## ? CHECKLIST TRI?N KHAI

### **?ã hoàn thành:**
- [x] Cài package Newtonsoft.Json
- [x] T?o IMoMoPaymentService interface
- [x] Implement MoMoPaymentService
- [x] T?o FormMoMoDemo v?i 5 s?n ph?m m?u
- [x] Tích h?p vào FormOrder
- [x] Thêm nút demo vào FormMain
- [x] HMAC-SHA256 signature
- [x] Async/await cho API call
- [x] Exception handling
- [x] T? ??ng m? trình duy?t
- [x] Build successful

### **N?u mu?n nâng cao:**
- [ ] Implement IPN callback endpoint
- [ ] L?u transaction log vào database
- [ ] Thêm model `MoMoTransaction`
- [ ] Migrate SecretKey vào appsettings.json
- [ ] Unit tests cho MoMoPaymentService
- [ ] Retry logic khi API fail
- [ ] Timeout configuration

---

## ?? K?T LU?N

**?ã tích h?p thành công MoMo Payment vào QuanLiCafe!**

? **FormMoMoDemo:** Demo ??c l?p v?i s?n ph?m m?u  
? **FormOrder:** Thanh toán MoMo cho ??n hàng th?c  
? **MoMoPaymentService:** Service x? lý API  
? **Build:** Successful, không l?i  

**Cách test:**
1. Ch?y ?ng d?ng (F5)
2. Click "Thanh Toán v?i MOMO" trong FormMain
3. Thêm s?n ph?m ? Click thanh toán
4. Xác nh?n ? Trình duy?t t? m?
5. Quét QR b?ng app MoMo test

**Happy Coding!** ??
