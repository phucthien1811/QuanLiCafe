namespace QuanLiCafe.Forms
{
    partial class FormChartProduct
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
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dtpNam = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            flpbieudol1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dtpNam
            // 
            dtpNam.CustomFormat = "yyyy";
            dtpNam.Format = DateTimePickerFormat.Custom;
            dtpNam.Location = new Point(128, 76);
            dtpNam.Name = "dtpNam";
            dtpNam.ShowUpDown = true;
            dtpNam.Size = new Size(64, 27);
            dtpNam.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 78);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 1;
            label1.Text = "Chọn năm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(170, 32);
            label2.Name = "label2";
            label2.Size = new Size(450, 21);
            label2.TabIndex = 2;
            label2.Text = "Biểu đồ thống kê doanh thu sản phẩm bán chạy nhất năm";
            // 
            // flpbieudol1
            // 
            flpbieudol1.BackColor = Color.White;
            flpbieudol1.Location = new Point(72, 130);
            flpbieudol1.Name = "flpbieudol1";
            flpbieudol1.Size = new Size(661, 335);
            flpbieudol1.TabIndex = 3;
            // 
            // FormChartProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(800, 511);
            Controls.Add(flpbieudol1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpNam);
            Name = "FormChartProduct";
            Text = "FormProduct";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DateTimePicker dtpNam;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flpbieudol1;
    }
}