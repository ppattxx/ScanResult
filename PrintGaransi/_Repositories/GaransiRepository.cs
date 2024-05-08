using PrintGaransi.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PrintGaransi._Repositories
{
    public class GaransiRepository : BaseRepository, IGaransiRepository
    {

        public GaransiRepository(string connetionString)
        {
            // Menggunakan koneksi dari konfigurasi
            this.connectionString = connetionString;
        }

        public GaransiModel GetByModelCode(GaransiModel model)
        {
            GaransiModel result = null;
            string query = "SELECT * FROM Global_Model_Codes WHERE ModelCode = @ModelCode";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                // Menggunakan properti yang sesuai dari objek GaransiModel
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = model.ModelCode;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new GaransiModel();
                        result.NoReg = reader["Register"].ToString();
                        result.ModelNumber = reader["ModelNumber"].ToString();
                        Console.WriteLine("Value of variable: " + result.ModelNumber);
                    }
                }
            }

            return result;
        }

        public IEnumerable<GaransiModel> GetData(string model)
        {
            throw new NotImplementedException();
        }
    }
}