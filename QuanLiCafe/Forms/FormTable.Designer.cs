namespace TableForm
{
    partial class TableForm
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
            this.label_timKiem = new System.Windows.Forms.Label();
            this.btn_timKiem = new System.Windows.Forms.Button();
            this.txb_timKiem = new System.Windows.Forms.TextBox();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.btn_xuatExcel = new System.Windows.Forms.Button();
            this.btn_lamMoi = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.dgv_table = new System.Windows.Forms.DataGridView();
            this.Soban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tenban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vitri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trangthai = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).BeginInit();
            this.SuspendLayout();
            // 
            // label_timKiem
            // 
            this.label_timKiem.AutoSize = true;
            this.label_timKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_timKiem.Location = new System.Drawing.Point(287, 410);
            this.label_timKiem.Name = "label_timKiem";
            this.label_timKiem.Size = new System.Drawing.Size(133, 19);
            this.label_timKiem.TabIndex = 23;
            this.label_timKiem.Text = "Tìm kiếm theo tên";
            // 
            // btn_timKiem
            // 
            this.btn_timKiem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_timKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timKiem.Location = new System.Drawing.Point(766, 398);
            this.btn_timKiem.Name = "btn_timKiem";
            this.btn_timKiem.Size = new System.Drawing.Size(97, 39);
            this.btn_timKiem.TabIndex = 22;
            this.btn_timKiem.Text = "Tìm Kiếm";
            this.btn_timKiem.UseVisualStyleBackColor = false;
            // 
            // txb_timKiem
            // 
            this.txb_timKiem.Location = new System.Drawing.Point(466, 407);
            this.txb_timKiem.Name = "txb_timKiem";
            this.txb_timKiem.Size = new System.Drawing.Size(283, 22);
            this.txb_timKiem.TabIndex = 21;
            // 
            // btn_thoat
            // 
            this.btn_thoat.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_thoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(12, 237);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(97, 39);
            this.btn_thoat.TabIndex = 20;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = false;
            // 
            // btn_xuatExcel
            // 
            this.btn_xuatExcel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_xuatExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuatExcel.Location = new System.Drawing.Point(12, 192);
            this.btn_xuatExcel.Name = "btn_xuatExcel";
            this.btn_xuatExcel.Size = new System.Drawing.Size(97, 39);
            this.btn_xuatExcel.TabIndex = 19;
            this.btn_xuatExcel.Text = "Xuất Excel";
            this.btn_xuatExcel.UseVisualStyleBackColor = false;
            // 
            // btn_lamMoi
            // 
            this.btn_lamMoi.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_lamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lamMoi.Location = new System.Drawing.Point(12, 147);
            this.btn_lamMoi.Name = "btn_lamMoi";
            this.btn_lamMoi.Size = new System.Drawing.Size(97, 39);
            this.btn_lamMoi.TabIndex = 18;
            this.btn_lamMoi.Text = "Làm mới";
            this.btn_lamMoi.UseVisualStyleBackColor = false;
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(12, 102);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(97, 39);
            this.btn_xoa.TabIndex = 17;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.Location = new System.Drawing.Point(12, 57);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(97, 39);
            this.btn_sua.TabIndex = 16;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(12, 12);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(97, 39);
            this.btn_them.TabIndex = 15;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            // 
            // dgv_table
            // 
            this.dgv_table.BackgroundColor = System.Drawing.Color.White;
            this.dgv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Soban,
            this.Tenban,
            this.Vitri,
            this.Trangthai});
            this.dgv_table.Location = new System.Drawing.Point(115, 12);
            this.dgv_table.Name = "dgv_table";
            this.dgv_table.RowHeadersWidth = 51;
            this.dgv_table.RowTemplate.Height = 24;
            this.dgv_table.Size = new System.Drawing.Size(799, 365);
            this.dgv_table.TabIndex = 24;
            // 
            // Soban
            // 
            this.Soban.HeaderText = "Số bàn";
            this.Soban.MinimumWidth = 6;
            this.Soban.Name = "Soban";
            this.Soban.Width = 125;
            // 
            // Tenban
            // 
            this.Tenban.HeaderText = "Tên bàn";
            this.Tenban.MinimumWidth = 6;
            this.Tenban.Name = "Tenban";
            this.Tenban.Width = 125;
            // 
            // Vitri
            // 
            this.Vitri.HeaderText = "Vị trí";
            this.Vitri.MinimumWidth = 6;
            this.Vitri.Name = "Vitri";
            this.Vitri.Width = 125;
            // 
            // Trangthai
            // 
            this.Trangthai.HeaderText = "Trạng thái";
            this.Trangthai.MinimumWidth = 6;
            this.Trangthai.Name = "Trangthai";
            this.Trangthai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Trangthai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Trangthai.Width = 125;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(926, 470);
            this.Controls.Add(this.dgv_table);
            this.Controls.Add(this.label_timKiem);
            this.Controls.Add(this.btn_timKiem);
            this.Controls.Add(this.txb_timKiem);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_xuatExcel);
            this.Controls.Add(this.btn_lamMoi);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_them);
            this.Name = "TableForm";
            this.Text = "Danh mục bàn";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_timKiem;
        private System.Windows.Forms.Button btn_timKiem;
        private System.Windows.Forms.TextBox txb_timKiem;
        private System.Windows.Forms.Button btn_thoat;
        private System.Windows.Forms.Button btn_xuatExcel;
        private System.Windows.Forms.Button btn_lamMoi;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.DataGridView dgv_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tenban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vitri;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Trangthai;
    }
}

