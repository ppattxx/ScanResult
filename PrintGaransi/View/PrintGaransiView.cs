using PrintGaransi.Model;
using PrintGaransi.Presenter;
using PrintGaransi.View;
using System.Drawing.Printing;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static PrintGaransi.View.IPrintGaransiView;
using PrintGaransi._Repositories;

namespace PrintGaransi
{
    public partial class PrintGaransiView : Form, IPrintGaransiView
    {
        private TabControlPresenter tabControlPresenter;
        private readonly GaransiModel _garansiModel;
        public PrintGaransiView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            InitializeTabControl();
            btnHome.BackColor = Color.FromArgb(0, 133, 181);
        }

        public void InitializeTabControl()
        {
            TabControlView tabControlView = new TabControlView(); // Create the user control instance
            tabControlPresenter = new TabControlPresenter(tabControlView, new GaransiRepository()); // Inisialisasi variabel instance
            splitContainer1.Panel2.Controls.Add(tabControlView);
            tabControlView.Dock = DockStyle.Fill;
        }


        //event

        private void PrintGaransi_Load(object sender, EventArgs e)
        {
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnHome.Click += delegate
            {
                int selectedTabPageIndex = 0;
                tabControlPresenter.ChangeTabPage(selectedTabPageIndex);
                btnHome.BackColor = Color.FromArgb(0, 133, 181);
                btnRePrint.BackColor = Color.FromArgb(0, 173, 181);
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
                btnHome.BackColor = Color.FromArgb(0, 173, 181);
                btnRePrint.BackColor = Color.FromArgb(0, 133, 181);
            };

            btnLogOut.Click += delegate
            {
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
                //Application.Exit();
                this.Hide();
            };

        }

        private void PrintGaransiView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }
    }
}
