namespace DrinkForm
{
    partial class FormMain
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
            DanhMucDoUong = new DataGridView();
            colHinh = new DataGridViewImageColumn();
            colMaDoUong = new DataGridViewTextBoxColumn();
            colTenDoUong = new DataGridViewTextBoxColumn();
            colMoTa = new DataGridViewTextBoxColumn();
            colGiaTien = new DataGridViewTextBoxColumn();
            colMaDanhMuc = new DataGridViewTextBoxColumn();
            colTenDanhMuc = new DataGridViewTextBoxColumn();
            txtTimKiem = new TextBox();
            labelTimKiem = new Label();
            btnTimKiem = new Button();
            btnThem = new Button();
            btnThoat = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            ((System.ComponentModel.ISupportInitialize)DanhMucDoUong).BeginInit();
            SuspendLayout();
            // 
            // DanhMucDoUong
            // 
            DanhMucDoUong.AllowUserToAddRows = false;
            DanhMucDoUong.BackgroundColor = SystemColors.ButtonFace;
            DanhMucDoUong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DanhMucDoUong.Columns.AddRange(new DataGridViewColumn[] { colHinh, colMaDoUong, colTenDoUong, colMoTa, colGiaTien, colMaDanhMuc, colTenDanhMuc });
            DanhMucDoUong.Location = new Point(122, 15);
            DanhMucDoUong.Margin = new Padding(3, 4, 3, 4);
            DanhMucDoUong.Name = "DanhMucDoUong";
            DanhMucDoUong.RowHeadersWidth = 51;
            DanhMucDoUong.RowTemplate.Height = 24;
            DanhMucDoUong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DanhMucDoUong.Size = new Size(782, 460);
            DanhMucDoUong.TabIndex = 1;
            DanhMucDoUong.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colHinh
            // 
            colHinh.DataPropertyName = "Hinh";
            colHinh.HeaderText = "Hình ảnh";
            colHinh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colHinh.MinimumWidth = 6;
            colHinh.Name = "colHinh";
            colHinh.Width = 125;
            // 
            // colMaDoUong
            // 
            colMaDoUong.DataPropertyName = "MaDoUong";
            colMaDoUong.HeaderText = "Mã đồ uống";
            colMaDoUong.MinimumWidth = 6;
            colMaDoUong.Name = "colMaDoUong";
            colMaDoUong.Width = 125;
            // 
            // colTenDoUong
            // 
            colTenDoUong.DataPropertyName = "TenDoUong";
            colTenDoUong.HeaderText = "Tên đồ uống";
            colTenDoUong.MinimumWidth = 6;
            colTenDoUong.Name = "colTenDoUong";
            colTenDoUong.Width = 125;
            // 
            // colMoTa
            // 
            colMoTa.DataPropertyName = "MoTa";
            colMoTa.HeaderText = "Mô tả";
            colMoTa.MinimumWidth = 6;
            colMoTa.Name = "colMoTa";
            colMoTa.Width = 125;
            // 
            // colGiaTien
            // 
            colGiaTien.DataPropertyName = "Gia";
            colGiaTien.HeaderText = "Giá tiền";
            colGiaTien.MinimumWidth = 6;
            colGiaTien.Name = "colGiaTien";
            colGiaTien.Width = 125;
            // 
            // colMaDanhMuc
            // 
            colMaDanhMuc.DataPropertyName = "MaDanhMuc";
            colMaDanhMuc.HeaderText = "Mã danh mục";
            colMaDanhMuc.MinimumWidth = 6;
            colMaDanhMuc.Name = "colMaDanhMuc";
            colMaDanhMuc.Width = 125;
            // 
            // colTenDanhMuc
            // 
            colTenDanhMuc.DataPropertyName = "TenDanhMuc";
            colTenDanhMuc.HeaderText = "Tên danh mục";
            colTenDanhMuc.MinimumWidth = 6;
            colTenDanhMuc.Name = "colTenDanhMuc";
            colTenDanhMuc.Width = 125;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(392, 508);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(382, 27);
            txtTimKiem.TabIndex = 2;
            // 
            // labelTimKiem
            // 
            labelTimKiem.AutoSize = true;
            labelTimKiem.Font = new Font("Times New Roman", 10.8F);
            labelTimKiem.Location = new Point(221, 509);
            labelTimKiem.Name = "labelTimKiem";
            labelTimKiem.Size = new Size(143, 20);
            labelTimKiem.TabIndex = 3;
            labelTimKiem.Text = "Tìm kiếm theo tên";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.DeepSkyBlue;
            btnTimKiem.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnTimKiem.ForeColor = SystemColors.ButtonFace;
            btnTimKiem.Location = new Point(811, 500);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(97, 49);
            btnTimKiem.TabIndex = 4;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DeepSkyBlue;
            btnThem.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnThem.ForeColor = SystemColors.ButtonFace;
            btnThem.Location = new Point(14, 15);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(97, 49);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.DeepSkyBlue;
            btnThoat.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnThoat.ForeColor = SystemColors.ButtonFace;
            btnThoat.Location = new Point(14, 246);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(97, 49);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.DeepSkyBlue;
            btnLamMoi.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = SystemColors.ButtonFace;
            btnLamMoi.Location = new Point(14, 188);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(97, 49);
            btnLamMoi.TabIndex = 8;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.DeepSkyBlue;
            btnXoa.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnXoa.ForeColor = SystemColors.ButtonFace;
            btnXoa.Location = new Point(14, 129);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(97, 49);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DeepSkyBlue;
            btnSua.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnSua.ForeColor = SystemColors.ButtonFace;
            btnSua.Location = new Point(14, 70);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(97, 49);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(962, 569);
            Controls.Add(btnThem);
            Controls.Add(btnThoat);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnTimKiem);
            Controls.Add(labelTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(DanhMucDoUong);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh Mục Đồ Uống";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)DanhMucDoUong).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DanhMucDoUong;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label labelTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridViewImageColumn colHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDoUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDoUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDanhMuc;
        private Button btnThem;
        private Button btnThoat;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
    }
}

