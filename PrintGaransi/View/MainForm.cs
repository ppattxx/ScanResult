using PrintGaransi.Model;
using PrintGaransi.Presenter;
using PrintGaransi.View;
using System.Drawing.Printing;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static PrintGaransi.View.IMainFormView;
using PrintGaransi._Repositories;
using Microsoft.VisualBasic.ApplicationServices;

namespace PrintGaransi
{
    public partial class MainForm : Form, IMainFormView
    {
        private TabControlPresenter tabControlPresenter;
        private readonly GaransiModel _garansiModel;
        public LoginModel _user;
        private TabControlView tabControlView;
        private TCPConnection connection;

        public MainForm(LoginModel user)
        {
            InitializeComponent();
            _user = user;
            AssociateAndRaiseViewEvents();
            InitializeTabControl();
            btnHome.BackColor = Color.FromArgb(0, 133, 181);

            tabControlPresenter.LoadAllDataList();
        }

        public void InitializeTabControl()
        {

            if (tabControlPresenter != null)
            {
                tabControlPresenter.UnassociateViewEvents(); // Tambahkan ini untuk menghapus event handler yang ada
            }

            tabControlView = new TabControlView(); // Create the user control instance
            TabControlDataPresenter presenterData = new TabControlDataPresenter(tabControlView, new GaransiRepository(), _user); // Inisialisasi variabel instance
            tabControlPresenter = new TabControlPresenter(presenterData);
            splitContainer1.Panel2.Controls.Add(tabControlView);
            tabControlView.Dock = DockStyle.Fill;
            connection = new TCPConnection(tabControlView.UpdateCodeBox, tabControlView.UpdateSerialBox);
        }


        //event
        private void AssociateAndRaiseViewEvents()
        {
            btnHome.Click += delegate
            {
                int selectedTabPageIndex = 0;
                tabControlPresenter.ChangeTabPage(selectedTabPageIndex);
                btnHome.BackColor = Color.FromArgb(0, 133, 181);
                btnRePrint.BackColor = Color.FromArgb(0, 35, 105);
            };

            btnSetting.Click += delegate
            {

                ISettingView settingView = SettingView.GetInstance();
                SettingPresenter settingPresenter = new SettingPresenter(settingView, new SettingModel());
                (settingView as Form)?.Show();
            };

            btnRePrint.Click += delegate
            {
                int selectedTabPageIndex = 1;
                tabControlPresenter.ChangeTabPage(selectedTabPageIndex);
                btnHome.BackColor = Color.FromArgb(0, 35, 105);
                btnRePrint.BackColor = Color.FromArgb(0, 133, 181);
            };

            btnLogOut.Click += delegate
            {
                connection.CloseConnection();

                tabControlPresenter.UnassociateViewEvents();
                ResetBinding();
                
                this.Close();

                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
            };
        }

        private void ResetBinding()
        {
            tabControlPresenter.ResetDataBinding();
            //tabControlPresenter.LoadAllDataList();
        }

        private void PrintGaransiView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        //Singeleton pattern (open a single  from instance)
        private static MainForm instance;
        public static MainForm GetInstance(LoginModel loginModel)
        {
            if (instance == null || instance.IsDisposed)
                instance = new MainForm(loginModel);
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
                instance._user = loginModel; // Set new user
                instance.InitializeTabControl();
            }
            return instance;
        }
    }
}
