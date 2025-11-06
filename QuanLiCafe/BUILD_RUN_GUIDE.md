# ?? H??NG D?N BUILD & CH?Y ?NG D?NG

## ?? YÊU C?U H? TH?NG

### **Ph?n m?m c?n thi?t:**
- ? **.NET 8 SDK** (ho?c cao h?n)
- ? **SQL Server Express** (ho?c SQL Server Developer)
- ? **Visual Studio 2022** (ho?c VS Code + C# Extension)
- ? **Git** (optional - ?? clone repo)

### **Ki?m tra .NET SDK:**
```bash
dotnet --version
# Output: 8.0.x
```

### **Ki?m tra SQL Server:**
```bash
# PowerShell
Get-Service | Where-Object {$_.Name -like "*SQL*"}

# Ho?c check tên máy
$env:COMPUTERNAME
# Output: TÊN_MÁY (dùng ?? t?o connection string)
```

---

## ?? B??C 1: SETUP CONNECTION STRING

### **File:** `QuanLiCafe/appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TÊN_MÁY\\SQLEXPRESS;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Thay `TÊN_MÁY` b?ng tên máy c?a b?n:**
- Cách 1: Ch?y `$env:COMPUTERNAME` trong PowerShell
- Cách 2: M? Command Prompt ? Ch?y `hostname`
- Cách 3: Windows Search ? "About Your PC" ? Device Name

**Ví d?:**
```
Server=LAPTOP-ABC123\\SQLEXPRESS;...
Server=DESKTOP-XYZ456\\SQLEXPRESS;...
```

---

## ??? B??C 2: T?O & MIGRATE DATABASE

### **Option A: S? d?ng dotnet CLI**

```bash
# 1. Restore packages
dotnet restore QuanLiCafe/QuanLiCafe.csproj

# 2. T?o migration (n?u ch?a có)
dotnet ef migrations add InitialCreate --project QuanLiCafe/QuanLiCafe.csproj

# 3. Update database
dotnet ef database update --project QuanLiCafe/QuanLiCafe.csproj
```

### **Option B: S? d?ng Visual Studio**

1. **Tools** ? **NuGet Package Manager** ? **Package Manager Console**
2. Ch?y l?nh:
```powershell
Add-Migration InitialCreate
Update-Database
```

### **Ki?m tra database:**
```bash
# SQL Server Management Studio (SSMS)
# Ho?c Azure Data Studio
# Ho?c VS Server Explorer

# Ki?m tra database "QuanLiCafeDB" ?ã t?n t?i
# Ki?m tra 8 tables:
# - Users
# - Tables
# - Categories
# - Products
# - Orders
# - OrderDetails
# - Inventories
# - ImportHistories
```

---

## ?? B??C 3: SEED DEMO DATA

**Seed data t? ??ng ch?y khi kh?i ??ng app l?n ??u!**

`Program.cs` ?ã tích h?p:
```csharp
DatabaseSeeder.SeedDemoData(DbContext);
```

**?i?u này s?:**
1. ? Update passwords sang BCrypt (admin123, staff123)
2. ? Thêm staff02, staff03
3. ? Seed 50 orders ng?u nhiên trong tháng hi?n t?i

**N?u mu?n seed l?i:**
1. Xóa database: `dotnet ef database drop`
2. T?o l?i: `dotnet ef database update`
3. Ch?y app ? Seed t? ??ng

---

## ?? B??C 4: BUILD PROJECT

### **Option A: dotnet CLI**
```bash
# Build solution
dotnet build QuanLiCafe.sln

# Ho?c build project
dotnet build QuanLiCafe/QuanLiCafe.csproj

# Build v?i configuration Release
dotnet build QuanLiCafe/QuanLiCafe.csproj -c Release
```

### **Option B: Visual Studio**
```
Build ? Build Solution (Ctrl+Shift+B)
```

### **Ki?m tra output:**
```
Build succeeded in 2.5s
    0 Warning(s)
    0 Error(s)
```

---

## ?? B??C 5: CH?Y ?NG D?NG

### **Option A: dotnet CLI**
```bash
dotnet run --project QuanLiCafe/QuanLiCafe.csproj
```

### **Option B: Visual Studio**
```
Debug ? Start Debugging (F5)
ho?c
Debug ? Start Without Debugging (Ctrl+F5)
```

### **Option C: Run file .exe**
```bash
# Sau khi build
cd QuanLiCafe/bin/Debug/net8.0-windows
.\QuanLiCafe.exe
```

---

## ?? B??C 6: ??NG NH?P

### **Form Login xu?t hi?n t? ??ng!**

**Tài kho?n demo:**

| Username | Password  | Role  | Quy?n |
|----------|-----------|-------|-------|
| admin    | admin123  | Admin | T?t c? (??t món, Báo cáo, Kho) |
| staff01  | staff123  | Staff | Ch? ??t món |
| staff02  | staff123  | Staff | Ch? ??t món |
| staff03  | staff123  | Staff | Ch? ??t món |

**??ng nh?p Admin ?? test ??y ?? ch?c n?ng!**

---

## ?? B??C 7: CH?Y UNIT TESTS

```bash
# Build tests
dotnet build QuanLiCafe.Tests/QuanLiCafe.Tests.csproj

# Run tests
dotnet test QuanLiCafe.Tests/QuanLiCafe.Tests.csproj

# Run v?i logging chi ti?t
dotnet test QuanLiCafe.Tests/QuanLiCafe.Tests.csproj --logger "console;verbosity=detailed"
```

**K?t qu? mong ??i:**
```
Test Run Successful.
Total tests: 12
     Passed: 12
 Total time: 5.4s
```

---

## ?? B??C 8: TEST CH?C N?NG

### **1. Test ??ng Nh?p:**
```
1. App kh?i ??ng ? Form Login hi?n ra
2. Nh?p: admin / admin123
3. Click "?? ??NG NH?P"
4. FormMain m? v?i user info "?? admin (Admin)"
```

### **2. Test Báo Cáo (Admin only):**
```
1. Click nút "?? Báo Cáo"
2. FormReport m? v?i 3 tabs
3. Ch?n kho?ng th?i gian (From/To)
4. Click "?? T?i L?i"
5. Ki?m tra d? li?u trong 3 tabs:
   - Tab 1: Doanh thu theo ngày
   - Tab 2: Top 5 s?n ph?m
   - Tab 3: Doanh thu theo nhân viên
```

### **3. Test ??t Món:**
```
1. Click b?t k? bàn nào (VD: Bàn 1)
2. FormOrder m?
3. Ch?n category ? Ch?n product
4. Nh?p s? l??ng ? Click "? THÊM MÓN"
5. Repeat cho nhi?u món
6. Nh?p discount % và VAT %
7. Click "?? THANH TOÁN"
8. Ch?n xu?t PDF ho?c Excel
9. File t? ??ng m?
```

### **4. Test Kho (Admin only):**
```
1. Click nút "?? Kho"
2. FormInventory m?
3. Click "? Thêm NVL" ? Nh?p info ? L?u
4. Ch?n nguyên li?u ? Click "?? Nh?p Kho"
5. Nh?p s? l??ng + giá ? Click "? Nh?p Kho"
6. Quantity t? ??ng t?ng
7. Click "?? L?ch S?" ? Xem import history
```

### **5. Test Phân Quy?n:**
```
1. ??ng xu?t (?óng app)
2. Login v?i staff01 / staff123
3. Ki?m tra:
   - ? Không th?y nút "?? Báo Cáo"
   - ? Không th?y nút "?? Kho"
   - ? V?n ??t món bình th??ng
```

---

## ?? TROUBLESHOOTING

### **L?i 1: Cannot connect to SQL Server**
```
Error: A network-related or instance-specific error
```

**Gi?i pháp:**
```bash
# 1. Check SQL Server ?ang ch?y
Get-Service | Where-Object {$_.Name -like "*SQL*"}

# 2. Start SQL Server
Start-Service MSSQL$SQLEXPRESS

# 3. Ki?m tra tên máy
$env:COMPUTERNAME

# 4. Update connection string trong appsettings.json
```

### **L?i 2: Migration failed**
```
Error: The entity type 'X' requires a primary key
```

**Gi?i pháp:**
```bash
# Xóa migration c?
dotnet ef migrations remove

# T?o l?i
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### **L?i 3: Seed data không ch?y**
```
Không có 50 orders trong database
```

**Gi?i pháp:**
```bash
# Xóa database
dotnet ef database drop --force

# T?o l?i
dotnet ef database update

# Ch?y app ? Seed t? ??ng
```

### **L?i 4: Login failed v?i admin**
```
Tên ??ng nh?p ho?c m?t kh?u không ?úng
```

**Gi?i pháp:**
```csharp
// DatabaseSeeder ?ã ch?y ch?a?
// Ki?m tra Users table có BCrypt hash ch?a

// Ho?c debug:
var admin = _context.Users.FirstOrDefault(u => u.Username == "admin");
Console.WriteLine(admin.PasswordHash); // Ph?i là BCrypt hash (60 chars)
```

### **L?i 5: FormReport không có d? li?u**
```
DataGridView tr?ng
```

**Gi?i pháp:**
```bash
# Ki?m tra có orders trong database
SELECT COUNT(*) FROM Orders

# N?u = 0 ? Seed l?i
# Xóa DB ? Update ? Run app
```

---

## ?? PACKAGES DEPENDENCIES

### **Ki?m tra packages:**
```bash
dotnet list QuanLiCafe/QuanLiCafe.csproj package
```

### **Output:**
```
BCrypt.Net-Next                     4.0.3
iTextSharp.LGPLv2.Core              3.4.22
EPPlus                              7.5.2
Microsoft.EntityFrameworkCore       8.0.11
Microsoft.EntityFrameworkCore.SqlServer 8.0.11
Microsoft.EntityFrameworkCore.Tools 8.0.11
Microsoft.Extensions.Configuration  8.0.1
```

### **Restore n?u thi?u:**
```bash
dotnet restore QuanLiCafe/QuanLiCafe.csproj
```

---

## ?? PERFORMANCE TIPS

### **1. T?i ?u EF Core:**
```csharp
// S? d?ng AsNoTracking cho read-only queries
var orders = _context.Orders
    .AsNoTracking()
    .Where(o => o.CreatedAt >= fromDate)
    .ToList();
```

### **2. Connection Pooling:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "...;Pooling=true;Min Pool Size=5;Max Pool Size=100;"
  }
}
```

### **3. Index trên columns hay query:**
```csharp
// Migration
migrationBuilder.CreateIndex(
    name: "IX_Orders_CreatedAt",
    table: "Orders",
    column: "CreatedAt");
```

---

## ? CHECKLIST CU?I CÙNG

Tr??c khi deploy production:

- [ ] Connection string ?úng
- [ ] Database ?ã migrate
- [ ] Seed data ?ã ch?y (50 orders)
- [ ] Login thành công v?i admin
- [ ] Báo cáo có d? li?u
- [ ] ??t món ho?t ??ng
- [ ] Thanh toán + Xu?t PDF/Excel OK
- [ ] Kho ho?t ??ng (Admin)
- [ ] Phân quy?n ?úng (Staff không th?y Report/Inventory)
- [ ] Unit tests 12/12 passed
- [ ] Build successful (0 warnings)

---

## ?? HOÀN T?T!

**?ng d?ng ?ã s?n sàng ch?y!**

```bash
# One-liner ?? ch?y nhanh:
dotnet build && dotnet run --project QuanLiCafe/QuanLiCafe.csproj
```

**Login:** admin / admin123  
**Enjoy!** ???
