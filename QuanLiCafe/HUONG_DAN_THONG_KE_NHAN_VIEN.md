# H??NG D?N S? D?NG - TH?NG KÊ DOANH THU THEO NHÂN VIÊN

## T?ng Quan
Module th?ng kê doanh thu theo nhân viên cho phép xem chi ti?t doanh thu c?a t?ng nhân viên trong kho?ng th?i gian và xu?t báo cáo.

---

## 1. M? Form Th?ng Kê Doanh Thu Theo Nhân Viên

### T? Form Main:
1. Click vào menu **"Th?ng kê"**
2. Ch?n **"Th?ng kê doanh thu theo nhân viên"**
3. Form `RevenueEmployee` s? ???c m?

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
| Mã nhân viên | ID c?a nhân viên | 1, 2, 3... |
| Tên nhân viên | Username c?a nhân viên | admin, staff01 |
| S? l??ng | S? ??n hàng - S? món | "25 ??n - 120 món" |
| Thành ti?n | T?ng doanh thu c?a nhân viên | 5,500,000 ? |

#### C. Thông tin t?ng h?p:
- **T?ng**: Hi?n th? t?ng doanh thu c?a t?t c? nhân viên

#### D. Các nút ch?c n?ng:
- **In báo cáo**: In báo cáo doanh thu
- **Xu?t Excel**: Xu?t d? li?u ra file CSV/Excel

---

## 3. Các Tính N?ng

### 3.1. Xem Doanh Thu Nhân Viên Hôm Nay (M?c ??nh)

Khi m? form, h? th?ng t? ??ng:
- Thi?t l?p **"T? ngày"** = Ngày hôm nay
- Thi?t l?p **"??n ngày"** = Ngày hôm nay
- Load và hi?n th? doanh thu c?a t?t c? nhân viên trong ngày
- S?p x?p theo doanh thu gi?m d?n (cao nh?t lên ??u)

**Ví d?:**
```
Ngày: 12/11/2024

STT | Mã NV | Tên NV   | S? l??ng        | Thành ti?n
----|-------|----------|-----------------|-------------
1   | 1     | admin    | 15 ??n - 60 món | 2,500,000 ?
2   | 2     | staff01  | 10 ??n - 40 món | 1,800,000 ?

T?ng: 4,300,000 ?
```

---

### 3.2. Xem Doanh Thu Theo Kho?ng Th?i Gian

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
- N?u không có d? li?u, h? th?ng s? hi?n th? thông báo
- D? li?u ???c group theo nhân viên (t?ng h?p t?t c? ??n c?a nhân viên)

**Ví d?:**
```
T? ngày: 01/11/2024
??n ngày: 12/11/2024

STT | Mã NV | Tên NV   | S? l??ng         | Thành ti?n
----|-------|----------|------------------|-------------
1   | 1     | admin    | 150 ??n - 600 món| 25,000,000 ?
2   | 2     | staff01  | 100 ??n - 400 món| 18,000,000 ?
3   | 3     | staff02  | 50 ??n - 200 món | 9,000,000 ?

T?ng: 52,000,000 ?
```

---

### 3.3. Phân Tích Hi?u Su?t Nhân Viên

D?a vào báo cáo, có th? ?ánh giá:

#### A. Top Nhân Viên
- Nhân viên có doanh thu cao nh?t
- Nhân viên ph?c v? nhi?u ??n nh?t
- Nhân viên bán nhi?u món nh?t

#### B. So Sánh Hi?u Su?t
```
Nhân viên A: 25,000,000 ? (150 ??n) = 166,667 ?/??n
Nhân viên B: 18,000,000 ? (100 ??n) = 180,000 ?/??n

? Nhân viên B có giá tr? ??n hàng trung bình cao h?n
```

#### C. ?ánh Giá Ch?t L??ng
- S? món/??n: ?ánh giá kh? n?ng upselling
- Doanh thu/??n: ?ánh giá giá tr? ??n hàng
- T?ng ??n: ?ánh giá n?ng su?t làm vi?c

---

### 3.4. In Báo Cáo

**B??c 1:** Load d? li?u mu?n in

**B??c 2:** Click nút **"In báo cáo"**

**N?i dung báo cáo:**
```
=== BÁO CÁO DOANH THU THEO NHÂN VIÊN ===
T? ngày: 01/11/2024
??n ngày: 12/11/2024
T?ng doanh thu: 52,000,000 ?
S? nhân viên: 3

Chi ti?t:

#1
Mã NV: 1
Tên NV: admin
S? l??ng: 150 ??n - 600 món
Doanh thu: 25,000,000 ?

#2
Mã NV: 2
Tên NV: staff01
S? l??ng: 100 ??n - 400 món
Doanh thu: 18,000,000 ?

#3
Mã NV: 3
Tên NV: staff02
S? l??ng: 50 ??n - 200 món
Doanh thu: 9,000,000 ?
```

---

### 3.5. Xu?t CSV/Excel

**B??c 1:** Load d? li?u mu?n xu?t

**B??c 2:** Click nút **"Xu?t Excel"**

