using Microsoft.Data.Sqlite;

namespace CodingTracker.basemkasem;

internal class DatabaseManeger
{
    internal void CreateDatabase(string connectionString)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText =
                    @"CREATE TABLE IF NOT EXISTS sessions (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date TEXT,
                        duration TEXT
                    )";

                command.ExecuteNonQuery();
            }
        }
    }

}
