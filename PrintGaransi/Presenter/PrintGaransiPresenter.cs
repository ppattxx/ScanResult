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
        private readonly GaransiRepository _repository;

        public PrintGaransiPresenter(IPrintGaransiView view)
        {
            _view = view;
            //_model = new GaransiModel("Mesin Cuci", "NA-W86BBZ2D", "P.14.PMI3.01113.0318", "244210012");
            _repository = new GaransiRepository();
            _printLayout = new PrintGaransiLayout();
            this._view.SearchModelNumber += SearchModelNumber;
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

        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            Console.WriteLine(_view.ModelCode);
            Console.WriteLine(_view.SerialNumber);

            var model = new GaransiModel
            {
                NoSeri = _view.SerialNumber,
                ModelCode = _view.ModelCode
            };

            var searchModel = _repository.GetModelByModelCode(_view.ModelCode);

            if (searchModel != null)
            {
                _view.ModelCode = searchModel.ModelCode;
                Console.WriteLine("Value of modelnumber: " + _view.ModelCode);
            }

        }
    }
}
