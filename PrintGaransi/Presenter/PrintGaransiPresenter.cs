using PrintGaransi.Model;
using PrintGaransi.View;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.Presenter
{
    public class PrintGaransiPresenter
    {
        private IPrintGaransiView _view;
        private GaransiModel _model;
        private PrintGaransiLayout _printLayout;

        public PrintGaransiPresenter(IPrintGaransiView view)
        {
            _view = view;
            _model = new GaransiModel("Mesin Cuci", "NA-W86BBZ2D", "P.14.PMI3.01113.0318", "244210012");
            _printLayout = new PrintGaransiLayout();
        }

        public void ShowGaransi()
        {
            _view.DisplayGaransi(_model);
        }

        public void PrintGaransi()
        {
            _view.ShowPrintPreviewDialog();
        }
        public void PrintGaransiLayout(PrintPageEventArgs e)
        {
            _printLayout.Print(e, _model);
        }
    }
}
