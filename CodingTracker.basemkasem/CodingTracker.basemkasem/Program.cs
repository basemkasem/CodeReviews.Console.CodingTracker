using CodingTracker.basemkasem;
using System.Configuration;

string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

DatabaseManeger databaseManeger = new();
databaseManeger.CreateDatabase(connectionString);