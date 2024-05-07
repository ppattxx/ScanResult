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

        public string jenisProduk;
        public string modelNumber;
        public string noReg;
        public string noSeri;
        public string modelCode;

        // Properties
        public string JenisProduk
        {
            get => jenisProduk;
            set => jenisProduk = value;
        }

        public string ModelNumber
        {
            get => modelNumber;
            set => modelNumber = value;
        }

        public string NoReg
        {
            get => noReg;
            set => noReg = value;
        }

        public string NoSeri
        {
            get => noSeri;
            set => noSeri = value;
        }
        public string ModelCode
        {
            get => modelCode;
            set => modelCode = value;
        }
    }
}

