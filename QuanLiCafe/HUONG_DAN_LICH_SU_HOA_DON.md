# H??NG D?N S? D?NG - L?CH S? HÓA ??N BÁN HÀNG

## T?ng Quan
Module l?ch s? hóa ??n bán hàng cho phép xem chi ti?t t?ng dòng ?? u?ng ?ã bán trong kho?ng th?i gian và xu?t báo cáo.

---

## 1. M? Form L?ch S? Hóa ??n

### T? Form Main:
1. Click vào menu **"Th?ng kê"**
2. Ch?n **"L?ch s? hóa ??n"**
3. Form `ReportForm` (FormHistory) s? ???c m?

---

## 2. Giao Di?n Form

### Các thành ph?n chính:

#### A. B? l?c ngày:
- **T? ngày**: Ch?n ngày b?t ??u
- **??n ngày**: Ch?n ngày k?t thúc
- **Nút "L?c d? li?u"**: Áp d?ng b? l?c

#### B. DataGridView hi?n th?:
| C?t | Mô t? | Ví d? |
|-----|-------|-------|
| STT | S? th? t? | 1, 2, 3... |
| Ngày | Ngày gi? t?o ??n | 12/11/2024 14:30 |
| Mã Phi?u | ID c?a Order (hóa ??n) | 1, 2, 3... |
| Mã Phi?u Chi Ti?t | ID c?a OrderDetail | 1, 2, 3... |
| Mã Nhân Viên | ID + Username nhân viên | 1 - admin |
| Mã Khách Hàng | ID khách hàng (n?u có) | N/A |
| Mã ?? U?ng | ID c?a Product | 1, 2, 3... |
| Tên ?? U?ng | Tên s?n ph?m | Cà phê ?en, Trà s?a |

#### C. Thông tin t?ng h?p:
- **T?ng (X dòng)**: Hi?n th? s? dòng chi ti?t
- **T?ng ti?n**: T?ng ti?n c?a t?t c? các dòng

#### D. Các nút ch?c n?ng:
- **In báo cáo**: In báo cáo l?ch s?
- **Xu?t Excel**: Xu?t d? li?u ra file CSV

---

## 3. Các Tính N?ng

### 3.1. Xem L?ch S? Hóa ??n Hôm Nay (M?c ??nh)

Khi m? form, h? th?ng t? ??ng:
- Thi?t l?p **"T? ngày"** = Ngày hôm nay
- Thi?t l?p **"??n ngày"** = Ngày hôm nay
- Load và hi?n th? t?t c? chi ti?t ??n hàng trong ngày
- S?p x?p theo th?i gian m?i?c?

**Ví d?:**
```
Ngày: 12/11/2024

STT | Ngày            | Mã Phi?u | Chi Ti?t | NV        | ?? U?ng
----|-----------------|----------|----------|-----------|-------------
1   | 12/11 14:30     | 15       | 45       | 1-admin   | Cà phê ?en
2   | 12/11 14:30     | 15       | 46       | 1-admin   | Trà s?a
3   | 12/11 10:20     | 14       | 43       | 2-staff01 | B?c x?u
4   | 12/11 10:20     | 14       | 44       | 2-staff01 | Cà phê s?a

T?ng: 150,000 ?
```

---

### 3.2. Xem L?ch S? Theo Kho?ng Th?i Gian

**B??c 1:** Ch?n ngày b?t ??u
- Click vào DateTimePicker "T? ngày"
- Ch?n ngày mu?n xem

**B??c 2:** Ch?n ngày k?t thúc
- Click vào DateTimePicker "??n ngày"
- Ch?n ngày k?t thúc

**B??c 3:** L?c d? li?u
- Click nút **"L?c d? li?u"**
- H? th?ng s? load và hi?n th? d? li?u

**L?u ý:**
- Ngày b?t ??u không ???c l?n h?n ngày k?t thúc
- Hi?n th? **t?ng dòng chi ti?t** c?a ??n hàng (không group)
- M?i món trong ??n s? là 1 dòng riêng

**Ví d?:**
```
T? ngày: 01/11/2024
??n ngày: 12/11/2024

T?ng: 500 dòng chi ti?t
T?ng ti?n: 45,000,000 ?
```

---

### 3.3. Phân Tích L?ch S?

