using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintGaransi.Model;
using PrintGaransi.View;


namespace PrintGaransi.Presenter
{
    public class SettingPresenter
    {
        private readonly ISettingView _view;
        private readonly SettingModel _model;

        public SettingPresenter(ISettingView view, SettingModel model) 
        {
            _view = view;
            _model = model;

            _view.SaveIPSettings += SaveIPSettings;
            _view.SavePortSettings += SavePortSettings;
            _view.LoadIP += View_LoadIP;
            _view.LoadPort += View_LoadPort;
        }

        private void View_LoadIP(object sender, EventArgs e)
        {
            string loadedIP = _model.LoadIP();
            _view.DisplayIP(loadedIP);
        }

        private void View_LoadPort(object sender, EventArgs e)
        {
            int loadedPort = _model.LoadPort();
            _view.DisplayPort(loadedPort);
        }

        private void SaveIPSettings(object sender, EventArgs e)
        {
            _model.SaveSettingIP(_view.ipaddress);
        }

        private void SavePortSettings(object sender, EventArgs e)
        {
            _model.SaveSettingPort(_view.portaddress);
        }
    }
}
