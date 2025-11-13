namespace TableForm
{
    partial class Delete_Table
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
            txb_TenBan = new TextBox();
            txb_SoBan = new TextBox();
            label_ViTri = new Label();
            label_TenBan = new Label();
            label_SoBan = new Label();
            label_ThongTin = new Label();
            SuspendLayout();
            // 
            // cb_GioiTinh
            // 
            cb_GioiTinh.FormattingEnabled = true;
            cb_GioiTinh.Location = new Point(129, 194);
            cb_GioiTinh.Margin = new Padding(3, 4, 3, 4);
            cb_GioiTinh.Name = "cb_GioiTinh";
            cb_GioiTinh.Size = new Size(365, 28);
            cb_GioiTinh.TabIndex = 42;
            // 
            // btn_luu
            // 
            btn_luu.BackColor = Color.DeepSkyBlue;
            btn_luu.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_luu.Location = new Point(383, 242);
            btn_luu.Margin = new Padding(3, 4, 3, 4);
            btn_luu.Name = "btn_luu";
            btn_luu.Size = new Size(112, 61);
            btn_luu.TabIndex = 41;
            btn_luu.Text = "Lưu";
            btn_luu.UseVisualStyleBackColor = false;
            // 
            // btn_huy
            // 
            btn_huy.BackColor = Color.Red;
            btn_huy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_huy.Location = new Point(240, 242);
            btn_huy.Margin = new Padding(3, 4, 3, 4);
            btn_huy.Name = "btn_huy";
            btn_huy.Size = new Size(112, 61);
            btn_huy.TabIndex = 40;
            btn_huy.Text = "Hủy";
            btn_huy.UseVisualStyleBackColor = false;
            // 
            // txb_TenBan
            // 
            txb_TenBan.Location = new Point(129, 149);
            txb_TenBan.Margin = new Padding(3, 4, 3, 4);
            txb_TenBan.Name = "txb_TenBan";
            txb_TenBan.Size = new Size(365, 27);
            txb_TenBan.TabIndex = 39;
            // 
            // txb_SoBan
            // 
            txb_SoBan.Location = new Point(130, 100);
            txb_SoBan.Margin = new Padding(3, 4, 3, 4);
            txb_SoBan.Name = "txb_SoBan";
            txb_SoBan.Size = new Size(365, 27);
            txb_SoBan.TabIndex = 38;
            // 
            // label_ViTri
            // 
            label_ViTri.AutoSize = true;
            label_ViTri.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ViTri.Location = new Point(44, 199);
            label_ViTri.Name = "label_ViTri";
            label_ViTri.Size = new Size(46, 20);
            label_ViTri.TabIndex = 37;
            label_ViTri.Text = "Vị trí";
            // 
            // label_TenBan
            // 
            label_TenBan.AutoSize = true;
            label_TenBan.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TenBan.Location = new Point(44, 151);
            label_TenBan.Name = "label_TenBan";
            label_TenBan.Size = new Size(69, 20);
            label_TenBan.TabIndex = 36;
            label_TenBan.Text = "Tên bàn";
            // 
            // label_SoBan
            // 
            label_SoBan.AutoSize = true;
            label_SoBan.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SoBan.Location = new Point(44, 102);
            label_SoBan.Name = "label_SoBan";
            label_SoBan.Size = new Size(59, 20);
            label_SoBan.TabIndex = 35;
            label_SoBan.Text = "Số bàn";
            // 
            // label_ThongTin
            // 
            label_ThongTin.AutoSize = true;
            label_ThongTin.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ThongTin.Location = new Point(18, 20);
            label_ThongTin.Name = "label_ThongTin";
            label_ThongTin.Size = new Size(79, 20);
            label_ThongTin.TabIndex = 34;
            label_ThongTin.Text = "Thông tin";
            // 
            // Delete_Table
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(511, 321);
            Controls.Add(cb_GioiTinh);
            Controls.Add(btn_luu);
            Controls.Add(btn_huy);
            Controls.Add(txb_TenBan);
            Controls.Add(txb_SoBan);
            Controls.Add(label_ViTri);
            Controls.Add(label_TenBan);
            Controls.Add(label_SoBan);
            Controls.Add(label_ThongTin);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Delete_Table";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xóa bàn";
            Load += Delete_Table_Load_1;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_GioiTinh;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.TextBox txb_TenBan;
        private System.Windows.Forms.TextBox txb_SoBan;
        private System.Windows.Forms.Label label_ViTri;
        private System.Windows.Forms.Label label_TenBan;
        private System.Windows.Forms.Label label_SoBan;
        private System.Windows.Forms.Label label_ThongTin;
    }
}