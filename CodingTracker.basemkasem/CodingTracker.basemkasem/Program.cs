using CodingTracker.basemkasem;
using System.Configuration;

internal class Program
{
    public static string? connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
    private static void Main(string[] args)
    {
        DatabaseManeger databaseManeger = new();
        databaseManeger.CreateDatabase(connectionString!);

        UserInput userInput = new();
        userInput.MainMenu();
    }
}