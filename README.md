# ?? Qu?n Lý Quán Cafe - Ph?n M?m Qu?n Lý Bán Hàng

Ph?n m?m qu?n lý quán cafe v?i ??y ?? tính n?ng: qu?n lý bàn, menu, ??n hàng, nhân viên, khách hàng, và báo cáo th?ng kê.

## ?? Tính N?ng

### ?? Qu?n Lý Tài Kho?n
- ??ng nh?p v?i 2 role: Admin và Staff
- Mã hóa m?t kh?u v?i BCrypt
- Qu?n lý nhân viên (thêm, s?a, xóa)

### ?? Qu?n Lý Bàn
- Xem tr?ng thái bàn (Tr?ng/?ang ph?c v?/?ã ?óng)
- Thêm/S?a/Xóa bàn
- Chuy?n bàn, g?p bàn

### ?? Qu?n Lý Menu
- Qu?n lý lo?i ?? u?ng (Categories)
- Qu?n lý ?? u?ng (Products)
- Thêm/S?a/Xóa menu
- Upload hình ?nh món

### ?? Qu?n Lý ??n Hàng
- T?o ??n hàng m?i
- Thêm/Xóa món trong ??n
- Tính toán VAT và gi?m giá
- Thanh toán ti?n m?t/MoMo

### ?? Qu?n Lý Khách Hàng
- Thêm thông tin khách hàng
- Tìm ki?m theo S?T
- L?ch s? mua hàng

### ?? Th?ng Kê & Báo Cáo
- Doanh thu theo ngày
- Doanh thu theo nhân viên
- L?ch s? hóa ??n chi ti?t
- Xu?t báo cáo Excel/CSV

## ??? Công Ngh? S? D?ng

- **.NET 8** - Framework chính
- **C# 12.0** - Ngôn ng? l?p trình
- **Entity Framework Core** - ORM
- **SQL Server/LocalDB** - Database
- **Windows Forms** - UI Framework
- **BCrypt.Net** - Mã hóa m?t kh?u

## ?? Yêu C?u H? Th?ng

- Windows 10/11
- .NET 8 SDK
- SQL Server 2019+ ho?c SQL Server Express
- Visual Studio 2022 (khuyên dùng) ho?c VS Code

## ?? H??ng D?n Cài ??t

### Cách 1: T? ??ng (Khuyên Dùng)

1. **Clone repository:**
```bash
git clone https://github.com/yourusername/QuanLiCafe.git
cd QuanLiCafe/QuanLiCafe
```

2. **Ch?y script setup:**
```bash
setup.bat
```

Script s? t? ??ng:
- Copy `appsettings.example.json` ? `appsettings.json`
- Nh?c b?n c?p nh?t connection string
- T?o migrations
- T?o database và b?ng
- Seed d? li?u m?u

3. **Ch?y ?ng d?ng:**
```bash
dotnet run
```

### Cách 2: Th? Công

Xem h??ng d?n chi ti?t trong [`SETUP_DATABASE.md`](SETUP_DATABASE.md)

## ?? Tài Kho?n M?c ??nh

Sau khi setup, s? d?ng các tài kho?n sau ?? ??ng nh?p:

**Admin:**
- Username: `admin`
- Password: `admin123`

**Staff:**
- Username: `staff01`
- Password: `staff123`

## ?? Tài Li?u

- [SETUP_DATABASE.md](SETUP_DATABASE.md) - H??ng d?n setup chi ti?t
- [HUONG_DAN_FORMS.md](QuanLiCafe/HUONG_DAN_FORMS.md) - H??ng d?n s? d?ng các form
- [HUONG_DAN_MIGRATION_CUSTOMER.md](QuanLiCafe/HUONG_DAN_MIGRATION_CUSTOMER.md) - H??ng d?n migration
- [HUONG_DAN_THONG_KE_DOANH_THU.md](QuanLiCafe/HUONG_DAN_THONG_KE_DOANH_THU.md) - Th?ng kê doanh thu
- [HUONG_DAN_THONG_KE_NHAN_VIEN.md](QuanLiCafe/HUONG_DAN_THONG_KE_NHAN_VIEN.md) - Th?ng kê nhân viên
- [HUONG_DAN_LICH_SU_HOA_DON.md](QuanLiCafe/HUONG_DAN_LICH_SU_HOA_DON.md) - L?ch s? hóa ??n

