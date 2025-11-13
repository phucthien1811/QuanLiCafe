# H??ng D?n Setup Database Khi Clone Project

## V?n ??

Khi clone project v? máy khác, b?n s? g?p l?i:
```
Error Locating Server/Instance
A network-related or instance-specific error occurred while establishing 
a connection to SQL Server...
```

## Nguyên Nhân

1. Connection string trong code ?ang tr? ??n SQL Server c?a máy khác
2. Th? m?c `Migrations/` không ???c commit (?? tránh xung ??t)

## Gi?i Pháp

### B??c 1: Ki?m Tra SQL Server Instance

M? **Command Prompt** và ch?y:
```cmd
sqlcmd -L
```

K?t qu? s? hi?n th? instance name c?a máy b?n, ví d?:
```
Servers:
  LAPTOP-ABC123\SQLEXPRESS
  (localdb)\MSSQLLocalDB
```

### B??c 2: T?o File `appsettings.json`

1. Copy file `appsettings.example.json` thành `appsettings.json`:
```cmd
cd QuanLiCafe
copy appsettings.example.json appsettings.json
```

2. M? file `appsettings.json` và **thay ??i hostname**:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_HOSTNAME\\SQLEXPRESS;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Thay `YOUR_HOSTNAME\\SQLEXPRESS` b?ng:**
- `localhost\\SQLEXPRESS` (n?u dùng SQL Server Express)
- `(localdb)\\MSSQLLocalDB` (n?u dùng LocalDB)
- Ho?c hostname c?a máy b?n (k?t qu? t? b??c 1)

### B??c 3: C?p Nh?t `CafeContextFactory.cs`

M? file `QuanLiCafe/Data/CafeContextFactory.cs` và thay ??i connection string:

```csharp
optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;");
```

### B??c 4: T?o Migrations (Quan Tr?ng!)

?? **Th? m?c `Migrations/` không ???c commit ?? tránh xung ??t gi?a các máy khác nhau**

T?o migrations m?i:
```cmd
cd QuanLiCafe
dotnet ef migrations add InitialCreate
```

K?t qu?: S? t?o th? m?c `Migrations/` v?i các file:
- `20XXXXXX_InitialCreate.cs`
- `20XXXXXX_InitialCreate.Designer.cs`
- `CafeContextModelSnapshot.cs`

### B??c 5: T?o Database

```cmd
dotnet ef database update
```

L?nh này s?:
1. T?o database `QuanLiCafeDB` (n?u ch?a có)
2. T?o t?t c? các b?ng: Users, Tables, Products, Categories, Orders, OrderDetails, Customers, v.v.
3. Seed d? li?u m?u (admin user, demo data)

### B??c 6: Ch?y ?ng D?ng

```cmd
dotnet run
```

**Thông tin ??ng nh?p:**
- Username: `admin`
- Password: `admin123`

## Các Connection String Th??ng Dùng

### SQL Server Express (Khuyên dùng)
```
Server=localhost\SQLEXPRESS;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;
```

### LocalDB (Nh? h?n)
```
Server=(localdb)\MSSQLLocalDB;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;
```

### Remote Server (N?u có)
```
Server=192.168.1.100\SQLEXPRESS;Database=QuanLiCafeDB;User Id=sa;Password=yourpassword;TrustServerCertificate=True;
```

## Ch?a Cài SQL Server?

### Option 1: SQL Server Express (Khuyên dùng)
Download: https://www.microsoft.com/en-us/sql-server/sql-server-downloads

Sau khi cài:
- Instance name m?c ??nh: `SQLEXPRESS`
- Connection string: `Server=localhost\\SQLEXPRESS;...`

### Option 2: SQL Server LocalDB (Nh? h?n)
?ã bao g?m trong Visual Studio 2022

Connection string: `Server=(localdb)\\MSSQLLocalDB;...`

## Troubleshooting

### L?i: "Cannot open database"
```cmd
# Xóa database c? và t?o l?i
dotnet ef database drop --force
dotnet ef database update
```

