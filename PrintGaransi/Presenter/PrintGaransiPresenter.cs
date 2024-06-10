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
    public LoginModel _login { get; }

    public PrintGaransiPresenter(IPrintGaransiView view, IGaransiRepository garansiRepository, LoginModel login)
    {
        _view = view;
        GaransiRepository = garansiRepository;
        _printLayout = new PrintGaransiLayout();
        this._view.Show();
        _login = login;
    }
}
