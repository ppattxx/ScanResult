namespace PrintGaransi.View
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            button3 = new Button();
            button2 = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            textBoxPassword = new TextBox();
            textBoxNik = new TextBox();
            label3 = new Label();
            roundedCornerPanel1 = new Resource.RoundedCornerPanel();
            btnConnect = new Resource.RJButton();
            btnExit = new Resource.RJButton();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedCornerPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(3, 3);
            button3.Name = "button3";
            button3.Size = new Size(194, 94);
            button3.TabIndex = 4;
            button3.Text = "Log Out";
            button3.TextImageRelation = TextImageRelation.ImageAboveText;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(194, 40);
            button2.TabIndex = 3;
            button2.Text = "Re-Print";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.TextImageRelation = TextImageRelation.ImageAboveText;
            button2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(button3, 0, 4);
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 5;
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(68, 128);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(68, 206);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 37);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(114, 164);
            panel1.Name = "panel1";
            panel1.Size = new Size(347, 3);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Location = new Point(114, 240);
            panel2.Name = "panel2";
            panel2.Size = new Size(347, 3);
            panel2.TabIndex = 7;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.None;
            textBoxPassword.BackColor = SystemColors.Control;
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPassword.Location = new Point(114, 208);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Password";
            textBoxPassword.Size = new Size(347, 26);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.KeyDown += textBoxPassword_KeyDown;
            // 
            // textBoxNik
            // 
            textBoxNik.Anchor = AnchorStyles.None;
            textBoxNik.BackColor = SystemColors.Control;
            textBoxNik.BorderStyle = BorderStyle.None;
            textBoxNik.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxNik.Location = new Point(114, 132);
            textBoxNik.Name = "textBoxNik";
            textBoxNik.PlaceholderText = "NIK";
            textBoxNik.Size = new Size(347, 26);
            textBoxNik.TabIndex = 1;
            textBoxNik.KeyDown += textBoxNik_KeyDown;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(235, 53);
            label3.Name = "label3";
            label3.Size = new Size(111, 33);
            label3.TabIndex = 8;
            label3.Text = "LOGIN";
            // 
            // roundedCornerPanel1
            // 
            roundedCornerPanel1.Anchor = AnchorStyles.None;
            roundedCornerPanel1.BackColor = SystemColors.Control;
            roundedCornerPanel1.BorderColor = Color.Black;
            roundedCornerPanel1.BorderSize = 1;
            roundedCornerPanel1.Controls.Add(btnExit);
            roundedCornerPanel1.Controls.Add(btnConnect);
            roundedCornerPanel1.Controls.Add(textBoxNik);
            roundedCornerPanel1.Controls.Add(label3);
            roundedCornerPanel1.Controls.Add(panel2);
            roundedCornerPanel1.Controls.Add(panel1);
            roundedCornerPanel1.Controls.Add(pictureBox1);
            roundedCornerPanel1.Controls.Add(textBoxPassword);
            roundedCornerPanel1.Controls.Add(pictureBox2);
            roundedCornerPanel1.CornerRadius = 15;
            roundedCornerPanel1.Location = new Point(129, 56);
            roundedCornerPanel1.Name = "roundedCornerPanel1";
            roundedCornerPanel1.Size = new Size(563, 363);
            roundedCornerPanel1.TabIndex = 9;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.None;
            btnConnect.BackColor = SystemColors.ControlDark;
            btnConnect.BackgroundColor = SystemColors.ControlDark;
            btnConnect.BorderColor = Color.PaleVioletRed;
            btnConnect.BorderRadius = 8;
            btnConnect.BorderSize = 0;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("MS Reference Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(147, 279);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(113, 40);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Login";
            btnConnect.TextColor = Color.White;
            btnConnect.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.BackColor = SystemColors.ControlDark;
            btnExit.BackgroundColor = SystemColors.ControlDark;
            btnExit.BorderColor = Color.PaleVioletRed;
            btnExit.BorderRadius = 8;
            btnExit.BorderSize = 0;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("MS Reference Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(309, 279);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(113, 40);
            btnExit.TabIndex = 10;
            btnExit.Text = "Exit";
            btnExit.TextColor = Color.White;
            btnExit.UseVisualStyleBackColor = false;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(800, 459);
            Controls.Add(roundedCornerPanel1);
            Name = "LoginView";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += LoginView_Load;
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            roundedCornerPanel1.ResumeLayout(false);
            roundedCornerPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button3;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBoxPassword;
        private TextBox textBoxNik;
        private Label label3;
        private Resource.RoundedCornerPanel roundedCornerPanel1;
        private Resource.RJButton btnConnect;
        private Resource.RJButton btnExit;
    }
}