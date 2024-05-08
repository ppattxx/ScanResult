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
            btnConnect = new Button();
            SuspendLayout();
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(234, 74);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(207, 23);
            textBoxIP.TabIndex = 0;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(234, 130);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(207, 23);
            textBoxPort.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 78);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 2;
            label1.Text = "IP Address";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 133);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(292, 190);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "connect";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // SettingView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxIP);
            Name = "SettingView";
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
        private Button btnConnect;
    }
}