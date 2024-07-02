using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintGaransi.Model
{
    public interface IGaransiRepository
    {
        void Add(dynamic model);
        IEnumerable<GaransiModel> GetData(string model);
        IEnumerable<GaransiModel> GetAll(string location);
        IEnumerable<GaransiModel> GetFilter(string globalCodeId, DateTime selectDate, string location);
        IEnumerable<GaransiModel> GetExists(string noSeri, string modelCode);
        List<string> JenisProduk();
    }
}
