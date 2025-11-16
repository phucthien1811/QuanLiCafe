namespace QuanLiCafe.Forms
{
    partial class FormAddUpTypeDrink
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
            textBox2 = new TextBox();
            MaDoUong = new TextBox();
            lbltenloai = new Label();
            lblmaloai = new Label();
            Info = new Label();
            SuspendLayout();
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.Font = new Font("Times New Roman", 10.8F);
            btnHuy.ForeColor = SystemColors.ButtonFace;
            btnHuy.Location = new Point(279, 157);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(110, 50);
            btnHuy.TabIndex = 10;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.DeepSkyBlue;
            btnLuu.Font = new Font("Times New Roman", 10.8F);
            btnLuu.ForeColor = SystemColors.ButtonFace;
            btnLuu.Location = new Point(141, 157);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(110, 50);
            btnLuu.TabIndex = 11;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(141, 106);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 27);
            textBox2.TabIndex = 8;
            // 
            // MaDoUong
            // 
            MaDoUong.Location = new Point(141, 66);
            MaDoUong.Margin = new Padding(3, 4, 3, 4);
            MaDoUong.Name = "MaDoUong";
            MaDoUong.Size = new Size(250, 27);
            MaDoUong.TabIndex = 9;
            // 
            // lbltenloai
            // 
            lbltenloai.AutoSize = true;
            lbltenloai.Font = new Font("Times New Roman", 10.8F);
            lbltenloai.Location = new Point(49, 108);
            lbltenloai.Name = "lbltenloai";
            lbltenloai.Size = new Size(73, 20);
            lbltenloai.TabIndex = 5;
            lbltenloai.Text = "Tên loại ";
            // 
            // lblmaloai
            // 
            lblmaloai.AutoSize = true;
            lblmaloai.Font = new Font("Times New Roman", 10.8F);
            lblmaloai.Location = new Point(49, 68);
            lblmaloai.Name = "lblmaloai";
            lblmaloai.Size = new Size(68, 20);
            lblmaloai.TabIndex = 6;
            lblmaloai.Text = "Mã loại ";
            // 
            // Info
            // 
            Info.AutoSize = true;
            Info.Font = new Font("Times New Roman", 10.8F);
            Info.Location = new Point(12, 9);
            Info.Name = "Info";
            Info.Size = new Size(79, 20);
            Info.TabIndex = 7;
            Info.Text = "Thông tin";
            // 
            // FormAddUpTypeDrink
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(436, 220);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(textBox2);
            Controls.Add(MaDoUong);
            Controls.Add(lbltenloai);
            Controls.Add(lblmaloai);
            Controls.Add(Info);
            Name = "FormAddUpTypeDrink";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm loại đồ uống";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHuy;
        private Button btnLuu;
        private TextBox textBox2;
        private TextBox MaDoUong;
        private Label lbltenloai;
        private Label lblmaloai;
        private Label Info;
    }
}