using Microsoft.Win32;
using PrintGaransi._Repositories;
using PrintGaransi.Model;
using PrintGaransi.View;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintGaransi.Presenter
{
    public class TabControlPresenter
    {
        private readonly ITabControlView _view;
        private IEnumerable<GaransiModel> _model;
        private PrintGaransiLayout _printLayout;
        private IModelNumberRepository ModelNumberRepository;
        private IGaransiRepository GaransiRepository;
        private BindingSource dataBindingSource;
        private BindingSource dataBindingSource2;
        private DateTime _lastScanTime;

        public TabControlPresenter(ITabControlView _view, IGaransiRepository garansiRepository)
        {
            this._view = _view;
            GaransiRepository = garansiRepository;
            ModelNumberRepository = new ModelNumberRepository();
            this._view.SearchModelNumber += SearchModelNumber;
            this._view.SearchFilter += SearchFilter;
            this._view.CheckProperties += CheckProperties;
            this._view.CellClicked += CellClicked;
            dataBindingSource = new BindingSource();
            dataBindingSource2 = new BindingSource();
            this._view.SetDefectListBindingSource(dataBindingSource);
            LoadAllDefectList();
        }

        private void CellClicked(object sender, EventArgs e)
        {
            var model = (GaransiModel)dataBindingSource2.Current;
            var detailModel = new
            {
                //SerialNumber = "12345678",
                //ModelNumber = "NA-W123JJI34",
                //ModelCode = "3D",
                SerialNumber = model.NoSeri,
                ModelNumber = model.ModelNumber,
                Register = model.NoReg,
                JenisProduk = model.JenisProduk,
                //InspectorId = view.InspectorId,
                //Inspector = view.Inspector,
                //Location = Location
            };

            _view.ShowPrintPreviewDialog(model);
        }

        private void CheckProperties(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_view.SerialNumber))
            {
                MessageBox.Show("SerialNumber is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.ModelNumber))
            {
                MessageBox.Show("ModelNumber is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Register))
            {
                MessageBox.Show("Register is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.JenisProduk))
            {
                MessageBox.Show("JenisProduk is required.");
                return;
            }

            // Panggil method untuk membuat model atau operasi lainnya
            CreateModel();
        }

        private void CreateModel()
        {
            DateTime currentTime = DateTime.Now;
            string date = currentTime.ToString("yyyy-MM-dd");
            string time = currentTime.ToString("HH:mm:ss");

            TimeSpan different = TimeSpan.Zero;
            if (_lastScanTime != DateTime.MinValue)
            {
                different = currentTime - _lastScanTime;
            }

            decimal actualTT = ConvertTimeSpanToDecimal(different);

            var model = new GaransiModel
            {
                JenisProduk = _view.JenisProduk,
                ModelCode = _view.ModelCode,
                ModelNumber = _view.ModelNumber,
                NoReg = _view.Register,
                NoSeri = _view.SerialNumber,
                Date = date,
                ScanTime = time,
                Different = different.ToString(@"hh\:mm\:ss"),
                ActualTT = actualTT.ToString("F2"),
                Location = "1"
            };

            GaransiRepository.Add(model);
            _view.ShowPrintPreviewDialog(model);

            _lastScanTime = currentTime;
        }

        private decimal ConvertTimeSpanToDecimal(TimeSpan different)
        {
            return (decimal)different.TotalHours;
        }

        private void LoadAllDefectList()
        {
            _model = GaransiRepository.GetAll();
            dataBindingSource.DataSource = _model;
            dataBindingSource2.DataSource = _model;
        }

        public void SearchFilter(object sender, EventArgs e)
        {
            _model = GaransiRepository.GetFilter(_view.Search);
            dataBindingSource2.DataSource = _model;
            _view.ShowFilter(dataBindingSource2);
        }

        public void ChangeTabPage(int index)
        {
            _view.SelectTabPageByIndex(index);
        }

        private void SearchModelNumber(object sender, ModelEventArgs e)
        {
            if (int.TryParse(_view.ModelCode, out int modelCode))
            {
                var model = new GaransiModel
                {
                    ModelCode = modelCode.ToString()
                };

                var searchModel = ModelNumberRepository.GetByModelCode(model);

                if (searchModel != null)
                {
                    _view.ModelNumber = searchModel.ModelNumber;
                    _view.Register = searchModel.NoReg;
                }
                else
                {
                    _view.SerialNumber = "";
                    _view.ModelCode = "";
                    _view.ModelNumber = "";
                    _view.Register = "";
                }
            }
        }

    }
}
