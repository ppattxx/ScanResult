using PrintGaransi._Repositories;
using PrintGaransi.Model;
using PrintGaransi.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PrintGaransi.Presenter
{
    public class TabControlPresenter
    {
        private readonly ITabControlView _view;
        private IEnumerable<GaransiModel> _model;
        private readonly GaransiModel _garansiModel;
        private readonly SettingModel _smodel;
        private readonly ProductTypeModel _productType;
        private readonly IModelNumberRepository _modelNumberRepository;
        private readonly IGaransiRepository _garansiRepository;
        private BindingSource _dataBindingSource;
        private BindingSource _dataBindingSource2;
        private DateTime _lastScanTime;

        public TabControlPresenter(ITabControlView view, IGaransiRepository garansiRepository)
        {
            _view = view;
            _garansiRepository = garansiRepository;
            _smodel = new SettingModel();
            _productType = new ProductTypeModel();
            _garansiModel = new GaransiModel();
            _modelNumberRepository = new ModelNumberRepository();

            _view.SearchModelNumber += SearchModelNumber;
            _view.SearchFilter += SearchFilter;
            _view.CheckProperties += CheckProperties;
            _view.CellClicked += CellClicked;
            _view.clickButton += ClickButton;

            _dataBindingSource = new BindingSource();
            _dataBindingSource2 = new BindingSource();
            _view.SetDefectListBindingSource(_dataBindingSource);
            LoadAllDataList();
        }

        private void ClickButton(object sender, EventArgs e)
        {
            string loadTime = _garansiModel.LoadScanTime();
            MessageBox.Show(loadTime);
            DateTime currentTime = DateTime.Now;
            string date = currentTime.ToString("yyyy-MM-dd");
            string time = currentTime.ToString("HH:mm:ss");
            _garansiModel.SaveScanTime(time);
            MessageBox.Show(time);
        }

        private void CellClicked(object sender, EventArgs e)
        {
            CreateModel();
        }

        private void CheckProperties(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SerialNumber))
            {
                MessageBox.Show("Serial Number is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.ModelNumber))
            {
                MessageBox.Show("Model Number is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Register))
            {
                MessageBox.Show("Register is required.");
                return;
            }

            CreateModel();
        }

        private void CreateModel()
        {
            string loadTime = _garansiModel.LoadScanTime();
            DateTime currentTime = DateTime.Now;
            string date = currentTime.ToString("yyyy-MM-dd");
            string time = currentTime.ToString("HH:mm:ss");
            _garansiModel.SaveScanTime(time);

            TimeSpan different = TimeSpan.Zero;
            if (_lastScanTime != DateTime.MinValue)
            {
                different = currentTime - _lastScanTime;
            }

            decimal actualTT = ConvertTimeSpanToDecimal(different);

            var model = new GaransiModel
            {
                JenisProduk = _productType.LoadProductType(),
                ModelCode = _view.ModelCode,
                ModelNumber = _view.ModelNumber,
                NoReg = _view.Register,
                NoSeri = _view.SerialNumber,
                Date = date,
                ScanTime = time,
                Different = different.ToString(@"hh\:mm\:ss"),
                ActualTT = actualTT.ToString("F2"),
                Location = _smodel.LoadLocationID()
            };

            _garansiRepository.Add(model);
            _view.ShowPrintPreviewDialog(model);

            LoadAllDataList();

            _lastScanTime = currentTime;
        }

        private decimal ConvertTimeSpanToDecimal(TimeSpan different)
        {
            return (decimal)different.TotalHours;
        }

        private void LoadAllDataList()
        {
            _model = _garansiRepository.GetAll();
            _dataBindingSource.DataSource = _model;
            _dataBindingSource2.DataSource = _model;
            _view.SetDefectListBindingSource(_dataBindingSource);
        }

        public void SearchFilter(object sender, EventArgs e)
        {
            _model = _garansiRepository.GetFilter(_view.Search);
            _dataBindingSource2.DataSource = _model;
            _view.ShowFilter(_dataBindingSource2);
        }

        public void ChangeTabPage(int index)
        {
            _view.SelectTabPageByIndex(index);
        }

        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            if (int.TryParse(_view.ModelCode, out int modelCode))
            {
                if (modelCode >= 0)
                {
                    var model = new GaransiModel
                    {
                        ModelCode = modelCode.ToString()
                    };

                    var searchModel = _modelNumberRepository.GetByModelCode(model);

                    if (searchModel != null)
                    {
                        _view.ModelNumber = searchModel.ModelNumber;
                        _view.Register = searchModel.NoReg;
                    }
                    else
                    {
                        ClearViewFields();
                    }
                }
                else
                {
                    ClearViewFields();
                }
            }
            else
            {
                MessageBox.Show("Not valid");
                ClearViewFields();
            }
        }

        private void ClearViewFields()
        {
            _view.SerialNumber = "";
            _view.ModelCode = "";
            _view.ModelNumber = "";
            _view.Register = "";
        }
    }
}
