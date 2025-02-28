using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

public interface IResultRepository
{
    void Add(dynamic model);
    List<ResultModel> GetAll();
}

public class ResultRepository : IResultRepository
{
    private readonly string LSBUConnection;

    public ResultRepository()
    {
        var connString = ConfigurationManager.ConnectionStrings["LSBUConnection"];
        if (connString == null)
        {
            throw new InvalidOperationException("Connection string 'LSBUConnection' tidak ditemukan di konfigurasi.");
        }

        LSBUConnection = connString.ConnectionString; // Simpan nilai dengan benar
    }

    public ResultRepository(string connectionString)
    {
        LSBUConnection = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public void Add(dynamic model)
    {
        using (var connection = new SqlConnection(LSBUConnection))
        using (var command = new SqlCommand())
        {
            connection.Open();
            command.Connection = connection;

            command.CommandText = "INSERT INTO Result_ScanMotorWash (product, scanResult, modelCodeId, motorModelId, result, dateTime, inspector, location) " +
                                  "VALUES (@product, @scanResult, @modelCodeId, @motorModelId, @result, @dateTime, @inspector, @location)";

            command.Parameters.Add("@product", SqlDbType.VarChar).Value = model.JenisProduk;
            command.Parameters.Add("@scanResult", SqlDbType.VarChar).Value = model.NoPart;
            command.Parameters.Add("@modelCodeId", SqlDbType.VarChar).Value = model.ModelCode;
            command.Parameters.Add("@motorModelId", SqlDbType.VarChar).Value = model.ModelNumber;
            command.Parameters.Add("@result", SqlDbType.VarChar).Value = model.ScanResult;
            command.Parameters.Add("@dateTime", SqlDbType.DateTime).Value = model.Date;
            command.Parameters.Add("@inspector", SqlDbType.VarChar).Value = model.InspectorId;
            command.Parameters.Add("@location", SqlDbType.VarChar).Value = model.Location;

            command.ExecuteNonQuery();
        }
    }

    public List<ResultModel> GetAll()
    {
        List<ResultModel> results = new List<ResultModel>();

        using (var connection = new SqlConnection(LSBUConnection))
        using (var command = new SqlCommand("SELECT id, product, scanResult, modelCodeId, motorModelId, result, dateTime, inspector, location FROM Result_ScanMotorWash", connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime dateTime = Convert.ToDateTime(reader["dateTime"]); // Ambil DateTime utuh

                    results.Add(new ResultModel
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        JenisProduk = reader["product"].ToString(),
                        PartCode = reader["scanResult"].ToString(),
                        PartCodeId = reader["modelCodeId"].ToString(),
                        ModelNumber = reader["motorModelId"].ToString(),
                        ScanResult = reader["result"].ToString(),
                        Date = dateTime,
                        InspectorId = reader["inspector"].ToString(),
                        Location = reader["location"].ToString(),
                    });
                }
            }
        }

        return results;
    }

    public void SaveAll(List<ResultModel> results)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LSBUConnection"].ConnectionString))
        {
            conn.Open();

            foreach (var result in results)
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE ResultsTable SET JenisProduk = @JenisProduk, NoPart = @NoPart, ModelCode = @ModelCode, ModelNumber = @ModelNumber, ScanResult = @ScanResult, Date = @Date, InspectorId = @InspectorId, Location = @Location WHERE ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@JenisProduk", result.JenisProduk);
                    cmd.Parameters.AddWithValue("@PartCode", result.PartCode);
                    cmd.Parameters.AddWithValue("@PartCodeId", result.PartCodeId);
                    cmd.Parameters.AddWithValue("@ModelNumber", result.ModelNumber);
                    cmd.Parameters.AddWithValue("@ScanResult", result.ScanResult);
                    cmd.Parameters.AddWithValue("@Date", result.Date);
                    cmd.Parameters.AddWithValue("@InspectorId", result.InspectorId);
                    cmd.Parameters.AddWithValue("@Location", result.Location);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }


}

public class ResultModel
{
    public int Id { get; set; } // Menambahkan ID untuk menyimpan nilai dari database
    public string JenisProduk { get; set; }
    public string PartCode { get; set; }
    public string PartCodeId { get; set; }
    public string ModelNumber { get; set; }
    public string ScanResult { get; set; }
    public DateTime Date { get; set; }
    public string ScanDate => Date.ToString("yyyy-MM-dd");
    public string ScanTime => Date.ToString("HH:mm:ss");
    public string InspectorId { get; set; }
    public string Location { get; set; }
}

