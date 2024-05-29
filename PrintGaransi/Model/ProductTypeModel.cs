using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintGaransi._Repositories;

namespace PrintGaransi.Model
{
    public class ProductTypeModel
    {
        private GaransiRepository _repository;

        public ProductTypeModel()
        {
            _repository = new GaransiRepository();
        }

        public List<string> GetProductTypeNames()
        {
            return _repository.JenisProduk();
        }

        public void SaveProductTypeName(string myData)
        {
            Properties.Settings.Default.ProductType = myData;
            Properties.Settings.Default.Save();
        }

        public string LoadProductType()
        {
            string productTypeName = Properties.Settings.Default.ProductType;
            return productTypeName;
        }
    }
}
