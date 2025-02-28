﻿using PrintGaransi._Repositories;
using PrintGaransi.Model;
using PrintGaransi.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrintGaransi.View
{
    public partial class SettingView : Form, ISettingView
    {
        private bool isInitializing;
        private string lastMode = "";
        private readonly IMainFormView _printGaransiView;
        private readonly PrintModeModel _printMode;

        public SettingView()
        {
            InitializeComponent();
            InitializeEventHandler();
            _printMode = new PrintModeModel();
            LoadCheckBoxSetting();
            LoadRadioSettings();
            LoadPrinters();
        }

        private void LoadCheckBoxSetting()
        {
            checkBox.Checked = Properties.Settings.Default.CheckBoxChecked;
        }

        private void LoadPrinters()
        {
            try
            {
                // Clear existing items
                printerBox.Items.Clear();

                // Get the list of installed printers and add them to the ComboBox
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    printerBox.Items.Add(printer);
                }

                // Optionally set the selected item to the default printer
                PrinterSettings settings = new PrinterSettings();
                if (printerBox.Items.Contains(settings.PrinterName))
                {
                    printerBox.SelectedItem = settings.PrinterName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading printers: " + ex.Message);
            }
        }

        private void LoadRadioSettings()
        {
            btnOn.Checked = Properties.Settings.Default.Mode == "on";
            btnOff.Checked = Properties.Settings.Default.Mode == "off";
            btnPreview.Checked = Properties.Settings.Default.Mode == "preview";
        }

        public List<string> JenisProdukNames
        {
            get => JPComboBox.DataSource as List<string>;
            set => JPComboBox.DataSource = value;
        }

        public List<string> LocationNames
        {
            get => locationBox.DataSource as List<string>;
            set => locationBox.DataSource = value;
        }

        public string ipaddress
        {
            get => textBoxIP.Text;
            set => textBoxIP.Text = value;
        }
        public string portaddress
        {
            get { return textBoxPort.Text; }
            set { textBoxPort.Text = value; }
        }

        public string mode { get; set; }

        public bool IsCheckBoxChecked
        {
            get => checkBox.Checked;
            set => checkBox.Checked = value;
        }
        public static string LocationName { get; internal set; }
        public static string ProductName { get; internal set; }

        public event EventHandler SelectedIndexChanged;
        public event EventHandler SaveIPSettings;
        public event EventHandler SavePortSettings;
        public event EventHandler LoadIP;
        public event EventHandler LoadPort;
        public event EventHandler LoadLocation;
        public event EventHandler LoadProductName;
        public event EventHandler SelectedProductType;
        public event EventHandler HandleRadioButton;
        public event EventHandler SelectedPrinterType;
        public event EventHandler LoadPrinterType;
        public event EventHandler HandleCheckBox;

        public void DisplayName(string JPName)
        {
            JPComboBox.Text = JPName;
        }

        public void DisplayIP(string IPaddress)
        {
            textBoxIP.Text = IPaddress;
        }

        public void DisplayPort(int Port)
        {
            textBoxPort.Text = Port.ToString();
        }

        public void DsiplayPrinterType(string printerType)
        {
            printerBox.Text = printerType;
        }

        public void InitializeEventHandler()
        {
            JPComboBox.SelectedIndexChanged += (sender, e) =>
            {
                if (!isInitializing)
                {
                    SelectedProductType?.Invoke(sender, e);
                }
            };

            locationBox.SelectedIndexChanged += (sender, e) =>
            {
                if (!isInitializing)
                {
                    SelectedIndexChanged?.Invoke(sender, e);
                }
            };

            textBoxIP.TextChanged += (sender, e) =>
            {
                SaveIPSettings?.Invoke(this, EventArgs.Empty);
            };

            textBoxPort.TextChanged += (sender, e) =>
            {
                SavePortSettings?.Invoke(this, EventArgs.Empty);
            };

            btnConnect.Click += delegate
            {
                if (!checkBox.Checked)
                {
                    // Tampilkan pesan atau lakukan tindakan yang sesuai
                    DialogResult dialogResult = CustomeMessageBox.Show("Mohon centang checkbox actived sebelum menutup setting.", "Peringatan", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.OK)
                    {
                        return;
                    }
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                ILoginView loginView = new LoginView();
                LoginPresenter loginPresenter = new LoginPresenter(loginView, new LoginRepository());
                (loginView as Form)?.Show();
                this.Close();
            };

            btnOn.CheckedChanged += (sender, e) =>
            {
                if (btnOn.Checked && lastMode != "on")
                {
                    mode = "on";
                    lastMode = "on";
                    HandleRadioButton?.Invoke(sender, e);
                }
            };

            btnOff.CheckedChanged += (sender, e) =>
            {
                if (btnOff.Checked && lastMode != "off")
                {
                    mode = "off";
                    lastMode = "off";
                    HandleRadioButton?.Invoke(sender, e);
                }
            };

            btnPreview.CheckedChanged += (sender, e) =>
            {
                if (btnPreview.Checked && lastMode != "preview")
                {
                    mode = "preview";
                    lastMode = "preview";
                    HandleRadioButton?.Invoke(sender, e);
                }
            };

            btnClose.Click += delegate
            {
                if (!checkBox.Checked)
                {
                    // Tampilkan pesan atau lakukan tindakan yang sesuai
                    DialogResult dialogResult = CustomeMessageBox.Show("Mohon centang checkbox actived sebelum menutup setting.", "Peringatan", MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.OK)
                    {
                        return;
                    }
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                this.Close();

            };

            printerBox.SelectedIndexChanged += (sender, e) =>
            {
                if (!isInitializing)
                {
                    SelectedPrinterType?.Invoke(sender, e);
                }
            };

            checkBox.CheckedChanged += (sender, e) =>
            {
                if (checkBox.Checked)
                {
                    // Ketika checkbox diceklis
                    textBoxIP.ReadOnly = true;
                    textBoxPort.ReadOnly = true;
                    JPComboBox.Enabled = false;
                    locationBox.Enabled = false;
                    printerBox.Enabled = false;
                    HandleCheckBox?.Invoke(sender, e);
                }
                else
                {
                    // Ketika checkbox tidak diceklis
                    textBoxIP.ReadOnly = false;
                    textBoxPort.ReadOnly = false;
                    JPComboBox.Enabled = true;
                    locationBox.Enabled = true;
                    printerBox.Enabled = true;
                    HandleCheckBox?.Invoke(sender, e);
                }
            };
        }

        public void DisplaySetting(string locationName)
        {
            locationBox.Text = locationName;
        }

        //Singeleton pattern (open a single  from instance)
        private static SettingView instance;
        public static SettingView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
                instance = new SettingView();
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            isInitializing = true;
            LoadProductName?.Invoke(this, EventArgs.Empty);
            LoadLocation?.Invoke(this, EventArgs.Empty);
            LoadIP?.Invoke(this, EventArgs.Empty);
            LoadPort?.Invoke(this, EventArgs.Empty);
            LoadPrinterType?.Invoke(this, EventArgs.Empty);
            isInitializing = false;

        }
        public string GetSelectedProduct()
        {
            return JPComboBox.SelectedItem?.ToString();
        }

        public string GetSelectedLocation()
        {
            return locationBox.SelectedItem?.ToString();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
