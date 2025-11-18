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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dtpNam = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            flpbieudol1 = new FlowLayoutPanel();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            flpbieudol1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
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
            flpbieudol1.Controls.Add(chart1);
            flpbieudol1.Location = new Point(72, 130);
            flpbieudol1.Name = "flpbieudol1";
            flpbieudol1.Size = new Size(661, 335);
            flpbieudol1.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(3, 3);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(658, 375);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
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
            flpbieudol1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DateTimePicker dtpNam;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flpbieudol1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}