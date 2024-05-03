using PrintGaransi.Model;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PrintGaransi._Repositories
{
    public class GaransiRepository
    {
        private readonly string connectionString;

        public GaransiRepository()
        {
            // Menggunakan koneksi dari konfigurasi
            this.connectionString = ConfigurationManager.ConnectionStrings["LSBUDBPRODUCTION"].ConnectionString;
        }

        public GaransiModel GetModelByModelCode(string modelCode)
        {
            GaransiModel model = null;
            MessageBox.Show("Repository");

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Global_Model_Code WHERE ModelCode = @ModelCode";
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = modelCode;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model = new GaransiModel();
                        model.NoReg = reader["Register"].ToString();
                        model.Model = reader["ModelNumber"].ToString();
                        Console.WriteLine("Value of variable: " + model.Model);
                    }
                }
            }

            return model;
        }
    }
}
