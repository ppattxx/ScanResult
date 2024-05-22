using PrintGaransi.Model;
using PrintGaransi.Presenter;
using PrintGaransi.View;
using static PrintGaransi.View.IPrintGaransiView;
using System.Drawing.Printing;
using Microsoft.VisualBasic.ApplicationServices;
using PrintGaransi._Repositories;

public class PrintGaransiPresenter
{
    private IPrintGaransiView _view;
    private GaransiModel _model;
    private PrintGaransiLayout _printLayout;
    private IGaransiRepository GaransiRepository;


    public PrintGaransiPresenter(IPrintGaransiView view, IGaransiRepository garansiRepository)
    {
        _view = view;
        GaransiRepository = garansiRepository;
        _printLayout = new PrintGaransiLayout();
        this._view.Show();
    }


    /***
    public void PrintGaransi()
    {
        _view.ShowPrintPreviewDialog();
    }

    public void PrintGaransiLayout(PrintPageEventArgs e)
    {
        var model = new GaransiModel
        {
            JenisProduk = _view.JenisProduk,
            ModelCode = _view.ModelCode,
            ModelNumber = _view.ModelNumber,
            NoReg = _view.Register,
            NoSeri = _view.SerialNumber
        };
        // _model belum diinisialisasi, jadi diubah menjadi parameter
        _printLayout.Print(e, model);
    }
    ***/
}
