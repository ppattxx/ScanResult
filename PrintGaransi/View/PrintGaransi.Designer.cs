namespace PrintGaransi
{
    partial class PrintGaransi
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
            textBoxModel = new TextBox();
            textBoxCode = new TextBox();
            SuspendLayout();
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(237, 116);
            btnPrint.Margin = new Padding(2, 2, 2, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(78, 20);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // textBoxSerial
            // 
            textBoxSerial.Location = new Point(30, 34);
            textBoxSerial.Name = "textBoxSerial";
            textBoxSerial.Size = new Size(189, 23);
            textBoxSerial.TabIndex = 1;
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new Point(30, 76);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new Size(189, 23);
            textBoxModel.TabIndex = 2;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(237, 34);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(189, 23);
            textBoxCode.TabIndex = 1;
            // 
            // PrintGaransi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(textBoxModel);
            Controls.Add(textBoxCode);
            Controls.Add(textBoxSerial);
            Controls.Add(btnPrint);
            Margin = new Padding(2, 2, 2, 2);
            Name = "PrintGaransi";
            Text = "Form1";
            Load += PrintGaransi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrint;
        private TextBox textBoxSerial;
        private TextBox textBoxModel;
        private TextBox textBoxCode;
    }
}
