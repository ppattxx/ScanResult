using PrintGaransi.Model;
using PrintGaransi.Presenter;
using PrintGaransi.View;
using System.Drawing.Printing;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using static PrintGaransi.View.IPrintGaransiView;

namespace PrintGaransi
{
    public partial class PrintGaransi : Form, IPrintGaransiView
    {
        private readonly PrintGaransiPresenter _presenter;
        private TCPConnection connection;
        public PrintGaransi()
        {
            InitializeComponent();
            _presenter = new PrintGaransiPresenter(this);
            AssociateAndRaiseViewEvents();
            Console.WriteLine("View");
        }

        //properties
        public string SerialNumber
        {
            get { return textBoxSerial.Text; }
            set { textBoxSerial.Text = value; }
        }
        public string ModelNumber
        {
            get { return textBoxModel.Text; }
            set { textBoxModel.Text = value; }
        }
        public string ModelCode
        {
            get { return textBoxCode.Text; }
            set { textBoxCode.Text = value; }
        }

        //event
        public event EventHandler<ModelEventArgs> SearchModelNumber;


        private void AssociateAndRaiseViewEvents()
        {
            btnPrint.Click += delegate
            {
                _presenter.PrintGaransi();
            };
        }

        public void DisplayGaransi(GaransiModel garansi)
        {
            //untuk ditampilkan ke textbox
            throw new NotImplementedException();
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
            }

        }

        private void UpdateCodeBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBoxModel.InvokeRequired)
            {
                textBoxModel.Invoke((MethodInvoker)(() => UpdateCodeBox(message)));
            }
            else
            {
                textBoxModel.Text = message;
                Console.WriteLine(ModelCode);
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
            connection = new TCPConnection(5000, UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await connection.StartServerAsync();
        }
    }
}
