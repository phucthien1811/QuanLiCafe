using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiCafe.Forms
{
    public partial class Toping : Form
    {
        public List<string> SelectedToppings { get; private set; } = new List<string>();
        
        private CheckBox chkTranChau;
        private CheckBox chkThachRau;
        private CheckBox chkPudding;
        private CheckBox chkThachDua;
        private CheckBox chkKemPhô;
        private CheckBox chkTrungCut;
        private Button btnXacNhan;
        private Button btnHuy;
        private Label lblTitle;
        private Label lblNote;

        public Toping()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }
        
        private void InitializeCustomComponents()
        {
            // Cấu hình form
            this.Text = "Chọn Topping";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.Wheat;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
            // Title
            lblTitle = new Label
            {
                Text = "Chọn Topping (mỗi loại +5,000đ)",
                Font = new Font("Tahoma", 12F, FontStyle.Bold),
                Location = new Point(20, 20),
                Size = new Size(350, 30),
                ForeColor = Color.DarkRed
            };
            
            // CheckBoxes
            chkTranChau = new CheckBox
            {
                Text = "Trân châu đen",
                Location = new Point(30, 70),
                Size = new Size(200, 30),
                Font = new Font("Tahoma", 10F)
            };
            
            chkThachRau = new CheckBox
            {
                Text = "Thạch rau câu",
                Location = new Point(30, 110),
                Size = new Size(200, 30),
                Font = new Font("Tahoma", 10F)
            };
            
            chkPudding = new CheckBox
            {
                Text = "Pudding",
                Location = new Point(30, 150),
                Size = new Size(200, 30),
                Font = new Font("Tahoma", 10F)
            };
            
            chkThachDua = new CheckBox
            {
                Text = "Thạch dừa",
                Location = new Point(30, 190),
                Size = new Size(200, 30),
                Font = new Font("Tahoma", 10F)
            };
            
            chkKemPhô = new CheckBox
            {
                Text = "Kem phô mai",
                Location = new Point(30, 230),
                Size = new Size(200, 30),
                Font = new Font("Tahoma", 10F)
            };
            
            chkTrungCut = new CheckBox
            {
                Text = "Trứng cút",
                Location = new Point(30, 270),
                Size = new Size(200, 30),
                Font = new Font("Tahoma", 10F)
            };
            
            // Note
            lblNote = new Label
            {
                Text = "* Có thể chọn nhiều topping",
                Font = new Font("Tahoma", 8F, FontStyle.Italic),
                Location = new Point(30, 305),
                Size = new Size(300, 20),
                ForeColor = Color.Gray
            };
            
            // Buttons
            btnXacNhan = new Button
            {
                Text = "Xác nhận",
                Location = new Point(200, 320),
                Size = new Size(80, 30),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Tahoma", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnXacNhan.Click += BtnXacNhan_Click;
            
            btnHuy = new Button
            {
                Text = "Hủy",
                Location = new Point(290, 320),
                Size = new Size(80, 30),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Tahoma", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnHuy.Click += BtnHuy_Click;
            
            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(chkTranChau);
            this.Controls.Add(chkThachRau);
            this.Controls.Add(chkPudding);
            this.Controls.Add(chkThachDua);
            this.Controls.Add(chkKemPhô);
            this.Controls.Add(chkTrungCut);
            this.Controls.Add(lblNote);
            this.Controls.Add(btnXacNhan);
            this.Controls.Add(btnHuy);
        }
        
        private void BtnXacNhan_Click(object sender, EventArgs e)
        {
            SelectedToppings.Clear();
            
            if (chkTranChau.Checked) SelectedToppings.Add("Trân châu đen");
            if (chkThachRau.Checked) SelectedToppings.Add("Thạch rau câu");
            if (chkPudding.Checked) SelectedToppings.Add("Pudding");
            if (chkThachDua.Checked) SelectedToppings.Add("Thạch dừa");
            if (chkKemPhô.Checked) SelectedToppings.Add("Kem phô mai");
            if (chkTrungCut.Checked) SelectedToppings.Add("Trứng cút");
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
