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
            label_timKiem = new Label();
            btn_timKiem = new Button();
            txb_timKiem = new TextBox();
            btn_thoat = new Button();
            btn_xuatExcel = new Button();
            btn_lamMoi = new Button();
            btn_xoa = new Button();
            btn_sua = new Button();
            btn_them = new Button();
            dgv_table = new DataGridView();
            Soban = new DataGridViewTextBoxColumn();
            Tenban = new DataGridViewTextBoxColumn();
            Vitri = new DataGridViewTextBoxColumn();
            Trangthai = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_table).BeginInit();
            SuspendLayout();
            // 
            // label_timKiem
            // 
            label_timKiem.AutoSize = true;
            label_timKiem.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_timKiem.Location = new Point(309, 512);
            label_timKiem.Name = "label_timKiem";
            label_timKiem.Size = new Size(143, 20);
            label_timKiem.TabIndex = 23;
            label_timKiem.Text = "Tìm kiếm theo tên";
            // 
            // btn_timKiem
            // 
            btn_timKiem.BackColor = Color.DeepSkyBlue;
            btn_timKiem.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_timKiem.ForeColor = SystemColors.ButtonFace;
            btn_timKiem.Location = new Point(766, 498);
            btn_timKiem.Margin = new Padding(3, 4, 3, 4);
            btn_timKiem.Name = "btn_timKiem";
            btn_timKiem.Size = new Size(97, 49);
            btn_timKiem.TabIndex = 22;
            btn_timKiem.Text = "Tìm Kiếm";
            btn_timKiem.UseVisualStyleBackColor = false;
            // 
            // txb_timKiem
            // 
            txb_timKiem.Location = new Point(466, 509);
            txb_timKiem.Margin = new Padding(3, 4, 3, 4);
            txb_timKiem.Name = "txb_timKiem";
            txb_timKiem.Size = new Size(283, 27);
            txb_timKiem.TabIndex = 21;
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
            btn_thoat.TabIndex = 20;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = false;
            // 
            // btn_xuatExcel
            // 
            btn_xuatExcel.BackColor = Color.DeepSkyBlue;
            btn_xuatExcel.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_xuatExcel.ForeColor = SystemColors.ButtonFace;
            btn_xuatExcel.Location = new Point(12, 240);
            btn_xuatExcel.Margin = new Padding(3, 4, 3, 4);
            btn_xuatExcel.Name = "btn_xuatExcel";
            btn_xuatExcel.Size = new Size(97, 49);
            btn_xuatExcel.TabIndex = 19;
            btn_xuatExcel.Text = "Xuất Excel";
            btn_xuatExcel.UseVisualStyleBackColor = false;
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
            btn_lamMoi.TabIndex = 18;
            btn_lamMoi.Text = "Làm mới";
            btn_lamMoi.UseVisualStyleBackColor = false;
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
            btn_xoa.TabIndex = 17;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = false;
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
            btn_sua.TabIndex = 16;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = false;
            btn_sua.Click += btn_sua_Click;
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
            btn_them.TabIndex = 15;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = false;
            // 
            // dgv_table
            // 
            dgv_table.BackgroundColor = Color.White;
            dgv_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_table.Columns.AddRange(new DataGridViewColumn[] { Soban, Tenban, Vitri, Trangthai });
            dgv_table.Location = new Point(115, 15);
            dgv_table.Margin = new Padding(3, 4, 3, 4);
            dgv_table.Name = "dgv_table";
            dgv_table.RowHeadersWidth = 51;
            dgv_table.RowTemplate.Height = 24;
            dgv_table.Size = new Size(748, 456);
            dgv_table.TabIndex = 24;
            // 
            // Soban
            // 
            Soban.HeaderText = "Số bàn";
            Soban.MinimumWidth = 6;
            Soban.Name = "Soban";
            Soban.Width = 125;
            // 
            // Tenban
            // 
            Tenban.HeaderText = "Tên bàn";
            Tenban.MinimumWidth = 6;
            Tenban.Name = "Tenban";
            Tenban.Width = 125;
            // 
            // Vitri
            // 
            Vitri.HeaderText = "Vị trí";
            Vitri.MinimumWidth = 6;
            Vitri.Name = "Vitri";
            Vitri.Width = 125;
            // 
            // Trangthai
            // 
            Trangthai.HeaderText = "Trạng thái";
            Trangthai.MinimumWidth = 6;
            Trangthai.Name = "Trangthai";
            Trangthai.Resizable = DataGridViewTriState.True;
            Trangthai.SortMode = DataGridViewColumnSortMode.Automatic;
            Trangthai.Width = 125;
            // 
            // TableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(906, 571);
            Controls.Add(dgv_table);
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
            Name = "TableForm";
            Text = "Danh mục bàn";
            ((System.ComponentModel.ISupportInitialize)dgv_table).EndInit();
            ResumeLayout(false);
            PerformLayout();

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

