namespace ReportForm
{
    partial class RevenueEmployee
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
            this.lb_TongTien = new System.Windows.Forms.Label();
            this.lb_Tong = new System.Windows.Forms.Label();
            this.btn_XuatExcel = new System.Windows.Forms.Button();
            this.btn_InBaoCao = new System.Windows.Forms.Button();
            this.btn_LocDuLieu = new System.Windows.Forms.Button();
            this.dtp_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtp_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.lb_DenNgay = new System.Windows.Forms.Label();
            this.lb_TuNgay = new System.Windows.Forms.Label();
            this.lb_tieude = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_HoaDon = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_TongTien
            // 
            this.lb_TongTien.AutoSize = true;
            this.lb_TongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TongTien.Location = new System.Drawing.Point(951, 534);
            this.lb_TongTien.Name = "lb_TongTien";
            this.lb_TongTien.Size = new System.Drawing.Size(27, 28);
            this.lb_TongTien.TabIndex = 35;
            this.lb_TongTien.Text = "...";
            // 
            // lb_Tong
            // 
            this.lb_Tong.AutoSize = true;
            this.lb_Tong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Tong.Location = new System.Drawing.Point(847, 534);
            this.lb_Tong.Name = "lb_Tong";
            this.lb_Tong.Size = new System.Drawing.Size(60, 28);
            this.lb_Tong.TabIndex = 34;
            this.lb_Tong.Text = "Tổng";
            // 
            // btn_XuatExcel
            // 
            this.btn_XuatExcel.BackColor = System.Drawing.Color.Lime;
            this.btn_XuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatExcel.Location = new System.Drawing.Point(588, 528);
            this.btn_XuatExcel.Name = "btn_XuatExcel";
            this.btn_XuatExcel.Size = new System.Drawing.Size(143, 42);
            this.btn_XuatExcel.TabIndex = 33;
            this.btn_XuatExcel.Text = "Xuất Excel";
            this.btn_XuatExcel.UseVisualStyleBackColor = false;
            // 
            // btn_InBaoCao
            // 
            this.btn_InBaoCao.BackColor = System.Drawing.Color.Blue;
            this.btn_InBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InBaoCao.Location = new System.Drawing.Point(439, 528);
            this.btn_InBaoCao.Name = "btn_InBaoCao";
            this.btn_InBaoCao.Size = new System.Drawing.Size(143, 42);
            this.btn_InBaoCao.TabIndex = 32;
            this.btn_InBaoCao.Text = "In báo cáo";
            this.btn_InBaoCao.UseVisualStyleBackColor = false;
            // 
            // btn_LocDuLieu
            // 
            this.btn_LocDuLieu.BackColor = System.Drawing.Color.Blue;
            this.btn_LocDuLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LocDuLieu.Location = new System.Drawing.Point(468, 131);
            this.btn_LocDuLieu.Name = "btn_LocDuLieu";
            this.btn_LocDuLieu.Size = new System.Drawing.Size(114, 44);
            this.btn_LocDuLieu.TabIndex = 31;
            this.btn_LocDuLieu.Text = "Lọc dữ liệu";
            this.btn_LocDuLieu.UseVisualStyleBackColor = false;
            // 
            // dtp_DenNgay
            // 
            this.dtp_DenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DenNgay.Location = new System.Drawing.Point(673, 88);
            this.dtp_DenNgay.Name = "dtp_DenNgay";
            this.dtp_DenNgay.Size = new System.Drawing.Size(125, 22);
            this.dtp_DenNgay.TabIndex = 30;
            // 
            // dtp_TuNgay
            // 
            this.dtp_TuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_TuNgay.Location = new System.Drawing.Point(398, 88);
            this.dtp_TuNgay.Name = "dtp_TuNgay";
            this.dtp_TuNgay.Size = new System.Drawing.Size(125, 22);
            this.dtp_TuNgay.TabIndex = 29;
            // 
            // lb_DenNgay
            // 
            this.lb_DenNgay.AutoSize = true;
            this.lb_DenNgay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DenNgay.Location = new System.Drawing.Point(581, 87);
            this.lb_DenNgay.Name = "lb_DenNgay";
            this.lb_DenNgay.Size = new System.Drawing.Size(86, 23);
            this.lb_DenNgay.TabIndex = 28;
            this.lb_DenNgay.Text = "Đến ngày";
            // 
            // lb_TuNgay
            // 
            this.lb_TuNgay.AutoSize = true;
            this.lb_TuNgay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TuNgay.Location = new System.Drawing.Point(317, 87);
            this.lb_TuNgay.Name = "lb_TuNgay";
            this.lb_TuNgay.Size = new System.Drawing.Size(75, 23);
            this.lb_TuNgay.TabIndex = 27;
            this.lb_TuNgay.Text = "Từ ngày";
            // 
            // lb_tieude
            // 
            this.lb_tieude.AutoSize = true;
            this.lb_tieude.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tieude.Location = new System.Drawing.Point(391, 23);
            this.lb_tieude.Name = "lb_tieude";
            this.lb_tieude.Size = new System.Drawing.Size(418, 38);
            this.lb_tieude.TabIndex = 26;
            this.lb_tieude.Text = "Xem lịch sử hóa đơn bán hàng";
            this.lb_tieude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 163);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_HoaDon
            // 
            this.dgv_HoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgv_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaNV,
            this.TenNV,
            this.SoLuong,
            this.ThanhTien});
            this.dgv_HoaDon.Location = new System.Drawing.Point(12, 193);
            this.dgv_HoaDon.Name = "dgv_HoaDon";
            this.dgv_HoaDon.RowHeadersWidth = 51;
            this.dgv_HoaDon.RowTemplate.Height = 24;
            this.dgv_HoaDon.Size = new System.Drawing.Size(1059, 317);
            this.dgv_HoaDon.TabIndex = 36;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 75;
            // 
            // MaNV
            // 
            this.MaNV.HeaderText = "Mã nhân viên";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.Width = 125;
            // 
            // TenNV
            // 
            this.TenNV.HeaderText = "Tên nhân viên";
            this.TenNV.MinimumWidth = 6;
            this.TenNV.Name = "TenNV";
            this.TenNV.Width = 125;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 125;
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.Width = 125;
            // 
            // DoanhThuTheoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(1083, 584);
            this.Controls.Add(this.dgv_HoaDon);
            this.Controls.Add(this.lb_TongTien);
            this.Controls.Add(this.lb_Tong);
            this.Controls.Add(this.btn_XuatExcel);
            this.Controls.Add(this.btn_InBaoCao);
            this.Controls.Add(this.btn_LocDuLieu);
            this.Controls.Add(this.dtp_DenNgay);
            this.Controls.Add(this.dtp_TuNgay);
            this.Controls.Add(this.lb_DenNgay);
            this.Controls.Add(this.lb_TuNgay);
            this.Controls.Add(this.lb_tieude);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DoanhThuTheoNhanVien";
            this.Text = "Thống kê doanh thu theo nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_TongTien;
        private System.Windows.Forms.Label lb_Tong;
        private System.Windows.Forms.Button btn_XuatExcel;
        private System.Windows.Forms.Button btn_InBaoCao;
        private System.Windows.Forms.Button btn_LocDuLieu;
        private System.Windows.Forms.DateTimePicker dtp_DenNgay;
        private System.Windows.Forms.DateTimePicker dtp_TuNgay;
        private System.Windows.Forms.Label lb_DenNgay;
        private System.Windows.Forms.Label lb_TuNgay;
        private System.Windows.Forms.Label lb_tieude;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
    }
}