**B??c 3:** Ch?n v? trí l?u file
- Ch?n th? m?c
- ??t tên file (m?c ??nh: `DoanhThuNhanVien_ddMMyyyy_HHmmss.csv`)
- Click "Save"

**C?u trúc file CSV:**
```csv
STT,Mã nhân viên,Tên nhân viên,S? l??ng,Thành ti?n
1,1,"admin","150 ??n - 600 món","25,000,000 ?"
2,2,"staff01","100 ??n - 400 món","18,000,000 ?"
3,3,"staff02","50 ??n - 200 món","9,000,000 ?"

,,,,
,,,T?ng doanh thu:,"52,000,000 ?"
,,,S? nhân viên:,3
```

---

## 4. Logic X? Lý

### 4.1. Cách Tính Doanh Thu Theo Nhân Viên

H? th?ng:
1. L?y t?t c? ??n hàng trong kho?ng th?i gian
2. Group theo `StaffId` (ID nhân viên)
3. Tính t?ng cho t?ng nhân viên:
   - S? ??n hàng: `Count()`
   - S? món: `Sum(OrderDetails.Quantity)`
   - T?ng ti?n: `Sum(TotalAmount)`
4. S?p x?p theo t?ng ti?n gi?m d?n

**Query LINQ:**
```csharp
var staffRevenue = _context.Orders
    .Include(o => o.OrderDetails)
    .Include(o => o.Staff)
    .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate 
                && o.TotalAmount > 0
                && o.OrderDetails.Any())
    .GroupBy(o => new { o.StaffId, o.Staff.Username })
    .Select(g => new
    {
        StaffId = g.Key.StaffId,
        StaffName = g.Key.Username,
        TotalOrders = g.Count(),
        TotalQuantity = g.Sum(o => o.OrderDetails.Sum(od => od.Quantity)),
        TotalRevenue = g.Sum(o => o.TotalAmount)
    })
    .OrderByDescending(s => s.TotalRevenue)
    .ToList();
```

**SQL t??ng ???ng:**
```sql
SELECT 
    s.Id AS StaffId,
    s.Username AS StaffName,
    COUNT(o.Id) AS TotalOrders,
    SUM(od.Quantity) AS TotalQuantity,
    SUM(o.TotalAmount) AS TotalRevenue
FROM Orders o
INNER JOIN Users s ON o.StaffId = s.Id
INNER JOIN OrderDetails od ON o.Id = od.OrderId
WHERE o.CreatedAt >= @StartDate 
  AND o.CreatedAt <= @EndDate
  AND o.TotalAmount > 0
GROUP BY s.Id, s.Username
ORDER BY TotalRevenue DESC
```

### 4.2. ??nh D?ng Hi?n Th?

- **S? l??ng**: `"{TotalOrders} ??n - {TotalQuantity} món"`
- **Ti?n**: `N0 ?` (Ví d?: 25,000,000 ?)
- **S?p x?p**: Theo doanh thu gi?m d?n

### 4.3. Tính T?ng Doanh Thu

```csharp
decimal tongDoanhThu = staffRevenue.Sum(s => s.TotalRevenue);
```

---

## 5. Use Cases & Ví D?

### Use Case 1: Xem Top Nhân Viên Tháng Này
```
Input:
- T? ngày: 01/11/2024
- ??n ngày: 30/11/2024
- Click "L?c d? li?u"

Output:
Danh sách nhân viên s?p x?p theo doanh thu cao?th?p

M?c ?ích: ?ánh giá hi?u su?t, th??ng nhân viên xu?t s?c
```

### Use Case 2: So Sánh 2 Nhân Viên
```
Input: Xem doanh thu cùng kho?ng th?i gian

Phân tích:
- Nhân viên A: 15 ??n, 3,000,000 ?
  ? Trung bình: 200,000 ?/??n
  
- Nhân viên B: 20 ??n, 3,200,000 ?
  ? Trung bình: 160,000 ?/??n

K?t lu?n:
- B ph?c v? nhi?u h?n
- A bán ???c giá tr? cao h?n/??n
```

### Use Case 3: Tìm Nhân Viên C?n ?ào T?o
```
Tiêu chí:
- Doanh thu th?p
- S? ??n ít
- Giá tr? ??n th?p

Action: ?ào t?o thêm v? k? n?ng bán hàng, menu
```

---

## 6. Báo Cáo & Phân Tích Nâng Cao

### 6.1. KPI (Key Performance Indicators)

#### Doanh Thu/Nhân Viên:
```
KPI = T?ng doanh thu / S? nhân viên
```

#### Hi?u Su?t Nhân Viên:
```
Hi?u su?t = (Doanh thu cá nhân / T?ng doanh thu) × 100%
```

#### Giá Tr? ??n Hàng Trung Bình:
```
GTTB = T?ng doanh thu / S? ??n hàng
```

### 6.2. Bi?u ?? (Có th? m? r?ng)

#### A. Bi?u ?? C?t:
- Tr?c X: Tên nhân viên
- Tr?c Y: Doanh thu
- Hi?n th? so sánh tr?c quan

