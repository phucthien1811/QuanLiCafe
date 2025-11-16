namespace QuanLiCafe.Forms
{
    partial class Introduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Introduct));
            pictureBox2 = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(324, -2);
            pictureBox2.Margin = new Padding(0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(139, 139);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label7.Location = new Point(44, 198);
            label7.Name = "label7";
            label7.Size = new Size(131, 20);
            label7.TabIndex = 13;
            label7.Text = "Huỳnh Gia Bảo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label8.Location = new Point(44, 163);
            label8.Name = "label8";
            label8.Size = new Size(191, 20);
            label8.TabIndex = 12;
            label8.Text = "Đỗ Nguyễn Trọng Phúc";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            label9.Location = new Point(44, 128);
            label9.Name = "label9";
            label9.Size = new Size(174, 20);
            label9.TabIndex = 11;
            label9.Text = "Trần Lê Minh Quang";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(44, 93);
            label10.Name = "label10";
            label10.Size = new Size(145, 20);
            label10.TabIndex = 10;
            label10.Text = "Nguyễn Hữu Duy";
            label10.Click += label10_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(44, 58);
            label11.Name = "label11";
            label11.Size = new Size(202, 20);
            label11.TabIndex = 9;
            label11.Text = "Nguyễn Trần Phúc Thiên";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.Location = new Point(12, 18);
            label12.Name = "label12";
            label12.Size = new Size(226, 20);
            label12.TabIndex = 8;
            label12.Text = "Đội ngũ phát triển phần mềm";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic);
            label1.Location = new Point(28, 234);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 14;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(81, 234);
            label2.Name = "label2";
            label2.Size = new Size(193, 20);
            label2.TabIndex = 15;
            label2.Text = "4399support@gmail.com";
            // 
            // Introduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(461, 270);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(pictureBox2);
            Name = "Introduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giới thiệu";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label1;
        private Label label2;
    }
}