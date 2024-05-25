using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintGaransi.Model;

namespace PrintGaransi._Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string DBConnection;
        public LoginRepository()
        {
            DBConnection = ConfigurationManager.ConnectionStrings["LSBU"].ConnectionString;
        }

        public LoginModel GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(DBConnection))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT Nik, Name, Password FROM Users WHERE Nik = @NikId";
                command.Parameters.Add("@NikId", SqlDbType.Int).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nik = reader["Nik"].ToString();
                        string name = reader["Name"].ToString();
                        string password = reader["Password"].ToString();

                        return new LoginModel { Nik = nik, Name = name, Password = password };
                    }
                    else
                    {
                        return null; // Pengguna tidak ditemukan
                    }

                }
            }
        }
    }
}
