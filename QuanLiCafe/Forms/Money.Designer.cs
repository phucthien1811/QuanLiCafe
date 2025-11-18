namespace win
{
    partial class Money
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblTong = new Label();
            button1 = new Button();
            txbchitietsanpham = new TextBox();
            txbGiamgia = new TextBox();
            txbTienKHDua = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txbTienThoi = new TextBox();
            label8 = new Label();
            label5 = new Label();
            txbTong = new TextBox();
            lblthongtinduoi = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(67, 35);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(67, 86);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 1;
            label2.Text = "Tiền khách đưa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(67, 137);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Giảm giá";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(67, 239);
            label4.Name = "label4";
            label4.Size = new Size(135, 20);
            label4.TabIndex = 3;
            label4.Text = "Chi tiết sản phẩm";
            // 
            // lblTong
            // 
            lblTong.AutoSize = true;
            lblTong.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTong.Location = new Point(70, 392);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(51, 20);
            lblTong.TabIndex = 4;
            lblTong.Text = "Tổng:";
            // 
            // button1
            // 
            button1.BackColor = Color.DeepSkyBlue;
            button1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(247, 480);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(193, 68);
            button1.TabIndex = 5;
            button1.Text = "Dã thanh toán";
            button1.UseVisualStyleBackColor = false;
            // 
            // txbchitietsanpham
            // 
            txbchitietsanpham.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbchitietsanpham.Location = new Point(255, 244);
            txbchitietsanpham.Margin = new Padding(3, 4, 3, 4);
            txbchitietsanpham.Multiline = true;
            txbchitietsanpham.Name = "txbchitietsanpham";
            txbchitietsanpham.Size = new Size(185, 134);
            txbchitietsanpham.TabIndex = 8;
            txbchitietsanpham.Text = "Cà Phê Đen";
            txbchitietsanpham.TextChanged += textBox3_TextChanged;
            // 
            // txbGiamgia
            // 
            txbGiamgia.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbGiamgia.Location = new Point(255, 133);
            txbGiamgia.Margin = new Padding(3, 4, 3, 4);
            txbGiamgia.Name = "txbGiamgia";
            txbGiamgia.Size = new Size(185, 28);
            txbGiamgia.TabIndex = 9;
            txbGiamgia.Text = "0";
            txbGiamgia.TextChanged += textBox4_TextChanged;
            // 
            // txbTienKHDua
            // 
            txbTienKHDua.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbTienKHDua.Location = new Point(255, 79);
            txbTienKHDua.Margin = new Padding(3, 4, 3, 4);
            txbTienKHDua.Name = "txbTienKHDua";
            txbTienKHDua.Size = new Size(185, 28);
            txbTienKHDua.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(457, 139);
            label6.Name = "label6";
            label6.Size = new Size(36, 20);
            label6.TabIndex = 11;
            label6.Text = "(%)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(457, 84);
            label7.Name = "label7";
            label7.Size = new Size(47, 20);
            label7.TabIndex = 12;
            label7.Text = "VND";
            // 
            // txbTienThoi
            // 
            txbTienThoi.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbTienThoi.Location = new Point(255, 186);
            txbTienThoi.Margin = new Padding(3, 4, 3, 4);
            txbTienThoi.Name = "txbTienThoi";
            txbTienThoi.Size = new Size(185, 28);
            txbTienThoi.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(67, 188);
            label8.Name = "label8";
            label8.Size = new Size(80, 20);
            label8.TabIndex = 14;
            label8.Text = "Tiền Thối";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(6, 435);
            label5.Name = "label5";
            label5.Size = new Size(516, 20);
            label5.TabIndex = 15;
            label5.Text = "(*)Nhân viên ấn vào nút đây sau khi xác nhận thanh toán thành công";
            // 
            // txbTong
            // 
            txbTong.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbTong.Location = new Point(255, 392);
            txbTong.Margin = new Padding(3, 4, 3, 4);
            txbTong.Name = "txbTong";
            txbTong.Size = new Size(185, 28);
            txbTong.TabIndex = 16;
            // 
            // lblthongtinduoi
            // 
            lblthongtinduoi.AutoSize = true;
            lblthongtinduoi.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblthongtinduoi.Location = new Point(36, 24);
            lblthongtinduoi.Name = "lblthongtinduoi";
            lblthongtinduoi.Size = new Size(403, 20);
            lblthongtinduoi.TabIndex = 17;
            lblthongtinduoi.Text = "Nhân viên vui lòng điền chính xác thông tin dưới đây";
            // 
            // Money
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(534, 561);
            Controls.Add(lblthongtinduoi);
            Controls.Add(txbTong);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(txbTienThoi);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txbTienKHDua);
            Controls.Add(txbGiamgia);
            Controls.Add(txbchitietsanpham);
            Controls.Add(button1);
            Controls.Add(lblTong);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Money";
            Text = "VND";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbchitietsanpham;
        private System.Windows.Forms.TextBox txbGiamgia;
        private System.Windows.Forms.TextBox txbTienKHDua;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private TextBox txbTienThoi;
        private Label label8;
        private Label label5;
        private TextBox txbTong;
        private Label lblthongtinduoi;
    }
}