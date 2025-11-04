# ?? H??NG D?N S? D?NG H? TH?NG QU?N LÝ QUÁN CAFE

## ?? T?ng Quan D? Án

H? th?ng qu?n lý quán cafe ???c xây d?ng b?ng **WinForms .NET 8** v?i **Entity Framework Core**, bao g?m:

- ? Qu?n lý 20 bàn (l??i 5x4)
- ? ??t món theo bàn
- ? Tính toán t? ??ng (Discount, VAT, Total)
- ? Data-binding v?i EF Core + LINQ
- ? Database SQL Server Express

---

## ?? C?u Trúc D? Án

```
QuanLiCafe/
??? Models/                      # Các Entity classes
?   ??? User.cs
?   ??? Table.cs
?   ??? Category.cs
?   ??? Product.cs
?   ??? Order.cs
?   ??? OrderDetail.cs
?   ??? Inventory.cs
?   ??? ImportHistory.cs
??? Data/                        # DbContext và Factory
?   ??? CafeContext.cs
?   ??? CafeContextFactory.cs
??? Forms/                       # WinForms
?   ??? FormMain.cs              # Màn hình chính - L??i bàn
?   ??? FormOrder.cs             # Màn hình ??t món
??? Helpers/                     # Helper classes
?   ??? TableStatusHelper.cs     # X? lý màu tr?ng thái bàn
??? Migrations/                  # EF Core Migrations
??? appsettings.json            # Connection String
??? Program.cs                  # Entry Point
```

---

## ??? CÀI ??T VÀ CH?Y D? ÁN

### **B??c 1: Ki?m Tra Yêu C?u H? Th?ng**

- ? .NET 8 SDK
- ? SQL Server Express (ho?c LocalDB)
- ? Visual Studio 2022 (ho?c VS Code)

### **B??c 2: Clone/M? D? Án**

```bash
cd D:\HP\201_LTWD\QuanLiCafe\QuanLiCafe
```

### **B??c 3: C?u Hình Connection String**

M? file `appsettings.json` và ki?m tra connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=LAPTOP-PHUCTHIE\\SQLEXPRESS;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**L?u ý:** Thay `LAPTOP-PHUCTHIE\\SQLEXPRESS` b?ng tên SQL Server c?a b?n.

### **B??c 4: Ch?y Migration ?? T?o Database**

```bash
# T?i th? m?c ch?a file .csproj
dotnet ef database update
```

L?nh này s?:
- T?o database `QuanLiCafeDB`
- T?o các b?ng theo ERD
- Seed d? li?u m?u (5 bàn, 5 s?n ph?m, 2 categories, 2 users, 5 inventory items)

### **B??c 5: Build và Ch?y**

```bash
dotnet build
dotnet run
```

Ho?c nh?n **F5** trong Visual Studio.

---

## ?? GIAO DI?N VÀ CH?C N?NG

### **1?? FormMain - Màn Hình Qu?n Lý Bàn**

#### **Giao Di?n:**
- Header màu xanh ??m v?i tiêu ?? "S? ?? BÀN"
- Nút "?? T?i L?i" ? góc ph?i header
- L??i 5x4 = 20 bàn, m?i bàn hi?n th?:
  - Tên bàn (vd: "Bàn 1")
  - Tr?ng thái (Tr?ng/?ang ph?c v?/?óng)

#### **Màu S?c Tr?ng Thái:**
```csharp
Free (Tr?ng)      ? LightGray (Xám nh?t)
Serving (Ph?c v?) ? LightGreen (Xanh lá nh?t)
Closed (?óng)     ? DarkGray (Xám ??m)
```

#### **Ch?c N?ng:**
- **Click vào bàn:** M? `FormOrder` ?? ??t món
- **Nút T?i L?i:** Refresh tr?ng thái bàn t? database
- **Hover hi?u ?ng:** Border xanh khi di chu?t qua bàn

