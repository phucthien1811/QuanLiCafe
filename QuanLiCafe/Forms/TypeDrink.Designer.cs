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
            panelLeft = new Panel();
            btnThoat = new Button();
            btnXuatExcel = new Button();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dtgvtypedrink = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvtypedrink).BeginInit();
            SuspendLayout();
            // 
            // labelTimKiem
            // 
            labelTimKiem.AutoSize = true;
            labelTimKiem.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTimKiem.Location = new Point(292, 755);
            labelTimKiem.Margin = new Padding(4, 0, 4, 0);
            labelTimKiem.Name = "labelTimKiem";
            labelTimKiem.Size = new Size(177, 27);
            labelTimKiem.TabIndex = 8;
            labelTimKiem.Text = "Tìm kiếm theo tên";
            // 
            // panelLeft
            // 
            panelLeft.BorderStyle = BorderStyle.FixedSingle;
            panelLeft.Controls.Add(btnThoat);
            panelLeft.Controls.Add(btnXuatExcel);
            panelLeft.Controls.Add(btnLamMoi);
            panelLeft.Controls.Add(btnXoa);
            panelLeft.Controls.Add(btnSua);
            panelLeft.Controls.Add(btnThem);
            panelLeft.Location = new Point(15, 19);
            panelLeft.Margin = new Padding(4, 5, 4, 5);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(212, 825);
            panelLeft.TabIndex = 7;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.FromArgb(192, 192, 255);
            btnThoat.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(31, 695);
            btnThoat.Margin = new Padding(4, 5, 4, 5);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(139, 94);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.FromArgb(192, 192, 255);
            btnXuatExcel.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatExcel.Location = new Point(31, 566);
            btnXuatExcel.Margin = new Padding(4, 5, 4, 5);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(139, 94);
            btnXuatExcel.TabIndex = 0;
            btnXuatExcel.Text = "Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(192, 192, 255);
            btnLamMoi.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.Location = new Point(31, 425);
            btnLamMoi.Margin = new Padding(4, 5, 4, 5);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(139, 94);
            btnLamMoi.TabIndex = 0;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(192, 192, 255);
            btnXoa.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(31, 295);
            btnXoa.Margin = new Padding(4, 5, 4, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(139, 94);
            btnXoa.TabIndex = 0;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(192, 192, 255);
            btnSua.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(31, 164);
            btnSua.Margin = new Padding(4, 5, 4, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(139, 94);
            btnSua.TabIndex = 0;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(192, 192, 255);
            btnThem.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(31, 30);
            btnThem.Margin = new Padding(4, 5, 4, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(139, 94);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(192, 192, 255);
            btnTimKiem.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTimKiem.Location = new Point(1064, 744);
            btnTimKiem.Margin = new Padding(4, 5, 4, 5);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(115, 61);
            btnTimKiem.TabIndex = 10;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(526, 755);
            txtTimKiem.Margin = new Padding(4, 5, 4, 5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(476, 31);
            txtTimKiem.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(315, 50);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 27);
            label1.TabIndex = 11;
            label1.Text = "Mã loại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(315, 109);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(82, 27);
            label2.TabIndex = 11;
            label2.Text = "Tên loại";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(570, 50);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(410, 31);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(570, 109);
            textBox2.Margin = new Padding(4, 5, 4, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(410, 31);
            textBox2.TabIndex = 12;
            // 
            // dtgvtypedrink
            // 
            dtgvtypedrink.BackgroundColor = SystemColors.ButtonHighlight;
            dtgvtypedrink.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvtypedrink.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dtgvtypedrink.GridColor = SystemColors.Window;
            dtgvtypedrink.Location = new Point(274, 166);
            dtgvtypedrink.Name = "dtgvtypedrink";
            dtgvtypedrink.RowHeadersWidth = 62;
            dtgvtypedrink.Size = new Size(905, 514);
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
            // TypeDrink
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(1228, 864);
            Controls.Add(dtgvtypedrink);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(labelTimKiem);
            Controls.Add(panelLeft);
            Margin = new Padding(4, 5, 4, 5);
            Name = "TypeDrink";
            Text = "Loại đồ uống";
            panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvtypedrink).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTimKiem;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private DataGridView dtgvtypedrink;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}