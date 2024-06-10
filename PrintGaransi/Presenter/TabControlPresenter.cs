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
        private readonly PrintModeModel _printMode;
        private readonly LoginModel _login;

        public TabControlPresenter(PrintGaransiDataPresenter Data)
        {
            _login = Data._User;
            _view = Data.View;
            _garansiRepository = Data.GaransiRepository;
            _smodel = new SettingModel();
            _productType = new ProductTypeModel();
            _garansiModel = new GaransiModel();
            _modelNumberRepository = new ModelNumberRepository();
            _printMode = new PrintModeModel();

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

            //load last scan time when start application
            string lastScanTimeString = _garansiModel.LoadScanTime();
            if (DateTime.TryParse(lastScanTimeString, null, System.Globalization.DateTimeStyles.RoundtripKind, out DateTime lastScanTime))
            {
                _lastScanTime = lastScanTime;
            }
            else
            {
                _lastScanTime = DateTime.MinValue;
            }
        }

        private void CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGridView && e.RowIndex >= 0)
            {
                var selectedRow = dataGridView.Rows[e.RowIndex];
                var selectedData = (GaransiModel)selectedRow.DataBoundItem;


                var model = new GaransiModel
                {
                    JenisProduk = selectedData.JenisProduk,
                    ModelCode = selectedData.ModelCode,
                    ModelNumber = selectedData.ModelNumber,
                    NoReg = selectedData.NoReg,
                    NoSeri = selectedData.NoSeri,
                    Date = selectedData.Date,
                    ScanTime = selectedData.ScanTime,
                    Different = selectedData.Different,
                    ActualTT = selectedData.ActualTT,
                    Location = selectedData.Location
                };

                _view.ShowPrintPreviewDialog(model);
            }
        }

        private void CheckProperties(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SerialNumber))
            {
                MessageBox.Show("Serial Number is required");
                return;
            }
            if (string.IsNullOrWhiteSpace(_view.ModelCode))
            {
                MessageBox.Show("Model Code is required");
                return;
            }
            if (string.IsNullOrWhiteSpace(_view.ModelNumber))
            {
                MessageBox.Show("Model Number is required");
                return;
            }
            if (string.IsNullOrWhiteSpace(_view.Register))
            {
                MessageBox.Show("Register is required");
                return;
            }

            var existingRecords = _garansiRepository.GetExists(_view.SerialNumber, _view.ModelCode);
            string mode = _printMode.GetMode();

            if(existingRecords != null && existingRecords.Any())
            {
              
               if( mode == "off")
               {
                   _view.Status = "Data sudah tersimpan dalam database";
                   _view.StatusBackColor = Color.Red;
                   _view.StatusForeColor = Color.White;
                   return;
               }
               else if( mode == "on")
               {
                   _view.Status = "Data sudah tersimpan dalam database";
                   _view.StatusBackColor = Color.Red;
                   _view.StatusForeColor = Color.White;
                   return;
               }
            }

            CreateModel();
        }

        private void CreateModel()
        {
            DateTime currentTime = DateTime.Now;
            string date = currentTime.ToString("d");
            string time;
            TimeSpan different = TimeSpan.Zero;
            string mode = _printMode.GetMode();
            var existingRecords = _garansiRepository.GetExists(_view.SerialNumber, _view.ModelCode);

            //mengatur waktu ketika sudah ganti hari
            if (_lastScanTime.Date != currentTime.Date)
            {
                time = currentTime.ToString("HH:mm:ss");
                _lastScanTime = currentTime;
            }
            else
            {
                time = currentTime.ToString(@"T");
            }


            if (_lastScanTime != DateTime.MinValue && _lastScanTime.Date == currentTime.Date)
            {
                different = currentTime - _lastScanTime;
            }
            else
            {
                different = TimeSpan.Zero;
            }

            decimal actualTT = (decimal)different.TotalSeconds;

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
                ActualTT = actualTT,
                Location = _smodel.LoadLocationID(),
                inspectorId = _view.InspectorId
            };
            _garansiRepository.Add(model);

            if (mode == "off")
            {
                if (existingRecords == null || !existingRecords.Any())
                {
                    // Data belum ada dalam database
                    MessageBox.Show("Mode print dalam keadaan OFF. Data telah tersimpan, tapi tidak bisa melakukan Print.");
                    _view.Status = "Data tersimpan, tapi print dalam mode OFF.";
                    _view.StatusBackColor = Color.Orange;
                    _view.StatusForeColor = Color.White;
                }
                else
                {
                    // Data sudah ada dalam database
                    MessageBox.Show("Mode print dalam keadaan OFF. Data sudah ada dalam database.");
                    _view.Status = "Data sudah tersimpan dalam database.";
                    _view.StatusBackColor = Color.Red;
                    _view.StatusForeColor = Color.White;
                }
            }
            else
            {
                if (existingRecords == null || !existingRecords.Any())
                {
                    // Data belum ada dalam database, print diizinkan
                    _view.ShowPrintPreviewDialog(model);
                    _view.Status = "";
                    _view.StatusBackColor = SystemColors.Control;
                    _view.StatusForeColor = SystemColors.ControlText;
                }
                else
                {
                    // Data sudah ada dalam database
                    MessageBox.Show("Data sudah ada dalam database.");
                    _view.Status = "Data sudah tersimpan dalam database.";
                    _view.StatusBackColor = Color.Red;
                    _view.StatusForeColor = Color.White;
                }
            }

            LoadAllDataList();

            _lastScanTime = currentTime;

            // Save Last Scan
            _garansiModel.SaveScanTime(_lastScanTime.ToString("O"));
        }

        private void LoadAllDataList()
        {   //manual set date
            //DateTime specificDate = new DateTime(2024, 5, 30);

            _model = _garansiRepository.GetAll();
            _dataBindingSource.DataSource = _model;
            _dataBindingSource2.DataSource = _model;
            _view.SetDefectListBindingSource(_dataBindingSource);
        }

        public void SearchFilter(object sender, EventArgs e)
        {
            _model = _garansiRepository.GetFilter(_view.Search, _view.SelectedDate);
            _dataBindingSource2.DataSource = _model;
            _view.ShowFilter(_dataBindingSource2);
        }

        public void ChangeTabPage(int index)
        {
            _view.SelectTabPageByIndex(index);
        }

        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
           var model = new GaransiModel
           {
               ModelCode = _view.ModelCode.ToString()
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
                MessageBox.Show("not found");
           }
        }

        private void ClearViewFields()
        {
            _view.SerialNumber = "";
            _view.ModelCode = "";
            _view.ModelNumber = "";
            _view.Register = "";
            _view.Status = "";
            _view.StatusBackColor = SystemColors.Control;
        }   
    }
}
