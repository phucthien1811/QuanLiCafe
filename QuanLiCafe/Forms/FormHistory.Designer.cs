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
            lb_tieude = new Label();
            lb_TuNgay = new Label();
            lb_DenNgay = new Label();
            dtp_TuNgay = new DateTimePicker();
            dtp_DenNgay = new DateTimePicker();
            btn_LocDuLieu = new Button();
            dgv_HoaDon = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            Ngay = new DataGridViewTextBoxColumn();
            MaPhieu = new DataGridViewTextBoxColumn();
            MaPhieuChiTiet = new DataGridViewTextBoxColumn();
            MaNV = new DataGridViewTextBoxColumn();
            MaKH = new DataGridViewTextBoxColumn();
            MaDoUong = new DataGridViewTextBoxColumn();
            TenDoUong = new DataGridViewTextBoxColumn();
            btn_InBaoCao = new Button();
            btn_XuatExcel = new Button();
            lb_Tong = new Label();
            lb_TongTien = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv_HoaDon).BeginInit();
            SuspendLayout();
            // 
            // lb_tieude
            // 
            lb_tieude.AutoSize = true;
            lb_tieude.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_tieude.Location = new Point(374, 35);
            lb_tieude.Name = "lb_tieude";
            lb_tieude.Size = new Size(380, 32);
            lb_tieude.TabIndex = 1;
            lb_tieude.Text = "Xem lịch sử hóa đơn bán hàng";
            lb_tieude.TextAlign = ContentAlignment.MiddleCenter;
            lb_tieude.Click += lb_tieude_Click;
            // 
            // lb_TuNgay
            // 
            lb_TuNgay.AutoSize = true;
            lb_TuNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_TuNgay.Location = new Point(307, 109);
            lb_TuNgay.Name = "lb_TuNgay";
            lb_TuNgay.Size = new Size(75, 23);
            lb_TuNgay.TabIndex = 2;
            lb_TuNgay.Text = "Từ ngày";
            // 
            // lb_DenNgay
            // 
            lb_DenNgay.AutoSize = true;
            lb_DenNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_DenNgay.Location = new Point(571, 109);
            lb_DenNgay.Name = "lb_DenNgay";
            lb_DenNgay.Size = new Size(86, 23);
            lb_DenNgay.TabIndex = 3;
            lb_DenNgay.Text = "Đến ngày";
            lb_DenNgay.Click += label1_Click;
            // 
            // dtp_TuNgay
            // 
            dtp_TuNgay.Format = DateTimePickerFormat.Short;
            dtp_TuNgay.Location = new Point(398, 110);
            dtp_TuNgay.Margin = new Padding(3, 4, 3, 4);
            dtp_TuNgay.Name = "dtp_TuNgay";
            dtp_TuNgay.Size = new Size(125, 27);
            dtp_TuNgay.TabIndex = 4;
            // 
            // dtp_DenNgay
            // 
            dtp_DenNgay.Format = DateTimePickerFormat.Short;
            dtp_DenNgay.Location = new Point(673, 110);
            dtp_DenNgay.Margin = new Padding(3, 4, 3, 4);
            dtp_DenNgay.Name = "dtp_DenNgay";
            dtp_DenNgay.Size = new Size(125, 27);
            dtp_DenNgay.TabIndex = 5;
            // 
            // btn_LocDuLieu
            // 
            btn_LocDuLieu.BackColor = Color.Blue;
            btn_LocDuLieu.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_LocDuLieu.ForeColor = SystemColors.ButtonFace;
            btn_LocDuLieu.Location = new Point(503, 160);
            btn_LocDuLieu.Margin = new Padding(3, 4, 3, 4);
            btn_LocDuLieu.Name = "btn_LocDuLieu";
            btn_LocDuLieu.Size = new Size(131, 46);
            btn_LocDuLieu.TabIndex = 6;
            btn_LocDuLieu.Text = "Lọc dữ liệu";
            btn_LocDuLieu.UseVisualStyleBackColor = false;
            // 
            // dgv_HoaDon
            // 
            dgv_HoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_HoaDon.BackgroundColor = Color.White;
            dgv_HoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_HoaDon.Columns.AddRange(new DataGridViewColumn[] { STT, Ngay, MaPhieu, MaPhieuChiTiet, MaNV, MaKH, MaDoUong, TenDoUong });
            dgv_HoaDon.Location = new Point(12, 241);
            dgv_HoaDon.Margin = new Padding(3, 4, 3, 4);
            dgv_HoaDon.Name = "dgv_HoaDon";
            dgv_HoaDon.ReadOnly = true;
            dgv_HoaDon.RowHeadersWidth = 51;
            dgv_HoaDon.RowTemplate.Height = 24;
            dgv_HoaDon.Size = new Size(1059, 396);
            dgv_HoaDon.TabIndex = 7;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            STT.ReadOnly = true;
            STT.Width = 75;
            // 
            // Ngay
            // 
            Ngay.HeaderText = "Ngày";
            Ngay.MinimumWidth = 6;
            Ngay.Name = "Ngay";
            Ngay.ReadOnly = true;
            Ngay.Width = 125;
            // 
            // MaPhieu
            // 
            MaPhieu.HeaderText = "Mã Phiếu";
            MaPhieu.MinimumWidth = 6;
            MaPhieu.Name = "MaPhieu";
            MaPhieu.ReadOnly = true;
            MaPhieu.Width = 125;
            // 
            // MaPhieuChiTiet
            // 
            MaPhieuChiTiet.HeaderText = "Mã phiếu chi tiết";
            MaPhieuChiTiet.MinimumWidth = 6;
            MaPhieuChiTiet.Name = "MaPhieuChiTiet";
            MaPhieuChiTiet.ReadOnly = true;
            MaPhieuChiTiet.Width = 150;
            // 
            // MaNV
            // 
            MaNV.HeaderText = "Mã nhân viên";
            MaNV.MinimumWidth = 6;
            MaNV.Name = "MaNV";
            MaNV.ReadOnly = true;
            MaNV.Width = 125;
            // 
            // MaKH
            // 
            MaKH.HeaderText = "Mã khách hàng";
            MaKH.MinimumWidth = 6;
            MaKH.Name = "MaKH";
            MaKH.ReadOnly = true;
            MaKH.Width = 140;
            // 
            // MaDoUong
            // 
            MaDoUong.HeaderText = "Mã đồ uống";
            MaDoUong.MinimumWidth = 6;
            MaDoUong.Name = "MaDoUong";
            MaDoUong.ReadOnly = true;
            MaDoUong.Width = 125;
            // 
            // TenDoUong
            // 
            TenDoUong.HeaderText = "Tên đồ uống";
            TenDoUong.MinimumWidth = 6;
            TenDoUong.Name = "TenDoUong";
            TenDoUong.ReadOnly = true;
            TenDoUong.Width = 125;
            // 
            // btn_InBaoCao
            // 
            btn_InBaoCao.BackColor = Color.Blue;
            btn_InBaoCao.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_InBaoCao.ForeColor = SystemColors.ButtonFace;
            btn_InBaoCao.Location = new Point(439, 660);
            btn_InBaoCao.Margin = new Padding(3, 4, 3, 4);
            btn_InBaoCao.Name = "btn_InBaoCao";
            btn_InBaoCao.Size = new Size(143, 52);
            btn_InBaoCao.TabIndex = 8;
            btn_InBaoCao.Text = "In báo cáo";
            btn_InBaoCao.UseVisualStyleBackColor = false;
            btn_InBaoCao.Click += btn_InBaoCao_Click;
            // 
            // btn_XuatExcel
            // 
            btn_XuatExcel.BackColor = Color.Lime;
            btn_XuatExcel.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_XuatExcel.ForeColor = SystemColors.ButtonFace;
            btn_XuatExcel.Location = new Point(588, 660);
            btn_XuatExcel.Margin = new Padding(3, 4, 3, 4);
            btn_XuatExcel.Name = "btn_XuatExcel";
            btn_XuatExcel.Size = new Size(143, 52);
            btn_XuatExcel.TabIndex = 9;
            btn_XuatExcel.Text = "Xuất Excel";
            btn_XuatExcel.UseVisualStyleBackColor = false;
            // 
            // lb_Tong
            // 
            lb_Tong.AutoSize = true;
            lb_Tong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Tong.Location = new Point(847, 668);
            lb_Tong.Name = "lb_Tong";
            lb_Tong.Size = new Size(60, 28);
            lb_Tong.TabIndex = 10;
            lb_Tong.Text = "Tổng";
            // 
            // lb_TongTien
            // 
            lb_TongTien.AutoSize = true;
            lb_TongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_TongTien.Location = new Point(951, 668);
            lb_TongTien.Name = "lb_TongTien";
            lb_TongTien.Size = new Size(27, 28);
            lb_TongTien.TabIndex = 11;
            lb_TongTien.Text = "...";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(1083, 730);
            Controls.Add(lb_TongTien);
            Controls.Add(lb_Tong);
            Controls.Add(btn_XuatExcel);
            Controls.Add(btn_InBaoCao);
            Controls.Add(dgv_HoaDon);
            Controls.Add(btn_LocDuLieu);
            Controls.Add(dtp_DenNgay);
            Controls.Add(dtp_TuNgay);
            Controls.Add(lb_DenNgay);
            Controls.Add(lb_TuNgay);
            Controls.Add(lb_tieude);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReportForm";
            Text = "Lịch sử hóa đơn bán hàng";
            Load += ReportForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgv_HoaDon).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
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

