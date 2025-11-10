namespace QuanLiCafe.Forms
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            menuStrip2 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            quảnLíKháchHàngToolStripMenuItem = new ToolStripMenuItem();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thôngTinCáNhânToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem = new ToolStripMenuItem();
            loạiĐồUốngToolStripMenuItem = new ToolStripMenuItem();
            đồUốngToolStripMenuItem = new ToolStripMenuItem();
            bànToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 28);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1305, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, danhMụcToolStripMenuItem, quảnLíKháchHàngToolStripMenuItem, thốngKêToolStripMenuItem, đăngXuấtToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(1305, 28);
            menuStrip2.TabIndex = 1;
            menuStrip2.Text = "menuStrip2";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinCáNhânToolStripMenuItem, nhânViênToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(85, 24);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loạiĐồUốngToolStripMenuItem, đồUốngToolStripMenuItem, bànToolStripMenuItem });
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(90, 24);
            danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // quảnLíKháchHàngToolStripMenuItem
            // 
            quảnLíKháchHàngToolStripMenuItem.Name = "quảnLíKháchHàngToolStripMenuItem";
            quảnLíKháchHàngToolStripMenuItem.Size = new Size(149, 24);
            quảnLíKháchHàngToolStripMenuItem.Text = "Quản lí khách hàng";
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Size = new Size(84, 24);
            thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(91, 24);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            thôngTinCáNhânToolStripMenuItem.Size = new Size(224, 26);
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            // 
            // nhânViênToolStripMenuItem
            // 
            nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            nhânViênToolStripMenuItem.Size = new Size(236, 26);
            nhânViênToolStripMenuItem.Text = "Nhân viên - Tài Khoản";
            nhânViênToolStripMenuItem.Click += nhânViênToolStripMenuItem_Click;
            // 
            // loạiĐồUốngToolStripMenuItem
            // 
            loạiĐồUốngToolStripMenuItem.Name = "loạiĐồUốngToolStripMenuItem";
            loạiĐồUốngToolStripMenuItem.Size = new Size(224, 26);
            loạiĐồUốngToolStripMenuItem.Text = "Loại đồ uống";
            // 
            // đồUốngToolStripMenuItem
            // 
            đồUốngToolStripMenuItem.Name = "đồUốngToolStripMenuItem";
            đồUốngToolStripMenuItem.Size = new Size(224, 26);
            đồUốngToolStripMenuItem.Text = "Đồ uống";
            // 
            // bànToolStripMenuItem
            // 
            bànToolStripMenuItem.Name = "bànToolStripMenuItem";
            bànToolStripMenuItem.Size = new Size(224, 26);
            bànToolStripMenuItem.Text = "Bàn";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1305, 678);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "Phần mềm quản lí quán cafe";
            Load += FormMain_Load;
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private ToolStripMenuItem nhânViênToolStripMenuItem;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem quảnLíKháchHàngToolStripMenuItem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem loạiĐồUốngToolStripMenuItem;
        private ToolStripMenuItem đồUốngToolStripMenuItem;
        private ToolStripMenuItem bànToolStripMenuItem;
    }
}
