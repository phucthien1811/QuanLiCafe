namespace QuanLiCafe.Forms
{
    partial class Toping
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
            lblchonthongtin = new Label();
            lblTong = new Label();
            flpTopingList = new FlowLayoutPanel();
            btnThem = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblchonthongtin
            // 
            lblchonthongtin.AutoSize = true;
            lblchonthongtin.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblchonthongtin.Location = new Point(27, 28);
            lblchonthongtin.Name = "lblchonthongtin";
            lblchonthongtin.Size = new Size(110, 20);
            lblchonthongtin.TabIndex = 0;
            lblchonthongtin.Text = "Chọn Toping";
            // 
            // lblTong
            // 
            lblTong.AutoSize = true;
            lblTong.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold);
            lblTong.Location = new Point(40, 528);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(54, 20);
            lblTong.TabIndex = 1;
            lblTong.Text = "Tổng:";
            // 
            // flpTopingList
            // 
            flpTopingList.BackColor = SystemColors.Control;
            flpTopingList.Location = new Point(43, 82);
            flpTopingList.Name = "flpTopingList";
            flpTopingList.Size = new Size(403, 395);
            flpTopingList.TabIndex = 2;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DeepSkyBlue;
            btnThem.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonFace;
            btnThem.Location = new Point(355, 516);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(91, 45);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Red;
            btnThoat.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = SystemColors.ButtonFace;
            btnThoat.Location = new Point(258, 516);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(91, 45);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // Toping
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(500, 585);
            Controls.Add(btnThoat);
            Controls.Add(btnThem);
            Controls.Add(flpTopingList);
            Controls.Add(lblTong);
            Controls.Add(lblchonthongtin);
            Name = "Toping";
            Text = "Toping";
            Load += Toping_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblchonthongtin;
        private Label lblTong;
        private FlowLayoutPanel flpTopingList;
        private Button btnThem;
        private Button btnThoat;
    }
}