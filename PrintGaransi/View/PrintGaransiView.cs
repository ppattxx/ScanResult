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
        public PrintGaransiView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            InitializeTabControl();
            btnHome.BackColor = Color.FromArgb(217, 215, 215);
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
                btnHome.BackColor = Color.FromArgb(217, 215, 215);
                btnRePrint.BackColor = SystemColors.Control;
                btnSetting.BackColor = SystemColors.Control;
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
                btnHome.BackColor = SystemColors.Control;
                btnSetting.BackColor = SystemColors.Control;
                btnRePrint.BackColor = Color.FromArgb(217, 215, 215);
            };

            btnLogOut.Click += delegate
            {
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
                //Application.Exit();
                this.Close();
            };

        }

        private void PrintGaransiView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /***
        public void ShowPrintPreviewDialog()
        {
            // Membuat PrintDocument baru
            PrintDocument pd = new PrintDocument();

            // Menambahkan event handler untuk PrintPage
            pd.PrintPage += (s, e) => _presenter.PrintGaransiLayout(e);

            // Membuat PrintPreviewDialog dan menetapkan PrintDocument-nya
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pd;

            // Menampilkan dialog preview cetak
            printPreviewDialog.ShowDialog();
        }
        ***/
    }
}
