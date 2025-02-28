using PrintGaransi.Model;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PrintGaransi._Repositories
{
    public class ModelNumberRepository : IModelNumberRepository
    {
        private readonly string DBConnection;

        public ModelNumberRepository()
        {
            DBConnection = ConfigurationManager.ConnectionStrings["LSBUConnection"].ConnectionString;
        }

        public List<GaransiModel> GetAllModelCodes()
        {
            List<GaransiModel> modelList = new List<GaransiModel>();
            string query = "SELECT ModelCodeId, Register, ModelNumber FROM GlobalModelCodes";

            using (SqlConnection connection = new SqlConnection(DBConnection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GaransiModel model = new GaransiModel
                        {
                            ModelCode = reader["ModelCodeId"].ToString(),
                            NoReg = reader["Register"].ToString(),
                            ModelNumber = reader["ModelNumber"].ToString()
                        };
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public bool InsertScanResult(string product, string scanResult, string? modelCodeId, string motorModelId, string result, DateTime dateTime, string inspector, string location)
        {
            try
            {
                string query = @"
            INSERT INTO Result_ScanMotorWash (product, scanResult, modelCodeId, motorModelId, result, dateTime, inspector, location)
            VALUES (@product, @scanResult, @modelCodeId, @motorModelId, @result, @dateTime, @inspector, @location)";

                using (SqlConnection connection = new SqlConnection(DBConnection))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Tambahkan parameter ke query
                    command.Parameters.AddWithValue("@product", product);
                    command.Parameters.AddWithValue("@scanResult", scanResult);
                    command.Parameters.AddWithValue("@modelCodeId", modelCodeId ?? (object)DBNull.Value); // Handle nullable string
                    command.Parameters.AddWithValue("@motorModelId", motorModelId);
                    command.Parameters.AddWithValue("@result", result);
                    command.Parameters.AddWithValue("@dateTime", dateTime);
                    command.Parameters.AddWithValue("@inspector", inspector);
                    command.Parameters.AddWithValue("@location", location);

                    // Buka koneksi
                    connection.Open();

                    // Eksekusi query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Jika ada baris yang terpengaruh, return true
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Log error atau tampilkan pesan error
                Console.WriteLine("Error inserting data: " + ex.Message);
                return false;
            }
        }
    }
}
