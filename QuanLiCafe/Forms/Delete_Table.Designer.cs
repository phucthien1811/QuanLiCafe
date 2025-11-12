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
            this.cb_GioiTinh = new System.Windows.Forms.ComboBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.txb_TenBan = new System.Windows.Forms.TextBox();
            this.txb_SoBan = new System.Windows.Forms.TextBox();
            this.label_ViTri = new System.Windows.Forms.Label();
            this.label_TenBan = new System.Windows.Forms.Label();
            this.label_SoBan = new System.Windows.Forms.Label();
            this.label_ThongTin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_GioiTinh
            // 
            this.cb_GioiTinh.FormattingEnabled = true;
            this.cb_GioiTinh.Location = new System.Drawing.Point(129, 155);
            this.cb_GioiTinh.Name = "cb_GioiTinh";
            this.cb_GioiTinh.Size = new System.Drawing.Size(365, 24);
            this.cb_GioiTinh.TabIndex = 42;
            // 
            // btn_luu
            // 
            this.btn_luu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_luu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luu.Location = new System.Drawing.Point(383, 194);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(112, 49);
            this.btn_luu.TabIndex = 41;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = false;
            // 
            // btn_huy
            // 
            this.btn_huy.BackColor = System.Drawing.Color.Red;
            this.btn_huy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_huy.Location = new System.Drawing.Point(240, 194);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(112, 49);
            this.btn_huy.TabIndex = 40;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.UseVisualStyleBackColor = false;
            // 
            // txb_TenBan
            // 
            this.txb_TenBan.Location = new System.Drawing.Point(129, 119);
            this.txb_TenBan.Name = "txb_TenBan";
            this.txb_TenBan.Size = new System.Drawing.Size(365, 22);
            this.txb_TenBan.TabIndex = 39;
            // 
            // txb_SoBan
            // 
            this.txb_SoBan.Location = new System.Drawing.Point(130, 80);
            this.txb_SoBan.Name = "txb_SoBan";
            this.txb_SoBan.Size = new System.Drawing.Size(365, 22);
            this.txb_SoBan.TabIndex = 38;
            // 
            // label_ViTri
            // 
            this.label_ViTri.AutoSize = true;
            this.label_ViTri.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ViTri.Location = new System.Drawing.Point(44, 159);
            this.label_ViTri.Name = "label_ViTri";
            this.label_ViTri.Size = new System.Drawing.Size(46, 20);
            this.label_ViTri.TabIndex = 37;
            this.label_ViTri.Text = "Vị trí";
            // 
            // label_TenBan
            // 
            this.label_TenBan.AutoSize = true;
            this.label_TenBan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TenBan.Location = new System.Drawing.Point(44, 121);
            this.label_TenBan.Name = "label_TenBan";
            this.label_TenBan.Size = new System.Drawing.Size(69, 20);
            this.label_TenBan.TabIndex = 36;
            this.label_TenBan.Text = "Tên bàn";
            // 
            // label_SoBan
            // 
            this.label_SoBan.AutoSize = true;
            this.label_SoBan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SoBan.Location = new System.Drawing.Point(44, 82);
            this.label_SoBan.Name = "label_SoBan";
            this.label_SoBan.Size = new System.Drawing.Size(59, 20);
            this.label_SoBan.TabIndex = 35;
            this.label_SoBan.Text = "Số bàn";
            // 
            // label_ThongTin
            // 
            this.label_ThongTin.AutoSize = true;
            this.label_ThongTin.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ThongTin.Location = new System.Drawing.Point(18, 16);
            this.label_ThongTin.Name = "label_ThongTin";
            this.label_ThongTin.Size = new System.Drawing.Size(79, 20);
            this.label_ThongTin.TabIndex = 34;
            this.label_ThongTin.Text = "Thông tin";
            // 
            // Delete_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(511, 257);
            this.Controls.Add(this.cb_GioiTinh);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.txb_TenBan);
            this.Controls.Add(this.txb_SoBan);
            this.Controls.Add(this.label_ViTri);
            this.Controls.Add(this.label_TenBan);
            this.Controls.Add(this.label_SoBan);
            this.Controls.Add(this.label_ThongTin);
            this.Name = "Delete_Table";
            this.Text = "Xóa bàn";
            this.ResumeLayout(false);
            this.PerformLayout();

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