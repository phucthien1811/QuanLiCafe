namespace QuanLiCafe.Forms
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnThoat = new Button();
            btnDangNhap = new Button();
            txtMatKhau = new TextBox();
            label3 = new Label();
            txtMaDangNhap = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumAquamarine;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(415, 4);
            panel1.Margin = new Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(529, 102);
            panel1.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 35);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(449, 29);
            label1.TabIndex = 0;
            label1.Text = "PHẦN MỀM QUẢN LÝ QUÁN CAFE";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(2, 4);
            pictureBox1.Margin = new Padding(5, 6, 5, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(414, 486);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Blue;
            btnThoat.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(764, 422);
            btnThoat.Margin = new Padding(5, 6, 5, 6);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(161, 68);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.Red;
            btnDangNhap.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(522, 422);
            btnDangNhap.Margin = new Padding(5, 6, 5, 6);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(231, 68);
            btnDangNhap.TabIndex = 14;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(448, 304);
            txtMatKhau.Margin = new Padding(5, 6, 5, 6);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(475, 31);
            txtMatKhau.TabIndex = 13;
            txtMatKhau.Text = "123";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(442, 256);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(112, 29);
            label3.TabIndex = 12;
            label3.Text = "Mật khẩu";
            // 
            // txtMaDangNhap
            // 
            txtMaDangNhap.Location = new Point(448, 190);
            txtMaDangNhap.Margin = new Padding(5, 6, 5, 6);
            txtMaDangNhap.Name = "txtMaDangNhap";
            txtMaDangNhap.Size = new Size(475, 31);
            txtMaDangNhap.TabIndex = 11;
            txtMaDangNhap.Text = "ADMIN";
            txtMaDangNhap.TextChanged += txtMaDangNhap_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(442, 142);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 29);
            label2.TabIndex = 10;
            label2.Text = "Mã đăng nhập";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(946, 492);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(label3);
            Controls.Add(txtMaDangNhap);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnThoat;
        private Button btnDangNhap;
        private TextBox txtMatKhau;
        private Label label3;
        private TextBox txtMaDangNhap;
        private Label label2;
    }
}
