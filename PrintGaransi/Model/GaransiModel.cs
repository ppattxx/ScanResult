using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrintGaransi.Model
{
    public class GaransiModel
    {
        public string id;
        public string jenisProduk;
        public string modelNumber;
        public string noReg;
        public string noSeri;
        public string modelCode;
        public string date;
        public string scanTime;
        public string different;
        public decimal actualTT;
        public string location;
        public string inspectorId;

        // Properties
        [DisplayName("ID")]
        [Browsable(false)]
        public string Id
        {
            get => id;
            set => id = value;
        }
        [DisplayName("Jenis Produk")]
        //[Browsable(false)]
        public string JenisProduk
        {
            get => jenisProduk;
            set => jenisProduk = value;
        }

        [DisplayName("Model Number")]
        public string ModelNumber
        {
            get => modelNumber;
            set => modelNumber = value;
        }

        [DisplayName("Model Code")]
        //[Browsable(false)]
        public string ModelCode
        {
            get => modelCode;
            set => modelCode = value;
        }


        [DisplayName("No. Register")]
        public string NoReg
        {
            get => noReg;
            set => noReg = value;
        }

        [DisplayName("Serial Number")]
        public string NoSeri
        {
            get => noSeri;
            set => noSeri = value;
        }


        [DisplayName("Scanning Date")]
        public string Date
        {
            get => date;
            set => date = value;
        }

        [DisplayName("Scanning Time")]
        public string ScanTime
        {
            get => scanTime;
            set => scanTime = value;
        }

        [DisplayName("Operator")]
        public string Inspector
        {
            get => inspectorId;
            set => inspectorId = value;
        }

        [DisplayName("Location")]
        //[Browsable(false)]
        public string Location
        {
            get => location;
            set => location = value;
        }
        public string InspectorId { get; internal set; }

        public void SaveScanTime(string myData)
        {
            Properties.Settings.Default.ScanTime = myData;
            Properties.Settings.Default.Save();
        }

        public string LoadScanTime()
        {
            string scanTime = Properties.Settings.Default.ScanTime;
            return scanTime;
        }
    }
}

