# ?? L?NH CLI - QU?N LÝ D? ÁN

## ?? CÀI ??T PACKAGES

```bash
# Entity Framework Core SQL Server
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.11

# Entity Framework Core Tools (cho migrations)
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.11

# Configuration JSON
dotnet add package Microsoft.Extensions.Configuration.Json --version 8.0.1
```

---

## ??? ENTITY FRAMEWORK MIGRATIONS

### **Cài ??t EF Core Tools (Global)**
```bash
dotnet tool install --global dotnet-ef
```

### **Ki?m Tra Phiên B?n**
```bash
dotnet ef --version
```

### **T?o Migration M?i**
```bash
# T?o migration ??u tiên
dotnet ef migrations add InitialCreate

# T?o migration ti?p theo (sau khi s?a model)
dotnet ef migrations add AddNewFeature
```

### **Xem Danh Sách Migrations**
```bash
dotnet ef migrations list
```

### **Áp D?ng Migration (T?o/Update Database)**
```bash
# Update lên migration m?i nh?t
dotnet ef database update

# Update lên migration c? th?
dotnet ef database update InitialCreate
```

### **Rollback Migration**
```bash
# Quay l?i migration tr??c ?ó
dotnet ef database update PreviousMigrationName

# Rollback t?t c? (xóa database)
dotnet ef database update 0
```

### **Xóa Migration Cu?i Cùng**
```bash
dotnet ef migrations remove
```

### **Xóa Database**
```bash
dotnet ef database drop
```

### **T?o Script SQL t? Migration**
```bash
# T?o script t? ??u ??n hi?n t?i
dotnet ef migrations script -o migration.sql

# T?o script t? migration A ??n B
dotnet ef migrations script FromMigration ToMigration -o partial.sql
```

---

## ??? BUILD VÀ RUN

### **Build D? Án**
```bash
# Build debug
dotnet build

# Build release
dotnet build --configuration Release
```

### **Ch?y ?ng D?ng**
```bash
# Ch?y trong ch? ?? debug
dotnet run

# Ch?y v?i c?u hình release
dotnet run --configuration Release
```

### **Clean Build**
```bash
dotnet clean
```

### **Restore Packages**
```bash
dotnet restore
```

---

## ??? QU?N LÝ PROJECT

### **T?o Project M?i**
```bash
# T?o WinForms project
dotnet new winforms -n QuanLiCafe -f net8.0

# T?o class library
dotnet new classlib -n QuanLiCafe.Core
```

### **Add Reference**
```bash
# Thêm reference ??n project khác
dotnet add reference ../QuanLiCafe.Core/QuanLiCafe.Core.csproj
```

### **List References**
```bash
dotnet list reference
```

---

## ??? SQL SERVER COMMANDS (PowerShell)

### **Ki?m Tra SQL Server Service**
```powershell
# Xem t?t c? SQL services
Get-Service | Where-Object {$_.Name -like "*SQL*"}

# Start SQL Server
Start-Service MSSQL$SQLEXPRESS

# Stop SQL Server
Stop-Service MSSQL$SQLEXPRESS
```

### **L?y Tên Máy (Computer Name)**
```powershell
$env:COMPUTERNAME
```

### **L?y Danh Sách SQL Instances**
```powershell
(Get-ItemProperty 'HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server').InstalledInstances
```

---

## ?? TESTING

### **Ch?y Unit Tests**
```bash
dotnet test
```

### **Ch?y Tests v?i Coverage**
```bash
dotnet test --collect:"XPlat Code Coverage"
```

---

## ?? GIT COMMANDS (N?u Dùng Git)

### **Initialize Repository**
```bash
git init
git add .
git commit -m "Initial commit - Cafe Management System"
```

### **Gitignore .NET**
```bash
# T?i .gitignore cho .NET
curl -o .gitignore https://raw.githubusercontent.com/github/gitignore/main/VisualStudio.gitignore
```

### **Common Git Commands**
```bash
# Check status
git status

# Add files
git add .

# Commit
git commit -m "Add FormMain and FormOrder"

# Push to remote
git push origin main
```

---

## ?? TROUBLESHOOTING COMMANDS

### **Xem Connection String Hi?n T?i**
```bash
# Trong PowerShell
Get-Content appsettings.json | Select-String "DefaultConnection"
```

### **Test Database Connection**
```bash
# Dùng sqlcmd
sqlcmd -S LAPTOP-PHUCTHIE\SQLEXPRESS -E -Q "SELECT @@VERSION"
```

### **Clear NuGet Cache**
```bash
dotnet nuget locals all --clear
```

### **Rebuild t? ??u**
```bash
dotnet clean
dotnet restore
dotnet build
```

---

## ?? SEED DATA COMMANDS

### **Ch?y Seed Data B?ng Code**
```csharp
// Trong Program.cs ho?c t?o file riêng
using (var context = new CafeContext())
{
    // Xóa data c?
    context.Database.EnsureDeleted();
    
    // T?o l?i database
    context.Database.EnsureCreated();
    
    // Ho?c dùng migrations
    context.Database.Migrate();
}
```

### **Script SQL Seed Manual**
```sql
-- Ch?y trong SQL Server Management Studio
USE QuanLiCafeDB;

-- Thêm bàn
INSERT INTO Tables (Name, Status) 
VALUES ('Bàn 1', 'Free'), ('Bàn 2', 'Free');

-- Thêm categories
INSERT INTO Categories (Name) 
VALUES (N'Cà phê'), (N'Trà s?a');

-- Thêm products
INSERT INTO Products (Name, Price, CategoryId) 
VALUES (N'Cà phê ?en', 25000, 1);
```

---

## ?? PUBLISH APPLICATION

### **Publish Self-Contained**
```bash
# Windows x64
dotnet publish -c Release -r win-x64 --self-contained

# Windows x86
dotnet publish -c Release -r win-x86 --self-contained
```

### **Publish Framework-Dependent**
```bash
dotnet publish -c Release
```

### **T?o Single File Executable**
```bash
dotnet publish -c Release -r win-x64 /p:PublishSingleFile=true --self-contained
```

---

## ?? BACKUP & RESTORE DATABASE

### **Backup Database**
```sql
BACKUP DATABASE QuanLiCafeDB 
TO DISK = 'C:\Backup\QuanLiCafeDB.bak'
WITH FORMAT;
```

### **Restore Database**
```sql
RESTORE DATABASE QuanLiCafeDB 
FROM DISK = 'C:\Backup\QuanLiCafeDB.bak'
WITH REPLACE;
```

---

## ?? QUICK START SCRIPT

T?o file `start.ps1`:

```powershell
# Quick Start Script
Write-Host "?? Starting Cafe Management System..." -ForegroundColor Green

# Check if database exists
Write-Host "?? Checking database..." -ForegroundColor Yellow
dotnet ef database update

# Build project
Write-Host "?? Building project..." -ForegroundColor Yellow
dotnet build

# Run application
Write-Host "?? Running application..." -ForegroundColor Green
dotnet run
```

Ch?y:
```powershell
.\start.ps1
```

---

**?? HOÀN T?T! D? án s?n sàng ch?y.**
