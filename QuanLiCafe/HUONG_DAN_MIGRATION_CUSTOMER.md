# H??NG D?N MIGRATION - THÊM B?NG KHÁCH HÀNG

## T?ng Quan
File này h??ng d?n cách th?c hi?n migration ?? thêm b?ng `Customers` (Khách hàng) vào database.

---

## B??c 1: Ki?m Tra Model Customer

??m b?o file `QuanLiCafe/Models/Customer.cs` ?ã ???c t?o v?i n?i dung:

```csharp
using System.ComponentModel.DataAnnotations;

namespace QuanLiCafe.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? Gender { get; set; } // Nam, N?, Khác

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
```

---

## B??c 2: Ki?m Tra DbContext

??m b?o `CafeContext.cs` ?ã thêm:

1. **DbSet Customer:**
```csharp
public DbSet<Customer> Customers { get; set; }
```

2. **C?u hình trong OnModelCreating:**
```csharp
// Customer Configuration
modelBuilder.Entity<Customer>(entity =>
{
    entity.ToTable("Customers");
    entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
    entity.Property(e => e.Gender).HasMaxLength(10);
    entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
    entity.HasIndex(e => e.PhoneNumber); // Index cho tìm ki?m nhanh
});
```

---

## B??c 3: T?o Migration

M? Terminal/PowerShell và ch?y l?nh:

```bash
cd D:\win_CK\QuanLiCafe
dotnet ef migrations add AddCustomerTable
```

**K?t qu?:**
- T?o file migration m?i trong th? m?c `Migrations/`
- Tên file: `20XXXXXX_AddCustomerTable.cs`

### N?i Dung Migration T?o Ra:

```csharp
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.CreateTable(
        name: "Customers",
        columns: table => new
        {
            Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
            PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Customers", x => x.Id);
        });

    migrationBuilder.CreateIndex(
        name: "IX_Customers_PhoneNumber",
        table: "Customers",
        column: "PhoneNumber");
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropTable(name: "Customers");
}
```

---

## B??c 4: Áp D?ng Migration Vào Database

```bash
dotnet ef database update
```

**K?t qu?:**
- T?o b?ng `Customers` trong database `CafeDB`
- T?o index trên c?t `PhoneNumber`

---

## B??c 5: Ki?m Tra Database

### S? d?ng SQL Server Management Studio (SSMS):

1. K?t n?i ??n server: `DESKTOP-B04TJ4O\SQLEXPRESS`
2. M? database `CafeDB`
3. Ki?m tra b?ng `Customers` trong Tables

### S? d?ng Command Line:

```bash
dotnet ef dbcontext scaffold "Server=DESKTOP-B04TJ4O\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir ModelsTemp --context-dir ContextTemp --force
```

---

## C?u Trúc B?ng Customers

| C?t | Ki?u D? Li?u | Ghi Chú |
|-----|-------------|---------|
| Id | int (PK, Identity) | Mã khách hàng t? t?ng |
| Name | nvarchar(100) NOT NULL | Tên khách hàng |
| Gender | nvarchar(10) NULL | Gi?i tính (Nam/N?/Khác) |
| PhoneNumber | nvarchar(15) NOT NULL | S? ?i?n tho?i (có index) |

---

## X? Lý L?i Th??ng G?p

### L?i 1: "Build failed"
**Nguyên nhân:** Code có l?i syntax ho?c thi?u using

**Gi?i pháp:**
```bash
dotnet clean
dotnet build
# Ki?m tra l?i và s?a
dotnet ef migrations add AddCustomerTable
```

### L?i 2: "A migration named 'AddCustomerTable' already exists"
**Nguyên nhân:** Migration ?ã t?n t?i

**Gi?i pháp:**
```bash
# Xóa migration c?
dotnet ef migrations remove

# Ho?c t?o migration m?i v?i tên khác
dotnet ef migrations add AddCustomerTableV2
```

### L?i 3: "Unable to connect to database"
**Nguyên nhân:** Connection string sai ho?c SQL Server không ch?y

**Gi?i pháp:**
1. Ki?m tra SQL Server ?ang ch?y
2. Ki?m tra connection string trong `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-B04TJ4O\\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### L?i 4: "The entity type 'Customer' requires a primary key"
**Nguyên nhân:** Thi?u [Key] attribute

**Gi?i pháp:**
Thêm `[Key]` tr??c thu?c tính Id trong model Customer

---

## Rollback Migration (Quay L?i Tr?ng Thái Tr??c)

### Xóa Migration Ch?a Apply:
```bash
dotnet ef migrations remove
```

### Rollback Migration ?ã Apply:
```bash
# Quay l?i migration tr??c ?ó
dotnet ef database update <TenMigrationTruocDo>

# Ví d?: Quay l?i InitialCreate
dotnet ef database update InitialCreate

# Sau ?ó xóa migration
dotnet ef migrations remove
```

---

## Ki?m Tra Ho?t ??ng C?a Forms

Sau khi migration thành công, ki?m tra các ch?c n?ng:

1. **M? FormCustomer:**
   - Menu Main ? Khách hàng ? Hi?n th? danh sách (r?ng ban ??u)

2. **Thêm Khách Hàng:**
   - Click nút "Thêm"
   - Nh?p: Tên, Gi?i tính, S? ?i?n tho?i
   - Click "L?u"
   - Ki?m tra danh sách ?ã có khách hàng m?i

3. **S?a Khách Hàng:**
   - Ch?n 1 khách hàng trong danh sách
   - Click nút "S?a"
   - Thay ??i thông tin
   - Click "L?u"

4. **Xóa Khách Hàng:**
   - Ch?n 1 khách hàng trong danh sách
   - Click nút "Xóa"
   - Xác nh?n xóa

5. **Tìm Ki?m:**
   - Nh?p s? ?i?n tho?i vào ô tìm ki?m
   - Click "Tìm ki?m"

---

## Seed D? Li?u M?u (Tùy Ch?n)

N?u mu?n thêm d? li?u m?u, thêm vào `SeedData()` trong `CafeContext.cs`:

```csharp
// Seed Customers
modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = 1, Name = "Nguy?n V?n A", Gender = "Nam", PhoneNumber = "0901234567" },
    new Customer { Id = 2, Name = "Tr?n Th? B", Gender = "N?", PhoneNumber = "0912345678" },
    new Customer { Id = 3, Name = "Lê V?n C", Gender = "Nam", PhoneNumber = "0923456789" }
);
```

Sau ?ó t?o migration m?i:
```bash
dotnet ef migrations add SeedCustomerData
dotnet ef database update
```

---

## L?nh H?u Ích

```bash
# Xem danh sách migrations
dotnet ef migrations list

# T?o script SQL t? migration
dotnet ef migrations script --output migration.sql

# Xem thông tin database hi?n t?i
dotnet ef dbcontext info

# Drop database (c?n th?n!)
dotnet ef database drop --force

# T?o l?i database t? ??u
dotnet ef database drop --force
dotnet ef database update
```

---

## Tài Li?u Tham Kh?o

- [Entity Framework Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [Connection Strings](https://www.connectionstrings.com/sql-server/)
- [EF Core CLI Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

---

## Ghi Chú

- Migration ?ã ???c th?c hi?n thành công vào ngày t?o
- B?ng Customers ?ã ???c t?o v?i index trên PhoneNumber
- Các form qu?n lý khách hàng ?ã ho?t ??ng ??y ??
- D? li?u ???c l?u tr? trong SQL Server Express

---

**Tác gi?:** GitHub Copilot  
**Ngày t?o:** 2024  
**Phiên b?n:** 1.0
