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
            SuspendLayout();
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(339, 193);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(111, 33);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // textBoxSerial
            // 
            textBoxSerial.Location = new Point(43, 57);
            textBoxSerial.Margin = new Padding(4, 5, 4, 5);
            textBoxSerial.Name = "textBoxSerial";
            textBoxSerial.Size = new Size(268, 31);
            textBoxSerial.TabIndex = 1;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(43, 127);
            textBoxCode.Margin = new Padding(4, 5, 4, 5);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(268, 31);
            textBoxCode.TabIndex = 2;
            // 
            // textBoxModelNumber
            // 
            textBoxModelNumber.Location = new Point(339, 57);
            textBoxModelNumber.Margin = new Padding(4, 5, 4, 5);
            textBoxModelNumber.Name = "textBoxModelNumber";
            textBoxModelNumber.Size = new Size(268, 31);
            textBoxModelNumber.TabIndex = 1;
            // 
            // textBoxRegister
            // 
            textBoxRegister.Location = new Point(339, 127);
            textBoxRegister.Margin = new Padding(4, 5, 4, 5);
            textBoxRegister.Name = "textBoxRegister";
            textBoxRegister.Size = new Size(268, 31);
            textBoxRegister.TabIndex = 2;
            // 
            // PrintGaransiView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxRegister);
            Controls.Add(textBoxCode);
            Controls.Add(textBoxModelNumber);
            Controls.Add(textBoxSerial);
            Controls.Add(btnPrint);
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
    }
}
