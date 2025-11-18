namespace win
{
    partial class PaymentT
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
            lblgiamgia = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            lblNgThucHIen = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 46);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên thực hiện";
            label1.Click += label1_Click;
            // 
            // lblgiamgia
            // 
            lblgiamgia.AutoSize = true;
            lblgiamgia.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblgiamgia.Location = new Point(21, 96);
            lblgiamgia.Name = "lblgiamgia";
            lblgiamgia.Size = new Size(138, 20);
            lblgiamgia.TabIndex = 1;
            lblgiamgia.Text = "Giảm giá (nếu có)";
            lblgiamgia.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 146);
            label3.Name = "label3";
            label3.Size = new Size(175, 20);
            label3.TabIndex = 2;
            label3.Text = "Phương thức thực hiện";
            // 
            // button1
            // 
            button1.BackColor = Color.DeepSkyBlue;
            button1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(44, 186);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(295, 68);
            button1.TabIndex = 3;
            button1.Text = "Chuyển khoản ";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.WindowFrame;
            button2.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(44, 262);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(295, 64);
            button2.TabIndex = 4;
            button2.Text = "Tiền mặt ";
            button2.UseVisualStyleBackColor = false;
            // 
            // lblNgThucHIen
            // 
            lblNgThucHIen.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNgThucHIen.Location = new Point(195, 46);
            lblNgThucHIen.Margin = new Padding(3, 4, 3, 4);
            lblNgThucHIen.Name = "lblNgThucHIen";
            lblNgThucHIen.Size = new Size(144, 28);
            lblNgThucHIen.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(195, 91);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(144, 28);
            textBox2.TabIndex = 6;
            textBox2.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(355, 93);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 7;
            label4.Text = "(%)";
            label4.Click += label4_Click;
            // 
            // PaymentT
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(401, 349);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(lblNgThucHIen);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(lblgiamgia);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PaymentT";
            Text = "Thanh Toán";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblgiamgia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox lblNgThucHIen;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}

