# ?? H??NG D?N S?A L?I K?T N?I SQL SERVER

## ? L?i Th??ng G?p

```
A network-related or instance-specific error occurred while establishing 
a connection to SQL Server. The server was not found or was not accessible.
```

---

## ? GI?I PHÁP

### **1?? S? D?ng `localhost` thay vì Tên Máy**

? **SAI:**
```csharp
optionsBuilder.UseSqlServer("Server=LAPTOP-PHUCTHIE\\SQLEXPRESS;...");
```

? **?ÚNG:**
```csharp
optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
```

---

### **2?? Các L?a Ch?n Connection String**

#### **Option 1: localhost (Khuy?n ngh?)**
```
Server=localhost\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;
```

#### **Option 2: (local)**
```
Server=(local)\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;
```

#### **Option 3: . (d?u ch?m)**
```
Server=.\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;
```

#### **Option 4: (LocalDB) - N?u dùng LocalDB**
```
Server=(localdb)\MSSQLLocalDB;Database=CafeDB;Trusted_Connection=True;
```

---

## ?? KI?M TRA SQL SERVER

### **B??c 1: Ki?m tra SQL Server ?ang ch?y**

M? PowerShell và ch?y:
```powershell
Get-Service | Where-Object {$_.Name -like "*SQL*"}
```

**K?t qu? mong ??i:**
```
Name                     Status
----                     ------
MSSQL$SQLEXPRESS        Running  ?
SQLAgent$SQLEXPRESS     Stopped   ?? (không c?n thi?t)
```

### **B??c 2: Start SQL Server n?u b? Stopped**

```powershell
Start-Service MSSQL$SQLEXPRESS
```

---

## ??? V? TRÍ C?N S?A TRONG PROJECT

### **1. File `CafeContext.cs`**

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"
        );
    }
}
```

### **2. File `appsettings.json` (n?u có)**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CafeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"
  }
}
```

---

## ?? KI?M TRA K?T N?I

### **Test v?i EF Core CLI:**

```powershell
cd "D:\1.H?c Ph?n\201_LTWD\QuanLiCafe\QuanLiCafe"
dotnet ef dbcontext info
```

**K?t qu? thành công:**
```
Database provider: Microsoft.EntityFrameworkCore.SqlServer
Database server: localhost\SQLEXPRESS
Database name: CafeDB
```

### **Test v?i SQL Server Management Studio:**

1. M? SSMS
2. Server name: `localhost\SQLEXPRESS` ho?c `.\\SQLEXPRESS`
3. Authentication: **Windows Authentication**
4. Click **Connect**

---

## ?? L?U Ý QUAN TR?NG

### **1. Thêm `Encrypt=False;` vào Connection String**

T? .NET 6 tr? ?i, Microsoft b?t bu?c mã hóa k?t n?i. N?u SQL Server không h? tr? SSL, c?n thêm:

```
TrustServerCertificate=True;Encrypt=False;
```

### **2. T?t Firewall n?u c?n**

N?u v?n l?i, t?m th?i t?t Windows Firewall:
```
Control Panel ? Windows Defender Firewall ? Turn off
```

### **3. Enable TCP/IP Protocol**

1. M? **SQL Server Configuration Manager**
2. SQL Server Network Configuration ? Protocols for SQLEXPRESS
3. Enable **TCP/IP**
4. Restart SQL Server

---

## ?? MIGRATION V?I CONNECTION ?ÚNG

Sau khi s?a connection string, ch?y migration:

```powershell
# Xóa database c? (n?u c?n)
dotnet ef database drop --force

# T?o l?i database
dotnet ef database update
```

---

## ?? TÓM T?T

? **?ã s?a:**
- Connection string t? `LAPTOP-PHUCTHIE\SQLEXPRESS` ? `localhost\SQLEXPRESS`
- Thêm `Encrypt=False;` ?? tránh l?i SSL

? **K?t qu?:**
- ?ng d?ng k?t n?i thành công t?i SQL Server
- Migration ch?y không l?i
- FormLogin, FormMain ho?t ??ng bình th??ng

---

**Ngày c?p nh?t:** 12/11/2024  
**Ng??i th?c hi?n:** GitHub Copilot
