namespace MemberForm
{
    partial class AddCustomer
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
            cb_GioiTinh = new ComboBox();
            btn_luu = new Button();
            btn_huy = new Button();
            txb_SDT = new TextBox();
            txb_TenKhachHang = new TextBox();
            txb_MaKhachHang = new TextBox();
            label_SDT = new Label();
            label_GioiTinh = new Label();
            label_TenKhachHang = new Label();
            label_MaKhachHang = new Label();
            label_ThongTin = new Label();
            SuspendLayout();
            // 
            // cb_GioiTinh
            // 
            cb_GioiTinh.FormattingEnabled = true;
            cb_GioiTinh.Location = new Point(182, 187);
            cb_GioiTinh.Margin = new Padding(3, 4, 3, 4);
            cb_GioiTinh.Name = "cb_GioiTinh";
            cb_GioiTinh.Size = new Size(365, 28);
            cb_GioiTinh.TabIndex = 44;
            // 
            // btn_luu
            // 
            btn_luu.BackColor = Color.DeepSkyBlue;
            btn_luu.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_luu.ForeColor = SystemColors.ButtonFace;
            btn_luu.Location = new Point(414, 290);
            btn_luu.Margin = new Padding(3, 4, 3, 4);
            btn_luu.Name = "btn_luu";
            btn_luu.Size = new Size(133, 44);
            btn_luu.TabIndex = 43;
            btn_luu.Text = "Lưu";
            btn_luu.UseVisualStyleBackColor = false;
            // 
            // btn_huy
            // 
            btn_huy.BackColor = Color.Red;
            btn_huy.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_huy.ForeColor = SystemColors.ButtonFace;
            btn_huy.Location = new Point(270, 290);
            btn_huy.Margin = new Padding(3, 4, 3, 4);
            btn_huy.Name = "btn_huy";
            btn_huy.Size = new Size(138, 44);
            btn_huy.TabIndex = 42;
            btn_huy.Text = "Hủy";
            btn_huy.UseVisualStyleBackColor = false;
            btn_huy.Click += btn_huy_Click_1;
            // 
            // txb_SDT
            // 
            txb_SDT.Location = new Point(182, 239);
            txb_SDT.Margin = new Padding(3, 4, 3, 4);
            txb_SDT.Name = "txb_SDT";
            txb_SDT.Size = new Size(365, 27);
            txb_SDT.TabIndex = 41;
            // 
            // txb_TenKhachHang
            // 
            txb_TenKhachHang.Location = new Point(182, 139);
            txb_TenKhachHang.Margin = new Padding(3, 4, 3, 4);
            txb_TenKhachHang.Name = "txb_TenKhachHang";
            txb_TenKhachHang.Size = new Size(365, 27);
            txb_TenKhachHang.TabIndex = 40;
            // 
            // txb_MaKhachHang
            // 
            txb_MaKhachHang.Location = new Point(182, 87);
            txb_MaKhachHang.Margin = new Padding(3, 4, 3, 4);
            txb_MaKhachHang.Name = "txb_MaKhachHang";
            txb_MaKhachHang.Size = new Size(365, 27);
            txb_MaKhachHang.TabIndex = 39;
            // 
            // label_SDT
            // 
            label_SDT.AutoSize = true;
            label_SDT.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SDT.Location = new Point(38, 246);
            label_SDT.Name = "label_SDT";
            label_SDT.Size = new Size(103, 20);
            label_SDT.TabIndex = 38;
            label_SDT.Text = "Số điện thoại";
            // 
            // label_GioiTinh
            // 
            label_GioiTinh.AutoSize = true;
            label_GioiTinh.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GioiTinh.Location = new Point(38, 198);
            label_GioiTinh.Name = "label_GioiTinh";
            label_GioiTinh.Size = new Size(73, 20);
            label_GioiTinh.TabIndex = 37;
            label_GioiTinh.Text = "Giới tính";
            // 
            // label_TenKhachHang
            // 
            label_TenKhachHang.AutoSize = true;
            label_TenKhachHang.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TenKhachHang.Location = new Point(38, 146);
            label_TenKhachHang.Name = "label_TenKhachHang";
            label_TenKhachHang.Size = new Size(125, 20);
            label_TenKhachHang.TabIndex = 36;
            label_TenKhachHang.Text = "Tên khách hàng";
            // 
            // label_MaKhachHang
            // 
            label_MaKhachHang.AutoSize = true;
            label_MaKhachHang.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_MaKhachHang.Location = new Point(38, 87);
            label_MaKhachHang.Name = "label_MaKhachHang";
            label_MaKhachHang.Size = new Size(120, 20);
            label_MaKhachHang.TabIndex = 35;
            label_MaKhachHang.Text = "Mã khách hàng";
            // 
            // label_ThongTin
            // 
            label_ThongTin.AutoSize = true;
            label_ThongTin.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ThongTin.Location = new Point(12, 31);
            label_ThongTin.Name = "label_ThongTin";
            label_ThongTin.Size = new Size(79, 20);
            label_ThongTin.TabIndex = 34;
            label_ThongTin.Text = "Thông tin";
            // 
            // AddCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Wheat;
            ClientSize = new Size(570, 349);
            Controls.Add(cb_GioiTinh);
            Controls.Add(btn_luu);
            Controls.Add(btn_huy);
            Controls.Add(txb_SDT);
            Controls.Add(txb_TenKhachHang);
            Controls.Add(txb_MaKhachHang);
            Controls.Add(label_SDT);
            Controls.Add(label_GioiTinh);
            Controls.Add(label_TenKhachHang);
            Controls.Add(label_MaKhachHang);
            Controls.Add(label_ThongTin);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddCustomer";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm khách hàng";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_GioiTinh;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.TextBox txb_SDT;
        private System.Windows.Forms.TextBox txb_TenKhachHang;
        private System.Windows.Forms.TextBox txb_MaKhachHang;
        private System.Windows.Forms.Label label_SDT;
        private System.Windows.Forms.Label label_GioiTinh;
        private System.Windows.Forms.Label label_TenKhachHang;
        private System.Windows.Forms.Label label_MaKhachHang;
        private System.Windows.Forms.Label label_ThongTin;
    }
}