#### **Code LINQ - Load Bàn:**
```csharp
var tables = _context.Tables
    .OrderBy(t => t.Id)
    .Take(20)
    .ToList();
```

---

### **2?? FormOrder - Màn Hình ??t Món**

#### **Giao Di?n Chia 2 Panel:**

**Panel Trái (350px):**
- ComboBox ch?n **Danh M?c** (Categories)
- ListBox hi?n th? **S?n Ph?m** theo category
- NumericUpDown **S? L??ng**
- TextBox **Ghi Chú**
- Button **? Thêm Món**

**Panel Ph?i (Fill):**
- DataGridView hi?n th? **Chi Ti?t ??n Hàng:**
  - Tên Món
  - S? L??ng
  - ??n Giá
  - Thành Ti?n
  - Ghi Chú
- Button **??? Xóa Món**
- Panel Thanh Toán:
  - Input **Gi?m Giá (%)** - default: 0
  - Input **VAT (%)** - default: 10
  - Label hi?n th?:
    - **T?m Tính**
    - **Gi?m Giá** (màu ??)
    - **VAT**
    - **T?NG C?NG** (màu xanh, bold, l?n)
- Button **?? THANH TOÁN** (màu xanh)
- Button **?? H?Y** (màu xám)

#### **Lu?ng X? Lý:**

**Khi M? FormOrder:**
```csharp
// LINQ: Ki?m tra order ?ang ph?c v?
_currentOrder = _context.Orders
    .Include(o => o.OrderDetails)
    .ThenInclude(od => od.Product)
    .Where(o => o.TableId == _tableId)
    .OrderByDescending(o => o.CreatedAt)
    .FirstOrDefault();

if (_currentOrder != null)
{
    // Load chi ti?t order c?
    LoadExistingOrderDetails();
}
else
{
    // T?o order m?i
    CreateNewOrder();
    // C?p nh?t tr?ng thái bàn ? "Serving"
}
```

**Load Categories:**
```csharp
var categories = _context.Categories
    .OrderBy(c => c.Name)
    .ToList();
```

**Load Products theo Category:**
```csharp
var products = _context.Products
    .Where(p => p.CategoryId == categoryId)
    .OrderBy(p => p.Name)
    .ToList();
```

**Thêm Món:**
- Ki?m tra món ?ã t?n t?i ? C?ng s? l??ng
- Món m?i ? Thêm vào `BindingList<OrderDetailViewModel>`
- Tính toán l?i t?ng ti?n

**Tính Toán T?ng Ti?n:**
```csharp
decimal subTotal = _orderDetails.Sum(od => od.SubTotal);
decimal discountAmount = subTotal * discountPercent / 100;
decimal afterDiscount = subTotal - discountAmount;
decimal vatAmount = afterDiscount * vatPercent / 100;
decimal total = afterDiscount + vatAmount;
```

**Thanh Toán:**
1. L?u OrderDetails vào database
2. C?p nh?t Order (Discount, VAT, TotalAmount)
3. C?p nh?t tr?ng thái bàn ? **"Free"**
4. ?óng form

---

## ?? DATABASE SCHEMA (ERD)

```
Users (Id, Username, PasswordHash, Role)
    ? (1:N)
Orders (Id, TableId, StaffId, CreatedAt, Discount, VAT, TotalAmount)
    ? (1:N)
OrderDetails (Id, OrderId, ProductId, Quantity, UnitPrice, Note)

Tables (Id, Name, Status)
    ? (1:N)
Orders

Categories (Id, Name)
    ? (1:N)
Products (Id, Name, Price, CategoryId, ImageUrl)

Inventory (Id, MaterialName, Unit, Quantity, ReorderLevel)
    ? (1:N)
ImportHistory (Id, MaterialId, Quantity, Cost, ImportedAt)
```

---

## ?? CÁC TRUY V?N LINQ QUAN TR?NG

### **1. Top 3 Món Giá Cao Nh?t**
```csharp
var topProducts = _context.Products
    .Include(p => p.Category)
    .OrderByDescending(p => p.Price)
    .Take(3)
    .ToList();
```

