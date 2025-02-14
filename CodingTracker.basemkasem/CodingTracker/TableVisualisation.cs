using Spectre.Console;

namespace CodingTracker;

internal class TableVisualisation
{
    public static void ShowTable()
    {
        var table = new Table();
        var sessions = DatabaseHelper.TableList();

        table.AddColumn("ID");
        table.AddColumn("Start Time");
        table.AddColumn("End Time");
        table.AddColumn("Duration");

        foreach (var session in sessions)
        {
            table.AddRow(session.Id.ToString(), session.StartTime.ToString(), session.EndTime.ToString(), TimeSpan.FromSeconds(session.Duration).ToString());
        }
        AnsiConsole.Write(table);
    }
}
