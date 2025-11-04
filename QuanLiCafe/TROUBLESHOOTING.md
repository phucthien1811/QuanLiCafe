# ?? KH?C PH?C S? C?

## ? L?i Ti?ng Vi?t Hi?n Th? Sai (?, ?, ?)

### Nguyên Nhân:
File source code b? l?i encoding, không ph?i UTF-8.

### Gi?i Pháp:

#### **Cách 1: Trong Visual Studio**
1. M? file b? l?i (VD: `FormMain.cs`, `TableStatusHelper.cs`)
2. Ch?n **File ? Advanced Save Options**
3. Ch?n **Encoding: Unicode (UTF-8 with signature) - Codepage 65001**
4. Click **OK** và **Save**
5. Build l?i: `Ctrl + Shift + B`

#### **Cách 2: Xóa Build Cache và Build L?i**
```bash
# M? PowerShell trong th? m?c d? án
cd D:\HP\201_LTWD\QuanLiCafe\QuanLiCafe

# Xóa bin và obj
Remove-Item -Recurse -Force bin, obj

# Build l?i t? ??u
dotnet clean
dotnet build
dotnet run
```

#### **Cách 3: S?a Tr?c Ti?p File TableStatusHelper.cs**
M? file `Helpers/TableStatusHelper.cs` và thay th? b?ng code sau:

```csharp
using System.Drawing;

namespace QuanLiCafe.Helpers
{
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
}
```

---

## ? L?i Designer Cannot Process Code

### Nguyên Nhân:
Designer c? g?ng load database trong `InitializeComponent()`.

### Gi?i Pháp:
Di chuy?n code load data t? constructor sang s? ki?n `Form.Load`:

```csharp
public FormMain()
{
    _context = Program.DbContext;
    InitializeComponent();
    this.Load += FormMain_Load; // ? G?n event Load
}

private void FormMain_Load(object? sender, EventArgs e)
{
    LoadTables(); // ? Load data ? ?ây
}
```

---

## ? L?i Cannot Connect to Database

### Gi?i Pháp:
1. Ki?m tra SQL Server ?ang ch?y:
```powershell
Get-Service | Where-Object {$_.Name -like "*SQL*"}
```

2. L?y tên máy chính xác:
```powershell
$env:COMPUTERNAME
```

3. S?a connection string trong `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TÊN_MÁY\\SQLEXPRESS;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

4. S?a trong `CafeContextFactory.cs`:
```csharp
optionsBuilder.UseSqlServer("Server=TÊN_MÁY\\SQLEXPRESS;Database=QuanLiCafeDB;Trusted_Connection=True;TrustServerCertificate=True;");
```

5. Ch?y migration l?i:
```bash
dotnet ef database update
```

---

## ?? Liên H? H? Tr?
- GitHub Issues: [T?o issue m?i](https://github.com/yourusername/QuanLiCafe/issues)
- Email: support@quanlicafe.com
