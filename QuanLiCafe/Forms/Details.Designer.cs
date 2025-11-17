namespace QuanLiCafe.Forms
{
    partial class Details
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
            panel1 = new Panel();
            lblloai = new Label();
            tbxToping = new TextBox();
            nmSoLuong = new NumericUpDown();
            label7 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            button1 = new Button();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button2 = new Button();
            label8 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblloai);
            panel1.Controls.Add(tbxToping);
            panel1.Controls.Add(nmSoLuong);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(17, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 580);
            panel1.TabIndex = 0;
            // 
            // lblloai
            // 
            lblloai.AutoSize = true;
            lblloai.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblloai.Location = new Point(232, 297);
            lblloai.Name = "lblloai";
            lblloai.Size = new Size(34, 20);
            lblloai.TabIndex = 592;
            lblloai.Text = "loại";
            // 
            // tbxToping
            // 
            tbxToping.Location = new Point(35, 327);
            tbxToping.Name = "tbxToping";
            tbxToping.Size = new Size(429, 27);
            tbxToping.TabIndex = 591;
            // 
            // nmSoLuong
            // 
            nmSoLuong.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nmSoLuong.Location = new Point(323, 75);
            nmSoLuong.Margin = new Padding(4, 5, 4, 5);
            nmSoLuong.Name = "nmSoLuong";
            nmSoLuong.Size = new Size(81, 27);
            nmSoLuong.TabIndex = 590;
            nmSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label7.Location = new Point(31, 367);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 13;
            label7.Text = "Mô tả";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(31, 401);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(433, 66);
            textBox2.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label6.Location = new Point(31, 297);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 11;
            label6.Text = "Toping";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(31, 503);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(433, 56);
            textBox1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label5.Location = new Point(31, 480);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 9;
            label5.Text = "Ghi chú:";
            // 
            // button1
            // 
            button1.Location = new Point(95, 293);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "Chọn";
            button1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(361, 251);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(54, 24);
            radioButton3.TabIndex = 7;
            radioButton3.TabStop = true;
            radioButton3.Text = "Lớn";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(202, 251);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(56, 24);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
            radioButton2.Text = "Vừa";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(39, 251);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(58, 24);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "Nhỏ";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 218);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 4;
            label4.Text = "Chọn Size:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label3.Location = new Point(232, 132);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 3;
            label3.Text = "Giá:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label2.Location = new Point(232, 75);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 2;
            label2.Text = "Số lượng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label1.Location = new Point(232, 20);
            label1.Name = "label1";
            label1.Size = new Size(43, 20);
            label1.TabIndex = 1;
            label1.Text = "Tên:";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(35, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(157, 158);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            button2.Location = new Point(396, 612);
            button2.Name = "button2";
            button2.Size = new Size(122, 34);
            button2.TabIndex = 1;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label8.Location = new Point(31, 619);
            label8.Name = "label8";
            label8.Size = new Size(59, 20);
            label8.TabIndex = 2;
            label8.Text = "Tổng: ";
            // 
            // Details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(550, 659);
            Controls.Add(label8);
            Controls.Add(button2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Details";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết sản phẩm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextBox textBox1;
        private Label label5;
        private Button button1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button2;
        private TextBox textBox2;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown nmSoLuong;
        private TextBox tbxToping;
        private Label label9;
        private Label lblloai;
    }
}