using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PrintGaransi.Model
{
    internal class NumberModelRepository : INumberModelRepository
    {
        private readonly string connectionString;

        public NumberModelRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["LSBUConnection"].ConnectionString;
        }

        public List<NumberModel> GetAllNumbers()
        {
            List<NumberModel> numbers = new List<NumberModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, partNumber, partCode FROM PartMotorWash"; // Sesuaikan dengan tabel di database
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        numbers.Add(new NumberModel
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            partNumber = reader["partNumber"].ToString(),
                            partCode = reader["partCode"].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return numbers;
        }
        public NumberModel GetNumber(string partCode)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, partNumber, partCode FROM PartMotorWash WHERE partCode = @partCode";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@partCode", partCode);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Jika ada data
                        {
                            return new NumberModel
                            {
                                id = Convert.ToInt32(reader["id"]),
                                partNumber = reader["partNumber"].ToString(),
                                partCode = reader["partCode"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return null; // Jika data tidak ditemukan
        }
    }
}
