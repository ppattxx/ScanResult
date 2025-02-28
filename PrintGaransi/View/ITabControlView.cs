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

        string GetModelCode();
        void SetModelCode(string value);

        string ModelNumber { get; set; }
        string Register { get; set; }
        string InspectorId { get; set; }
        string Inspector { get; set; }
        string Search { get; set; }
        string PartCode { get; set; }
        DateTime SelectedDate { get; }

        string GetStatus();
        void SetStatus(string value);

        Color StatusBackColor { get; set; }
        Color StatusForeColor { get; set; }
        Color btnOk { get; set; }
        Color btnCancel { get; set; }
        bool SubmitButtonEnabled { get; set; }
        int SubmitButtonClicked { get; set; }
        bool BtnOkEnabled { get; set; }
        bool BtnCancelEnabled { get; set; }
        string SelectedStatus { get; }
        string LastInput { get; set; }
        string SrchPartCode { get; set; }


        // Events
        event EventHandler<ModelEventArgs> SearchModelNumber;
        event EventHandler SearchFilter;
        event EventHandler CheckProperties;
        event EventHandler<DataGridViewCellEventArgs> CellClicked;

        // Methods
        void ShowFilter(BindingSource model);
        void ShowPrintPreviewDialog(GaransiModel model, string printerType);
        void SetDefectListBindingSource(BindingSource model);
        void SelectTabPageByIndex(int data);
        void setOkNg(bool ok);
        void ShowPrintPreviewDialog(ResultModel model, string printerType);
        void PushDataToDatabase(string scanResult);
        void LoadAllDataList();
        void Refresh();
        void ResetButtonColor();
    }

    public class ModelEventArgs : EventArgs
    {
        public string Message { get; set; }

        public ModelEventArgs(string message)
        {
            Message = message;
        }
    }
}
