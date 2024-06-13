using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintGaransi.Model;
using PrintGaransi.View;
using PrintGaransi._Repositories;

namespace PrintGaransi.Presenter
{
    public class LoginPresenter
    {
        private ILoginView _view;
        private ILoginRepository _repository;

        public LoginPresenter(ILoginView view, ILoginRepository repository)
        {
            _view = view;
            _repository = repository;
            _view.Login += Login;
            this._view.Show();
        }

        private void Login(object sender, EventArgs e)
        {
            string nik = _view.Nik;
            string password = _view.Password;

            LoginModel user = _repository.GetUserByUsername(nik);

            if (user?.Nik == nik && user?.Password == password)
            {
                _view.CloseView();
                IMainFormView printGaransiView = MainForm.GetInstance(user);
                //IGaransiRepository garansi = new GaransiRepository();
                //MainFormPresenter garansiPresenter = new MainFormPresenter(printGaransiView, garansi, user);
                printGaransiView.Show();

            }
            else
            {
                _view.ShowMessage("Invalid username or password");
            }
        }
    }
}
