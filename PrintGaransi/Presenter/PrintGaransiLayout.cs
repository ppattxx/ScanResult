using PrintGaransi.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.Presenter
{
    public class PrintGaransiLayout
    {
        public void Print(PrintPageEventArgs e, GaransiModel garansi)
        {
            // Menentukan ukuran kertas dan margin
            PaperSize customPaperSize = new PaperSize("Custom", 130, 250); //dalam satuan mm
            e.PageSettings.PaperSize = customPaperSize;
            int marginTop = 410;
            int yPos = marginTop;
            int xPos = 214;

            // Menentukan font
            Font fs1 = new Font("Helvetica", 12);
            Font fs2 = new Font("Helvetica", 10);
            Font fs3 = new Font("Helvetica", 14.5f);
            Font fs4 = new Font("Helvetica", 12.5f);

            // Mencetak informasi garansi
            e.Graphics.DrawString(garansi.JenisProduk, fs1, Brushes.Black, new PointF(xPos + 4, yPos + 54));
            yPos += 20;
            e.Graphics.DrawString(garansi.ModelNumber, fs4, Brushes.Black, new PointF(xPos + 4, yPos + 67.5f));
            e.Graphics.DrawString(garansi.NoReg, fs2, Brushes.Black, new PointF(xPos + 5, yPos + 105));
            e.Graphics.DrawString(garansi.NoSeri, fs3, Brushes.Black, new PointF(xPos + 4, yPos + 137));

            // Mencetak informasi garansi untuk Toko
            e.Graphics.DrawString(garansi.JenisProduk, fs1, Brushes.Black, new PointF(xPos + 4, yPos + 444));
            yPos += 20;
            e.Graphics.DrawString(garansi.ModelNumber, fs4, Brushes.Black, new PointF(xPos + 4, yPos + 457.9f));
            e.Graphics.DrawString(garansi.NoReg, fs2, Brushes.Black, new PointF(xPos + 5, yPos + 495.5f));
            e.Graphics.DrawString(garansi.NoSeri, fs3, Brushes.Black, new PointF(xPos + 4, yPos + 527));
        }
    }
}