## ?? C?u Trúc Project

```
QuanLiCafe/
??? Data/                      # DbContext, Seeder
??? Models/                    # Entity models
??? Forms/                     # Windows Forms
??? Helpers/                   # Utility classes
??? Migrations/               # EF Core migrations (ignored)
??? appsettings.json          # Configuration (ignored)
??? appsettings.example.json  # Template configuration
??? setup.bat                 # Setup script
```

## ??? Database Schema

### B?ng Chính

| B?ng | Mô t? |
|------|-------|
| **Users** | Tài kho?n nhân viên |
| **Tables** | Danh sách bàn |
| **Categories** | Lo?i ?? u?ng |
| **Products** | Menu ?? u?ng |
| **Orders** | ??n hàng |
| **OrderDetails** | Chi ti?t ??n hàng |
| **Customers** | Khách hàng |
| **Inventories** | Kho nguyên li?u |
| **ImportHistories** | L?ch s? nh?p hàng |

Xem diagram: [Database Schema](docs/database-schema.png)

## ?? Các Module Chính

### 1. Module Qu?n Lý Bàn
- `FormTable.cs` - Danh sách bàn
- `Add_Table.cs` - Thêm bàn m?i
- `Delete_Table.cs` - Xóa bàn

### 2. Module Qu?n Lý Menu
- `FormDrink.cs` - Danh sách ?? u?ng
- `FormAddDrink.cs` - Thêm ?? u?ng
- `FormUpdateDrink.cs` - Qu?n lý lo?i ?? u?ng

### 3. Module ??n Hàng
- `FormMain.cs` - Giao di?n chính, qu?n lý ??n hàng
- `FormMoMoDemo.cs` - Thanh toán MoMo

### 4. Module Khách Hàng
- `FormCustomer.cs` - Danh sách khách hàng
- `AddCustomer.cs` - Thêm/S?a khách hàng
- `DeleteCustom.cs` - Xóa khách hàng

### 5. Module Báo Cáo
- `RevenueEDay.cs` - Doanh thu theo ngày
- `RevenueEmployee.cs` - Doanh thu theo nhân viên
- `FormHistory.cs` - L?ch s? hóa ??n

## ?? Troubleshooting

### L?i: "Cannot connect to SQL Server"
```bash
# Ki?m tra SQL Server ?ang ch?y
services.msc

# Ho?c dùng SQL Server Configuration Manager
```

### L?i: "Build failed"
```bash
# Clean và rebuild
dotnet clean
dotnet build
```

### L?i: "Migrations conflict"
```bash
# Xóa migrations và t?o l?i
rmdir /s Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Reset Database
```bash
dotnet ef database drop --force
dotnet ef database update
```

## ?? ?óng Góp

Contributions are welcome! Please:
1. Fork repository
2. T?o branch m?i: `git checkout -b feature/AmazingFeature`
3. Commit changes: `git commit -m 'Add AmazingFeature'`
4. Push to branch: `git push origin feature/AmazingFeature`
5. T?o Pull Request

## ?? License

This project is licensed under the MIT License - see [LICENSE](LICENSE) file for details.

## ?? Tác Gi?

- **Your Name** - *Initial work*

## ?? Acknowledgments

- Entity Framework Core team
- .NET community
- All contributors

## ?? Liên H?

- Email: your.email@example.com
- GitHub: [@yourusername](https://github.com/yourusername)

---

**Note:** File `appsettings.json` và th? m?c `Migrations/` ?ã ???c ignore trong Git ?? tránh xung ??t. M?i developer c?n t? t?o trên máy mình theo h??ng d?n trong `SETUP_DATABASE.md`.
