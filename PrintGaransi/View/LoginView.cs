using Microsoft.VisualBasic.Logging;
using PrintGaransi._Repositories;
using PrintGaransi.Model;
using PrintGaransi.Presenter;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace PrintGaransi.View
{
    public partial class LoginView : Form, ILoginView
    {
        public bool isClickedOnce = true;
        public LoginView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public string Nik
        {
            get { return textBoxNik.Text; }
            set { textBoxNik.Text = value; }
        }

        public string Password
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }

        public bool IsLoginSuccessful { get; private set; }

        public event EventHandler Login;

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void CloseView()
        {
            this.Hide();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnConnect.Click += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(Nik))
                {
                    Login?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
            };

            btnExit.Click += delegate
            {
                Application.Exit();
            };

            hiddenPass.Click += delegate
            {
                if (isClickedOnce)
                {
                    hiddenPass.Image = Properties.Resources.hide;
                    textBoxPassword.PasswordChar = '\0';
                    isClickedOnce = false;
                }
                else
                {
                    hiddenPass.Image = Properties.Resources.show;
                    textBoxPassword.PasswordChar = '*';
                    isClickedOnce = true;
                }
            };
        }

        private void textBoxNik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(Nik))
            {
                Login?.Invoke(this, EventArgs.Empty);
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(Nik))
            {
                Login?.Invoke(this, EventArgs.Empty);
            }
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            textBoxNik.Focus();
        }
    }
}