### **2. Bàn ?ang Tr?ng**
```csharp
var freeTables = _context.Tables
    .Where(t => t.Status == "Free")
    .ToList();
```

### **3. Nguyên Li?u D??i M?c T?n Kho**
```csharp
var lowStockMaterials = _context.Inventories
    .Where(i => i.Quantity < i.ReorderLevel)
    .ToList();
```

### **4. T?ng Doanh Thu Theo Ngày**
```csharp
var revenue = _context.Orders
    .Where(o => o.CreatedAt.Date == DateTime.Today)
    .Sum(o => o.TotalAmount);
```

---

## ?? HELPER CLASS - Màu Tr?ng Thái Bàn

**File:** `Helpers/TableStatusHelper.cs`

```csharp
public static class TableStatusHelper
{
    public static Color GetColorByStatus(string status)
    {
        return status switch
        {
            "Free" => Color.LightGray,
            "Serving" => Color.LightGreen,
            "Closed" => Color.DarkGray,
            _ => Color.White
        };
    }

    public static string GetStatusText(string status)
    {
        return status switch
        {
            "Free" => "Tr?ng",
            "Serving" => "?ang ph?c v?",
            "Closed" => "?óng",
            _ => status
        };
    }
}
```

---

## ?? KI?M TH?

### **Test Case 1: ??t Món M?i**
1. M? FormMain
2. Click vào bàn "Free" ? M? FormOrder
3. Ch?n Category ? Ch?n Product ? Thêm món
4. Nh?p Discount, VAT
5. Thanh toán ? Bàn v? "Free"

### **Test Case 2: Load Order C?**
1. ??t món nh?ng không thanh toán
2. ?óng FormOrder
3. M? l?i FormOrder ? Hi?n th? order c?

### **Test Case 3: Reload Tr?ng Thái**
1. Click "T?i L?i" ? FormMain
2. Ki?m tra tr?ng thái bàn c?p nh?t

---

## ?? X? LÝ L?I TH??NG G?P

### **1. Không K?t N?i Database**
```bash
# Ki?m tra SQL Server ?ang ch?y
Get-Service | Where-Object {$_.Name -like "*SQL*"}

# L?y tên máy
$env:COMPUTERNAME

# S?a connection string trong appsettings.json
"Server=TÊN_MÁY\\SQLEXPRESS;..."
```

### **2. Migration L?i**
```bash
# Xóa migration c?
dotnet ef migrations remove

# T?o l?i
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### **3. L?i Seed Data Ti?ng Vi?t**
- ??m b?o file `.cs` ???c l?u v?i encoding **UTF-8 with BOM**
- Trong Visual Studio: File ? Advanced Save Options ? UTF-8 with BOM

---

## ?? TÀI LI?U THAM KH?O

- [Entity Framework Core Docs](https://docs.microsoft.com/en-us/ef/core/)
- [WinForms Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
- [LINQ Query Syntax](https://docs.microsoft.com/en-us/dotnet/csharp/linq/)

---

## ????? THÔNG TIN D? ÁN

- **Framework:** .NET 8 / WinForms
- **Database:** SQL Server Express
- **ORM:** Entity Framework Core 8.0
- **Design Pattern:** Repository Pattern (via DbContext)

---

## ?? TÍNH N?NG M? R?NG (G?i Ý)

1. ? **Login Form** - Xác th?c user (Admin/Staff)
2. ? **Báo cáo doanh thu** - Chart hi?n th? theo ngày/tháng
3. ? **Qu?n lý nhân viên** - CRUD Users
4. ? **Qu?n lý kho** - CRUD Inventory + Import History
5. ? **In hóa ??n** - Export PDF/Print receipt
6. ? **??t bàn tr??c** - Reservation system
7. ? **Tích ?i?m khách hàng** - Loyalty program

---

**© 2025 - Qu?n Lý Quán Cafe WinForms**
