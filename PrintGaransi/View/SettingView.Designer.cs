namespace PrintGaransi.View
{
    partial class SettingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingView));
            textBoxIP = new TextBox();
            textBoxPort = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            label4 = new Label();
            locationBox = new ComboBox();
            btnConnect = new Resource.RDButton();
            label5 = new Label();
            JPComboBox = new ComboBox();
            label6 = new Label();
            btnOn = new RadioButton();
            btnOff = new RadioButton();
            btnClose = new Resource.RDButton();
            label7 = new Label();
            btnPreview = new RadioButton();
            label8 = new Label();
            printerBox = new ComboBox();
            checkBox = new CheckBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // textBoxIP
            // 
            textBoxIP.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxIP.Location = new Point(309, 289);
            textBoxIP.Margin = new Padding(3, 4, 3, 4);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(351, 37);
            textBoxIP.TabIndex = 0;
            // 
            // textBoxPort
            // 
            textBoxPort.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPort.Location = new Point(309, 356);
            textBoxPort.Margin = new Padding(3, 4, 3, 4);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(351, 37);
            textBoxPort.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            label1.Location = new Point(109, 293);
            label1.Name = "label1";
            label1.Size = new Size(150, 32);
            label1.TabIndex = 2;
            label1.Text = "Camera IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            label2.Location = new Point(109, 364);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 3;
            label2.Text = "Camera Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(318, 32);
            label3.Name = "label3";
            label3.Size = new Size(171, 51);
            label3.TabIndex = 5;
            label3.Text = "Setting";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 5;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            label4.Location = new Point(109, 460);
            label4.Name = "label4";
            label4.Size = new Size(129, 32);
            label4.TabIndex = 6;
            label4.Text = "Location";
            // 
            // locationBox
            // 
            locationBox.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            locationBox.FormattingEnabled = true;
            locationBox.Location = new Point(312, 455);
            locationBox.Margin = new Padding(3, 4, 3, 4);
            locationBox.Name = "locationBox";
            locationBox.Size = new Size(348, 41);
            locationBox.TabIndex = 7;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(27, 60, 115);
            btnConnect.BackgroundColor = Color.FromArgb(27, 60, 115);
            btnConnect.BorderColor = Color.PaleVioletRed;
            btnConnect.BorderRadius = 8;
            btnConnect.BorderSize = 0;
            btnConnect.Cursor = Cursors.Hand;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.Transparent;
            btnConnect.Image = (Image)resources.GetObject("btnConnect.Image");
            btnConnect.ImageAlign = ContentAlignment.MiddleLeft;
            btnConnect.Location = new Point(157, 737);
            btnConnect.Margin = new Padding(3, 4, 3, 4);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(200, 53);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "     Connect";
            btnConnect.TextColor = Color.Transparent;
            btnConnect.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            label5.Location = new Point(109, 540);
            label5.Name = "label5";
            label5.Size = new Size(187, 32);
            label5.TabIndex = 9;
            label5.Text = "Jenis Produk";
            // 
            // JPComboBox
            // 
            JPComboBox.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            JPComboBox.FormattingEnabled = true;
            JPComboBox.Location = new Point(312, 528);
            JPComboBox.Margin = new Padding(3, 4, 3, 4);
            JPComboBox.Name = "JPComboBox";
            JPComboBox.Size = new Size(348, 41);
            JPComboBox.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(106, 221);
            label6.Name = "label6";
            label6.Size = new Size(155, 32);
            label6.TabIndex = 2;
            label6.Text = "Print Mode";
            // 
            // btnOn
            // 
            btnOn.AutoSize = true;
            btnOn.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOn.Location = new Point(332, 221);
            btnOn.Margin = new Padding(3, 4, 3, 4);
            btnOn.Name = "btnOn";
            btnOn.Size = new Size(83, 43);
            btnOn.TabIndex = 11;
            btnOn.TabStop = true;
            btnOn.Text = "On";
            btnOn.UseVisualStyleBackColor = true;
            // 
            // btnOff
            // 
            btnOff.AutoSize = true;
            btnOff.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOff.Location = new Point(421, 221);
            btnOff.Margin = new Padding(3, 4, 3, 4);
            btnOff.Name = "btnOff";
            btnOff.Size = new Size(83, 43);
            btnOff.TabIndex = 11;
            btnOff.TabStop = true;
            btnOff.Text = "Off";
            btnOff.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.BackgroundColor = Color.Red;
            btnClose.BorderColor = Color.PaleVioletRed;
            btnClose.BorderRadius = 8;
            btnClose.BorderSize = 0;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(422, 737);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(200, 53);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.TextColor = Color.White;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(309, 401);
            label7.Name = "label7";
            label7.Size = new Size(399, 22);
            label7.TabIndex = 12;
            label7.Text = "*Click button Connect after change IP/Port";
            // 
            // btnPreview
            // 
            btnPreview.AutoSize = true;
            btnPreview.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPreview.Location = new Point(510, 221);
            btnPreview.Margin = new Padding(3, 4, 3, 4);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(155, 43);
            btnPreview.TabIndex = 11;
            btnPreview.TabStop = true;
            btnPreview.Text = "Preview";
            btnPreview.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 15.75F, FontStyle.Bold);
            label8.Location = new Point(109, 608);
            label8.Name = "label8";
            label8.Size = new Size(103, 32);
            label8.TabIndex = 9;
            label8.Text = "Printer";
            // 
            // printerBox
            // 
            printerBox.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            printerBox.FormattingEnabled = true;
            printerBox.Location = new Point(312, 596);
            printerBox.Margin = new Padding(3, 4, 3, 4);
            printerBox.Name = "printerBox";
            printerBox.Size = new Size(348, 41);
            printerBox.TabIndex = 10;
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Cursor = Cursors.Hand;
            checkBox.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox.Location = new Point(332, 155);
            checkBox.Margin = new Padding(3, 4, 3, 4);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(167, 43);
            checkBox.TabIndex = 13;
            checkBox.Text = "checklist";
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(109, 155);
            label9.Name = "label9";
            label9.Size = new Size(213, 32);
            label9.TabIndex = 2;
            label9.Text = "Actived Setting";
            // 
            // SettingView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 857);
            Controls.Add(checkBox);
            Controls.Add(label7);
            Controls.Add(btnPreview);
            Controls.Add(btnOff);
            Controls.Add(btnOn);
            Controls.Add(printerBox);
            Controls.Add(label8);
            Controls.Add(JPComboBox);
            Controls.Add(label5);
            Controls.Add(btnClose);
            Controls.Add(btnConnect);
            Controls.Add(locationBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxIP);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettingView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Setting";
            Load += SettingView_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxIP;
        private TextBox textBoxPort;
        private Label label1;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button button3;
        private Button button2;
        private Label label4;
        private ComboBox locationBox;
        private Resource.RDButton btnConnect;
        private Label label5;
        private ComboBox JPComboBox;
        private Label label6;
        private RadioButton btnOn;
        private RadioButton btnOff;
        private Resource.RDButton btnClose;
        private Label label7;
        private RadioButton btnPreview;
        private Label label8;
        private ComboBox printerBox;
        private CheckBox checkBox;
        private Label label9;
    }
}