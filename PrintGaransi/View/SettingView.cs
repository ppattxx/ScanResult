using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrintGaransi.View
{
    public partial class SettingView : Form, ISettingView
    {
        public SettingView()
        {
            InitializeComponent();
            InitializeEventHandler();
        }

        public string ipaddress
        {
            get => textBoxIP.Text;
            set => textBoxIP.Text = value;
        }
        public int portaddress
        {
            get { return int.Parse(textBoxPort.Text); }
            set { textBoxPort.Text = value.ToString(); }
        }

        public event EventHandler SaveIPSettings;
        public event EventHandler SavePortSettings;
        public event EventHandler LoadIP;
        public event EventHandler LoadPort;

        public void DisplayIP(string IPaddress)
        {
            textBoxIP.Text = IPaddress;
        }

        public void DisplayPort(int Port)
        {
            textBoxPort.Text = Port.ToString();
        }

        public void InitializeEventHandler()
        {
            textBoxIP.TextChanged += (sender, e) =>
            {
                SaveIPSettings?.Invoke(this, EventArgs.Empty);
            };

            textBoxPort.TextChanged += (sender, e) =>
            {
                SavePortSettings?.Invoke(this, EventArgs.Empty);
            };

            btnConnect.Click += delegate
            { };
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
            LoadIP?.Invoke(this, EventArgs.Empty);
            LoadPort?.Invoke(this, EventArgs.Empty);
        }
    }
}