#### A. Theo ??n Hàng (Order)
```
??n #15 (12/11/2024 14:30):
- Dòng 1: Cà phê ?en
- Dòng 2: Trà s?a
- Dòng 3: Bánh ng?t

? 1 ??n có nhi?u dòng chi ti?t
```

#### B. Theo Nhân Viên
```
Nhân viên "admin":
- Ph?c v? ??n #15, #16, #17
- T?ng 10 dòng chi ti?t
- T?ng ti?n: 2,500,000 ?
```

#### C. Theo ?? U?ng
```
"Cà phê ?en":
- Xu?t hi?n 25 l?n trong l?ch s?
- T?ng ti?n: 625,000 ?
- ?? u?ng bán ch?y nh?t
```

---

### 3.4. In Báo Cáo

**B??c 1:** Load d? li?u mu?n in

**B??c 2:** Click nút **"In báo cáo"**

**N?i dung báo cáo:**
```
=== L?CH S? HÓA ??N BÁN HÀNG ===
T? ngày: 01/11/2024
??n ngày: 12/11/2024
T?ng s? dòng: 500
T?ng ti?n: 45,000,000 ?

Chi ti?t:

#1
Ngày: 12/11/2024 14:30
Mã phi?u: 15
Mã chi ti?t: 45
Nhân viên: 1 - admin
?? u?ng: Cà phê ?en (Mã: 1)

#2
Ngày: 12/11/2024 14:30
Mã phi?u: 15
Mã chi ti?t: 46
Nhân viên: 1 - admin
?? u?ng: Trà s?a (Mã: 4)

...
```

---

### 3.5. Xu?t CSV/Excel

**B??c 1:** Load d? li?u mu?n xu?t

**B??c 2:** Click nút **"Xu?t Excel"**

**B??c 3:** Ch?n v? trí l?u file
- Ch?n th? m?c
- ??t tên file (m?c ??nh: `LichSuHoaDon_ddMMyyyy_HHmmss.csv`)
- Click "Save"

**C?u trúc file CSV:**
```csv
STT,Ngày,Mã Phi?u,Mã Phi?u Chi Ti?t,Mã Nhân Viên,Mã Khách Hàng,Mã ?? U?ng,Tên ?? U?ng
1,"12/11/2024 14:30",15,45,"1 - admin","N/A",1,"Cà phê ?en"
2,"12/11/2024 14:30",15,46,"1 - admin","N/A",4,"Trà s?a"
3,"12/11/2024 10:20",14,43,"2 - staff01","N/A",3,"B?c x?u"

,,,,,,T?ng s? dòng:,500
,,,,,,T?ng ti?n:,"45,000,000 ?"
```

---

## 4. Logic X? Lý

### 4.1. Cách L?y D? Li?u

H? th?ng l?y d? li?u t? b?ng `OrderDetails`:
- Join v?i `Order` ?? l?y thông tin ??n hàng
- Join v?i `Staff` ?? l?y thông tin nhân viên
- Join v?i `Product` ?? l?y thông tin ?? u?ng
- Filter theo `Order.CreatedAt` trong kho?ng th?i gian
- S?p x?p theo `Order.CreatedAt` gi?m d?n (m?i nh?t lên ??u)

**Query LINQ:**
```csharp
var orderDetails = _context.OrderDetails
    .Include(od => od.Order)
        .ThenInclude(o => o.Staff)
    .Include(od => od.Product)
    .Where(od => od.Order.CreatedAt >= startDate 
                && od.Order.CreatedAt <= endDate
                && od.Order.TotalAmount > 0)
    .OrderByDescending(od => od.Order.CreatedAt)
    .ToList();
```

**SQL t??ng ???ng:**
```sql
SELECT 
    od.Id AS MaPhieuChiTiet,
    o.Id AS MaPhieu,
    o.CreatedAt AS Ngay,
    o.StaffId,
    s.Username AS TenNV,
    od.ProductId AS MaDoUong,
    p.Name AS TenDoUong,
    od.Quantity,
    od.UnitPrice,
    (od.Quantity * od.UnitPrice) AS ThanhTien
FROM OrderDetails od
INNER JOIN Orders o ON od.OrderId = o.Id
INNER JOIN Users s ON o.StaffId = s.Id
INNER JOIN Products p ON od.ProductId = p.Id
WHERE o.CreatedAt >= @StartDate 
  AND o.CreatedAt <= @EndDate
  AND o.TotalAmount > 0
ORDER BY o.CreatedAt DESC
```

