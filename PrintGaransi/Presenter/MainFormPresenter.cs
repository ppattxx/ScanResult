using PrintGaransi.Model;
using PrintGaransi.Presenter;
using PrintGaransi.View;
using static PrintGaransi.View.IMainFormView;
using System.Drawing.Printing;
using Microsoft.VisualBasic.ApplicationServices;
using PrintGaransi._Repositories;

public class MainFormPresenter
{
    private IMainFormView _view;
    private GaransiModel _model;
    private PrintGaransiLayout _printLayout;
    private IGaransiRepository GaransiRepository;
    public LoginModel _login { get; }

    public MainFormPresenter(IMainFormView view, IGaransiRepository garansiRepository, LoginModel login)
    {
        _view = view;
        GaransiRepository = garansiRepository;
        _printLayout = new PrintGaransiLayout();
        this._view.Show();
        _login = login;
    }
}
