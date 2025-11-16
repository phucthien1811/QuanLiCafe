namespace QuanLiCafe.Forms
{
    partial class FormAddUpToping
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnHuy = new Button();
            btnLuu = new Button();
            textBox4 = new TextBox();
            textBox2 = new TextBox();
            MaDoUong = new TextBox();
            lblGia = new Label();
            lblTentp = new Label();
            lblMaTP = new Label();
            Info = new Label();
            SuspendLayout();
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.Font = new Font("Times New Roman", 10.8F);
            btnHuy.ForeColor = SystemColors.ButtonFace;
            btnHuy.Location = new Point(325, 187);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(110, 50);
            btnHuy.TabIndex = 12;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DeepSkyBlue;
            btnLuu.Font = new Font("Times New Roman", 10.8F);
            btnLuu.ForeColor = SystemColors.ButtonFace;
            btnLuu.Location = new Point(187, 187);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(110, 50);
            btnLuu.TabIndex = 13;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(187, 140);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(250, 27);
            textBox4.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(187, 103);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 27);
            textBox2.TabIndex = 10;
            // 
            // MaDoUong
            // 
            MaDoUong.Location = new Point(187, 66);
            MaDoUong.Margin = new Padding(3, 4, 3, 4);
            MaDoUong.Name = "MaDoUong";
            MaDoUong.Size = new Size(250, 27);
            MaDoUong.TabIndex = 11;
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Times New Roman", 10.8F);
            lblGia.Location = new Point(49, 144);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(65, 20);
            lblGia.TabIndex = 5;
            lblGia.Text = "Giá tiền";
            // 
            // lblTentp
            // 
            lblTentp.AutoSize = true;
            lblTentp.Font = new Font("Times New Roman", 10.8F);
            lblTentp.Location = new Point(49, 106);
            lblTentp.Name = "lblTentp";
            lblTentp.Size = new Size(93, 20);
            lblTentp.TabIndex = 6;
            lblTentp.Text = "Tên Toping";
            // 
            // lblMaTP
            // 
            lblMaTP.AutoSize = true;
            lblMaTP.Font = new Font("Times New Roman", 10.8F);
            lblMaTP.Location = new Point(49, 68);
            lblMaTP.Name = "lblMaTP";
            lblMaTP.Size = new Size(96, 20);
            lblMaTP.TabIndex = 7;
            lblMaTP.Text = "Mã đồ uống";
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.Font = new Font("Times New Roman", 10.8F);
            Info.Location = new Point(12, 9);
            Info.Name = "Info";
            Info.Size = new Size(79, 20);
            Info.TabIndex = 8;
            Info.Text = "Thông tin";
            // 
            // FormAddUpToping
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(470, 262);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(MaDoUong);
            Controls.Add(lblGia);
            Controls.Add(lblTentp);
            Controls.Add(lblMaTP);
            Controls.Add(Info);
            Name = "FormAddUpToping";
            Text = "Thêm Toping";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHuy;
        private Button btnLuu;
        private TextBox textBox4;
        private TextBox textBox2;
        private TextBox MaDoUong;
        private Label lblGia;
        private Label lblTentp;
        private Label lblMaTP;
        private Label Info;
    }
}