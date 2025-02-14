using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker;

internal class DatabaseHelper
{
    public static SqliteConnection Connection
    {
        get
        {
            string? connectionString = GetConnectionString();
            return new SqliteConnection(connectionString);
        }
    }

    public static string GetConnectionString()
    {
        string? connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Error: Connection string is not configured.");
        }
        return connectionString;
    }

    public static void CreateTable()
    {
        string? connectionString = GetConnectionString();
        using (var connection = new SqliteConnection(connectionString))
        {
            SQLitePCL.Batteries.Init();

            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS CodingSessions
                (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                StartTime TEXT,
                EndTime TEXT,
                Duration INTEGER)";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }
    }

    public static List<CodingSession> TableList()
    {
        var sql = "SELECT * FROM CodingSessions;";
        List<CodingSession> sessions = Connection.Query<CodingSession>(sql).ToList();
        return sessions;
    }
}
