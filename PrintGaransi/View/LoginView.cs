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

        public void HideView()
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
                }
            };

            btnExit.Click += delegate
            {
                Application.Exit();
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
