using PrintGaransi.Model;
using PrintGaransi.Presenter;
using PrintGaransi.View;
using System.Drawing.Printing;

namespace PrintGaransi
{
    public partial class PrintGaransi : Form, IPrintGaransiView
    {
        private readonly PrintGaransiPresenter _presenter;
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
    }
}
