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
            roundedCornerPanel1 = new Resource.RDPanel();
            label2 = new Label();
            label1 = new Label();
            hiddenPass = new PictureBox();
            btnExit = new Resource.RDButton();
            btnConnect = new Resource.RDButton();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            roundedCornerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hiddenPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
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
            pictureBox1.Location = new Point(190, 190);
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
            pictureBox2.Location = new Point(190, 268);
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
            panel1.Location = new Point(236, 226);
            panel1.Name = "panel1";
            panel1.Size = new Size(347, 3);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Location = new Point(236, 302);
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
            textBoxPassword.Location = new Point(236, 270);
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
            textBoxNik.Location = new Point(236, 194);
            textBoxNik.Name = "textBoxNik";
            textBoxNik.PlaceholderText = "NIK";
            textBoxNik.Size = new Size(347, 25);
            textBoxNik.TabIndex = 1;
            textBoxNik.KeyDown += textBoxNik_KeyDown;
            // 
            // roundedCornerPanel1
            // 
            roundedCornerPanel1.Anchor = AnchorStyles.None;
            roundedCornerPanel1.BackColor = Color.White;
            roundedCornerPanel1.BorderColor = Color.Silver;
            roundedCornerPanel1.BorderSize = 1;
            roundedCornerPanel1.Controls.Add(label2);
            roundedCornerPanel1.Controls.Add(label1);
            roundedCornerPanel1.Controls.Add(hiddenPass);
            roundedCornerPanel1.Controls.Add(btnExit);
            roundedCornerPanel1.Controls.Add(btnConnect);
            roundedCornerPanel1.Controls.Add(textBoxNik);
            roundedCornerPanel1.Controls.Add(panel2);
            roundedCornerPanel1.Controls.Add(panel1);
            roundedCornerPanel1.Controls.Add(pictureBox1);
            roundedCornerPanel1.Controls.Add(textBoxPassword);
            roundedCornerPanel1.Controls.Add(pictureBox2);
            roundedCornerPanel1.CornerRadius = 15;
            roundedCornerPanel1.Font = new Font("Arial", 15.75F);
            roundedCornerPanel1.Location = new Point(221, 88);
            roundedCornerPanel1.Name = "roundedCornerPanel1";
            roundedCornerPanel1.Size = new Size(789, 446);
            roundedCornerPanel1.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Helvetica", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(46, 119, 174);
            label2.Location = new Point(130, 87);
            label2.Name = "label2";
            label2.Size = new Size(529, 43);
            label2.TabIndex = 1;
            label2.Text = "Laundry System Business Unit";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Helvetica", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(46, 119, 174);
            label1.Location = new Point(59, 30);
            label1.Name = "label1";
            label1.Size = new Size(679, 57);
            label1.TabIndex = 0;
            label1.Text = "WARRANTY CARD PRINTING";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hiddenPass
            // 
            hiddenPass.Image = Properties.Resources.hide;
            hiddenPass.Location = new Point(548, 264);
            hiddenPass.Name = "hiddenPass";
            hiddenPass.Size = new Size(35, 31);
            hiddenPass.TabIndex = 11;
            hiddenPass.TabStop = false;
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
            btnExit.Font = new Font("Helvetica", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(442, 374);
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
            btnConnect.Font = new Font("Helvetica", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(247, 374);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(113, 40);
            btnConnect.TabIndex = 9;
            btnConnect.Text = "Login";
            btnConnect.TextColor = Color.White;
            btnConnect.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(1229, 632);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 235, 245);
            ClientSize = new Size(1229, 632);
            Controls.Add(roundedCornerPanel1);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginView";
            Text = "WARRANTY CARD PRINTING";
            WindowState = FormWindowState.Maximized;
            Load += LoginView_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            roundedCornerPanel1.ResumeLayout(false);
            roundedCornerPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hiddenPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Resource.RDPanel roundedCornerPanel1;
        private Resource.RDButton btnConnect;
        private Resource.RDButton btnExit;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox3;
        private PictureBox hiddenPass;
    }
}