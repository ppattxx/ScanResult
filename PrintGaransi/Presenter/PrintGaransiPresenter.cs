using PrintGaransi.Model;
using PrintGaransi.View;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrintGaransi.View.IPrintGaransiView;
using System.Windows.Forms;
using System.Configuration;
using PrintGaransi._Repositories;

namespace PrintGaransi.Presenter
{
    public class PrintGaransiPresenter
    {
        private IPrintGaransiView _view;
        private GaransiModel _model;
        private PrintGaransiLayout _printLayout;
        private IGaransiRepository GaransiRepository;

        public PrintGaransiPresenter(IPrintGaransiView view, IGaransiRepository garansiRepository)
        {
            _view = view;
            //_model = new GaransiModel("Mesin Cuci", "NA-W86BBZ2D", "P.14.PMI3.01113.0318", "244210012");
            GaransiRepository = garansiRepository;
            _printLayout = new PrintGaransiLayout();
            this._view.SearchModelNumber += SearchModelNumber;
        }

        public void PrintGaransi()
        {
            _view.ShowPrintPreviewDialog();
        }
        public void PrintGaransiLayout(PrintPageEventArgs e)
        {
            _printLayout.Print(e, _model);
        }

        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            Console.WriteLine(_view.ModelCode);
            Console.WriteLine(_view.SerialNumber);

            var model = new GaransiModel
            {
                ModelCode = _view.ModelCode
            };

            var searchModel = GaransiRepository.GetByModelCode(model);

            if (searchModel != null)
            {
                _view.ModelCode = searchModel.ModelCode;
                _view.ModelNumber = searchModel.ModelNumber;
                _view.Register = searchModel.noReg;
            }

        }
    }
}
