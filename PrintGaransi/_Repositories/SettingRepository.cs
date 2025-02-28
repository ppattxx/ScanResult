using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using static PrintGaransi._Repositories.SettingRepository;
using PrintGaransi.Model;

namespace PrintGaransi._Repositories
{
    public class SettingRepository
    {
        private string DbConnectionCommon;
        private int locationId;
        public SettingRepository()
        {
            DbConnectionCommon = ConfigurationManager.ConnectionStrings["LSBUConnection"].ConnectionString;
        }

        public List<string> GetData()
        {
            List<string> dataList = new List<string>();

            using (SqlConnection connection = new SqlConnection(DbConnectionCommon))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Locations";
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataList.Add(reader["LocationName"].ToString());
                    }

                    reader.Close();
                }
            }
            return dataList;
        }

        public int GetID(string locationName)
        {

            using (SqlConnection connection = new SqlConnection(DbConnectionCommon))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Id FROM Locations WHERE LocationName = @LocationName";
                    command.Parameters.AddWithValue("@LocationName", locationName);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        locationId = Convert.ToInt32(reader["Id"]);
                    }

                    reader.Close();
                }
            }
            return locationId;
        }
    }
}
