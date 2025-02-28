using Microsoft.IdentityModel.Tokens;
using PrintGaransi._Repositories;
using PrintGaransi.Model;
using PrintGaransi.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrintGaransi.Presenter
{
    public class TabControlPresenter
    {
        private readonly ITabControlView _view;
        private IEnumerable<ResultModel> _model;
        private readonly GaransiModel _garansiModel;
        private readonly SettingModel _smodel;
        private readonly ProductTypeModel _productType;
        private readonly PrinterTypeModel _printerType;
        private readonly IModelNumberRepository _modelNumberRepository;
        private readonly IGaransiRepository _garansiRepository;
        private readonly ResultRepository _resultModel;
        private BindingSource _dataBindingSource;
        private BindingSource _dataBindingSource2;
        private DateTime _lastScanTime;
        private string inputModelCode;
        private string mode;
        private DateTime date;
        private readonly PrintModeModel _printMode;
        private readonly LoginModel _login;

        public int SrchPartCodeId_TextChanged { get; }
        public int SrchPartCode_TextChanged { get; }
        public int SrchModelNum_TextChanged { get; }

        public TabControlPresenter(TabControlDataPresenter Data)
        {
            _login = Data._User;
            _view = Data.View;
            _garansiRepository = Data.GaransiRepository;
            _smodel = new SettingModel();
            _productType = new ProductTypeModel();
            _garansiModel = new GaransiModel();
            _modelNumberRepository = new ModelNumberRepository();
            _printMode = new PrintModeModel();
            _printerType = new PrinterTypeModel();
            _resultModel = new ResultRepository(ConfigurationManager.ConnectionStrings["LSBUConnection"].ConnectionString);

            _view.SearchModelNumber += SearchModelNumber;
            _view.SearchFilter += SearchFilter;
            _view.CheckProperties += CheckProperties;
            _view.CellClicked += CellClicked;
            _view.Inspector = _login.Name;
            _view.InspectorId = _login.Nik;

            _dataBindingSource = new BindingSource();
            _dataBindingSource2 = new BindingSource();
            _view.SetDefectListBindingSource(_dataBindingSource);

            LoadAllDataList();
        }


        private void CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGridView && e.RowIndex >= 0)
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];
                var selectedData = (ResultModel)selectedRow.DataBoundItem;


                var model = new ResultModel
                {
                    JenisProduk = selectedData.JenisProduk,
                    PartCode = selectedData.PartCode,
                    PartCodeId = selectedData.PartCodeId,
                    ModelNumber = selectedData.ModelNumber,
                    ScanResult = selectedData.ScanResult,
                    Date = selectedData.Date,
                    InspectorId = selectedData.InspectorId,
                    Location = selectedData.Location
                };
            }
        }

        private void CheckProperties(object sender, EventArgs e)
        {
            // Validasi setiap input harus terisi
            if (string.IsNullOrWhiteSpace(_view.SerialNumber))
            {
                _view.SetStatus("Serial Number harus terisi");
                SetStatusWarning();
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.ModelNumber))
            {
                _view.SetStatus("Model harus terisi");
                SetStatusWarning();
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Register))
            {
                _view.SetStatus("Register harus terisi");
                SetStatusWarning();
                return;
            }

            // **Perbandingan Serial Number & Model Number**
            if (_view.SerialNumber != "")
            {
                if (_view.SerialNumber.Trim().Equals(_view.PartCode.Trim(),StringComparison.OrdinalIgnoreCase))
                {
                    _view.btnOk = Color.Green;
                    _view.BtnOkEnabled = true;
                    _view.BtnCancelEnabled = false;
                    _view.btnCancel = Color.Gray;
                    _view.PushDataToDatabase("OK");
                    _view.SetStatus("Data berhasil disimpan");
                    _view.StatusBackColor = Color.Green;
                }
                else
                {
                    _view.btnOk = Color.Gray;
                    _view.BtnOkEnabled = false;
                    _view.BtnCancelEnabled = true;
                    _view.btnCancel = Color.Red;
                    _view.PushDataToDatabase("NG");
                    _view.SetStatus("Data gagal disimpan");
                    _view.StatusBackColor = Color.Red;
                    MessageBox.Show("hasilnya ng");
                }
                _view.Refresh();
                LoadAllDataList();
                _view.ResetButtonColor();
            }
        }
        // Fungsi tambahan untuk mengatur status warning
        private void SetStatusWarning()
        {
            _view.StatusBackColor = Color.Yellow;
            _view.StatusForeColor = Color.Black;
            _view.BtnOkEnabled = false;
            _view.BtnCancelEnabled = true;
            _view.btnCancel = Color.Red;
        }

        public void LoadAllDataList()
        {
            try
            {
                DateTime today = DateTime.Today;

                // Ambil semua data
                var results = _resultModel.GetAll();

                // Filter hanya data hari ini
                var filteredResults = results.Where(x => x.Date.Date == today).ToList();

                _dataBindingSource.DataSource = filteredResults ?? new List<ResultModel>();
                _view.SetDefectListBindingSource(_dataBindingSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void SaveAllDataList()
        {
            try
            {
                // Ambil data dari DataGridView (BindingSource)
                var updatedResults = (List<ResultModel>)_dataBindingSource.DataSource;

                // Simpan ke database (gunakan repository)
                _resultModel.SaveAll(updatedResults);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SearchFilter(object sender, EventArgs e)
        {
            DateTime selectedDate = _view.SelectedDate.Date;
            string selectedStatus = _view.SelectedStatus; 
            string searchPartCode = _view.SrchPartCode?.Trim();

            _model = _resultModel.GetAll(); 

            var filteredData = _model.Where(r => r.Date.Date == selectedDate).ToList();

            if (selectedStatus != "ALL" && !string.IsNullOrEmpty(selectedStatus))
            {
                filteredData = filteredData.Where(r => r.ScanResult.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filter berdasarkan SrchPartCode di tiga kolom (PartCode, PartCodeId, ModelNumber)
            if (!string.IsNullOrEmpty(searchPartCode))
            {
                filteredData = filteredData.Where(r =>
                    r.PartCode.Contains(searchPartCode, StringComparison.OrdinalIgnoreCase) ||
                    r.PartCodeId.Contains(searchPartCode, StringComparison.OrdinalIgnoreCase) ||
                    r.ModelNumber.Contains(searchPartCode, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }


            _dataBindingSource.DataSource = filteredData;
            _view.ShowFilter(_dataBindingSource);
        }


        public void ChangeTabPage(int index)
        {
            _view.SelectTabPageByIndex(index);
        }

        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            var model = new GaransiModel
            {
                ModelCode = _view.GetModelCode().ToString()
            };
            _view.LastInput = _view.SerialNumber;

            var allModels = _modelNumberRepository.GetAllModelCodes();
            var searchModel = allModels.FirstOrDefault(m => m.ModelCode == model.ModelCode);

            if (searchModel != null)
            {
                _view.ModelNumber = searchModel.ModelNumber;
                _view.Register = searchModel.NoReg;
            }
            else
            {
                ClearViewFields();
                _view.SetStatus("Hasil scan tidak terbaca");
                _view.StatusBackColor = Color.Yellow;
                _view.StatusForeColor = Color.Black;
            }
        }

        private void ClearViewFields()
        {
            _view.SerialNumber = "";
            _view.SetStatus("");
            _view.StatusBackColor = SystemColors.Control;
        }

        public void ResetDataBinding()
        {
            _dataBindingSource.DataSource = null;
            _dataBindingSource2.DataSource = null;
            _view.SetDefectListBindingSource(null);
            _view.SetDefectListBindingSource(_dataBindingSource);
            ClearViewFields();
            LoadAllDataList();
        }

        public void UnassociateViewEvents()
        {
            _view.SearchModelNumber -= SearchModelNumber;
            _view.SearchFilter -= SearchFilter;
            _view.CheckProperties -= CheckProperties;
            _view.CellClicked -= CellClicked;
        }
    }
}
