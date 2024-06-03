using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintGaransi.View
{
    public partial class FontViewer : Form
    {
        public FontViewer()
        {
            InitializeComponent();

            var installedFonts = new InstalledFontCollection();
            var fontFamilies = installedFonts.Families;

            var listBox = new ListBox
            {
                Dock = DockStyle.Fill
            };

            foreach (var fontFamily in fontFamilies)
            {
                listBox.Items.Add(fontFamily.Name);
            }

            this.Controls.Add(listBox);
            this.Text = "Installed Fonts";
            this.Width = 300;
            this.Height = 400;
        }
    }
}
