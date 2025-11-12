# H??NG D?N S? D?NG CH?C N?NG TH?NG KÊ DOANH THU

## T?ng Quan
Module th?ng kê doanh thu cho phép xem chi ti?t doanh thu theo ngày và xu?t báo cáo.

---

## 1. M? Form Th?ng Kê Doanh Thu

### T? Form Main:
1. Click vào menu **"Th?ng kê"**
2. Ch?n **"Th?ng kê doanh thu theo ngày"**
3. Form `RevenueEDay` s? ???c m?

---

## 2. Giao Di?n Form Th?ng Kê

### Các thành ph?n chính:

#### A. B? l?c ngày:
- **T? ngày**: Ch?n ngày b?t ??u
- **??n ngày**: Ch?n ngày k?t thúc
- **Nút "L?c d? li?u"**: Áp d?ng b? l?c

#### B. DataGridView hi?n th?:
| C?t | Mô t? |
|-----|-------|
| STT | S? th? t? |
| Ngày thanh toán | Ngày gi? thanh toán hóa ??n |
| S? l??ng | T?ng s? món trong hóa ??n |
| T?ng ti?n | T?ng ti?n c?a hóa ??n |

#### C. Thông tin t?ng h?p:
- **T?ng**: Hi?n th? t?ng doanh thu c?a kho?ng th?i gian ?ã ch?n

#### D. Các nút ch?c n?ng:
- **In báo cáo**: In báo cáo doanh thu
- **Xu?t Excel**: Xu?t d? li?u ra file Excel/CSV

---

## 3. Các Tính N?ng

### 3.1. Xem Doanh Thu Ngày Hôm Nay (M?c ??nh)

Khi m? form, h? th?ng t? ??ng:
- Thi?t l?p **"T? ngày"** = Ngày hôm nay
- Thi?t l?p **"??n ngày"** = Ngày hôm nay
- Load và hi?n th? t?t c? hóa ??n ?ã thanh toán trong ngày

**Ví d?:**
```
Ngày: 12/11/2024
T?ng doanh thu: 1,500,000 ?
S? hóa ??n: 25
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

**Ví d?:**
```
T? ngày: 01/11/2024
??n ngày: 12/11/2024
T?ng doanh thu: 18,500,000 ?
S? hóa ??n: 300
```

---

### 3.3. In Báo Cáo

**B??c 1:** Load d? li?u mu?n in (theo ngày ho?c kho?ng th?i gian)

**B??c 2:** Click nút **"In báo cáo"**

**N?i dung báo cáo:**
```
=== BÁO CÁO DOANH THU THEO NGÀY ===
T? ngày: 01/11/2024
??n ngày: 12/11/2024
T?ng doanh thu: 18,500,000 ?
S? hóa ??n: 300

Chi ti?t:
- 01/11/2024 10:30 | SL: 5 | T?ng: 150,000 ?
- 01/11/2024 14:20 | SL: 3 | T?ng: 120,000 ?
...
```

---

### 3.4. Xu?t Excel

**B??c 1:** Load d? li?u mu?n xu?t

**B??c 2:** Click nút **"Xu?t Excel"**

**B??c 3:** Ch?n v? trí l?u file
- Ch?n th? m?c
- ??t tên file (m?c ??nh: `DoanhThu_ddMMyyyy_HHmmss.xlsx`)
- Click "Save"

**C?u trúc file Excel/CSV:**
```csv
STT,Ngày thanh toán,S? l??ng,T?ng ti?n
1,01/11/2024 10:30,5,150,000 ?
2,01/11/2024 14:20,3,120,000 ?
...

,,T?ng doanh thu,18,500,000 ?
```

---

## 4. Logic X? Lý

### 4.1. Cách Tính Doanh Thu

H? th?ng l?y d? li?u t? b?ng `Orders` v?i ?i?u ki?n:
- `CreatedAt` trong kho?ng th?i gian ???c ch?n
- `TotalAmount > 0` (?ã ???c tính t?ng ti?n)
- Có ít nh?t 1 `OrderDetail` (?ã có món)

**Query SQL t??ng ???ng:**
```sql
SELECT o.*, SUM(od.Quantity) as SoLuong
FROM Orders o
INNER JOIN OrderDetails od ON o.Id = od.OrderId
WHERE o.CreatedAt >= @StartDate 
  AND o.CreatedAt <= @EndDate
  AND o.TotalAmount > 0
