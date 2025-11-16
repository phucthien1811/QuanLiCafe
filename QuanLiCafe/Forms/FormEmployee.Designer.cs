namespace QuanLiCafe.Forms
{
    partial class FormEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployee));
            menuThoat = new ToolStripMenuItem();
            menuXoa = new ToolStripMenuItem();
            menuSua = new ToolStripMenuItem();
            menuThem = new ToolStripMenuItem();
            menuTimKiem = new Button();
            txtSearch = new TextBox();
            label6 = new Label();
            dtgvData = new DataGridView();
            txtDiaChi = new TextBox();
            label5 = new Label();
            txtSDT = new TextBox();
            label4 = new Label();
            txtMatKhau = new TextBox();
            label3 = new Label();
            txtTenNV = new TextBox();
            label2 = new Label();
            txtMaNV = new TextBox();
            menuStrip1 = new MenuStrip();
            menuXoaTrang = new ToolStripMenuItem();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgvData).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuThoat
            // 
            menuThoat.Image = (Image)resources.GetObject("menuThoat.Image");
            menuThoat.Name = "menuThoat";
            menuThoat.Size = new Size(88, 27);
            menuThoat.Text = "Thoát";
            menuThoat.Click += MenuThoat_Click;
            // 
            // menuXoa
            // 
            menuXoa.Image = (Image)resources.GetObject("menuXoa.Image");
            menuXoa.Name = "menuXoa";
            menuXoa.Size = new Size(73, 27);
            menuXoa.Text = "Xóa";
            menuXoa.Click += MenuXoa_Click;
            // 
            // menuSua
            // 
            menuSua.Image = (Image)resources.GetObject("menuSua.Image");
            menuSua.Name = "menuSua";
            menuSua.Size = new Size(72, 27);
            menuSua.Text = "Sửa";
            menuSua.Click += MenuSua_Click;
            // 
            // menuThem
            // 
            menuThem.Image = (Image)resources.GetObject("menuThem.Image");
            menuThem.Name = "menuThem";
            menuThem.Size = new Size(87, 27);
            menuThem.Text = "Thêm";
            menuThem.Click += MenuThem_Click;
            // 
            // menuTimKiem
            // 
            menuTimKiem.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuTimKiem.Image = (Image)resources.GetObject("menuTimKiem.Image");
            menuTimKiem.ImageAlign = ContentAlignment.MiddleLeft;
            menuTimKiem.Location = new Point(680, 634);
            menuTimKiem.Margin = new Padding(4, 5, 4, 5);
            menuTimKiem.Name = "menuTimKiem";
            menuTimKiem.Size = new Size(140, 52);
            menuTimKiem.TabIndex = 28;
            menuTimKiem.Text = "Tìm kiếm";
            menuTimKiem.UseVisualStyleBackColor = true;
            menuTimKiem.Click += MenuTimKiem_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(472, 643);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(199, 24);
            txtSearch.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(313, 648);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(142, 20);
            label6.TabIndex = 26;
            label6.Text = "Tìm kiếm theo tên";
            // 
            // dtgvData
            // 
            dtgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvData.Location = new Point(25, 200);
            dtgvData.Margin = new Padding(4, 5, 4, 5);
            dtgvData.Name = "dtgvData";
            dtgvData.RowHeadersWidth = 51;
            dtgvData.Size = new Size(824, 425);
            dtgvData.TabIndex = 25;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiaChi.Location = new Point(161, 144);
            txtDiaChi.Margin = new Padding(4, 5, 4, 5);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(657, 24);
            txtDiaChi.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 149);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 23;
            label5.Text = "Ghi chú";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(620, 100);
            txtSDT.Margin = new Padding(4, 5, 4, 5);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(199, 24);
            txtSDT.TabIndex = 22;
            txtSDT.Text = "Staff";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(484, 104);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 21;
            label4.Text = "Role ";
            label4.Click += label4_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(620, 58);
            txtMatKhau.Margin = new Padding(4, 5, 4, 5);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(199, 24);
            txtMatKhau.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(484, 63);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 19;
            label3.Text = "Mật khẩu";
            // 
            // txtTenNV
            // 
            txtTenNV.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenNV.Location = new Point(161, 103);
            txtTenNV.Margin = new Padding(4, 5, 4, 5);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(199, 24);
            txtTenNV.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 108);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 17;
            label2.Text = "Username";
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaNV.Location = new Point(161, 61);
            txtMaNV.Margin = new Padding(4, 5, 4, 5);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(199, 24);
            txtMaNV.TabIndex = 16;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuThem, menuSua, menuXoa, menuXoaTrang, menuThoat });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(8, 3, 0, 3);
            menuStrip1.Size = new Size(849, 33);
            menuStrip1.TabIndex = 29;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuXoaTrang
            // 
            menuXoaTrang.Image = (Image)resources.GetObject("menuXoaTrang.Image");
            menuXoaTrang.Name = "menuXoaTrang";
            menuXoaTrang.Size = new Size(119, 27);
            menuXoaTrang.Text = "Xóa trắng";
            menuXoaTrang.Click += MenuXoaTrang_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 66);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(26, 20);
            label1.TabIndex = 15;
            label1.Text = "ID";
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(849, 692);
            Controls.Add(menuTimKiem);
            Controls.Add(txtSearch);
            Controls.Add(label6);
            Controls.Add(dtgvData);
            Controls.Add(txtDiaChi);
            Controls.Add(label5);
            Controls.Add(txtSDT);
            Controls.Add(label4);
            Controls.Add(txtMatKhau);
            Controls.Add(label3);
            Controls.Add(txtTenNV);
            Controls.Add(label2);
            Controls.Add(txtMaNV);
            Controls.Add(menuStrip1);
            Controls.Add(label1);
            Name = "FormEmployee";
            Text = "Quản Lý Nhân Viên";
            Load += FormEmployee_Load_1;
            ((System.ComponentModel.ISupportInitialize)dtgvData).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem menuThoat;
        private ToolStripMenuItem menuXoa;
        private ToolStripMenuItem menuSua;
        private ToolStripMenuItem menuThem;
        private Button menuTimKiem;
        private TextBox txtSearch;
        private Label label6;
        private DataGridView dtgvData;
        private TextBox txtDiaChi;
        private Label label5;
        private TextBox txtSDT;
        private Label label4;
        private TextBox txtMatKhau;
        private Label label3;
        private TextBox txtTenNV;
        private Label label2;
        private TextBox txtMaNV;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuXoaTrang;
        private Label label1;
    }
}