### 4.2. Tính T?ng Ti?n

```csharp
decimal tongTien = 0;
foreach (var detail in orderDetails)
{
    decimal lineTotal = detail.Quantity * detail.UnitPrice;
    tongTien += lineTotal;
}
```

### 4.3. ??nh D?ng Hi?n Th?

- **Ngày gi?**: `dd/MM/yyyy HH:mm` (Ví d?: 12/11/2024 14:30)
- **Ti?n**: `N0 ?` (Ví d?: 150,000 ?)
- **Nhân viên**: `{Id} - {Username}` (Ví d?: 1 - admin)

---

## 5. So Sánh V?i Các Form Khác

| Tiêu chí | L?ch S? Hóa ??n | Doanh Thu Theo Ngày | Doanh Thu Theo NV |
|----------|-----------------|---------------------|-------------------|
| **??n v? hi?n th?** | Chi ti?t t?ng dòng | T?ng ??n hàng | T?ng h?p theo NV |
| **Group by** | Không group | Không group | Group theo StaffId |
| **M?c ?ích** | Xem chi ti?t món ?ã bán | Xem t?ng ??n theo ngày | ?ánh giá NV |
| **Thông tin chính** | Món, NV, Mã phi?u | S? món, T?ng ti?n | S? ??n, Doanh thu |

---

## 6. Use Cases & Ví D?

### Use Case 1: Ki?m Tra ??n Hàng C? Th?
```
Tình hu?ng: Khách hàng phàn nàn v? ??n #15

Cách làm:
1. M? form l?ch s?
2. Tìm các dòng có "Mã Phi?u" = 15
3. Xem chi ti?t:
   - Món gì ?ã order
   - Nhân viên nào ph?c v?
   - Th?i gian t?o ??n

K?t qu?: Phát hi?n thi?u 1 món ? Gi?i quy?t khi?u n?i
```

### Use Case 2: Xem Món Bán Ch?y
```
Tình hu?ng: Mu?n bi?t món nào bán nhi?u nh?t

Cách làm:
1. Xu?t CSV toàn b? tháng
2. Pivot/??m theo "Tên ?? U?ng"
3. S?p x?p gi?m d?n

K?t qu?: 
- Cà phê ?en: 200 l?n
- Trà s?a: 150 l?n
- B?c x?u: 120 l?n
```

### Use Case 3: Ki?m Tra Công Vi?c Nhân Viên
```
Tình hu?ng: Xem nhân viên làm vi?c gì trong ca

Cách làm:
1. L?c theo ngày/ca làm vi?c
2. Xem các dòng c?a nhân viên
3. ??m s? ??n ?ã ph?c v?

K?t qu?: ?ánh giá n?ng su?t làm vi?c
```

### Use Case 4: Phát Hi?n L?i D? Li?u
```
Tình hu?ng: Phát hi?n d? li?u b?t th??ng

Cách làm:
1. Xem l?ch s? chi ti?t
2. Tìm các dòng:
   - Giá 0 ??ng
   - S? l??ng âm
   - Th?i gian không h?p lý

K?t qu?: S?a l?i d? li?u, c?i thi?n quy trình
```

---

## 7. X? Lý L?i

### L?i 1: "Không có l?ch s? hóa ??n trong kho?ng th?i gian này!"
**Nguyên nhân:** 
- Không có ??n hàng nào
- T?t c? ??n ch?a thanh toán

**Gi?i pháp:**
- Ch?n kho?ng th?i gian khác
- Ki?m tra có ??n hàng ?ã hoàn thành ch?a

### L?i 2: "Ngày b?t ??u không ???c l?n h?n ngày k?t thúc!"
**Nguyên nhân:** Ch?n sai kho?ng th?i gian

**Gi?i pháp:** Ch?n l?i ngày cho ?úng

### L?i 3: "L?i t?i l?ch s? hóa ??n"
**Nguyên nhân:** L?i database ho?c query

**Gi?i pháp:**
1. Ki?m tra k?t n?i database
2. Ki?m tra log chi ti?t
3. Restart ?ng d?ng

