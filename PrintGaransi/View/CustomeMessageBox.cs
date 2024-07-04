using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintGaransi.View
{
    public partial class CustomeMessageBox : Form
    {
        private int borderSize = 2;

        public CustomeMessageBox(string text, string title, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            InitializeComponent();
            InitializeItems();
            this.labelMessage.Text = text;
            this.labelCaption.Text = title;
            SetFormSize();
            SetButtons(buttons, defaultButton);//Set Default Buttons
        }

        public static DialogResult Show(string text, string title, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
        {
            using (CustomeMessageBox customMessageBox = new CustomeMessageBox(text, title, buttons, defaultButton))
            {
                return customMessageBox.ShowDialog();
            }
        }

        private void SetButtons(MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton)
        {
            int xCenter = (this.panelButtons.Width - button1.Width) / 2;
            int yCenter = (this.panelButtons.Height - button1.Height) / 2;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    // OK Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter, yCenter);
                    button1.Text = "OK";
                    button1.DialogResult = DialogResult.OK;
                    // Set Default Button
                    SetDefaultButton(defaultButton);
                    break;
                case MessageBoxButtons.OKCancel:
                    // OK Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = "OK";
                    button1.DialogResult = DialogResult.OK;
                    // Cancel Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = "Cancel";
                    button2.DialogResult = DialogResult.Cancel;
                    button2.BackColor = Color.IndianRed;
                    // Set Default Button
                    SetDefaultButton(defaultButton);
                    break;
                case MessageBoxButtons.YesNo:
                    // Yes Button
                    button1.Visible = true;
                    button1.Location = new Point(xCenter - (button1.Width / 2) - 5, yCenter);
                    button1.Text = "Yes";
                    button1.DialogResult = DialogResult.Yes;
                    // No Button
                    button2.Visible = true;
                    button2.Location = new Point(xCenter + (button2.Width / 2) + 5, yCenter);
                    button2.Text = "No";
                    button2.DialogResult = DialogResult.No;
                    button2.BackColor = Color.IndianRed;
                    // Set Default Button
                    if (defaultButton != MessageBoxDefaultButton.Button3) // There are only 2 buttons, so the Default Button cannot be Button3
                        SetDefaultButton(defaultButton);
                    else
                        SetDefaultButton(MessageBoxDefaultButton.Button1);
                    break;
            }
        }

        private void SetDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case MessageBoxDefaultButton.Button1: // Focus button 1
                    button1.Select();
                    button1.ForeColor = Color.White;
                    button1.Font = new Font(button1.Font, FontStyle.Underline);
                    break;
                case MessageBoxDefaultButton.Button2: // Focus button 2
                    button2.Select();
                    button2.ForeColor = Color.White;
                    button2.Font = new Font(button2.Font, FontStyle.Underline);
                    break;
            }
        }

        private void SetFormSize()
        {
            int width = this.labelMessage.Width + this.panelBody.Padding.Left;
            int height = this.panelTitleBar.Height + this.labelMessage.Height + this.panelButtons.Height + this.panelBody.Padding.Top;
            this.Size = new Size(width, height);
        }

        private void InitializeItems()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize); // Set border size
            this.labelMessage.MaximumSize = new Size(550, 0);
            this.button2.DialogResult = DialogResult.Cancel;
            this.button1.DialogResult = DialogResult.OK;
            this.button1.Visible = false;
            this.button2.Visible = false;
        }

    }
}
