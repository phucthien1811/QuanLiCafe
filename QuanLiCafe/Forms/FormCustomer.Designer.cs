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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_lamMoi = new System.Windows.Forms.Button();
            this.btn_xuatExcel = new System.Windows.Forms.Button();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.txb_timKiem = new System.Windows.Forms.TextBox();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.label_timKiem = new System.Windows.Forms.Label();
            this.dgv_customer = new System.Windows.Forms.DataGridView();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customer)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(12, 12);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(97, 39);
            this.btn_them.TabIndex = 0;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.Location = new System.Drawing.Point(12, 57);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(97, 39);
            this.btn_sua.TabIndex = 1;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(12, 102);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(97, 39);
            this.btn_xoa.TabIndex = 6;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            // 
            // btn_lamMoi
            // 
            this.btn_lamMoi.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_lamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lamMoi.Location = new System.Drawing.Point(12, 147);
            this.btn_lamMoi.Name = "btn_lamMoi";
            this.btn_lamMoi.Size = new System.Drawing.Size(97, 39);
            this.btn_lamMoi.TabIndex = 7;
            this.btn_lamMoi.Text = "Làm mới";
            this.btn_lamMoi.UseVisualStyleBackColor = false;
            // 
            // btn_xuatExcel
            // 
            this.btn_xuatExcel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_xuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuatExcel.Location = new System.Drawing.Point(12, 192);
            this.btn_xuatExcel.Name = "btn_xuatExcel";
            this.btn_xuatExcel.Size = new System.Drawing.Size(97, 39);
            this.btn_xuatExcel.TabIndex = 8;
            this.btn_xuatExcel.Text = "Xuất Excel";
            this.btn_xuatExcel.UseVisualStyleBackColor = false;
            // 
            // btn_thoat
            // 
            this.btn_thoat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_thoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(12, 237);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(97, 39);
            this.btn_thoat.TabIndex = 9;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = false;
            // 
            // txb_timKiem
            // 
            this.txb_timKiem.Location = new System.Drawing.Point(466, 407);
            this.txb_timKiem.Name = "txb_timKiem";
            this.txb_timKiem.Size = new System.Drawing.Size(283, 22);
            this.txb_timKiem.TabIndex = 11;
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_timKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timKiem.Location = new System.Drawing.Point(766, 398);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.Size = new System.Drawing.Size(97, 39);
            this.btn_timKiem.TabIndex = 12;
            this.btn_timKiem.Text = "Tìm Kiếm";
            this.btn_timKiem.UseVisualStyleBackColor = false;
            // 
            // label_timKiem
            // 
            this.label_timKiem.AutoSize = true;
            this.label_timKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timKiem.Location = new System.Drawing.Point(287, 410);
            this.label_timKiem.Name = "label_timKiem";
            this.label_timKiem.Size = new System.Drawing.Size(142, 19);
            this.label_timKiem.TabIndex = 13;
            this.label_timKiem.Text = "Tìm kiếm theo SDT";
            this.label_timKiem.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgv_customer
            // 
            this.dgv_customer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_customer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_customer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_customer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKH,
            this.TenKH,
            this.GioiTinh,
            this.SDT});
            this.dgv_customer.Location = new System.Drawing.Point(115, 12);
            this.dgv_customer.Name = "dgv_customer";
            this.dgv_customer.RowHeadersWidth = 51;
            this.dgv_customer.RowTemplate.Height = 24;
            this.dgv_customer.Size = new System.Drawing.Size(799, 365);
            this.dgv_customer.TabIndex = 14;
            // 
            // MaKH
            // 
            this.MaKH.HeaderText = "Mã KH";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            this.MaKH.Width = 125;
            // 
            // TenKH
            // 
            this.TenKH.HeaderText = "Tên KH";
            this.TenKH.MinimumWidth = 6;
            this.TenKH.Name = "TenKH";
            this.TenKH.Width = 150;
            // 
            // GioiTinh
            // 
            this.GioiTinh.HeaderText = "Giới Tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Width = 110;
            // 
            // SDT
            // 
            this.SDT.HeaderText = "Số điện thoại";
            this.SDT.MinimumWidth = 6;
            this.SDT.Name = "SDT";
            this.SDT.Width = 125;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(926, 470);
            this.Controls.Add(this.dgv_customer);
            this.Controls.Add(this.label_timKiem);
            this.Controls.Add(this.btn_timKiem);
            this.Controls.Add(this.txb_timKiem);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_xuatExcel);
            this.Controls.Add(this.btn_lamMoi);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Name = "CustomerForm";
            this.Text = "Danh mục khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_customer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

