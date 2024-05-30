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
            SuspendLayout();
            // 
            // textBoxIP
            // 
            textBoxIP.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxIP.Location = new Point(311, 104);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(207, 31);
            textBoxIP.TabIndex = 0;
            // 
            // textBoxPort
            // 
            textBoxPort.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPort.Location = new Point(311, 160);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(207, 31);
            textBoxPort.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(136, 107);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 2;
            label1.Text = "IP Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(136, 166);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(221, 33);
            label3.Name = "label3";
            label3.Size = new Size(235, 31);
            label3.TabIndex = 5;
            label3.Text = "Setting IP Camera";
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
            label4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(136, 232);
            label4.Name = "label4";
            label4.Size = new Size(94, 25);
            label4.TabIndex = 6;
            label4.Text = "Location";
            // 
            // locationBox
            // 
            locationBox.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            locationBox.FormattingEnabled = true;
            locationBox.Location = new Point(314, 228);
            locationBox.Name = "locationBox";
            locationBox.Size = new Size(204, 34);
            locationBox.TabIndex = 7;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.FromArgb(0, 173, 181);
            btnConnect.BackgroundColor = Color.FromArgb(0, 173, 181);
            btnConnect.BorderColor = Color.PaleVioletRed;
            btnConnect.BorderRadius = 20;
            btnConnect.BorderSize = 0;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(250, 385);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(150, 40);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "Connect";
            btnConnect.TextColor = Color.White;
            btnConnect.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(136, 292);
            label5.Name = "label5";
            label5.Size = new Size(137, 25);
            label5.TabIndex = 9;
            label5.Text = "Jenis Produk";
            // 
            // JPComboBox
            // 
            JPComboBox.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            JPComboBox.FormattingEnabled = true;
            JPComboBox.Location = new Point(314, 283);
            JPComboBox.Name = "JPComboBox";
            JPComboBox.Size = new Size(204, 34);
            JPComboBox.TabIndex = 10;
            // 
            // SettingView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 488);
            Controls.Add(JPComboBox);
            Controls.Add(label5);
            Controls.Add(btnConnect);
            Controls.Add(locationBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxIP);
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
    }
}