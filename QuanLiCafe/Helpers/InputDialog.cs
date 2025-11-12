using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiCafe.Helpers
{
    public static class InputDialog
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() 
            { 
                Left = 20, 
                Top = 20, 
                Width = 340,
                Text = text 
            };

            TextBox textBox = new TextBox() 
            { 
                Left = 20, 
                Top = 50, 
                Width = 340,
                Text = defaultValue
            };

            Button confirmation = new Button() 
            { 
                Text = "OK", 
                Left = 180, 
                Width = 80, 
                Top = 90, 
                DialogResult = DialogResult.OK 
            };

            Button cancel = new Button() 
            { 
                Text = "H?y", 
                Left = 270, 
                Width = 80, 
                Top = 90, 
                DialogResult = DialogResult.Cancel 
            };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
