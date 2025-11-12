namespace QuanLiCafe.Forms
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            ImageList imageList1;
            menuNhanVien = new ToolStripMenuItem();
            btnDanhMuc = new ToolStripMenuItem();
            menuLDU = new ToolStripMenuItem();
            menuDoUong = new ToolStripMenuItem();
            menuBan = new ToolStripMenuItem();
            menuKho = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            dtNgayOrder = new DateTimePicker();
            label7 = new Label();
            txtMaNV = new TextBox();
            label6 = new Label();
            menuThongTinCaNhan = new ToolStripMenuItem();
            nmSoLuong = new NumericUpDown();
            label1 = new Label();
            btnXoa = new Button();
            btnThem = new Button();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            menuDoanhThuNgay = new ToolStripMenuItem();
            menuThongKeDoanhThuNV = new ToolStripMenuItem();
            menuLichSuHoaDon = new ToolStripMenuItem();
            btnTim = new Button();
            txtTenDoUong = new TextBox();
            label3 = new Label();
            btnIn = new Button();
            btnBanDaChon = new Button();
            btnDX = new ToolStripMenuItem();
            menuKH = new ToolStripMenuItem();
            dtgvDoUong = new DataGridView();
            HinhAnh = new DataGridViewImageColumn();
            MaDoUong = new DataGridViewTextBoxColumn();
            TenDoUong = new DataGridViewTextBoxColumn();
            GiaTien = new DataGridViewTextBoxColumn();
            label8 = new Label();
            label2 = new Label();
            btnThanhToan = new Button();
            dtgvHoaDon = new DataGridView();
            listViewBan = new ListView();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            lblTongTien = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            imageList1 = new ImageList(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvDoUong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuNhanVien
            // 
            menuNhanVien.Name = "menuNhanVien";
            menuNhanVien.Size = new Size(261, 28);
            menuNhanVien.Text = "Nhân viên - Tài khoản";
            menuNhanVien.Click += nhânViênToolStripMenuItem_Click;
            // 
            // btnDanhMuc
            // 
            btnDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { menuLDU, menuDoUong, menuBan, menuKho });
            btnDanhMuc.Image = (Image)resources.GetObject("btnDanhMuc.Image");
            btnDanhMuc.Name = "btnDanhMuc";
            btnDanhMuc.Size = new Size(123, 27);
            btnDanhMuc.Text = "Danh mục";
            btnDanhMuc.Click += danhMụcToolStripMenuItem_Click;
            // 
            // menuLDU
            // 
            menuLDU.Name = "menuLDU";
            menuLDU.Size = new Size(195, 28);
            menuLDU.Text = "Loại đồ uống";
            menuLDU.Click += menuLDU_Click;
            // 
            // menuDoUong
            // 
            menuDoUong.Name = "menuDoUong";
            menuDoUong.Size = new Size(195, 28);
            menuDoUong.Text = "Đồ uống";
            menuDoUong.Click += menuDoUong_Click;
            // 
            // menuBan
            // 
            menuBan.Name = "menuBan";
            menuBan.Size = new Size(195, 28);
            menuBan.Text = "Bàn";
            menuBan.Click += menuBan_Click;
            // 
            // menuKho
            // 
            menuKho.Name = "menuKho";
            menuKho.Size = new Size(195, 28);
            menuKho.Text = "Quản lý kho";
            menuKho.Click += menuKho_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtNgayOrder);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtMaNV);
            groupBox1.Controls.Add(label6);
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(1012, 67);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(513, 172);
            groupBox1.TabIndex = 590;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // dtNgayOrder
            // 
            dtNgayOrder.Enabled = false;
            dtNgayOrder.Format = DateTimePickerFormat.Short;
            dtNgayOrder.Location = new Point(248, 86);
            dtNgayOrder.Margin = new Padding(4, 5, 4, 5);
            dtNgayOrder.Name = "dtNgayOrder";
            dtNgayOrder.Size = new Size(256, 26);
            dtNgayOrder.TabIndex = 109;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(53, 93);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(101, 18);
            label7.TabIndex = 105;
            label7.Text = "Ngày hóa đơn";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(248, 52);
            txtMaNV.Margin = new Padding(4, 5, 4, 5);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(256, 26);
            txtMaNV.TabIndex = 104;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(53, 60);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(139, 18);
            label6.TabIndex = 103;
            label6.Text = "Nhân viên bán hàng";
            // 
            // menuThongTinCaNhan
            // 
            menuThongTinCaNhan.Name = "menuThongTinCaNhan";
            menuThongTinCaNhan.Size = new Size(261, 28);
            menuThongTinCaNhan.Text = "Thông tin cá nhân";
            menuThongTinCaNhan.Click += menuThongTinCaNhan_Click;
            // 
            // nmSoLuong
            // 
            nmSoLuong.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nmSoLuong.Location = new Point(674, 72);
            nmSoLuong.Margin = new Padding(4, 5, 4, 5);
            nmSoLuong.Name = "nmSoLuong";
            nmSoLuong.Size = new Size(81, 27);
            nmSoLuong.TabIndex = 589;
            nmSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(510, 75);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 25);
            label1.TabIndex = 588;
            label1.Text = "SỐ LƯỢNG :";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.FlatStyle = FlatStyle.Popup;
            btnXoa.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(1014, 249);
            btnXoa.Margin = new Padding(4, 5, 4, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(247, 46);
            btnXoa.TabIndex = 587;
            btnXoa.Text = "Xóa đồ uống";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += BtnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(0, 0, 192);
            btnThem.FlatStyle = FlatStyle.Popup;
            btnThem.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(763, 67);
            btnThem.Margin = new Padding(4, 5, 4, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(129, 46);
            btnThem.TabIndex = 586;
            btnThem.Text = "Thêm mới";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += BtnThem_Click;
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuDoanhThuNgay, menuThongKeDoanhThuNV, menuLichSuHoaDon });
            thốngKêToolStripMenuItem.Image = (Image)resources.GetObject("thốngKêToolStripMenuItem.Image");
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Size = new Size(115, 27);
            thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // menuDoanhThuNgay
            // 
            menuDoanhThuNgay.Name = "menuDoanhThuNgay";
            menuDoanhThuNgay.Size = new Size(370, 28);
            menuDoanhThuNgay.Text = "Thống kê doanh thu theo ngày";
            menuDoanhThuNgay.Click += menuDoanhThuNgay_Click;
            // 
            // menuThongKeDoanhThuNV
            // 
            menuThongKeDoanhThuNV.Name = "menuThongKeDoanhThuNV";
            menuThongKeDoanhThuNV.Size = new Size(370, 28);
            menuThongKeDoanhThuNV.Text = "Thống kê doanh thu theo nhân viên";
            menuThongKeDoanhThuNV.Click += menuThongKeDoanhThuNV_Click;
            // 
            // menuLichSuHoaDon
            // 
            menuLichSuHoaDon.Name = "menuLichSuHoaDon";
            menuLichSuHoaDon.Size = new Size(370, 28);
            menuLichSuHoaDon.Text = "Xem lịch sử hóa đơn";
            menuLichSuHoaDon.Click += menuLichSuHoaDon_Click;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.FromArgb(0, 0, 192);
            btnTim.FlatStyle = FlatStyle.Popup;
            btnTim.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTim.ForeColor = Color.White;
            btnTim.Location = new Point(911, 139);
            btnTim.Margin = new Padding(4, 5, 4, 5);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(93, 46);
            btnTim.TabIndex = 594;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += BtnTim_Click;
            // 
            // txtTenDoUong
            // 
            txtTenDoUong.CharacterCasing = CharacterCasing.Upper;
            txtTenDoUong.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenDoUong.ForeColor = Color.Black;
            txtTenDoUong.Location = new Point(699, 143);
            txtTenDoUong.Margin = new Padding(4, 5, 4, 5);
            txtTenDoUong.Name = "txtTenDoUong";
            txtTenDoUong.Size = new Size(203, 26);
            txtTenDoUong.TabIndex = 593;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(518, 149);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(170, 21);
            label3.TabIndex = 592;
            label3.Text = "Tìm theo tên đồ uống";
            // 
            // btnIn
            // 
            btnIn.BackColor = Color.FromArgb(0, 64, 0);
            btnIn.FlatStyle = FlatStyle.Popup;
            btnIn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIn.ForeColor = Color.White;
            btnIn.Location = new Point(1558, 921);
            btnIn.Margin = new Padding(4, 5, 4, 5);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(195, 46);
            btnIn.TabIndex = 591;
            btnIn.Text = "In hóa đơn";
            btnIn.UseVisualStyleBackColor = false;
            // 
            // btnBanDaChon
            // 
            btnBanDaChon.BackColor = Color.FromArgb(0, 192, 0);
            btnBanDaChon.FlatStyle = FlatStyle.Popup;
            btnBanDaChon.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanDaChon.ForeColor = Color.White;
            btnBanDaChon.Location = new Point(230, 67);
            btnBanDaChon.Margin = new Padding(4, 5, 4, 5);
            btnBanDaChon.Name = "btnBanDaChon";
            btnBanDaChon.Size = new Size(195, 46);
            btnBanDaChon.TabIndex = 585;
            btnBanDaChon.Text = "Chưa chọn bàn";
            btnBanDaChon.UseVisualStyleBackColor = false;
            // 
            // btnDX
            // 
            btnDX.Image = (Image)resources.GetObject("btnDX.Image");
            btnDX.Name = "btnDX";
            btnDX.Size = new Size(123, 27);
            btnDX.Text = "Đăng xuất";
            btnDX.Click += BtnDX_Click;
            // 
            // menuKH
            // 
            menuKH.Image = (Image)resources.GetObject("menuKH.Image");
            menuKH.Name = "menuKH";
            menuKH.Size = new Size(197, 27);
            menuKH.Text = "Quản lý khách hàng";
            menuKH.Click += menuKH_Click;
            // 
            // dtgvDoUong
            // 
            dtgvDoUong.AllowUserToAddRows = false;
            dtgvDoUong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvDoUong.BackgroundColor = Color.White;
            dtgvDoUong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvDoUong.Columns.AddRange(new DataGridViewColumn[] { HinhAnh, MaDoUong, TenDoUong, GiaTien });
            dtgvDoUong.Location = new Point(432, 193);
            dtgvDoUong.Margin = new Padding(4, 5, 4, 5);
            dtgvDoUong.Name = "dtgvDoUong";
            dtgvDoUong.ReadOnly = true;
            dtgvDoUong.RowHeadersWidth = 51;
            dtgvDoUong.Size = new Size(573, 786);
            dtgvDoUong.TabIndex = 595;
            // 
            // HinhAnh
            // 
            HinhAnh.HeaderText = "Hình ảnh";
            HinhAnh.ImageLayout = DataGridViewImageCellLayout.Stretch;
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            HinhAnh.ReadOnly = true;
            HinhAnh.Width = 125;
            // 
            // MaDoUong
            // 
            MaDoUong.HeaderText = "Mã đồ uống";
            MaDoUong.MinimumWidth = 6;
            MaDoUong.Name = "MaDoUong";
            MaDoUong.ReadOnly = true;
            MaDoUong.Width = 80;
            // 
            // TenDoUong
            // 
            TenDoUong.HeaderText = "Tên đồ uống";
            TenDoUong.MinimumWidth = 6;
            TenDoUong.Name = "TenDoUong";
            TenDoUong.ReadOnly = true;
            TenDoUong.Width = 125;
            // 
            // GiaTien
            // 
            GiaTien.HeaderText = "Giá tiền";
            GiaTien.MinimumWidth = 6;
            GiaTien.Name = "GiaTien";
            GiaTien.ReadOnly = true;
            GiaTien.Width = 125;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(0, 75);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(214, 25);
            label8.TabIndex = 584;
            label8.Text = "BÀN ĐANG CHỌN :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(1012, 932);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(84, 25);
            label2.TabIndex = 582;
            label2.Text = "TỔNG:";
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.FromArgb(0, 0, 192);
            btnThanhToan.FlatStyle = FlatStyle.Popup;
            btnThanhToan.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(1360, 921);
            btnThanhToan.Margin = new Padding(4, 5, 4, 5);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(195, 46);
            btnThanhToan.TabIndex = 581;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += BtnThanhToan_Click;
            // 
            // dtgvHoaDon
            // 
            dtgvHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgvHoaDon.BackgroundColor = Color.White;
            dtgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvHoaDon.Location = new Point(1012, 301);
            dtgvHoaDon.Margin = new Padding(4, 5, 4, 5);
            dtgvHoaDon.Name = "dtgvHoaDon";
            dtgvHoaDon.RowHeadersWidth = 51;
            dtgvHoaDon.Size = new Size(756, 611);
            dtgvHoaDon.TabIndex = 580;
            // 
            // listViewBan
            // 
            listViewBan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listViewBan.BackColor = Color.White;
            listViewBan.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listViewBan.LargeImageList = imageList1;
            listViewBan.Location = new Point(3, 129);
            listViewBan.Margin = new Padding(4, 5, 4, 5);
            listViewBan.Name = "listViewBan";
            listViewBan.Size = new Size(420, 849);
            listViewBan.TabIndex = 578;
            listViewBan.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "table_no.jpg");
            imageList1.Images.SetKeyName(1, "table_yes.jpg");
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuNhanVien, menuThongTinCaNhan });
            hệThốngToolStripMenuItem.Image = (Image)resources.GetObject("hệThốngToolStripMenuItem.Image");
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(116, 27);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // lblTongTien
            // 
            lblTongTien.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(1106, 929);
            lblTongTien.Margin = new Padding(4, 0, 4, 0);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(88, 26);
            lblTongTien.TabIndex = 583;
            lblTongTien.Text = "O VNĐ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1534, 46);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 249);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 579;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, btnDanhMuc, menuKH, thốngKêToolStripMenuItem, btnDX });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1769, 31);
            menuStrip1.TabIndex = 577;
            menuStrip1.Text = "menuStrip1";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1769, 980);
            Controls.Add(groupBox1);
            Controls.Add(nmSoLuong);
            Controls.Add(label1);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(btnTim);
            Controls.Add(txtTenDoUong);
            Controls.Add(label3);
            Controls.Add(btnIn);
            Controls.Add(btnBanDaChon);
            Controls.Add(dtgvDoUong);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(btnThanhToan);
            Controls.Add(dtgvHoaDon);
            Controls.Add(listViewBan);
            Controls.Add(lblTongTien);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Name = "FormMain";
            Text = "Phần mềm quản lí quán cafe";
            Load += FormMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvDoUong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem menuNhanVien;
        private ToolStripMenuItem btnDanhMuc;
        private ToolStripMenuItem menuLDU;
        private ToolStripMenuItem menuDoUong;
        private ToolStripMenuItem menuBan;
        private ToolStripMenuItem menuKho;
        private GroupBox groupBox1;
        private DateTimePicker dtNgayOrder;
        private Label label7;
        private TextBox txtMaNV;
        private Label label6;
        private ToolStripMenuItem menuThongTinCaNhan;
        private NumericUpDown nmSoLuong;
        private Label label1;
        private Button btnXoa;
        private Button btnThem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private ToolStripMenuItem menuDoanhThuNgay;
        private ToolStripMenuItem menuThongKeDoanhThuNV;
        private ToolStripMenuItem menuLichSuHoaDon;
        private Button btnTim;
        internal TextBox txtTenDoUong;
        private Label label3;
        private Button btnIn;
        private Button btnBanDaChon;
        private ToolStripMenuItem btnDX;
        private ToolStripMenuItem menuKH;
        private DataGridView dtgvDoUong;
        private DataGridViewImageColumn HinhAnh;
        private DataGridViewTextBoxColumn MaDoUong;
        private DataGridViewTextBoxColumn TenDoUong;
        private DataGridViewTextBoxColumn GiaTien;
        private Label label8;
        private Label label2;
        private Button btnThanhToan;
        private DataGridView dtgvHoaDon;
        private ListView listViewBan;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private Label lblTongTien;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
    }
}
