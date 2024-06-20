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

            string query = "SELECT Result_Warranty_Cards.Id, Result_Warranty_Cards.JenisProduk, Result_Warranty_Cards.ModelCode, Result_Warranty_Cards.ModelNumber, Result_Warranty_Cards.SerialNumber, Result_Warranty_Cards.Register, Result_Warranty_Cards.ScanningDate, Result_Warranty_Cards.ScanningTime, Locations.LocationName AS Location, AspNetUsers.Name AS InspectorId " +
                "FROM Result_Warranty_Cards " +
                "INNER JOIN LSBU_Auth.dbo.AspNetUsers ON Result_Warranty_Cards.InspectorId = AspNetUsers.NIK " +
                "INNER JOIN LSBU_Common.dbo.Locations ON Result_Warranty_Cards.Location = Locations.Id " +
                "WHERE CONVERT(DATE, ScanningDate) = @date ORDER BY Id DESC;";

            using (SqlConnection connection = new SqlConnection(LSBUDBPRODUCTION))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@date", Convert.ToDateTime(DateTime.Today).Date);
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
                            Location = reader["Location"].ToString(),
                            Inspector = reader["InspectorId"].ToString()
                        });
                    }
                }
                connection.Close();
            }
            return models;
        }


        public IEnumerable<GaransiModel> GetFilter(string serialNumber, DateTime selectedDate)
        {
            List<GaransiModel> results = new List<GaransiModel>();
            string query = "SELECT Result_Warranty_Cards.Id, Result_Warranty_Cards.JenisProduk, Result_Warranty_Cards.ModelCode, Result_Warranty_Cards.ModelNumber, Result_Warranty_Cards.SerialNumber, Result_Warranty_Cards.Register, Result_Warranty_Cards.ScanningDate, Result_Warranty_Cards.ScanningTime, Locations.LocationName AS Location, AspNetUsers.Name AS InspectorId " +
                "FROM Result_Warranty_Cards " +
                "INNER JOIN LSBU_Auth.dbo.AspNetUsers ON Result_Warranty_Cards.InspectorId = AspNetUsers.NIK " +
                "INNER JOIN LSBU_Common.dbo.Locations ON Result_Warranty_Cards.Location = Locations.Id " +
                "WHERE SerialNumber LIKE @SerialNumber AND CAST(ScanningDate AS DATE) = @SelectedDate ";

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
                            Location = reader["Location"].ToString(),
                            Inspector = reader["InspectorId"].ToString()
                        };
                        results.Add(result);
                    }
                }
                connection.Close();
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

                command.CommandText = "INSERT INTO Result_Warranty_Cards (JenisProduk, ModelCode, ModelNumber, SerialNumber, ScanningDate, ScanningTime, Location, Register, InspectorId) values (@JenisProduk, @ModelCode, @ModelNumber, @SerialNumber, @ScanningDate, @ScanningTime, @Location, @Register, @InspectorId)";
                command.Parameters.Add("@JenisProduk", SqlDbType.VarChar).Value = model.JenisProduk;
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = model.ModelCode;
                command.Parameters.Add("@ModelNumber", SqlDbType.VarChar).Value = model.ModelNumber;
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = model.NoSeri;
                command.Parameters.Add("@ScanningDate", SqlDbType.Date).Value = model.Date;
                command.Parameters.Add("@ScanningTime", SqlDbType.Time).Value = model.ScanTime;
                command.Parameters.Add("@Location", SqlDbType.Int).Value = model.Location;
                command.Parameters.Add("@Register", SqlDbType.VarChar).Value = model.NoReg;
                command.Parameters.Add("@InspectorId", SqlDbType.VarChar).Value = model.inspectorId;
                command.ExecuteNonQuery();

                connection.Close();
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
                connection.Close();
            }
            return dataList;
        }

        public IEnumerable<GaransiModel> GetExists(string noSeri, string modelCode)
        {
            List<GaransiModel> results = new List<GaransiModel>();
            string query = "SELECT * FROM Result_Warranty_Cards WHERE SerialNumber = @SerialNumber AND ModelCode = @ModelCode";

            using (SqlConnection connection = new SqlConnection(LSBUDBPRODUCTION))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.Add("@SerialNumber", SqlDbType.VarChar).Value = noSeri;
                command.Parameters.Add("@ModelCode", SqlDbType.VarChar).Value = modelCode;

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
                            Location = reader["Location"].ToString()
                        };
                        results.Add(result);
                    }
                }
                connection.Close();
            }

            return results;
        }
    }
}
