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
            lb_TongTien = new Label();
            lb_Tong = new Label();
            btn_XuatExcel = new Button();
            btn_InBaoCao = new Button();
            btn_LocDuLieu = new Button();
            dtp_DenNgay = new DateTimePicker();
            dtp_TuNgay = new DateTimePicker();
            lb_DenNgay = new Label();
            lb_TuNgay = new Label();
            lb_tieude = new Label();
            dgv_HoaDon = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            MaNV = new DataGridViewTextBoxColumn();
            TenNV = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_HoaDon).BeginInit();
            SuspendLayout();
            // 
            // lb_TongTien
            // 
            lb_TongTien.AutoSize = true;
            lb_TongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_TongTien.Location = new Point(951, 668);
            lb_TongTien.Name = "lb_TongTien";
            lb_TongTien.Size = new Size(27, 28);
            lb_TongTien.TabIndex = 35;
            lb_TongTien.Text = "...";
            // 
            // lb_Tong
            // 
            lb_Tong.AutoSize = true;
            lb_Tong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Tong.Location = new Point(847, 668);
            lb_Tong.Name = "lb_Tong";
            lb_Tong.Size = new Size(60, 28);
            lb_Tong.TabIndex = 34;
            lb_Tong.Text = "Tổng";
            // 
            // btn_XuatExcel
            // 
            btn_XuatExcel.BackColor = Color.Lime;
            btn_XuatExcel.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_XuatExcel.ForeColor = SystemColors.ButtonFace;
            btn_XuatExcel.Location = new Point(588, 660);
            btn_XuatExcel.Margin = new Padding(3, 4, 3, 4);
            btn_XuatExcel.Name = "btn_XuatExcel";
            btn_XuatExcel.Size = new Size(143, 52);
            btn_XuatExcel.TabIndex = 33;
            btn_XuatExcel.Text = "Xuất Excel";
            btn_XuatExcel.UseVisualStyleBackColor = false;
            // 
            // btn_InBaoCao
            // 
            btn_InBaoCao.BackColor = Color.Blue;
            btn_InBaoCao.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_InBaoCao.ForeColor = SystemColors.ButtonFace;
            btn_InBaoCao.Location = new Point(439, 660);
            btn_InBaoCao.Margin = new Padding(3, 4, 3, 4);
            btn_InBaoCao.Name = "btn_InBaoCao";
            btn_InBaoCao.Size = new Size(143, 52);
            btn_InBaoCao.TabIndex = 32;
            btn_InBaoCao.Text = "In báo cáo";
            btn_InBaoCao.UseVisualStyleBackColor = false;
            // 
            // btn_LocDuLieu
            // 
            btn_LocDuLieu.BackColor = Color.Blue;
            btn_LocDuLieu.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_LocDuLieu.ForeColor = SystemColors.ButtonFace;
            btn_LocDuLieu.Location = new Point(468, 164);
            btn_LocDuLieu.Margin = new Padding(3, 4, 3, 4);
            btn_LocDuLieu.Name = "btn_LocDuLieu";
            btn_LocDuLieu.Size = new Size(114, 55);
            btn_LocDuLieu.TabIndex = 31;
            btn_LocDuLieu.Text = "Lọc dữ liệu";
            btn_LocDuLieu.UseVisualStyleBackColor = false;
            // 
            // dtp_DenNgay
            // 
            dtp_DenNgay.Format = DateTimePickerFormat.Short;
            dtp_DenNgay.Location = new Point(673, 110);
            dtp_DenNgay.Margin = new Padding(3, 4, 3, 4);
            dtp_DenNgay.Name = "dtp_DenNgay";
            dtp_DenNgay.Size = new Size(125, 27);
            dtp_DenNgay.TabIndex = 30;
            // 
            // dtp_TuNgay
            // 
            dtp_TuNgay.Format = DateTimePickerFormat.Short;
            dtp_TuNgay.Location = new Point(379, 110);
            dtp_TuNgay.Margin = new Padding(3, 4, 3, 4);
            dtp_TuNgay.Name = "dtp_TuNgay";
            dtp_TuNgay.Size = new Size(125, 27);
            dtp_TuNgay.TabIndex = 29;
            // 
            // lb_DenNgay
            // 
            lb_DenNgay.AutoSize = true;
            lb_DenNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_DenNgay.Location = new Point(581, 109);
            lb_DenNgay.Name = "lb_DenNgay";
            lb_DenNgay.Size = new Size(86, 23);
            lb_DenNgay.TabIndex = 28;
            lb_DenNgay.Text = "Đến ngày";
            // 
            // lb_TuNgay
            // 
            lb_TuNgay.AutoSize = true;
            lb_TuNgay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_TuNgay.Location = new Point(296, 111);
            lb_TuNgay.Name = "lb_TuNgay";
            lb_TuNgay.Size = new Size(75, 23);
            lb_TuNgay.TabIndex = 27;
            lb_TuNgay.Text = "Từ ngày";
            // 
            // lb_tieude
            // 
            lb_tieude.AutoSize = true;
            lb_tieude.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_tieude.Location = new Point(351, 29);
            lb_tieude.Name = "lb_tieude";
            lb_tieude.Size = new Size(380, 32);
            lb_tieude.TabIndex = 26;
            lb_tieude.Text = "Xem lịch sử hóa đơn bán hàng";
            lb_tieude.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv_HoaDon
            // 
            dgv_HoaDon.BackgroundColor = Color.White;
            dgv_HoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_HoaDon.Columns.AddRange(new DataGridViewColumn[] { STT, MaNV, TenNV, SoLuong, ThanhTien });
            dgv_HoaDon.Location = new Point(12, 241);
            dgv_HoaDon.Margin = new Padding(3, 4, 3, 4);
            dgv_HoaDon.Name = "dgv_HoaDon";
            dgv_HoaDon.RowHeadersWidth = 51;
            dgv_HoaDon.RowTemplate.Height = 24;
            dgv_HoaDon.Size = new Size(1059, 396);
            dgv_HoaDon.TabIndex = 36;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            STT.Width = 75;
            // 
            // MaNV
            // 
            MaNV.HeaderText = "Mã nhân viên";
            MaNV.MinimumWidth = 6;
            MaNV.Name = "MaNV";
            MaNV.Width = 125;
            // 
            // TenNV
            // 
            TenNV.HeaderText = "Tên nhân viên";
            TenNV.MinimumWidth = 6;
            TenNV.Name = "TenNV";
            TenNV.Width = 125;
            // 
            // SoLuong
            // 
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.Width = 125;
            // 
            // ThanhTien
            // 
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.Width = 125;
            // 
            // RevenueEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(1083, 730);
            Controls.Add(dgv_HoaDon);
            Controls.Add(lb_TongTien);
            Controls.Add(lb_Tong);
            Controls.Add(btn_XuatExcel);
            Controls.Add(btn_InBaoCao);
            Controls.Add(btn_LocDuLieu);
            Controls.Add(dtp_DenNgay);
            Controls.Add(dtp_TuNgay);
            Controls.Add(lb_DenNgay);
            Controls.Add(lb_TuNgay);
            Controls.Add(lb_tieude);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RevenueEmployee";
            Text = "Thống kê doanh thu theo nhân viên";
            ((System.ComponentModel.ISupportInitialize)dgv_HoaDon).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.DataGridView dgv_HoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
    }
}