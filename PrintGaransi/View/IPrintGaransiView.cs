using PrintGaransi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.View
{
    public interface IPrintGaransiView
    {

        //properties - fields
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }

        //event
        event EventHandler<ModelEventArgs> SearchModelNumber;

        void DisplayGaransi(GaransiModel garansi);
        void ShowPrintPreviewDialog();

        public class ModelEventArgs : EventArgs
        {
            public string Message { get; set; }

            public ModelEventArgs(string message)
            {
                Message = message;
            }
        }
    }
}
