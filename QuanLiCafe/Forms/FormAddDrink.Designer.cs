namespace DrinkForm
{
    partial class EditDrinkForm
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
            Info = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            MaDoUong = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            picHinh = new PictureBox();
            btnLuu = new Button();
            btnHuy = new Button();
            llChonHinh = new LinkLabel();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)picHinh).BeginInit();
            SuspendLayout();
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Info.Location = new Point(30, 15);
            Info.Name = "Info";
            Info.Size = new Size(92, 21);
            Info.TabIndex = 0;
            Info.Text = "Thông tin";
            Info.Click += Info_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 72);
            label1.Name = "label1";
            label1.Size = new Size(105, 21);
            label1.TabIndex = 0;
            label1.Text = "Mã đồ uống";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 138);
            label2.Name = "label2";
            label2.Size = new Size(123, 21);
            label2.TabIndex = 0;
            label2.Text = "Loại đồ uống";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 202);
            label3.Name = "label3";
            label3.Size = new Size(118, 21);
            label3.TabIndex = 0;
            label3.Text = "Tên đồ uống";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(30, 262);
            label4.Name = "label4";
            label4.Size = new Size(57, 21);
            label4.TabIndex = 0;
            label4.Text = "Mô tả";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(30, 319);
            label5.Name = "label5";
            label5.Size = new Size(77, 21);
            label5.TabIndex = 0;
            label5.Text = "Giá tiền";
            // 
            // MaDoUong
            // 
            MaDoUong.Location = new Point(299, 72);
            MaDoUong.Margin = new Padding(3, 4, 3, 4);
            MaDoUong.Name = "MaDoUong";
            MaDoUong.Size = new Size(250, 28);
            MaDoUong.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(299, 201);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 28);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(299, 260);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(250, 28);
            textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(299, 318);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(250, 28);
            textBox4.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(299, 138);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(250, 30);
            comboBox1.TabIndex = 2;
            // 
            // picHinh
            // 
            picHinh.BackColor = SystemColors.ActiveBorder;
            picHinh.Location = new Point(625, 72);
            picHinh.Margin = new Padding(3, 4, 3, 4);
            picHinh.Name = "picHinh";
            picHinh.Size = new Size(196, 196);
            picHinh.TabIndex = 3;
            picHinh.TabStop = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(0, 192, 0);
            btnLuu.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.Location = new Point(299, 378);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(124, 34);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.Location = new Point(429, 378);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 34);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += button2_Click;
            // 
            // llChonHinh
            // 
            llChonHinh.AutoSize = true;
            llChonHinh.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            llChonHinh.Location = new Point(625, 324);
            llChonHinh.Name = "llChonHinh";
            llChonHinh.Size = new Size(92, 22);
            llChonHinh.TabIndex = 5;
            llChonHinh.TabStop = true;
            llChonHinh.Text = "Chọn hình";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(740, 324);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(81, 22);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Xóa hình";
            // 
            // EditDrinkForm
            // 
            AutoScaleDimensions = new SizeF(8F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(882, 428);
            Controls.Add(linkLabel1);
            Controls.Add(llChonHinh);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(picHinh);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(MaDoUong);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Info);
            Font = new Font("Arial Narrow", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EditDrinkForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm mới đồ uống";
            Load += EditDrinkForm_Load;
            ((System.ComponentModel.ISupportInitialize)picHinh).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MaDoUong;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox picHinh;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.LinkLabel llChonHinh;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}