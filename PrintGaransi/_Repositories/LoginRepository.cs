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
        private readonly string DBConnectionLogin;
        public LoginRepository()
        {
            DBConnectionLogin = ConfigurationManager.ConnectionStrings["DBConnectionLogin"].ConnectionString;
        }

        public LoginModel GetUserByUsername(string username)
        {
            using (var connection = new SqlConnection(DBConnectionLogin))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT PasswordHash, NIK, Name FROM AspNetUsers WHERE NIK = @NIK";
                command.Parameters.Add("@NIK", SqlDbType.Int).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string Nik = reader["NIK"].ToString();
                        string Name = reader["Name"].ToString();
                        string Password = reader["PasswordHash"].ToString();

                        return new LoginModel { Nik = Nik, Name = Name, Password = Password };
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