#### B. Bi?u ?? Tròn:
- Ph?n tr?m ?óng góp c?a t?ng nhân viên
- Hi?n th? t? l? doanh thu

#### C. Bi?u ?? Xu H??ng:
- Theo dõi doanh thu theo th?i gian
- So sánh tháng này vs tháng tr??c

---

## 7. X? Lý L?i

### L?i 1: "Không có d? li?u doanh thu trong kho?ng th?i gian này!"
**Nguyên nhân:** 
- Không có ??n hàng nào trong kho?ng th?i gian
- Ho?c nhân viên ch?a ph?c v? ??n nào

**Gi?i pháp:**
- Ch?n kho?ng th?i gian khác
- Ki?m tra có ??n hàng ?ã thanh toán ch?a

### L?i 2: "Ngày b?t ??u không ???c l?n h?n ngày k?t thúc!"
**Nguyên nhân:** Ch?n sai kho?ng th?i gian

**Gi?i pháp:** Ch?n l?i ngày cho ?úng

### L?i 3: "L?i t?i d? li?u doanh thu"
**Nguyên nhân:** L?i database ho?c query

**Gi?i pháp:**
1. Ki?m tra k?t n?i database
2. Ki?m tra log chi ti?t
3. Restart ?ng d?ng

---

## 8. Tips & Best Practices

### 8.1. ?ánh Giá Hi?u Su?t

? **Nên:**
- Xem báo cáo ??nh k? (hàng tu?n/tháng)
- So sánh v?i k? tr??c
- ??t m?c tiêu rõ ràng cho nhân viên
- Th??ng nhân viên có thành tích t?t

? **Không nên:**
- Ch? ?ánh giá d?a vào doanh thu
- B? qua y?u t? ch?t l??ng ph?c v?
- So sánh không công b?ng (ca làm khác nhau)

### 8.2. S? D?ng D? Li?u

**?? ?ào t?o:**
- Tìm ?i?m y?u c?a t?ng nhân viên
- Chia s? k? n?ng t? nhân viên gi?i

**?? ??ng viên:**
- Công nh?n thành tích
- T?o ??ng l?c c?nh tranh lành m?nh

**?? l?p k? ho?ch:**
- S?p x?p ca làm h?p lý
- Phân công nhân viên vào ca ?ông khách

---

## 9. M? R?ng & C?i Ti?n

### 9.1. Thêm Filter Nhân Viên
```csharp
// ComboBox ch?n nhân viên c? th?
cmbNhanVien.DataSource = _context.Users.ToList();
```

### 9.2. Hi?n Th? Chi Ti?t
```csharp
// Click vào row ? hi?n th? danh sách ??n hàng c?a nhân viên ?ó
dgv_HoaDon.CellDoubleClick += ShowOrderDetails;
```

### 9.3. Export PDF
```csharp
// Xu?t báo cáo ??p h?n v?i iTextSharp
using iTextSharp.text;
using iTextSharp.text.pdf;
```

### 9.4. Dashboard T?ng H?p
```csharp
// Hi?n th?:
// - Top 3 nhân viên
// - T?ng doanh thu
// - T?ng tr??ng so v?i k? tr??c
// - Bi?u ?? xu h??ng
```

### 9.5. Thông Báo T? ??ng
```csharp
// G?i email báo cáo cu?i tháng
// Thông báo khi nhân viên ??t m?c tiêu
```

---

## 10. Security & Permissions

### Quy?n Truy C?p:
- **Admin**: Xem t?t c? nhân viên
- **Staff**: Ch? xem doanh thu c?a b?n thân (có th? m? r?ng)

### B?o M?t D? Li?u:
- Không cho phép s?a d? li?u l?ch s?
- Mã hóa khi export
- L?u log khi xem báo cáo

---

## 11. Database Schema

### B?ng Liên Quan:

```sql
-- Orders
Id, TableId, StaffId, CreatedAt, TotalAmount

-- Users (Staff)
Id, Username, Role

-- OrderDetails
Id, OrderId, ProductId, Quantity, UnitPrice
```

### Index Quan Tr?ng:
```sql
-- T?ng t?c query
CREATE INDEX IX_Orders_StaffId_CreatedAt 
ON Orders(StaffId, CreatedAt);

CREATE INDEX IX_Orders_CreatedAt_TotalAmount 
ON Orders(CreatedAt, TotalAmount);
```

---

## 12. Performance Tips

### V?i D? Li?u L?n:
- S? d?ng pagination
- Cache k?t qu?
- T?i ?u query v?i index
- S? d?ng stored procedure

### Query Optimization:
```csharp
// Ch? l?y field c?n thi?t
.Select(o => new { o.Id, o.StaffId, o.TotalAmount })

// S? d?ng AsNoTracking() n?u ch? ??c
.AsNoTracking()
```

---

**Tác gi?:** GitHub Copilot  
**Ngày t?o:** 2024  
**Phiên b?n:** 1.0  
**Liên quan:** RevenueEDay, FormMain
