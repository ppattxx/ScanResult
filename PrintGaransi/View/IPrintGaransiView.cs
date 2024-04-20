using PrintGaransi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.View
{
    public interface IPrintGaransiView
    {
        void DisplayGaransi(GaransiModel garansi);
        void ShowPrintPreviewDialog();
    }
}