GROUP BY o.Id
ORDER BY o.CreatedAt DESC
```

### 4.2. ??nh D?ng Hi?n Th?

- **Ngày gi?**: `dd/MM/yyyy HH:mm` (Ví d?: 12/11/2024 14:30)
- **Ti?n**: `N0 ?` (Ví d?: 1,500,000 ?)
- **S? l??ng**: Integer (Ví d?: 25)

### 4.3. Tính T?ng Doanh Thu

```csharp
decimal tongDoanhThu = orders.Sum(o => o.TotalAmount);
```

---

## 5. X? Lý L?i

### L?i 1: "Không có d? li?u doanh thu trong kho?ng th?i gian này!"
**Nguyên nhân:** 
- Không có ??n hàng nào trong kho?ng th?i gian ???c ch?n
- Ho?c t?t c? ??n hàng ch?a ???c thanh toán

**Gi?i pháp:**
- Ch?n kho?ng th?i gian khác
- Ki?m tra xem có ??n hàng ?ã thanh toán ch?a

### L?i 2: "Ngày b?t ??u không ???c l?n h?n ngày k?t thúc!"
**Nguyên nhân:** 
- Ch?n "T? ngày" > "??n ngày"

**Gi?i pháp:**
- Ch?n l?i ngày cho ?úng

### L?i 3: "L?i t?i d? li?u doanh thu"
**Nguyên nhân:** 
- L?i k?t n?i database
- L?i query

**Gi?i pháp:**
1. Ki?m tra k?t n?i database
2. Ki?m tra log chi ti?t l?i
3. Restart ?ng d?ng

### L?i 4: "Không có d? li?u ?? xu?t!"
**Nguyên nhân:** 
- DataGridView không có d? li?u

**Gi?i pháp:**
- Load d? li?u tr??c khi xu?t

---

## 6. Demo & Test Cases

### Test Case 1: Xem doanh thu ngày hôm nay
```
Input: M? form (m?c ??nh ngày hôm nay)
Expected: Hi?n th? t?t c? hóa ??n thanh toán hôm nay
```

### Test Case 2: Xem doanh thu tu?n này
```
Input: 
- T? ngày: 06/11/2024 (Th? 2)
- ??n ngày: 12/11/2024 (Ch? nh?t)
Expected: Hi?n th? t?t c? hóa ??n trong tu?n
```

### Test Case 3: Xem doanh thu tháng này
```
Input:
- T? ngày: 01/11/2024
- ??n ngày: 30/11/2024
Expected: Hi?n th? t?t c? hóa ??n trong tháng
```

### Test Case 4: Xu?t báo cáo
```
Input: Click "Xu?t Excel" khi có d? li?u
Expected: File CSV/Excel ???c t?o thành công
```

---

## 7. M? R?ng & C?i Ti?n

### 7.1. Thêm Bi?u ??
```csharp
// S? d?ng Chart control ?? hi?n th? bi?u ?? doanh thu
// - Bi?u ?? c?t: Doanh thu theo ngày
// - Bi?u ?? tròn: T? l? doanh thu theo s?n ph?m
```

### 7.2. Xu?t PDF
```csharp
// S? d?ng iTextSharp ?? xu?t báo cáo PDF
using iTextSharp.text;
using iTextSharp.text.pdf;
```

### 7.3. G?i Email Báo Cáo
```csharp
// T? ??ng g?i báo cáo qua email
using System.Net.Mail;
```

### 7.4. So Sánh Doanh Thu
```csharp
// So sánh doanh thu v?i:
// - Ngày hôm qua
// - Tu?n tr??c
// - Tháng tr??c
```

### 7.5. L?c Theo Nhân Viên
```csharp
// Thêm ComboBox ?? l?c theo nhân viên ph?c v?
var orders = _context.Orders
    .Where(o => o.StaffId == selectedStaffId)
    .ToList();
```

---

## 8. C?u Trúc Code

### File Structure:
```
QuanLiCafe/
??? Forms/
?   ??? RevenueEDay.cs              # Form chính
?   ??? RevenueEDay.Designer.cs     # Designer
?   ??? RevenueEDay.resx            # Resources
??? Models/
?   ??? Order.cs                    # Model ??n hàng
?   ??? OrderDetail.cs              # Model chi ti?t ??n
??? Data/
    ??? CafeContext.cs              # Database context
```

### Key Methods:
```csharp
// Load d? li?u
private void LoadRevenueData(DateTime fromDate, DateTime toDate)

// L?c d? li?u
private void Btn_LocDuLieu_Click(object sender, EventArgs e)

// In báo cáo
private void Btn_InBaoCao_Click(object sender, EventArgs e)

// Xu?t Excel
private void Btn_XuatExcel_Click(object sender, EventArgs e)

// T?o n?i dung báo cáo
private string GenerateReport()

// Xu?t Excel
private void ExportToExcel(string filePath)
```

---

## 9. Database Schema

### B?ng Orders:
```sql
CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY,
    TableId INT NOT NULL,
    StaffId INT NOT NULL,
    CreatedAt DATETIME NOT NULL,
    Discount DECIMAL(5,2) DEFAULT 0,
    VAT DECIMAL(5,2) DEFAULT 10,
    TotalAmount DECIMAL(18,2) NOT NULL
);
```

### B?ng OrderDetails:
```sql
CREATE TABLE OrderDetails (
    Id INT PRIMARY KEY IDENTITY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    Note NVARCHAR(500)
);
```

---

## 10. L?u Ý Quan Tr?ng

### Security:
- Ch? Admin và Staff có quy?n xem báo cáo
- D? li?u nh?y c?m c?n ???c mã hóa

### Performance:
- V?i s? l??ng ??n hàng l?n, nên:
  - S? d?ng pagination
  - Cache d? li?u
  - T?i ?u query v?i index

### Data Integrity:
- ??m b?o `TotalAmount` ???c tính chính xác
- Validate d? li?u tr??c khi xu?t báo cáo

---

**Tác gi?:** GitHub Copilot  
**Ngày t?o:** 2024  
**Phiên b?n:** 1.0
