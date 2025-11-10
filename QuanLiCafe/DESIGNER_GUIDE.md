# ?? H??NG D?N S? D?NG DESIGNER KÉO TH?

## ? ?Ã CHUY?N FORMLOGIN SANG DESIGNER

### **C?u trúc file:**

```
QuanLiCafe/Forms/
??? FormLogin.cs              ? Code-behind (event handlers only)
??? FormLogin.Designer.cs     ? Designer generated code (UI controls)
```

---

## ?? **CÁCH S? D?NG DESIGNER**

### **B??c 1: M? Designer**

1. Trong **Solution Explorer**, double-click vào `FormLogin.cs`
2. Ho?c right-click ? **View Designer** (`Shift + F7`)

### **B??c 2: Kéo th? controls**

B?n có th?:
- ? Kéo controls t? **Toolbox** (View ? Toolbox ho?c `Ctrl + Alt + X`)
- ? Di chuy?n controls b?ng chu?t
- ? Resize controls b?ng chu?t
- ? Ch?nh properties trong **Properties Window** (`F4`)

### **B??c 3: Ch?nh s?a properties**

**Các controls hi?n có:**

| Control | Name | Properties |
|---------|------|------------|
| Panel | `panelHeader` | BackColor, Dock, Height |
| Label | `lblTitle` | Text, Font, ForeColor |
| Panel | `panelMain` | BackColor, Location, Size |
| Label | `lblUsername` | Text, Font, ForeColor |
| TextBox | `txtUsername` | BorderStyle, Font |
| Label | `lblPassword` | Text, Font, ForeColor |
| TextBox | `txtPassword` | BorderStyle, Font, UseSystemPasswordChar |
| CheckBox | `chkShowPassword` | Text, Font |
| Button | `btnLogin` | Text, Font, BackColor, ForeColor |
| Button | `btnExit` | Text, Font, BackColor, ForeColor |

---

## ?? **CH?NH S?A TRONG DESIGNER**

### **Ví d? 1: Thay ??i text c?a button**

1. Click vào `btnLogin` trong Designer
2. Trong Properties window, tìm property `Text`
3. ??i thành `"?? ??NG NH?P"` (n?u mu?n ti?ng Vi?t)
4. Save (`Ctrl + S`)

### **Ví d? 2: Thêm control m?i**

1. M? **Toolbox** (`Ctrl + Alt + X`)
2. Kéo control (VD: Label) vào form
3. Ch?nh properties trong Properties window
4. Double-click vào control ?? t?o event handler t? ??ng

### **Ví d? 3: Thay ??i màu button**

1. Click vào `btnLogin`
2. Trong Properties window, tìm `BackColor`
3. Click vào dropdown ? Ch?n màu
4. Save

---

## ?? **EVENT HANDLERS TRONG CODE-BEHIND**

File `FormLogin.cs` ch? ch?a **logic code**:

```csharp
// ? Event handlers
private void BtnLogin_Click(object sender, EventArgs e)
{
    // Logic login
}

private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
{
    // Toggle password visibility
}

// ? Hover effects
private void btnLogin_MouseEnter(object sender, EventArgs e)
{
    btnLogin.BackColor = Color.FromArgb(39, 174, 96);
}
```

---

## ?? **T?O EVENT HANDLER T? DESIGNER**

### **Cách 1: Double-click**
1. M? Designer
2. Double-click vào control (VD: Button)
3. Visual Studio t? ??ng t?o event handler trong code-behind

### **Cách 2: Properties Window**
1. Click vào control
2. Trong Properties window, click icon ? (Events)
3. Double-click vào event name (VD: `Click`)
4. Visual Studio t?o handler t? ??ng

---

## ?? **CHUY?N CÁC FORM KHÁC SANG DESIGNER**

B?n có th? làm t??ng t? v?i các form khác:

### **FormMain:**
```
FormMain.cs              ? Code-behind
FormMain.Designer.cs     ? Designer generated
```

### **FormOrder:**
```
FormOrder.cs             ? Code-behind
FormOrder.Designer.cs    ? Designer generated
```

