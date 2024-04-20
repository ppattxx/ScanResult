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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(237, 116);
            btnPrint.Margin = new Padding(2);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(78, 20);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(30, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(189, 23);
            textBox2.TabIndex = 2;
            // 
            // PrintGaransi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnPrint);
            Margin = new Padding(2);
            Name = "PrintGaransi";
            Text = "Form1";
            Load += PrintGaransi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrint;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}
