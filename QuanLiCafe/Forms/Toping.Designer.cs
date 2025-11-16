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
            lblchon = new Label();
            SuspendLayout();
            // 
            // lblchon
            // 
            lblchon.AutoSize = true;
            lblchon.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblchon.Location = new Point(30, 36);
            lblchon.Name = "lblchon";
            lblchon.Size = new Size(115, 23);
            lblchon.TabIndex = 0;
            lblchon.Text = "Chọn Toping";
            // 
            // Toping
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(414, 409);
            Controls.Add(lblchon);
            Name = "Toping";
            Text = "Chọn Toping";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblchon;
    }
}