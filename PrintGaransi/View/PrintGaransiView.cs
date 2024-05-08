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
        private readonly PrintGaransiPresenter _presenter;
        private TCPConnection connection;
        public PrintGaransiView()
        {
            InitializeComponent();
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["LSBUDBPRODUCTION"].ConnectionString;
            IGaransiRepository garansiRepository = new GaransiRepository(sqlConnectionString);
            _presenter = new PrintGaransiPresenter(this, garansiRepository);
            AssociateAndRaiseViewEvents();
        }

        //properties
        public string SerialNumber
        {
            get { return textBoxSerial.Text; }
            set { textBoxSerial.Text = value; }
        }
        public string ModelNumber
        {
            get { return textBoxModelNumber.Text; }
            set { textBoxModelNumber.Text = value; }
        }
        public string ModelCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        public string Register
        {
            get { return textBoxRegister.Text; }
            set { textBoxRegister.Text = value; }
        }

        //event
        public event EventHandler<ModelEventArgs> SearchModelNumber;
        public event KeyEventHandler KeyDownEvent;


        private void AssociateAndRaiseViewEvents()
        {
            btnPrint.Click += delegate
            {
                _presenter.PrintGaransi();
            };

            btnSetting.Click += delegate
            {
                ISettingView settingView = SettingView.GetInstance();
                SettingPresenter settingPresenter = new SettingPresenter(settingView, new SettingModel());
                (settingView as Form)?.Show();
            };
        }


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

        private void UpdateSerialBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxSerial.InvokeRequired)
            {
                textBoxSerial.Invoke((MethodInvoker)(() => UpdateSerialBox(message)));
            }
            else
            {
                textBoxSerial.Text = message;
            MessageBox.Show(message);
            }
        }

        private void UpdateCodeBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxCode.InvokeRequired)
            {
                textBoxCode.Invoke((MethodInvoker)(() => UpdateCodeBox(message)));
            }
            else
            {
                textBoxCode.Text = message;
            }
            PerformModelSearch();
        }

        private void PerformModelSearch()
        {
            // Raise the event with the data from the view
            SearchModelNumber?.Invoke(this, new ModelEventArgs(SerialNumber));
        }

        private async void PrintGaransi_Load(object sender, EventArgs e)
        {
            connection = new TCPConnection(UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await connection.ConnectToServerAsync();
        }

        private void textBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            // Jika tombol "Enter" ditekan
            if (e.KeyCode == Keys.Enter)
            {
                // Jika enter ditekan, kirim Keys.Enter
                KeyDownEvent?.Invoke(this, new KeyEventArgs(Keys.Enter));
                PerformModelSearch();
            }
            else
            {
                // Jika bukan tombol "Enter", maka pasti karakter yang dimasukkan
                // Jika yang dimasukkan adalah angka, kirim Keys.None
                if (int.TryParse(textBoxSerial.Text, out int _))
                {
                    KeyDownEvent?.Invoke(this, new KeyEventArgs(Keys.None));
                }
            }
        }
    }
}
