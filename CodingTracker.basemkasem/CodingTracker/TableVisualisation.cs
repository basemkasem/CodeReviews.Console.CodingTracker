using System.Globalization;
using Spectre.Console;

namespace CodingTracker;

internal class TableVisualisation
{
    public static void ShowTable()
    {
        var table = new Table();
        var sessions = DatabaseHelper.TableList();

        if (sessions.Count == 0)
        {
            AnsiConsole.Markup("[red]No records found. You need to add a session first.[/]\n");
            return;
        }

        table.AddColumn("ID");
        table.AddColumn("Start Time");
        table.AddColumn("End Time");
        table.AddColumn("Duration");

        foreach (var session in sessions)
        {
            table.AddRow(session.Id.ToString(), session.StartTime.ToString(CultureInfo.GetCultureInfo("fr-FR")), session.EndTime.ToString(CultureInfo.GetCultureInfo("fr-FR")), TimeSpan.FromSeconds(session.Duration).ToString());
        }
        AnsiConsole.Write(table);
    }
}
