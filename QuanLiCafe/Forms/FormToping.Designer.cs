namespace QuanLiCafe.Forms
{
    partial class FormToping
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
            btn_thoat = new Button();
            btn_lamMoi = new Button();
            btn_xoa = new Button();
            btn_sua = new Button();
            btn_them = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btn_thoat
            // 
            btn_thoat.BackColor = Color.DeepSkyBlue;
            btn_thoat.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_thoat.ForeColor = SystemColors.ButtonFace;
            btn_thoat.Location = new Point(12, 239);
            btn_thoat.Margin = new Padding(3, 4, 3, 4);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(97, 49);
            btn_thoat.TabIndex = 14;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = false;
            // 
            // btn_lamMoi
            // 
            btn_lamMoi.BackColor = Color.DeepSkyBlue;
            btn_lamMoi.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_lamMoi.ForeColor = SystemColors.ButtonFace;
            btn_lamMoi.Location = new Point(12, 182);
            btn_lamMoi.Margin = new Padding(3, 4, 3, 4);
            btn_lamMoi.Name = "btn_lamMoi";
            btn_lamMoi.Size = new Size(97, 49);
            btn_lamMoi.TabIndex = 13;
            btn_lamMoi.Text = "Làm mới";
            btn_lamMoi.UseVisualStyleBackColor = false;
            // 
            // btn_xoa
            // 
            btn_xoa.BackColor = Color.DeepSkyBlue;
            btn_xoa.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_xoa.ForeColor = SystemColors.ButtonFace;
            btn_xoa.Location = new Point(12, 126);
            btn_xoa.Margin = new Padding(3, 4, 3, 4);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(97, 49);
            btn_xoa.TabIndex = 12;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = false;
            // 
            // btn_sua
            // 
            btn_sua.BackColor = Color.DeepSkyBlue;
            btn_sua.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            btn_sua.ForeColor = SystemColors.ButtonFace;
            btn_sua.Location = new Point(12, 69);
            btn_sua.Margin = new Padding(3, 4, 3, 4);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(97, 49);
            btn_sua.TabIndex = 11;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = false;
            // 
            // btn_them
            // 
            btn_them.BackColor = Color.DeepSkyBlue;
            btn_them.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_them.ForeColor = SystemColors.ButtonFace;
            btn_them.Location = new Point(12, 13);
            btn_them.Margin = new Padding(3, 4, 3, 4);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(97, 49);
            btn_them.TabIndex = 10;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridView1.Location = new Point(130, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(525, 338);
            dataGridView1.TabIndex = 15;
            // 
            // Column1
            // 
            Column1.HeaderText = "Mã Toping";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Tên Toping";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Giá";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // FormToping
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(677, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btn_thoat);
            Controls.Add(btn_lamMoi);
            Controls.Add(btn_xoa);
            Controls.Add(btn_sua);
            Controls.Add(btn_them);
            Name = "FormToping";
            Text = "FormToping";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_thoat;
        private Button btn_lamMoi;
        private Button btn_xoa;
        private Button btn_sua;
        private Button btn_them;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}