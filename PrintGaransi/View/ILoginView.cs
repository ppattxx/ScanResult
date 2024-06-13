using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.View
{
    public interface ILoginView
    {
        string Nik { get; }
        string Name { get; }
        string Password { get; }
        bool IsLoginSuccessful { get; }
        void ShowMessage(string message);
        void CloseView();
        void Show();
        event EventHandler Login;

    }
}
