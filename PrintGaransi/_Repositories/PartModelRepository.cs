using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PrintGaransi.Model;

namespace PrintGaransi._Repositories
{
    internal class PartModelRepository
    {
        private readonly string _connectionString;

        public PartModelRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["LSBUConnection"].ConnectionString;
        }

        public PartModel GetPartNumbersByModelCodeId(string modelCodeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                Console.WriteLine("Mencari modelCodeId: " + modelCodeId); // Debugging

                string query = "SELECT partNumberId FROM ScanParts WHERE modelCodeId = @ModelCodeId";
                var result = connection.Query<PartModel>(query, new { ModelCodeId = modelCodeId }).FirstOrDefault();

                if (result == null)
                {
                    Console.WriteLine("Tidak ada data ditemukan untuk modelCodeId: " + modelCodeId);
                }
                else
                {
                    Console.WriteLine("Data ditemukan: " + result.partNumberId);
                }

                return result;
            }
        }

    }
}
