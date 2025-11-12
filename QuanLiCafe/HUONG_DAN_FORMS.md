# ?? H??NG D?N LÀM VI?C V?I FORMS

## ?? L?U Ý QUAN TR?NG

D? án này có 2 lo?i forms:

### 1?? **Forms có Designer** (Có th? m? b?ng Designer)
- ? FormMain
- ? FormLogin  
- ? FormEmployee
- ? FormDrink
- ? FormAddDrink
- ? FormUpdateDrink
- ? Add_Table, Delete_Table
- ? DoanhThuTheoNgay, DoanhThuTheoNhanVien

**Cách làm vi?c:**
- Double-click vào file `.cs` ho?c `.Designer.cs` ?? m? Designer
- Kéo th? controls t? Toolbox
- Ch?nh s?a properties trong Properties window

---

### 2?? **Forms code th? công** (KHÔNG dùng Designer)
- ? FormInventory
- ? FormInventoryEdit
- ? FormImportStock
- ? FormImportHistory
- ? FormReport
- ? FormOrder

**?? QUAN TR?NG:**
- ? **KHÔNG** double-click vào `.Designer.cs`
- ? **KHÔNG** m? b?ng Designer (s? th?y màn hình tr?ng)
- ? **CH?** ch?nh s?a code trong file `.cs`
- ? **Ch?y ?ng d?ng (F5)** ?? xem giao di?n

---

## ?? H??ng d?n ch?nh s?a Forms code th? công

### Ví d?: Thay ??i màu button trong FormInventory

```csharp
private void InitializeComponent()
{
    // ...existing code...
    
    // Thay ??i màu button "Thêm NVL"
    btnAdd = CreateButton("? Thêm NVL", 15, 15, Color.FromArgb(46, 204, 113));
    //                                                             ?
    // ??i thành màu khác:    Color.Red, Color.Blue, Color.FromArgb(R, G, B)
    
    // Thay ??i kích th??c button
    btnAdd = new Button
    {
        Text = "? Thêm NVL",
        Location = new Point(15, 15),
        Size = new Size(200, 50),  // ? ??i t? 170x45 thành 200x50
        BackColor = Color.FromArgb(46, 204, 113),
        // ...
    };
}
```

### Ví d?: Thêm button m?i

```csharp
private void InitializeComponent()
{
    // ...existing code trong TOOLBAR section...
    
    // Thêm button m?i
    var btnDelete = CreateButton("??? Xóa", 1165, 15, Color.FromArgb(231, 76, 60));
    btnDelete.Click += BtnDelete_Click;
    
    // Thêm vào panel
    panelToolbar.Controls.Add(btnDelete);
    
    // ...existing code...
}

// Thêm event handler
private void BtnDelete_Click(object? sender, EventArgs e)
{
    MessageBox.Show("Xóa!");
}
```

---

## ?? Danh sách màu ??p s? d?ng trong d? án

```csharp
// Header background
Color.FromArgb(52, 73, 94)    // Xanh ??m

// Buttons
Color.FromArgb(46, 204, 113)  // Xanh lá (Success)
Color.FromArgb(52, 152, 219)  // Xanh d??ng (Primary)
Color.FromArgb(243, 156, 18)  // Cam (Warning)
Color.FromArgb(231, 76, 60)   // ?? (Danger)
Color.FromArgb(149, 165, 166) // Xám (Secondary)
Color.FromArgb(155, 89, 182)  // Tím (Info)

// Background
Color.WhiteSmoke              // N?n form
Color.White                   // N?n tr?ng
Color.FromArgb(236, 240, 241) // Xám nh?t (Alternating rows)
```

---

## ?? Ch?y ?ng d?ng

1. **M? Visual Studio**
2. **M? solution** `QuanLiCafe.sln`
3. **Nh?n F5** ho?c click nút ?? Start
4. **??ng nh?p:**
   - Username: `admin`
   - Password: `admin123`

---

## ?? C?u trúc Forms

```
Forms/
??? FormLogin.cs              ? Màn hình ??ng nh?p (có Designer)
??? FormMain.cs               ? Màn hình chính (có Designer)
??? FormEmployee.cs           ? Qu?n lý nhân viên (có Designer)
??? FormInventory.cs          ? Qu?n lý kho (code th? công) ??
?   ??? FormInventoryEdit.cs  ? Thêm/s?a nguyên li?u (code th? công) ??
?   ??? FormImportStock.cs    ? Nh?p kho (code th? công) ??
?   ??? FormImportHistory.cs  ? L?ch s? nh?p (code th? công) ??
??? FormReport.cs             ? Báo cáo (code th? công) ??
??? FormOrder.cs              ? ??t món (code th? công) ??
```

---

## ? Câu h?i th??ng g?p

### ? **T?i sao tôi m? FormInventory trong Designer nh?ng th?y màn hình tr?ng?**
? Form này s? d?ng `InitializeComponent()` th? công, không t??ng thích v?i Designer.  
? Ch? ch?nh s?a code trong file `.cs`

### ? **Làm sao ?? thêm controls vào FormInventory?**
? Vi?t code th? công trong method `InitializeComponent()`  
? Xem các ví d? phía trên

### ? **Tôi có th? chuy?n FormInventory sang dùng Designer ???c không?**
? Có th? nh?ng r?t t?n công và d? m?t code  
? Không khuy?n ngh?

### ? **Làm sao ?? xem giao di?n FormInventory?**
? Ch?y ?ng d?ng (F5) ? ??ng nh?p ? Vào menu "Danh m?c" ? "Qu?n lý kho"

---

## ?? Liên h? h? tr?

N?u c?n h? tr?, hãy liên h? team phát tri?n!
