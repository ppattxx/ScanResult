using PrintGaransi.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrintGaransi._Repositories
{
    public class GaransiRepository : IGaransiRepository
    {
        private string LSBUDBPRODUCTION;
        public GaransiRepository()
        {
            LSBUDBPRODUCTION = ConfigurationManager.ConnectionStrings["LSBUDBPRODUCTION"].ConnectionString;
        }

        public IEnumerable<GaransiModel> GetData(string model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GaransiModel> GetAll()
        {
            List<GaransiModel> models = new List<GaransiModel>();
            string query = "SELECT * FROM Results";

            using (SqlConnection connection = new SqlConnection(LSBUDBPRODUCTION))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        models.Add(new GaransiModel
                        {
                            Id = reader["Id"].ToString(),
                            JenisProduk = reader["JenisProduk"].ToString(),
                            ModelCode = reader["ModelCode"].ToString(),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            NoSeri = reader["SerialNumber"].ToString(),
                            NoReg = reader["Register"].ToString(),
                            Date = reader["ScanningDate"].ToString(),
                            ScanTime = reader["ScanningTime"].ToString(),
                            Different = reader["Different"].ToString(),
                            ActualTT = reader["ActualTT"].ToString(),
                            Location = reader["Location"].ToString()
                        });
                    }
                }
            }
            return models;
        }

        public IEnumerable<GaransiModel> GetFilter(string serialNumber)
        {
            List<GaransiModel> results = new List<GaransiModel>();
            string query = "SELECT * FROM Results WHERE SerialNumber = @SerialNumber";

            using (SqlConnection connection = new SqlConnection(LSBUDBPRODUCTION))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = serialNumber;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var result = new GaransiModel
                        {
                            Id = reader["Id"].ToString(),
                            JenisProduk = reader["JenisProduk"].ToString(),
                            ModelCode = reader["ModelCode"].ToString(),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            NoSeri = reader["SerialNumber"].ToString(),
                            NoReg = reader["Register"].ToString(),
                            Date = reader["ScanningDate"].ToString(),
                            ScanTime = reader["ScanningTime"].ToString(),
                            Different = reader["Different"].ToString(),
                            ActualTT = reader["ActualTT"].ToString(),
                            Location = reader["Location"].ToString()
                        };
                        results.Add(result);
                    }
                }
            }

            return results;
        }

        public void Add(dynamic model)
        {
            using (var connection = new SqlConnection(LSBUDBPRODUCTION))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "INSERT INTO Results (JenisProduk, ModelCode, ModelNumber, SerialNumber, ScanningDate, ScanningTime, Different, ActualTT, Location, Register) values (@JenisProduk, M@odelCode, @ModelNumber, @SerialNumber, @ScanningDate, @ScanningTime, @Different, @ActualTT, @Location, @Register)";
                command.Parameters.Add("@JenisProduk", SqlDbType.VarChar).Value = model.JenisProduk;
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = model.ModelCode;
                command.Parameters.Add("@ModelNumber", SqlDbType.VarChar).Value = model.ModelNumber;
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = model.SerialNumber;
                command.Parameters.Add("@ScanningDate", SqlDbType.Date).Value = model.ScanningDate;
                command.Parameters.Add("@ScanningDate", SqlDbType.Time).Value = model.ScanningDate;
                command.Parameters.Add("@Different", SqlDbType.Time).Value = model.Different;
                command.Parameters.Add("@ActualTT", SqlDbType.Decimal).Value = model.ActualTT;
                command.Parameters.Add("@Location", SqlDbType.Int).Value = model.Location;
                command.Parameters.Add("@Register", SqlDbType.VarChar).Value = model.Register;
                command.ExecuteNonQuery();
            }
        }
    }
}
