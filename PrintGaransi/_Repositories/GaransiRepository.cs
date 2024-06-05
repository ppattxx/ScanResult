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
            LSBUDBPRODUCTION = ConfigurationManager.ConnectionStrings["LSBUProduction"].ConnectionString;
        }

        public IEnumerable<GaransiModel> GetData(string model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GaransiModel> GetAll()
        {
            List<GaransiModel> models = new List<GaransiModel>();
            string query = "SELECT * FROM Result_Warranty_Cards WHERE CONVERT(DATE, ScanningDate) = CONVERT(DATE, GETDATE()) ORDER BY Id DESC;";

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
                            Date = Convert.ToDateTime(reader["ScanningDate"]).ToString("yyyy-MM-dd"),
                            ScanTime = reader["ScanningTime"].ToString(),
                            Different = reader["Different"].ToString(),
                            ActualTT = reader["ActualTT"] != DBNull.Value ? Convert.ToDecimal(reader["ActualTT"]) : 0m,
                            Location = reader["Location"].ToString()
                        });
                    }
                }
            }
            return models;
        }


        public IEnumerable<GaransiModel> GetFilter(string serialNumber, DateTime selectedDate)
        {
            List<GaransiModel> results = new List<GaransiModel>();
            string query = "SELECT * FROM Result_Warranty_Cards WHERE SerialNumber LIKE @SerialNumber AND CAST(ScanningDate AS DATE) = @SelectedDate";

            using (SqlConnection connection = new SqlConnection(LSBUDBPRODUCTION))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = "%" + serialNumber;
                command.Parameters.Add("@SelectedDate", SqlDbType.Date).Value = selectedDate.Date;

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
                            Date = Convert.ToDateTime(reader["ScanningDate"]).ToString("yyyy-MM-dd"),
                            ScanTime = reader["ScanningTime"].ToString(),
                            Different = reader["Different"].ToString(),
                            ActualTT = reader["ActualTT"] != DBNull.Value ? Convert.ToDecimal(reader["ActualTT"]) : 0m,
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

                command.CommandText = "INSERT INTO Result_Warranty_Cards (JenisProduk, ModelCode, ModelNumber, SerialNumber, ScanningDate, ScanningTime, Different, ActualTT, Location, Register) values (@JenisProduk, @ModelCode, @ModelNumber, @SerialNumber, @ScanningDate, @ScanningTime, @Different, @ActualTT, @Location, @Register)";
                command.Parameters.Add("@JenisProduk", SqlDbType.VarChar).Value = model.JenisProduk;
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = model.ModelCode;
                command.Parameters.Add("@ModelNumber", SqlDbType.VarChar).Value = model.ModelNumber;
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = model.NoSeri;
                command.Parameters.Add("@ScanningDate", SqlDbType.Date).Value = model.Date;
                command.Parameters.Add("@ScanningTime", SqlDbType.Time).Value = model.ScanTime;
                command.Parameters.Add("@Different", SqlDbType.Time).Value = model.Different;
                command.Parameters.Add("@ActualTT", SqlDbType.Decimal).Value = model.ActualTT;
                command.Parameters.Add("@Location", SqlDbType.Int).Value = model.Location;
                command.Parameters.Add("@Register", SqlDbType.VarChar).Value = model.NoReg;
                command.ExecuteNonQuery();
            }
        }

        public List<string> JenisProduk()
        {
            List<string> dataList = new List<string>();

            using (SqlConnection connection = new SqlConnection(LSBUDBPRODUCTION))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM ProductType";
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataList.Add(reader["ProductName"].ToString());
                    }

                    reader.Close();
                }
            }
            return dataList;
        }

        public bool Exists(string noSeri, string modelCode)
        {
            using (SqlConnection connection = new SqlConnection(LSBUDBPRODUCTION))
            {
                string query = "SELECT COUNT(*) FROM Result_Warranty_Cards WHERE SerialNumber = @NoSeri AND ModelCode = @ModelCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NoSeri", noSeri);
                    command.Parameters.AddWithValue("@ModelCode", modelCode);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
