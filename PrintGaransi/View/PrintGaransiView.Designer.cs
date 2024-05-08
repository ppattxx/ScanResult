namespace PrintGaransi
{
    partial class PrintGaransiView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPrint = new Button();
            textBoxSerial = new TextBox();
            textBoxCode = new TextBox();
            textBoxModelNumber = new TextBox();
            textBoxRegister = new TextBox();
            btnSetting = new Button();
            SuspendLayout();
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(235, 142);
            btnPrint.Margin = new Padding(2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(78, 20);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // textBoxSerial
            // 
            textBoxSerial.Location = new Point(28, 60);
            textBoxSerial.Name = "textBoxSerial";
            textBoxSerial.Size = new Size(189, 23);
            textBoxSerial.TabIndex = 1;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(28, 102);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(189, 23);
            textBoxCode.TabIndex = 2;
            textBoxCode.KeyDown += textBoxCode_KeyDown;
            // 
            // textBoxModelNumber
            // 
            textBoxModelNumber.Location = new Point(235, 60);
            textBoxModelNumber.Name = "textBoxModelNumber";
            textBoxModelNumber.Size = new Size(189, 23);
            textBoxModelNumber.TabIndex = 1;
            // 
            // textBoxRegister
            // 
            textBoxRegister.Location = new Point(235, 102);
            textBoxRegister.Name = "textBoxRegister";
            textBoxRegister.Size = new Size(189, 23);
            textBoxRegister.TabIndex = 2;
            // 
            // btnSetting
            // 
            btnSetting.Location = new Point(459, 23);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(75, 23);
            btnSetting.TabIndex = 3;
            btnSetting.Text = "Setting";
            btnSetting.UseVisualStyleBackColor = true;
            // 
            // PrintGaransiView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(btnSetting);
            Controls.Add(textBoxRegister);
            Controls.Add(textBoxCode);
            Controls.Add(textBoxModelNumber);
            Controls.Add(textBoxSerial);
            Controls.Add(btnPrint);
            Margin = new Padding(2);
            Name = "PrintGaransiView";
            Text = "Form1";
            Load += PrintGaransi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrint;
        private TextBox textBoxSerial;
        private TextBox textBoxCode;
        private TextBox textBoxModelNumber;
        private TextBox textBoxRegister;
        private Button btnSetting;
    }
}
