using System;
using System.Reflection;
using System.Windows.Forms;
using PrintGaransi.Model;

namespace PrintGaransi.View
{
    public interface ITabControlView
    {
        // Properties
        string SerialNumber { get; set; }
        string ModelCode { get; set; }
        string ModelNumber { get; set; }
        string Register { get; set; }
        string Search { get; set; }

        // Events
        event EventHandler<ModelEventArgs> SearchModelNumber;
        event EventHandler SearchFilter;
        event EventHandler CheckProperties;
        event EventHandler<DataGridViewCellEventArgs> CellClicked;

        // Methods
        void ShowFilter(BindingSource model);
        void ShowPrintPreviewDialog(GaransiModel model);
        void SetDefectListBindingSource(BindingSource model);
        void SelectTabPageByIndex(int data);
    }

    public class ModelEventArgs : EventArgs
    {
        public string Message { get; set; }

        public ModelEventArgs(string message)
        {
            Message = message;
        }
    }

    public enum TabControlAction
    {
        Selected,
        Deselected,
        // Other actions as needed
    }
}
