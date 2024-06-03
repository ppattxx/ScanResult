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
}
