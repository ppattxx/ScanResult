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
using static PrintGaransi.View.IMainFormView;
using PrintGaransi.Presenter;
using System.Runtime.CompilerServices;
using System.CodeDom;
using System.Data.SqlClient;

namespace PrintGaransi.View
{
    public partial class TabControlView : UserControl, ITabControlView
    {
        private PrintGaransiLayout _printLayout;
        private TCPConnection connection;
        private bool disableEvent = false;
        private bool buttonClickedOnce = false;
        private string inspectorId;
        private PrintModeModel _printMode;
        private ModelNumberRepository _numberRepo = new ModelNumberRepository();
        private ResultRepository _resultRepo = new ResultRepository();
        private PartModelRepository _partRepo = new PartModelRepository();
        private NumberModelRepository _partNumberRepo = new NumberModelRepository();
        private bool _btnOkEnabled;
        private bool _btnCancelEnabled;
        public TabControlView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            _printLayout = new PrintGaransiLayout();
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            InitializeDateTimePicker();
            _printMode = new PrintModeModel();
            LoadComboBox();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 12); // Ganti "Arial" dengan font yang diinginkan
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadData();
        }

        private void LoadComboBox()
        {
            // Ambil data dari repository
            List<GaransiModel> modelList = _numberRepo.GetAllModelCodes();

            // Tambahkan opsi "Pilih Model" sebagai item pertama
            if (modelList == null) modelList = new List<GaransiModel>();
            modelList.Insert(0, new GaransiModel { ModelNumber = "Pilih Model", ModelCode = "" });

            // Set ComboBox DataSource
            comboBox1.DataSource = modelList;
            comboBox1.DisplayMember = "ModelNumber";
            comboBox1.ValueMember = "ModelCode";

            // Pilih item pertama ("Pilih Model") sebagai default
            comboBox1.SelectedIndex = 0;
        }

        private void InitializeDateTimePicker()
        {
            dtFromDate.CustomFormat = "dd MMMM yyyy";
        }

        public string SerialNumber
        {
            get { return textBoxSerial.Text; }
            set { textBoxSerial.Text = value; }
        }
        public string ModelNumber
        {
            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }
        public string PartCode
        {
            get { return textBoxModelNumber.Text; }
            set { textBoxModelNumber.Text = value; }
        }

        public string LastInput
        {
            get { return textBox6.Text; }
            set { textBox6.Text = value; }
        }

        private string _modelCode;
        private object bindingSource;
        private string connectionString;
        private TabControlPresenter _presenter;

        public string GetModelCode()
        { return _modelCode; }
        public void SetModelCode(string value)
        { _modelCode = value; }

        public string Register
        {
            get { return textBoxRegister.Text; }
            set { textBoxRegister.Text = value; }
        }

        public string GetStatus()
        { return textBoxStatus.Text; }

        public void SetStatus(string value)
        { textBoxStatus.Text = value; }
        public Color StatusBackColor
        {
            get { return textBoxStatus.BackColor; }
            set { textBoxStatus.BackColor = value; }
        }
        public Color StatusForeColor
        {
            get { return textBoxStatus.ForeColor; }
            set { textBoxStatus.ForeColor = value; }
        }

        public DateTime SelectedDate => dtFromDate.Value;

        public string InspectorId
        {
            get { return inspectorId; }
            set { inspectorId = value; }
        }
        public string Inspector
        {
            get { return textBoxInspector.Text; }
            set { textBoxInspector.Text = value; }
        }

        public string ModelCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Color btnOk
        {
            get { return btnPrint.BackColor; }
            set { btnPrint.BackColor = value; }
        }
        public Color btnCancel
        {
            get { return btnNg.BackColor; }
            set { btnNg.BackColor = value; }
        }

        public bool SubmitButtonEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SubmitButtonClicked { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool BtnOkEnabled
        {
            get { return _btnOkEnabled; }
            set
            {
                _btnOkEnabled = value;
                btnPrint.Enabled = value; // Mengatur status tombol "OK" (btnPrint)
            }
        }

        public bool BtnCancelEnabled
        {
            get { return _btnCancelEnabled; }
            set
            {
                _btnCancelEnabled = value;
                btnNg.Enabled = value; // Mengatur status tombol "Cancel" (btnNg)
            }
        }

        public string Search { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //event
        public event EventHandler<ModelEventArgs> SearchModelNumber;
        public event EventHandler SearchFilter;
        public event EventHandler CheckProperties;
        public event EventHandler<DataGridViewCellEventArgs> CellClicked;

        private async void TabControlView_Load(object sender, EventArgs e)
        {
            timer1.Start();
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

            //dataGridView2.CellContentClick += (sender, e) =>
            //{
            //    CellClicked?.Invoke(sender, e);
            //};

            btnManual.Click += delegate
            {
                if (!buttonClickedOnce)
                {
                    btnManual.BackColor = Color.Teal;
                    // Logic to execute when button is clicked for the first time
                    btnClear.Visible = true;
                    disableEvent = false;
                    btnManual.Text = "Auto Print";

                    textBoxSerial.ReadOnly = false;
                    textBoxSerial.Focus();

                    textBoxStatus.BackColor = SystemColors.Control;

                    SerialNumber = "";
                    SetStatus("");

                    buttonClickedOnce = true; // Update button state
                }
                else
                {
                    btnManual.BackColor = Color.Teal;
                    btnClear.Visible = false;
                    textBoxSerial.ReadOnly = true;
                    //textBoxCode.ReadOnly = true;
                    textBoxModelNumber.ReadOnly = true;
                    textBoxRegister.ReadOnly = true;
                    btnManual.Text = "Input Manual";
                    textBoxStatus.BackColor = SystemColors.Control;


                    SerialNumber = "";
                    SetStatus("");

                    disableEvent = false;
                    buttonClickedOnce = false;
                }
            };

            btnClear.Click += delegate
            {
                SerialNumber = "";
                textBoxStatus.BackColor = SystemColors.Control;
                textBoxSerial.Focus();
            };

            timer1.Tick += delegate
            {
                timeHeader.Text = DateTime.Now.ToLongTimeString();
                DateHeader.Text = DateTime.Now.ToLongDateString();
            };

            btnClear2.Click += delegate
            {
                dtFromDate.Text = DateTime.Now.ToString();
                SelectedStatus = "ALL";
                SrchPartCode.Text = "";
                SearchFilter?.Invoke(this, EventArgs.Empty);
            };

        }

        public void ShowFilter(BindingSource model)
        {

        }

        public void ShowPrintPreviewDialog(GaransiModel model, string printerName)
        {
            string mode = _printMode.GetMode();

            // Membuat PrintDocument baru
            PrintDocument pd = new PrintDocument();

            // Menetapkan printer yang akan digunakan
            if (!string.IsNullOrEmpty(printerName))
            {
                pd.PrinterSettings.PrinterName = printerName;
            }

            // Menambahkan event handler untuk PrintPage
            pd.PrintPage += (s, e) => _printLayout.Print(e, model);

            if (mode == "preview")
            {
                // Membuat PrintPreviewDialog dan menetapkan PrintDocument-nya
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = pd;

                printPreviewDialog.Load += (s, e) =>
                {
                    // Mengakses PrintPreviewControl menggunakan refleksi
                    PrintPreviewControl printPreviewControl = FindPrintPreviewControl(printPreviewDialog);

                    if (printPreviewControl != null)
                    {
                        printPreviewControl.Zoom = 1.0; // Mengatur zoom 100%
                    }

                    // Mengatur posisi jendela ke tengah layar
                    printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
                    printPreviewDialog.WindowState = FormWindowState.Maximized;
                };

                // Menampilkan dialog preview cetak
                printPreviewDialog.ShowDialog();
            }
            else
            {
                pd.Print();
            }
        }

        private PrintPreviewControl FindPrintPreviewControl(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is PrintPreviewControl previewControl)
                {
                    return previewControl;
                }
                else
                {
                    PrintPreviewControl foundControl = FindPrintPreviewControl(control);
                    if (foundControl != null)
                    {
                        return foundControl;
                    }
                }
            }
            return null;
        }

        public void UpdateSerialBox(string message)
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
            PerformModelSearch();
        }

        public void UpdateCodeBox(string message)
        {
            // Invoke UI updates on the UI thread
            if (comboBox1.InvokeRequired)
            {
                comboBox1.Invoke((MethodInvoker)(() => UpdateCodeBox(message)));
            }
            else
            {
                comboBox1.Text = message;
            }
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
            if (model != null)
            {
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null; // Pastikan data lama dihapus
                dataGridView1.DataSource = model;
                dataGridView1.Refresh();
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)   
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchFilter?.Invoke(this, EventArgs.Empty);
            }
        }

        private void textBoxRegister_TextChanged(object sender, EventArgs e)
        {
            if (!disableEvent)
            {
                if (comboBox1.Text == null)
                {
                    MessageBox.Show("Data Product tidak ditemukan", "Pemberitahuan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else
                {

                    CheckProperties?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private void textBoxSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxSerial.Text.Length >= 2)
                {
                    string code = textBoxSerial.Text.Trim();
                    comboBox1.Text = textBoxSerial.Text.Substring(0, 2);

                    // Pindahkan CheckProperties setelah semua data siap
                    textBox6.Text = textBoxSerial.Text;

                    // Fokus dulu ke TextBox sebelum validasi
                    textBoxSerial.Focus();

                    // **Panggil CheckProperties setelah data tersimpan**
                    CheckProperties?.Invoke(this, EventArgs.Empty);

                    // **Reset Tombol ke Abu-Abu Setelah Validasi**
                    btnOk = Color.Gray;
                    BtnOkEnabled = false;
                    btnCancel = Color.Gray;
                    BtnCancelEnabled = false;

                    textBoxSerial.Clear();
                }
            }
        }


        //private void ResetFields()
        //{
        //    textBoxSerial.Clear();
        //    textBoxStatus.Clear();
        //    textBoxStatus.BackColor = SystemColors.Control;
        //    textBoxSerial.Focus(); // Kembalikan fokus ke input serial number
        //}


        private void dtFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchFilter?.Invoke(this, EventArgs.Empty);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0) // Hindari saat "Pilih Model" dipilih
            {
                if (comboBox1.SelectedItem is GaransiModel selectedModel)
                {
                    string selectedModelNumber = selectedModel.ModelCode;
                    PartModel partModel = _partRepo.GetPartNumbersByModelCodeId(selectedModelNumber);
                    NumberModel numberModel = _partNumberRepo.GetNumber(partModel.partNumberId);

                    if (partModel != null)
                    {
                        textBoxModelNumber.Text = partModel.partNumberId;
                        textBoxRegister.Text = numberModel.partNumber;
                    }
                    else
                    {
                        textBoxModelNumber.Text = "Data tidak ditemukan";
                        textBoxRegister.Text = "";
                    }
                }
            }
            else
            {
                // Reset input jika memilih "Pilih Model"
                textBoxModelNumber.Text = "";
                textBoxRegister.Text = "";
            }
        }

        public void setOkNg(bool ok)
        {
            if (!ok)
            {
                btnPrint.Enabled = false; // Menonaktifkan tombol
                btnPrint.BackColor = Color.Gray;
                btnPrint.ForeColor = Color.White;

                btnNg.BackColor = Color.Red;
                btnNg.ForeColor = Color.White;
            }
            else
            {
                btnPrint.Enabled = true; // Aktifkan tombol
                btnPrint.BackColor = Color.Green; // Warna berubah sesuai kondisi
                btnPrint.ForeColor = Color.White;

                btnNg.BackColor = Color.Gray;
                btnNg.ForeColor = Color.White;
            }
        }


        private void textBoxSerial_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSerial.Text))
            {
                if (!string.IsNullOrEmpty(textBoxModelNumber.Text))
                {
                    if (textBoxSerial.Text.Trim().Equals(textBoxModelNumber.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        setOkNg(true);
                    }
                    else
                    {
                        setOkNg(false);
                    }
                }
            }
        }

        private void AddToDataGridView(string serialNumber, string modelNumber, string status)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate { AddToDataGridView(serialNumber, modelNumber, status); });
            }
            else
            {
                dataGridView1.Rows.Add(serialNumber, modelNumber, status, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }


        public void ShowPrintPreviewDialog(ResultModel model, string printerType)
        {
            throw new NotImplementedException();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ScanResult") // Sesuaikan dengan nama kolom Anda
            {
                if (e.Value != null)
                {
                    string result = e.Value.ToString();

                    if (result == "NG")
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }


        private string GetProductFromSettings()
        {
            return SettingView.ProductName; // Sesuaikan dengan properti yang ada
        }

        private string GetLocationFromSettings()
        {
            return SettingView.LocationName; // Sesuaikan dengan properti yang ada
        }

        private void AddToDataGridView(string product, string scan, string modelCodeId, string motorModelId, string result, string date, string time, string inspector, string location)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke((MethodInvoker)delegate { AddToDataGridView(product, scan, modelCodeId, motorModelId, result, date, time, inspector, location); });
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnNg_Click(object sender, EventArgs e)
        {

        }

        public void PushDataToDatabase()
        {
            throw new NotImplementedException();
        }

        void ITabControlView.PushDataToDatabase(string scanResult)
        {
            string product = Properties.Settings.Default.ProductType;  // Ambil dari Setting View
            string location = Properties.Settings.Default.LocationID.ToString(); // Ambil dari Setting View
            string modelCodeId = comboBox1.SelectedValue?.ToString(); // Dari combobox
            string motorModelId = comboBox1.Text; // Dari TextBox Model Number
            string inspector = textBoxInspector.Text; // Dari TextBox Inspector
            string result = scanResult; // OK atau NG
            string scan = textBoxSerial.Text;
            DateTime dateTime = DateTime.Now; // Waktu saat ini

            // Simpan ke database
            bool isSuccess = _numberRepo.InsertScanResult(product, scan, modelCodeId, motorModelId, result, dateTime, inspector, location);

            if (isSuccess)
            {
                string date = dateTime.ToString("yyyy-MM-dd");
                string time = dateTime.ToString("HH:mm:ss");
                AddToDataGridView(product, scan, modelCodeId, motorModelId, result, date, time, inspector, location);
            }
            else
            {
                MessageBox.Show("Gagal menyimpan data ke database.");
            }
        }

        private void LoadData()
        {
            dataGridView1.DataSource = _resultRepo.GetAll()
        .Select(x => new
        {
            x.JenisProduk,
            x.PartCode,
            x.PartCodeId,
            x.ModelNumber,
            x.ScanResult,
            ScanDate = x.Date.ToString("yyyy-MM-dd"),  // Format hanya tanggal
            ScanTime = x.Date.ToString("HH:mm:ss"),  // Format hanya waktu
            x.InspectorId,
            x.Location
        })
        .ToList();
        }
        public string SelectedStatus
        {
            get => comboBox2.SelectedItem?.ToString() ?? "";
            set => comboBox2.SelectedItem = value; // Setter untuk mengubah nilai dari luar
        }

        string ITabControlView.SrchPartCode
        {
            get => SrchPartCode.Text.Trim();
            set => SrchPartCode.Text = value;
        }


        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadAllDataList()
        {

        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                comboBox2.Text = "Pilih Status";
            }
        }



        private void textBoxInspector_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void SrchPartCode_TextChanged(object sender, EventArgs e)
        {
            
        }

        void ITabControlView.ResetButtonColor()
        {

        }
    }
}
