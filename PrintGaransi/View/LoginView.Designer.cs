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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            textBoxPassword = new TextBox();
            textBoxNik = new TextBox();
            label3 = new Label();
            roundedCornerPanel1 = new Resource.RDPanel();
            btnExit = new Resource.RDButton();
            btnConnect = new Resource.RDButton();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedCornerPanel1.SuspendLayout();
            panel3.SuspendLayout();
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
            textBoxPassword.BackColor = Color.White;
            textBoxPassword.BorderStyle = BorderStyle.None;
            textBoxPassword.Font = new Font("Arial", 15.75F);
            textBoxPassword.Location = new Point(114, 208);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Password";
            textBoxPassword.Size = new Size(347, 25);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.KeyDown += textBoxPassword_KeyDown;
            // 
            // textBoxNik
            // 
            textBoxNik.Anchor = AnchorStyles.None;
            textBoxNik.BackColor = Color.White;
            textBoxNik.BorderStyle = BorderStyle.None;
            textBoxNik.Font = new Font("Arial", 15.75F);
            textBoxNik.Location = new Point(114, 132);
            textBoxNik.Name = "textBoxNik";
            textBoxNik.PlaceholderText = "NIK";
            textBoxNik.Size = new Size(347, 25);
            textBoxNik.TabIndex = 1;
            textBoxNik.KeyDown += textBoxNik_KeyDown;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(235, 53);
            label3.Name = "label3";
            label3.Size = new Size(110, 33);
            label3.TabIndex = 8;
            label3.Text = "LOGIN";
            // 
            // roundedCornerPanel1
            // 
            roundedCornerPanel1.Anchor = AnchorStyles.None;
            roundedCornerPanel1.BackColor = Color.White;
            roundedCornerPanel1.BorderColor = Color.Silver;
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
            roundedCornerPanel1.Font = new Font("Arial", 15.75F);
            roundedCornerPanel1.Location = new Point(331, 151);
            roundedCornerPanel1.Name = "roundedCornerPanel1";
            roundedCornerPanel1.Size = new Size(563, 363);
            roundedCornerPanel1.TabIndex = 9;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.BackColor = Color.Red;
            btnExit.BackgroundColor = Color.Red;
            btnExit.BorderColor = Color.PaleVioletRed;
            btnExit.BorderRadius = 8;
            btnExit.BorderSize = 0;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial Rounded MT Bold", 14.25F);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(330, 274);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(113, 40);
            btnExit.TabIndex = 10;
            btnExit.Text = "Exit";
            btnExit.TextColor = Color.White;
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnConnect
            // 
            btnConnect.Anchor = AnchorStyles.None;
            btnConnect.BackColor = Color.FromArgb(27, 60, 115);
            btnConnect.BackgroundColor = Color.FromArgb(27, 60, 115);
            btnConnect.BorderColor = Color.PaleVioletRed;
            btnConnect.BorderRadius = 8;
            btnConnect.BorderSize = 0;
            btnConnect.FlatAppearance.BorderSize = 0;
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Arial Rounded MT Bold", 14.25F);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(135, 274);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(113, 40);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Login";
            btnConnect.TextColor = Color.White;
            btnConnect.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(46, 119, 174);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1229, 89);
            panel3.TabIndex = 10;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(666, 26);
            label2.Name = "label2";
            label2.Size = new Size(551, 40);
            label2.TabIndex = 1;
            label2.Text = "Laundry Systems Business Unit";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 14);
            label1.Name = "label1";
            label1.Size = new Size(619, 55);
            label1.TabIndex = 0;
            label1.Text = "PRINT WARRANTY CARD";
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 235, 245);
            ClientSize = new Size(1229, 632);
            Controls.Add(panel3);
            Controls.Add(roundedCornerPanel1);
            Name = "LoginView";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += LoginView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            roundedCornerPanel1.ResumeLayout(false);
            roundedCornerPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button3;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBoxPassword;
        private TextBox textBoxNik;
        private Label label3;
        private Resource.RDPanel roundedCornerPanel1;
        private Resource.RDButton btnConnect;
        private Resource.RDButton btnExit;
        private Panel panel3;
        private Label label2;
        private Label label1;
    }
}