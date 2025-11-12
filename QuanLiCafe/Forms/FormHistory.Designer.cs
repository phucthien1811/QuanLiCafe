namespace ReportForm
{
    partial class ReportForm
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
            this.pb_Avatar = new System.Windows.Forms.PictureBox();
            this.lb_tieude = new System.Windows.Forms.Label();
            this.lb_TuNgay = new System.Windows.Forms.Label();
            this.lb_DenNgay = new System.Windows.Forms.Label();
            this.dtp_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.btn_LocDuLieu = new System.Windows.Forms.Button();
            this.dgv_HoaDon = new System.Windows.Forms.DataGridView();
            this.btn_InBaoCao = new System.Windows.Forms.Button();
            this.btn_XuatExcel = new System.Windows.Forms.Button();
            this.lb_Tong = new System.Windows.Forms.Label();
            this.lb_TongTien = new System.Windows.Forms.Label();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhieuChiTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDoUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDoUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Avatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Avatar
            // 
            this.pb_Avatar.Location = new System.Drawing.Point(12, 12);
            this.pb_Avatar.Name = "pb_Avatar";
            this.pb_Avatar.Size = new System.Drawing.Size(163, 163);
            this.pb_Avatar.TabIndex = 0;
            this.pb_Avatar.TabStop = false;
            // 
            // lb_tieude
            // 
            this.lb_tieude.AutoSize = true;
            this.lb_tieude.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tieude.Location = new System.Drawing.Point(391, 23);
            this.lb_tieude.Name = "lb_tieude";
            this.lb_tieude.Size = new System.Drawing.Size(418, 38);
            this.lb_tieude.TabIndex = 1;
            this.lb_tieude.Text = "Xem lịch sử hóa đơn bán hàng";
            this.lb_tieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_tieude.Click += new System.EventHandler(this.lb_tieude_Click);
            // 
            // lb_TuNgay
            // 
            this.lb_TuNgay.AutoSize = true;
            this.lb_TuNgay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TuNgay.Location = new System.Drawing.Point(317, 87);
            this.lb_TuNgay.Name = "lb_TuNgay";
            this.lb_TuNgay.Size = new System.Drawing.Size(75, 23);
            this.lb_TuNgay.TabIndex = 2;
            this.lb_TuNgay.Text = "Từ ngày";
            // 
            // lb_DenNgay
            // 
            this.lb_DenNgay.AutoSize = true;
            this.lb_DenNgay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DenNgay.Location = new System.Drawing.Point(581, 87);
            this.lb_DenNgay.Name = "lb_DenNgay";
            this.lb_DenNgay.Size = new System.Drawing.Size(86, 23);
            this.lb_DenNgay.TabIndex = 3;
            this.lb_DenNgay.Text = "Đến ngày";
            this.lb_DenNgay.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtp_TuNgay
            // 
            this.dtp_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_TuNgay.Location = new System.Drawing.Point(398, 88);
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.Size = new System.Drawing.Size(125, 22);
            this.dtp_TuNgay.TabIndex = 4;
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DenNgay.Location = new System.Drawing.Point(673, 88);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.Size = new System.Drawing.Size(125, 22);
            this.dtp_DenNgay.TabIndex = 5;
            // 
            // btn_LocDuLieu
            // 
            this.btn_LocDuLieu.BackColor = System.Drawing.Color.Blue;
            this.btn_LocDuLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LocDuLieu.Location = new System.Drawing.Point(468, 131);
            this.btn_LocDuLieu.Name = "btn_LocDuLieu";
            this.btn_LocDuLieu.Size = new System.Drawing.Size(114, 44);
            this.btn_LocDuLieu.TabIndex = 6;
            this.btn_LocDuLieu.Text = "Lọc dữ liệu";
            this.btn_LocDuLieu.UseVisualStyleBackColor = false;
            // 
            // dgv_HoaDon
            // 
            this.dgv_HoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_HoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgv_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.Ngay,
            this.MaPhieu,
            this.MaPhieuChiTiet,
            this.MaNV,
            this.MaKH,
            this.MaDoUong,
            this.TenDoUong});
            this.dgv_HoaDon.Location = new System.Drawing.Point(12, 193);
            this.dgv_HoaDon.Name = "dgv_HoaDon";
            this.dgv_HoaDon.ReadOnly = true;
            this.dgv_HoaDon.RowHeadersWidth = 51;
            this.dgv_HoaDon.RowTemplate.Height = 24;
            this.dgv_HoaDon.Size = new System.Drawing.Size(1059, 317);
            this.dgv_HoaDon.TabIndex = 7;
            // 
            // btn_InBaoCao
            // 
            this.btn_InBaoCao.BackColor = System.Drawing.Color.Blue;
            this.btn_InBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InBaoCao.Location = new System.Drawing.Point(439, 528);
            this.btn_InBaoCao.Name = "btn_InBaoCao";
            this.btn_InBaoCao.Size = new System.Drawing.Size(143, 42);
            this.btn_InBaoCao.TabIndex = 8;
            this.btn_InBaoCao.Text = "In báo cáo";
            this.btn_InBaoCao.UseVisualStyleBackColor = false;
            this.btn_InBaoCao.Click += new System.EventHandler(this.btn_InBaoCao_Click);
            // 
            // btn_XuatExcel
            // 
            this.btn_XuatExcel.BackColor = System.Drawing.Color.Lime;
            this.btn_XuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatExcel.Location = new System.Drawing.Point(588, 528);
            this.btn_XuatExcel.Name = "btn_XuatExcel";
            this.btn_XuatExcel.Size = new System.Drawing.Size(143, 42);
            this.btn_XuatExcel.TabIndex = 9;
            this.btn_XuatExcel.Text = "Xuất Excel";
            this.btn_XuatExcel.UseVisualStyleBackColor = false;
            // 
            // lb_Tong
            // 
            this.lb_Tong.AutoSize = true;
            this.lb_Tong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Tong.Location = new System.Drawing.Point(847, 534);
            this.lb_Tong.Name = "lb_Tong";
            this.lb_Tong.Size = new System.Drawing.Size(60, 28);
            this.lb_Tong.TabIndex = 10;
            this.lb_Tong.Text = "Tổng";
            // 
            // lb_TongTien
            // 
            this.lb_TongTien.AutoSize = true;
            this.lb_TongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TongTien.Location = new System.Drawing.Point(951, 534);
            this.lb_TongTien.Name = "lb_TongTien";
            this.lb_TongTien.Size = new System.Drawing.Size(27, 28);
            this.lb_TongTien.TabIndex = 11;
            this.lb_TongTien.Text = "...";
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Width = 75;
            // 
            // Ngay
            // 
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.MinimumWidth = 6;
            this.Ngay.Name = "Ngay";
            this.Ngay.ReadOnly = true;
            this.Ngay.Width = 125;
            // 
            // MaPhieu
            // 
            this.MaPhieu.HeaderText = "Mã Phiếu";
            this.MaPhieu.MinimumWidth = 6;
            this.MaPhieu.Name = "MaPhieu";
            this.MaPhieu.ReadOnly = true;
            this.MaPhieu.Width = 125;
            // 
            // MaPhieuChiTiet
            // 
            this.MaPhieuChiTiet.HeaderText = "Mã phiếu chi tiết";
            this.MaPhieuChiTiet.MinimumWidth = 6;
            this.MaPhieuChiTiet.Name = "MaPhieuChiTiet";
            this.MaPhieuChiTiet.ReadOnly = true;
            this.MaPhieuChiTiet.Width = 150;
            // 
            // MaNV
            // 
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            this.MaNV.Width = 125;
            // 
            // MaKH
            // 
            this.MaKH.HeaderText = "Mã khách hàng";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            this.MaKH.ReadOnly = true;
            this.MaKH.Width = 140;
            // 
            // MaDoUong
            // 
            this.MaDoUong.HeaderText = "Mã đồ uống";
            this.MaDoUong.MinimumWidth = 6;
            this.MaDoUong.Name = "MaDoUong";
            this.MaDoUong.ReadOnly = true;
            this.MaDoUong.Width = 125;
            // 
            // TenDoUong
            // 
            this.TenDoUong.HeaderText = "Tên đồ uống";
            this.TenDoUong.MinimumWidth = 6;
            this.TenDoUong.Name = "TenDoUong";
            this.TenDoUong.ReadOnly = true;
            this.TenDoUong.Width = 125;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1083, 584);
            this.Controls.Add(this.lb_TongTien);
            this.Controls.Add(this.lb_Tong);
            this.Controls.Add(this.btn_XuatExcel);
            this.Controls.Add(this.btn_InBaoCao);
            this.Controls.Add(this.dgv_HoaDon);
            this.Controls.Add(this.btn_LocDuLieu);
            this.Controls.Add(this.dtp_DenNgay);
            this.Controls.Add(this.dtp_TuNgay);
            this.Controls.Add(this.lb_DenNgay);
            this.Controls.Add(this.lb_TuNgay);
            this.Controls.Add(this.lb_tieude);
            this.Controls.Add(this.pb_Avatar);
            this.Name = "ReportForm";
            this.Text = "Lịch sử hóa đơn bán hàng";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Avatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Avatar;
        private System.Windows.Forms.Label lb_tieude;
        private System.Windows.Forms.Label lb_TuNgay;
        private System.Windows.Forms.Label lb_DenNgay;
        private System.Windows.Forms.DateTimePicker dtp_TuNgay;
        private System.Windows.Forms.DateTimePicker dtp_DenNgay;
        private System.Windows.Forms.Button btn_LocDuLieu;
        private System.Windows.Forms.DataGridView dgv_HoaDon;
        private System.Windows.Forms.Button btn_InBaoCao;
        private System.Windows.Forms.Button btn_XuatExcel;
        private System.Windows.Forms.Label lb_Tong;
        private System.Windows.Forms.Label lb_TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieuChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDoUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDoUong;
    }
}

