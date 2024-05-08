using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.View
{
    public interface ISettingView
    {
        string ipaddress { get; set; }
        int portaddress { get; set; }

        //Event
        event EventHandler SaveIPSettings;
        event EventHandler SavePortSettings;
        event EventHandler LoadIP;
        event EventHandler LoadPort;

        // Methods
        void DisplayIP(string IPaddress);
        void DisplayPort(int Port);
    }
}
