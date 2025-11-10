namespace QuanLiCafe.Forms
{
    partial class FormLogin
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
            panelHeader = new Panel();
            lblTitle = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            txbUserName = new TextBox();
            panel3 = new Panel();
            txbPassword = new TextBox();
            label2 = new Label();
            btnLogin = new Button();
            btnExit = new Button();
            panelHeader.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 73, 94);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(548, 133);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(11, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(549, 107);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "☕ LOGIN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 157);
            panel1.Name = "panel1";
            panel1.Size = new Size(523, 225);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(txbUserName);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(517, 58);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 13);
            label1.Name = "label1";
            label1.Size = new Size(159, 24);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập:";
            // 
            // txbUserName
            // 
            txbUserName.Location = new Point(177, 14);
            txbUserName.Name = "txbUserName";
            txbUserName.Size = new Size(327, 27);
            txbUserName.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(txbPassword);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(3, 84);
            panel3.Name = "panel3";
            panel3.Size = new Size(517, 58);
            panel3.TabIndex = 2;
            // 
            // txbPassword
            // 
            txbPassword.Location = new Point(177, 14);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(327, 27);
            txbPassword.TabIndex = 1;
            txbPassword.UseSystemPasswordChar = true;
            txbPassword.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 13);
            label2.Name = "label2";
            label2.Size = new Size(104, 24);
            label2.TabIndex = 0;
            label2.Text = "Mật khẩu:";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(31, 167);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(136, 35);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(350, 167);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(136, 35);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += button2_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(548, 391);
            Controls.Add(panel1);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            panelHeader.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private Panel panel1;
        private Panel panel2;
        private TextBox txbUserName;
        private Label label1;
        private Panel panel3;
        private TextBox txbPassword;
        private Label label2;
        private Button btnLogin;
        private Button btnExit;
    }
}
