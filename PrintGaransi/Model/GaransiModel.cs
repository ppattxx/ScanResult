using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.Model
{
    public class GaransiModel
    {
        public string JenisProduk { get; set; }
        public string Model { get; set; }
        public string NoReg { get; set; }
        public string NoSeri { get; set; }

        public GaransiModel(string jenisProduk, string model, string noReg, string noSeri)
        {
            JenisProduk = jenisProduk;
            Model = model;
            NoReg = noReg;
            NoSeri = noSeri;
        }
    }
}
