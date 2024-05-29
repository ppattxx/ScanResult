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
            int xPos = 220;

            // Menentukan font
            Font fs1 = new Font("Arial", 14, FontStyle.Bold);
            Font fs2 = new Font("Arial", 10);

            // Mencetak informasi garansi
            e.Graphics.DrawString(garansi.JenisProduk, fs1, Brushes.Black, new PointF(xPos, yPos + 55));
            yPos += 20;
            e.Graphics.DrawString(garansi.ModelNumber, fs2, Brushes.Black, new PointF(xPos, yPos + 73));
            e.Graphics.DrawString(garansi.NoReg, fs2, Brushes.Black, new PointF(xPos, yPos + 105));
            e.Graphics.DrawString(garansi.NoSeri, fs2, Brushes.Black, new PointF(xPos, yPos + 140));

            // Mencetak informasi garansi untuk Toko
            e.Graphics.DrawString(garansi.JenisProduk, fs1, Brushes.Black, new PointF(xPos, yPos + 440));
            yPos += 20;
            e.Graphics.DrawString(garansi.ModelNumber, fs2, Brushes.Black, new PointF(xPos, yPos + 460));
            e.Graphics.DrawString(garansi.NoReg, fs2, Brushes.Black, new PointF(xPos, yPos + 495));
            e.Graphics.DrawString(garansi.NoSeri, fs2, Brushes.Black, new PointF(xPos, yPos + 530));
        }
    }
}
