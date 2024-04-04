using Microsoft.Data.Sqlite;

namespace CodingTracker.basemkasem;

internal class CodingController
{
    internal void CreatOperation()
    {
        using(var connection = new SqliteConnection(Program.connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"";
        }
    }
    internal void ReadOperation() 
    {
        
    }
    internal void UpdateOperation()
    {

    }
    internal void DeleteOperation() 
    { 

    }
}
