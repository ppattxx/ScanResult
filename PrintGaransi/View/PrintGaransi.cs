using PrintGaransi.Model;
using PrintGaransi.Presenter;
using PrintGaransi.View;
using System.Drawing.Printing;

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
        }

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
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke((MethodInvoker)(() => UpdateSerialBox(message)));
            }
            else
            {
                textBox1.Text = message;
            }

        }

        private void UpdateCodeBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (textBox2.InvokeRequired)
            {
                textBox2.Invoke((MethodInvoker)(() => UpdateCodeBox(message)));
            }
            else
            {
                textBox2.Text = message;
            }
        }

        private async void PrintGaransi_Load(object sender, EventArgs e)
        {
            connection = new TCPConnection(5000, UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await connection.StartServerAsync();
        }
    }
}