### **FormReport:**
```
FormReport.cs            ? Code-behind
FormReport.Designer.cs   ? Designer generated
```

---

## ?? **L?U Ý QUAN TR?NG**

### **? KHÔNG NÊN:**
- S?a tr?c ti?p file `*.Designer.cs` b?ng tay
- Xóa dòng `#region Windows Form Designer generated code`
- S?a method `InitializeComponent()` trong Designer.cs

### **? NÊN:**
- Luôn s? d?ng Designer ?? ch?nh UI
- Ch? s?a event handlers trong file `*.cs`
- Dùng Properties window ?? set properties

---

## ?? **SO SÁNH: CODE TAY vs DESIGNER**

### **Code tay (nh? tr??c):**
```csharp
// FormLogin.cs
private void InitializeComponent()
{
    this.Text = "Login - Cafe Management";
    this.Size = new Size(500, 400);
    
    var btnLogin = new Button
    {
        Text = "LOGIN",
        Location = new Point(50, 300),
        Size = new Size(180, 50)
        // ... many lines
    };
    
    this.Controls.Add(btnLogin);
}
```

**?u ?i?m:**
- ? Ki?m soát hoàn toàn code
- ? D? copy-paste

**Nh??c ?i?m:**
- ? Khó visualize UI
- ? T?n th?i gian set properties

---

### **Designer kéo th? (nh? bây gi?):**

**File FormLogin.cs:**
```csharp
public partial class FormLogin : Form
{
    public FormLogin()
    {
        InitializeComponent(); // G?i code t? Designer
    }
    
    // Ch? có event handlers
    private void BtnLogin_Click(object sender, EventArgs e)
    {
        // Logic
    }
}
```

**File FormLogin.Designer.cs:**
```csharp
// Visual Studio t? ??ng generate
private void InitializeComponent()
{
    this.btnLogin = new System.Windows.Forms.Button();
    // ... Auto-generated code
}
```

**?u ?i?m:**
- ? Visualize UI tr?c quan
- ? Kéo th? nhanh
- ? Properties window ti?n l?i
- ? Auto-generate code

**Nh??c ?i?m:**
- ? Khó track changes trong Git (Designer.cs r?t dài)

---

## ?? **DEMO: THAY ??I TEXT BUTTON**

### **B??c 1:** M? Designer
```
Right-click FormLogin.cs ? View Designer
```

### **B??c 2:** Click vào `btnLogin`

### **B??c 3:** Trong Properties window (`F4`)
```
Text: ?? LOGIN
     ? ??i thành
Text: ?? ??NG NH?P
```

### **B??c 4:** Save (`Ctrl + S`)

### **B??c 5:** Build & Run
```
F5
```

**K?t qu?:** Button text ?ã thay ??i mà không c?n vi?t code!

---

## ?? **CHECKLIST CHUY?N ??I**

Khi chuy?n form sang Designer:

- [x] T?o file `Form.Designer.cs`
- [x] Di chuy?n `InitializeComponent()` sang Designer.cs
- [x] Khai báo controls ? cu?i Designer.cs
- [x] Gi? l?i event handlers trong `Form.cs`
- [x] ?ánh d?u class `partial`
- [x] Build successful
- [x] Test UI ho?t ??ng ?úng

---

## ?? **TÀI LI?U THAM KH?O**

- [Windows Forms Designer - Microsoft Docs](https://docs.microsoft.com/en-us/visualstudio/designers/windows-forms-designer)
- [Partial Classes - C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods)

---

## ? **K?T LU?N**

**FormLogin ?ã ???c chuy?n sang Designer pattern!**

B?n bây gi? có th?:
- ? M? Designer (`Shift + F7`)
- ? Kéo th? controls
- ? Ch?nh properties b?ng Properties window
- ? Double-click t?o event handlers t? ??ng
- ? Visualize UI tr?c quan

**T?t c? code logic v?n ? FormLogin.cs, còn UI ? FormLogin.Designer.cs!** ??
