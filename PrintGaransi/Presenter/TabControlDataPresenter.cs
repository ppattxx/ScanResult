using PrintGaransi.Model;
using PrintGaransi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.Presenter
{
    public class TabControlDataPresenter
    {
        public ITabControlView View { get; }
        public IGaransiRepository GaransiRepository { get; }
        public LoginModel _User { get; }

        public TabControlDataPresenter(ITabControlView view, IGaransiRepository garansiRepository,LoginModel user)
        {
            View = view;
            GaransiRepository = garansiRepository;   
            _User = user;

        }
    }
}