### L?i: "Login failed for user"
- Ki?m tra SQL Server ?ang ch?y
- Ki?m tra Windows Authentication ???c b?t
- Th? dùng SQL Server Authentication v?i User/Password

### L?i: "Instance not found"
- Ch?y l?i `sqlcmd -L` ?? ki?m tra instance name
- M? **SQL Server Configuration Manager**
- Ki?m tra SQL Server Service ?ang ch?y

### L?i: "Build failed" khi ch?y migrations
```cmd
# Clean và rebuild
dotnet clean
dotnet build
dotnet ef migrations add InitialCreate
```

### L?i: "A migration named 'InitialCreate' already exists"
```cmd
# Xóa migrations c? và t?o m?i
# Cách 1: Xóa th? m?c Migrations
rmdir /s Migrations

# Cách 2: Dùng EF CLI
dotnet ef migrations remove

# Sau ?ó t?o l?i
dotnet ef migrations add InitialCreate
```

## C?u Trúc Database

Sau khi ch?y migrations, database s? có các b?ng:

| B?ng | Mô t? |
|------|-------|
| Users | Tài kho?n nhân viên (admin, staff) |
| Tables | Danh sách bàn |
| Categories | Lo?i ?? u?ng (Cà phê, Trà s?a) |
| Products | ?? u?ng |
| Orders | ??n hàng |
| OrderDetails | Chi ti?t ??n hàng |
| Customers | Khách hàng |
| Inventories | Kho nguyên li?u |
| ImportHistories | L?ch s? nh?p hàng |

## D? Li?u M?u

Database s? t? ??ng t?o:

**Users:**
- admin / admin123 (Role: Admin)
- staff01 / staff123 (Role: Staff)

**Tables:**
- Bàn 1, Bàn 2, Bàn 3, Bàn 4, Bàn 5

**Categories:**
- Cà phê
- Trà s?a

**Products:**
- Cà phê ?en (25,000 ?)
- Cà phê s?a (30,000 ?)
- B?c x?u (28,000 ?)
- Trà s?a truy?n th?ng (35,000 ?)
- Trà s?a matcha (40,000 ?)

## L?u Ý Quan Tr?ng

?? **Các file/folder sau ?ã ???c ignore trong Git:**

1. `appsettings.json` - Ch?a connection string
2. `Migrations/` - Ch?a migration files
3. `*.db, *.mdf, *.ldf` - Database files

**T?i sao?**
- M?i developer có máy khác nhau ? connection string khác nhau
- Migrations có th? conflict gi?a các máy ? m?i ng??i t? t?o
- Tránh commit thông tin nh?y c?m lên Git

## Quy Trình Làm Vi?c Nhóm

### Developer A (T?o model m?i)
```cmd
# T?o migration m?i
dotnet ef migrations add AddNewFeature

# Apply vào database
dotnet ef database update

# Commit code (không commit Migrations/)
git add .
git commit -m "Add new feature"
git push
```

### Developer B (Pull code m?i)
```cmd
# Pull code
git pull

# T?o l?i migrations t? ??u
rmdir /s Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Script Nhanh

T?o file `setup.bat` ?? t? ??ng setup:

```bat
@echo off
echo ======================================
echo  QUAN LY CAFE - DATABASE SETUP
echo ======================================
echo.

echo [1/5] Copying appsettings.json...
copy appsettings.example.json appsettings.json
echo Done!
echo.

echo [2/5] Please update connection string in appsettings.json
echo Press any key when ready...
pause > nul
echo.

echo [3/5] Creating migrations...
dotnet ef migrations add InitialCreate
echo Done!
echo.

echo [4/5] Creating database...
dotnet ef database update
echo Done!
echo.

echo [5/5] Setup complete!
echo.
echo Login credentials:
echo Username: admin
echo Password: admin123
echo.
pause
```

## Liên H?

N?u g?p v?n ??, tham kh?o:
- `HUONG_DAN_MIGRATION_CUSTOMER.md` - H??ng d?n migration chi ti?t
- `HUONG_DAN_FORMS.md` - H??ng d?n s? d?ng các form
- `HUONG_DAN_THONG_KE_DOANH_THU.md` - H??ng d?n module th?ng kê
