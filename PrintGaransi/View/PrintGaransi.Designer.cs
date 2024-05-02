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
            textBox3 = new TextBox();
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
            // textBoxModel
            // 
            textBoxModel.Location = new Point(43, 127);
            textBoxModel.Margin = new Padding(4, 5, 4, 5);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new Size(268, 31);
            textBoxModel.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(339, 57);
            textBox3.Margin = new Padding(4, 5, 4, 5);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(268, 31);
            textBox3.TabIndex = 1;
            // 
            // PrintGaransi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxModel);
            Controls.Add(textBox3);
            Controls.Add(textBoxSerial);
            Controls.Add(btnPrint);
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
        private TextBox textBox3;
    }
}