---

## 8. Tips & Best Practices

### 8.1. Tìm Ki?m Nhanh

? **Nên:**
- S? d?ng Ctrl+F trong Excel sau khi xu?t
- Filter theo c?t c? th?
- L?u các báo cáo quan tr?ng

? **Không nên:**
- L?c quá nhi?u d? li?u cùng lúc (ch?m)
- Không backup d? li?u

### 8.2. Phân Tích D? Li?u

**?? ki?m tra ch?t l??ng:**
- Xem t? l? ??n hàng l?i
- Ki?m tra th?i gian ph?c v?
- Phát hi?n món bán ?

**?? t?i ?u kinh doanh:**
- Xác ??nh gi? cao ?i?m
- ?i?u ch?nh menu
- L?p k? ho?ch nhân s?

---

## 9. M? R?ng & C?i Ti?n

### 9.1. Thêm Filter Nâng Cao
```csharp
// Filter theo nhân viên
cmbNhanVien.DataSource = _context.Users.ToList();

// Filter theo ?? u?ng
cmbDoUong.DataSource = _context.Products.ToList();
```

### 9.2. Hi?n th? S? L??ng & Giá
```csharp
// Thêm c?t S? l??ng, ??n giá, Thành ti?n
dgv_HoaDon.Columns.Add("SoLuong", "S? l??ng");
dgv_HoaDon.Columns.Add("DonGia", "??n giá");
dgv_HoaDon.Columns.Add("ThanhTien", "Thành ti?n");
```

### 9.3. Thêm Ghi Chú
```csharp
// Hi?n th? OrderDetail.Note n?u có
row.Cells["GhiChu"].Value = detail.Note ?? "";
```

### 9.4. Export PDF
```csharp
// Xu?t báo cáo ??p h?n v?i iTextSharp
using iTextSharp.text;
using iTextSharp.text.pdf;
```

### 9.5. Tích H?p Khách Hàng
```csharp
// N?u Order có CustomerId
row.Cells["MaKH"].Value = order.CustomerId;
row.Cells["TenKH"].Value = order.Customer?.Name;
```

---

## 10. Database Schema

### B?ng Liên Quan:

```sql
-- Orders
Id, TableId, StaffId, CreatedAt, TotalAmount

-- OrderDetails
Id, OrderId, ProductId, Quantity, UnitPrice, Note

-- Users (Staff)
Id, Username, Role

-- Products
Id, Name, Price, CategoryId

-- Tables
Id, Name, Status
```

### Query T?i ?u:
```sql
-- Index ?? t?ng t?c query
CREATE INDEX IX_OrderDetails_OrderId 
ON OrderDetails(OrderId);

CREATE INDEX IX_Orders_CreatedAt 
ON Orders(CreatedAt);
```

---

## 11. Performance Tips

### V?i D? Li?u L?n (>10,000 dòng):
- S? d?ng pagination
- Gi?i h?n kho?ng th?i gian
- T?i ?u query v?i index
- Load theo batch

### Query Optimization:
```csharp
// Ch? l?y field c?n thi?t
.Select(od => new 
{ 
    od.Id, 
    od.Order.CreatedAt, 
    od.Order.StaffId,
    od.ProductId,
    od.Product.Name
})
```

---

## 12. Báo Cáo & Phân Tích

### 12.1. Th?ng Kê T?ng Quan
- T?ng s? ??n hàng
- T?ng s? món ?ã bán
- T?ng doanh thu
- Giá tr? ??n hàng trung bình

### 12.2. Top S?n Ph?m
```sql
SELECT ProductId, COUNT(*) AS SoLan
FROM OrderDetails
GROUP BY ProductId
ORDER BY SoLan DESC
LIMIT 10
```

### 12.3. Phân Tích Theo Gi?
```sql
SELECT DATEPART(HOUR, o.CreatedAt) AS Gio,
       COUNT(*) AS SoDon
FROM Orders o
GROUP BY DATEPART(HOUR, o.CreatedAt)
ORDER BY Gio
```

---

**Tác gi?:** GitHub Copilot  
**Ngày t?o:** 2024  
**Phiên b?n:** 1.0  
**Liên quan:** RevenueEDay, RevenueEmployee, FormMain
