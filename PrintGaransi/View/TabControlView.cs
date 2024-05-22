using PrintGaransi._Repositories;
using PrintGaransi.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PrintGaransi.View.IPrintGaransiView;
using PrintGaransi.Presenter;

namespace PrintGaransi.View
{
    public partial class TabControlView : UserControl, ITabControlView
    {
        private PrintGaransiLayout _printLayout;
        private TCPConnection connection;
        public TabControlView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            _printLayout = new PrintGaransiLayout();
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
        }

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

        public string JenisProduk
        {
            get { return textBoxJP.Text; }
            set { textBoxJP.Text = value; }
        }

        public string Search
        {
            get { return textBoxSearch.Text; }
            set { textBoxSearch.Text = value; }
        }

        //event
        public event EventHandler<ModelEventArgs> SearchModelNumber;
        public event EventHandler SearchFilter;
        public event EventHandler CheckProperties;
        public event EventHandler CellClicked;

        private async void TabControlView_Load(object sender, EventArgs e)
        {
            textBoxJP.Focus();
            connection = new TCPConnection(UpdateCodeBox, UpdateSerialBox); // Passing both update methods
            await connection.ConnectToServerAsync();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnPrint.Click += delegate
            {
                CheckProperties?.Invoke(this, EventArgs.Empty);
            };

            btnSearch.Click += delegate
            {
                SearchFilter?.Invoke(this, EventArgs.Empty);
            };

            dataGridView2.CellContentClick += (sender, e) =>
            {
                DataGridViewRow selectedRow = dataGridView2.Rows[e.RowIndex];
                var selectedCell = selectedRow.DataBoundItem as GaransiModel;
                CellClicked?.Invoke(this, EventArgs.Empty);
                //CheckProperties?.Invoke(this, EventArgs.Empty);
            };
        }

        public void ShowFilter(BindingSource model)
        {
            dataGridView2.DataSource = model;
        }

        public void ShowPrintPreviewDialog(GaransiModel model)
        {
            // Membuat PrintDocument baru
            PrintDocument pd = new PrintDocument();

            // Menambahkan event handler untuk PrintPage
            pd.PrintPage += (s, e) => _printLayout.Print(e, model);

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

        public void SelectTabPageByIndex(int data)
        {
            if (data >= 0 && data < tabControl1.TabPages.Count)
            {
                tabControl1.SelectedIndex = data;
            }
        }

        public void SetDefectListBindingSource(BindingSource model)
        {
            dataGridView1.DataSource = model;
            dataGridView2.DataSource = model;
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchFilter?.Invoke(this, EventArgs.Empty);
            }
        }

        private void textBoxSerial_TextChanged(object sender, EventArgs e)
        {
            CheckProperties?.Invoke(this, EventArgs.Empty);
        }
    }
}
