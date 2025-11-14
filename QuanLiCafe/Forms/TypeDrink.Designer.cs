namespace DrinkForm
{
    partial class TypeDrink
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
            labelTimKiem = new Label();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            dtgvtypedrink = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            btnThoat = new Button();
            btnXuatExcel = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgvtypedrink).BeginInit();
            SuspendLayout();
            // 
            // labelTimKiem
            // 
            labelTimKiem.AutoSize = true;
            labelTimKiem.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTimKiem.Location = new Point(245, 486);
            labelTimKiem.Name = "labelTimKiem";
            labelTimKiem.Size = new Size(143, 20);
            labelTimKiem.TabIndex = 8;
            labelTimKiem.Text = "Tìm kiếm theo tên";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.DeepSkyBlue;
            btnTimKiem.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.ButtonFace;
            btnTimKiem.Location = new Point(800, 474);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(97, 49);
            btnTimKiem.TabIndex = 10;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(396, 483);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(382, 27);
            txtTimKiem.TabIndex = 9;
            // 
            // dtgvtypedrink
            // 
            dtgvtypedrink.BackgroundColor = SystemColors.ButtonHighlight;
            dtgvtypedrink.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvtypedrink.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dtgvtypedrink.GridColor = SystemColors.Window;
            dtgvtypedrink.Location = new Point(169, 22);
            dtgvtypedrink.Margin = new Padding(2);
            dtgvtypedrink.Name = "dtgvtypedrink";
            dtgvtypedrink.RowHeadersWidth = 62;
            dtgvtypedrink.Size = new Size(724, 411);
            dtgvtypedrink.TabIndex = 13;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã loại";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tên loại";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 150;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.DeepSkyBlue;
            btnThoat.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnThoat.ForeColor = SystemColors.ButtonFace;
            btnThoat.Location = new Point(22, 347);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(97, 49);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += button1_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.DeepSkyBlue;
            btnXuatExcel.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnXuatExcel.ForeColor = SystemColors.ButtonFace;
            btnXuatExcel.Location = new Point(22, 282);
            btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(97, 49);
            btnXuatExcel.TabIndex = 2;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.DeepSkyBlue;
            btnLamMoi.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnLamMoi.ForeColor = SystemColors.ButtonFace;
            btnLamMoi.Location = new Point(22, 217);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(97, 49);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.DeepSkyBlue;
            btnXoa.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnXoa.ForeColor = SystemColors.ButtonFace;
            btnXoa.Location = new Point(22, 152);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(97, 49);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DeepSkyBlue;
            btnSua.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnSua.ForeColor = SystemColors.ButtonFace;
            btnSua.Location = new Point(22, 87);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(97, 49);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DeepSkyBlue;
            btnThem.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btnThem.ForeColor = SystemColors.ButtonFace;
            btnThem.Location = new Point(22, 22);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(97, 49);
            btnThem.TabIndex = 6;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(900, 87);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(25, 27);
            textBox1.TabIndex = 14;
            textBox1.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(900, 120);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(25, 27);
            textBox2.TabIndex = 15;
            textBox2.Visible = false;
            // 
            // TypeDrink
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(947, 542);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnThoat);
            Controls.Add(btnXuatExcel);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dtgvtypedrink);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(labelTimKiem);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TypeDrink";
            Text = "Loại đồ uống";
            ((System.ComponentModel.ISupportInitialize)dtgvtypedrink).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private DataGridView dtgvtypedrink;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Button btnThoat;
        private Button btnXuatExcel;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}