namespace PrintGaransi.View
{
    partial class CustomeMessageBox
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
            panelTitleBar = new TableLayoutPanel();
            panelBody = new TableLayoutPanel();
            labelMessage = new Label();
            panelButtons = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            labelCaption = new Label();
            panelTitleBar.SuspendLayout();
            panelBody.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitleBar
            // 
            panelTitleBar.ColumnCount = 1;
            panelTitleBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelTitleBar.Controls.Add(panelBody, 0, 1);
            panelTitleBar.Controls.Add(panelButtons, 0, 2);
            panelTitleBar.Controls.Add(labelCaption, 0, 0);
            panelTitleBar.Dock = DockStyle.Fill;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Margin = new Padding(0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.RowCount = 3;
            panelTitleBar.RowStyles.Add(new RowStyle(SizeType.Percent, 14.7635527F));
            panelTitleBar.RowStyles.Add(new RowStyle(SizeType.Percent, 51.90311F));
            panelTitleBar.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelTitleBar.Size = new Size(675, 222);
            panelTitleBar.TabIndex = 0;
            // 
            // panelBody
            // 
            panelBody.ColumnCount = 1;
            panelBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.1833744F));
            panelBody.Controls.Add(labelMessage, 0, 0);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(3, 35);
            panelBody.Name = "panelBody";
            panelBody.RowCount = 1;
            panelBody.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelBody.Size = new Size(669, 109);
            panelBody.TabIndex = 0;
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Dock = DockStyle.Fill;
            labelMessage.Font = new Font("Helvetica", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelMessage.Location = new Point(3, 0);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(663, 109);
            labelMessage.TabIndex = 2;
            labelMessage.Text = "label2";
            labelMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelButtons
            // 
            panelButtons.ColumnCount = 2;
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelButtons.Controls.Add(button1, 0, 0);
            panelButtons.Controls.Add(button2, 1, 0);
            panelButtons.Dock = DockStyle.Fill;
            panelButtons.Location = new Point(3, 150);
            panelButtons.Name = "panelButtons";
            panelButtons.RowCount = 1;
            panelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelButtons.Size = new Size(669, 69);
            panelButtons.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.MediumSeaGreen;
            button1.Font = new Font("Helvetica", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(116, 16);
            button1.Name = "button1";
            button1.Size = new Size(101, 37);
            button1.TabIndex = 0;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.Firebrick;
            button2.Font = new Font("Helvetica", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(451, 16);
            button2.Name = "button2";
            button2.Size = new Size(101, 37);
            button2.TabIndex = 0;
            button2.Text = "Cancle";
            button2.UseVisualStyleBackColor = false;
            // 
            // labelCaption
            // 
            labelCaption.AutoSize = true;
            labelCaption.BackColor = Color.FromArgb(0, 35, 105);
            labelCaption.Dock = DockStyle.Fill;
            labelCaption.Font = new Font("Helvetica Rounded", 23.9999962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCaption.ForeColor = Color.White;
            labelCaption.Location = new Point(0, 0);
            labelCaption.Margin = new Padding(0);
            labelCaption.Name = "labelCaption";
            labelCaption.Size = new Size(675, 32);
            labelCaption.TabIndex = 2;
            labelCaption.Text = "title";
            labelCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CustomeMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 222);
            Controls.Add(panelTitleBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomeMessageBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomeMessageBox";
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelBody.ResumeLayout(false);
            panelBody.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel panelTitleBar;
        private TableLayoutPanel panelBody;
        private TableLayoutPanel panelButtons;
        private Button button1;
        private Label labelCaption;
        private Label labelMessage;
        private Button button2;
    }
}