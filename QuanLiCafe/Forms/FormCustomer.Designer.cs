namespace MemberForm
{
    partial class CustomerForm
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
            btn_them = new Button();
            btn_sua = new Button();
            btn_xoa = new Button();
            btn_lamMoi = new Button();
            btn_xuatExcel = new Button();
            btn_thoat = new Button();
            txb_timKiem = new TextBox();
            btn_timKiem = new Button();
            label_timKiem = new Label();
            dgv_customer = new DataGridView();
            MaKH = new DataGridViewTextBoxColumn();
            TenKH = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_customer).BeginInit();
            SuspendLayout();
            // 
            // btn_them
            // 
            btn_them.BackColor = Color.DeepSkyBlue;
            btn_them.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_them.ForeColor = SystemColors.ButtonFace;
            btn_them.Location = new Point(12, 15);
            btn_them.Margin = new Padding(3, 4, 3, 4);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(97, 49);
            btn_them.TabIndex = 0;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = false;
            btn_them.Click += button1_Click;
            // 
            // btn_sua
            // 
            btn_sua.BackColor = Color.DeepSkyBlue;
            btn_sua.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_sua.ForeColor = SystemColors.ButtonFace;
            btn_sua.Location = new Point(12, 71);
            btn_sua.Margin = new Padding(3, 4, 3, 4);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(97, 49);
            btn_sua.TabIndex = 1;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = false;
            // 
            // btn_xoa
            // 
            btn_xoa.BackColor = Color.DeepSkyBlue;
            btn_xoa.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_xoa.ForeColor = SystemColors.ButtonFace;
            btn_xoa.Location = new Point(12, 128);
            btn_xoa.Margin = new Padding(3, 4, 3, 4);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(97, 49);
            btn_xoa.TabIndex = 6;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = false;
            // 
            // btn_lamMoi
            // 
            btn_lamMoi.BackColor = Color.DeepSkyBlue;
            btn_lamMoi.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_lamMoi.ForeColor = SystemColors.ButtonFace;
            btn_lamMoi.Location = new Point(12, 184);
            btn_lamMoi.Margin = new Padding(3, 4, 3, 4);
            btn_lamMoi.Name = "btn_lamMoi";
            btn_lamMoi.Size = new Size(97, 49);
            btn_lamMoi.TabIndex = 7;
            btn_lamMoi.Text = "Làm mới";
            btn_lamMoi.UseVisualStyleBackColor = false;
            // 
            // btn_xuatExcel
            // 
            btn_xuatExcel.BackColor = Color.DeepSkyBlue;
            btn_xuatExcel.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xuatExcel.ForeColor = SystemColors.ButtonFace;
            btn_xuatExcel.Location = new Point(12, 240);
            btn_xuatExcel.Margin = new Padding(3, 4, 3, 4);
            btn_xuatExcel.Name = "btn_xuatExcel";
            btn_xuatExcel.Size = new Size(97, 49);
            btn_xuatExcel.TabIndex = 8;
            btn_xuatExcel.Text = "Xuất Excel";
            btn_xuatExcel.UseVisualStyleBackColor = false;
            btn_xuatExcel.Click += btn_xuatExcel_Click_1;
            // 
            // btn_thoat
            // 
            btn_thoat.BackColor = Color.DeepSkyBlue;
            btn_thoat.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_thoat.ForeColor = SystemColors.ButtonFace;
            btn_thoat.Location = new Point(12, 296);
            btn_thoat.Margin = new Padding(3, 4, 3, 4);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(97, 49);
            btn_thoat.TabIndex = 9;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = false;
            // 
            // txb_timKiem
            // 
            txb_timKiem.Location = new Point(520, 449);
            txb_timKiem.Margin = new Padding(3, 4, 3, 4);
            txb_timKiem.Name = "txb_timKiem";
            txb_timKiem.Size = new Size(283, 27);
            txb_timKiem.TabIndex = 11;
            // 
            // btn_timKiem
            // 
            btn_timKiem.BackColor = Color.DeepSkyBlue;
            btn_timKiem.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_timKiem.ForeColor = SystemColors.ButtonFace;
            btn_timKiem.Location = new Point(809, 440);
            btn_timKiem.Margin = new Padding(3, 4, 3, 4);
            btn_timKiem.Name = "btn_timKiem";
            btn_timKiem.Size = new Size(108, 49);
            btn_timKiem.TabIndex = 12;
            btn_timKiem.Text = "Tìm Kiếm";
            btn_timKiem.UseVisualStyleBackColor = false;
            // 
            // label_timKiem
            // 
            label_timKiem.AutoSize = true;
            label_timKiem.Font = new Font("Times New Roman", 10.8F);
            label_timKiem.Location = new Point(357, 452);
            label_timKiem.Name = "label_timKiem";
            label_timKiem.Size = new Size(156, 20);
            label_timKiem.TabIndex = 13;
            label_timKiem.Text = "Tìm kiếm theo SDT";
            label_timKiem.Click += label1_Click;
            // 
            // dgv_customer
            // 
            dgv_customer.BackgroundColor = Color.White;
            dgv_customer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_customer.Columns.AddRange(new DataGridViewColumn[] { MaKH, TenKH, GioiTinh, SDT });
            dgv_customer.Location = new Point(115, 15);
            dgv_customer.Margin = new Padding(3, 4, 3, 4);
            dgv_customer.Name = "dgv_customer";
            dgv_customer.RowHeadersWidth = 51;
            dgv_customer.RowTemplate.Height = 24;
            dgv_customer.Size = new Size(800, 410);
            dgv_customer.TabIndex = 14;
            // 
            // MaKH
            // 
            MaKH.HeaderText = "Mã KH";
            MaKH.MinimumWidth = 6;
            MaKH.Name = "MaKH";
            MaKH.Width = 125;
            // 
            // TenKH
            // 
            TenKH.HeaderText = "Tên KH";
            TenKH.MinimumWidth = 6;
            TenKH.Name = "TenKH";
            TenKH.Width = 150;
            // 
            // GioiTinh
            // 
            GioiTinh.HeaderText = "Giới Tính";
            GioiTinh.MinimumWidth = 6;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.Width = 110;
            // 
            // SDT
            // 
            SDT.HeaderText = "Số điện thoại";
            SDT.MinimumWidth = 6;
            SDT.Name = "SDT";
            SDT.Width = 125;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(932, 503);
            Controls.Add(dgv_customer);
            Controls.Add(label_timKiem);
            Controls.Add(btn_timKiem);
            Controls.Add(txb_timKiem);
            Controls.Add(btn_thoat);
            Controls.Add(btn_xuatExcel);
            Controls.Add(btn_lamMoi);
            Controls.Add(btn_xoa);
            Controls.Add(btn_sua);
            Controls.Add(btn_them);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh mục khách hàng";
            ((System.ComponentModel.ISupportInitialize)dgv_customer).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_lamMoi;
        private System.Windows.Forms.Button btn_xuatExcel;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.TextBox txb_timKiem;
        private System.Windows.Forms.Button btn_timKiem;
        private System.Windows.Forms.Label label_timKiem;
        private System.Windows.Forms.DataGridView dgv_customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
    }
}

