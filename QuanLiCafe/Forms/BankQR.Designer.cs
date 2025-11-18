namespace WindowsForms
{
    partial class formThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formThanhToan));
            lTenTK = new Label();
            lSoTK = new Label();
            txtTenTK = new TextBox();
            txtSoTK = new TextBox();
            picQRCODE = new PictureBox();
            lblThongtin = new Label();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)picQRCODE).BeginInit();
            SuspendLayout();
            // 
            // lTenTK
            // 
            lTenTK.AutoSize = true;
            lTenTK.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lTenTK.Location = new Point(96, 60);
            lTenTK.Name = "lTenTK";
            lTenTK.Size = new Size(109, 20);
            lTenTK.TabIndex = 0;
            lTenTK.Text = "Tên tài khoản";
            // 
            // lSoTK
            // 
            lSoTK.AutoSize = true;
            lSoTK.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lSoTK.Location = new Point(101, 107);
            lSoTK.Name = "lSoTK";
            lSoTK.Size = new Size(99, 20);
            lSoTK.TabIndex = 0;
            lSoTK.Text = "Số tài khoản";
            // 
            // txtTenTK
            // 
            txtTenTK.Location = new Point(211, 57);
            txtTenTK.Margin = new Padding(3, 4, 3, 4);
            txtTenTK.Name = "txtTenTK";
            txtTenTK.Size = new Size(201, 27);
            txtTenTK.TabIndex = 1;
            txtTenTK.Text = "NGUYEN HUU DUY";
            // 
            // txtSoTK
            // 
            txtSoTK.Location = new Point(211, 104);
            txtSoTK.Margin = new Padding(3, 4, 3, 4);
            txtSoTK.Name = "txtSoTK";
            txtSoTK.Size = new Size(201, 27);
            txtSoTK.TabIndex = 1;
            txtSoTK.Text = "0123456789";
            txtSoTK.TextChanged += txtSoTK_TextChanged;
            // 
            // picQRCODE
            // 
            picQRCODE.Image = (Image)resources.GetObject("picQRCODE.Image");
            picQRCODE.Location = new Point(126, 159);
            picQRCODE.Margin = new Padding(3, 4, 3, 4);
            picQRCODE.Name = "picQRCODE";
            picQRCODE.Size = new Size(288, 285);
            picQRCODE.SizeMode = PictureBoxSizeMode.StretchImage;
            picQRCODE.TabIndex = 2;
            picQRCODE.TabStop = false;
            // 
            // lblThongtin
            // 
            lblThongtin.AutoSize = true;
            lblThongtin.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongtin.Location = new Point(17, 19);
            lblThongtin.Name = "lblThongtin";
            lblThongtin.Size = new Size(85, 20);
            lblThongtin.TabIndex = 3;
            lblThongtin.Text = "Thông Tin";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 468);
            label1.Name = "label1";
            label1.Size = new Size(516, 20);
            label1.TabIndex = 4;
            label1.Text = "(*)Nhân viên ấn vào nút đây sau khi xác nhận thanh toán thành công";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DeepSkyBlue;
            button1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(173, 508);
            button1.Name = "button1";
            button1.Size = new Size(200, 52);
            button1.TabIndex = 5;
            button1.Text = "Đã thanh toán";
            button1.UseVisualStyleBackColor = false;
            // 
            // formThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(556, 582);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(lblThongtin);
            Controls.Add(picQRCODE);
            Controls.Add(txtSoTK);
            Controls.Add(txtTenTK);
            Controls.Add(lSoTK);
            Controls.Add(lTenTK);
            Margin = new Padding(3, 4, 3, 4);
            Name = "formThanhToan";
            Text = "Thanh toán bằng ngân hàng";
            ((System.ComponentModel.ISupportInitialize)picQRCODE).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTenTK;
        private System.Windows.Forms.Label lSoTK;
        private System.Windows.Forms.TextBox txtTenTK;
        private System.Windows.Forms.TextBox txtSoTK;
        private System.Windows.Forms.PictureBox picQRCODE;
        private Label lblThongtin;
        private Label label1;
        private Button button1;
    }
}

