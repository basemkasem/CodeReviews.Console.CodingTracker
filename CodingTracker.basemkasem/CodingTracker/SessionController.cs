using Dapper;
using Spectre.Console;

namespace CodingTracker;

internal class SessionController
{

    private static DateTime PromptForTime(string promptMessage)
    {
        DateTime time = new DateTime();
        AnsiConsole.Prompt(
            new TextPrompt<string>(promptMessage).Validate(t =>
            {
                if (t.ValidateTime().Check)
                {
                    time = t.ValidateTime().Value;
                    return ValidationResult.Success();
                }
                else
                {
                    return ValidationResult.Error("Invalid time format.");
                }
            })
        );
        return time;
    }

    public static CodingSession GetRecord(int recordId)
    {
        var sql = "SELECT * FROM CodingSessions WHERE Id = @id;";
        var codingSession = DatabaseHelper.Connection.Query<CodingSession>(sql, new { id = recordId }).First();
        return codingSession;
    }

    public static void AddSession()
    {
        AnsiConsole.Markup("[bold]Add a new coding session[/]\n" +
            "[yellow]Make sure to right time in this format (dd/MM/yyyy hh:mm)[/]\n");
        DateTime startTime = PromptForTime("Enter start time: ");
        DateTime endTime = PromptForTime("Enter end time: ");
        while (endTime < startTime)
        {
            AnsiConsole.Markup("[red]End time cannot be earlier than start time. Please enter a valid end time.[/]\n");
            endTime = PromptForTime("Enter end time (hh:MM): ");
        }
        var session = new CodingSession(startTime, endTime);

        var sql = "INSERT INTO CodingSessions (StartTime, EndTime, Duration) VALUES (@startTime, @endTime, @duration);";
        DatabaseHelper.Connection.Execute(sql, new { startTime = startTime.ToString(), endTime = endTime.ToString(), duration = session.Duration });
        AnsiConsole.Markup("[green]Record is Added successfully.[/]\nPress any key to continue...");
    }

    private static void UpdateStartTime(int recordId)
    {
        CodingSession session = GetRecord(recordId);
        AnsiConsole.Markup($"[bold]Update start time from {session.StartTime}[/]\n[yellow]" +
            "Make sure to right time in this format (dd/MM/yyyy hh:mm)[/]\n");
        DateTime newStartTime = PromptForTime("Enter start time: ");
        while (newStartTime > session.StartTime)
        {
            AnsiConsole.Markup("[red]Start time cannot be later than end time. Please enter a valid end time.[/]\n");
            newStartTime = PromptForTime("Enter start time (dd/MM/yyyy hh:mm): ");
        }
        
        session.StartTime = newStartTime;

        var sql = @"UPDATE CodingSessions 
                    SET StartTime = @startTime, Duration = @duration
                    WHERE Id = @id;";

        DatabaseHelper.Connection.Execute(sql, new { startTime = newStartTime.ToString(), id = recordId, duration = session.Duration });
    }

    private static void UpdateEndTime(int recordId)
    {
        CodingSession session = GetRecord(recordId);
        AnsiConsole.Markup($"[bold]Update end time from {session.EndTime}[/]\n[yellow]" +
            "Make sure to right time in this format (dd/MM/yyyy hh:mm)[/]\n");
        DateTime newEndTime = PromptForTime("Enter end time: ");
        
        while (newEndTime < session.EndTime)
        {
            AnsiConsole.Markup("[red]End time cannot be earlier than start time. Please enter a valid end time.[/]\n");
            newEndTime = PromptForTime("Enter end time (dd/MM/yyyy hh:mm): ");
        }
        session.EndTime = newEndTime;

        var sql = @"UPDATE CodingSessions 
                    SET EndTime = @endTime, Duration = @duration
                    WHERE Id = @id";
        DatabaseHelper.Connection.Execute(sql, new { endTime = newEndTime.ToString(), id = recordId, duration = session.Duration });
    }

    public static void ShowSessions()
    {
        TableVisualisation.ShowTable();
        AnsiConsole.Markup("Press [green]any key[/] to continue...");
    }
    public static void UpdateSession()
    {
        var sessionsList = DatabaseHelper.TableList();
        if (sessionsList.Count == 0)
        {
            AnsiConsole.Markup("[red]No records found. You need to add a session first.[/]\nPress any key to continue...");
            return;
        }
        var updateRecord = AnsiConsole.Prompt(new SelectionPrompt<CodingSession>()
        .Title("Which record will you update?")
        .AddChoices(DatabaseHelper.TableList())
        );

        var updateOptionInput = AnsiConsole.Prompt(
            new SelectionPrompt<UpdateOptions>()
                .Title("What would you like to do?")
                .AddChoices(Enum.GetValues<UpdateOptions>())
        );

        switch (updateOptionInput)
        {
            case UpdateOptions.UpdateStartTime:
                UpdateStartTime(updateRecord.Id);
                break;
            case UpdateOptions.UpdateEndTime:
                UpdateEndTime(updateRecord.Id);
                break;
        }
        AnsiConsole.Markup("[green]Record is updated successfully.[/]\nPress any key to continue...");
    }

    public static void DeleteSession()
    {
        var sessionsList = DatabaseHelper.TableList();
        if (sessionsList.Count == 0)
        {
            AnsiConsole.Markup("[red]No records found. You need to add a session first.[/]\nPress any key to continue...");
            return;
        }

        var updateOptionInput = AnsiConsole.Prompt(
            new SelectionPrompt<DeleteOptions>()
            .Title("What would you like to do?")
        .AddChoices(Enum.GetValues<DeleteOptions>())
        );

        switch (updateOptionInput)
        {
            case DeleteOptions.DeleteRecord:
                var deleteRecord = AnsiConsole.Prompt(
                    new SelectionPrompt<CodingSession>()
                    .Title("Which record will you delete?")
                    .AddChoices(sessionsList)
                    );
                var sql = @"DELETE FROM CodingSessions 
                            WHERE Id = @id";
                DatabaseHelper.Connection.Execute(sql, new { id = deleteRecord.Id });
                AnsiConsole.Markup("[green]Record is deleted successfully.[/]\nPress any key to continue...");
                break;

            case DeleteOptions.DeleteAll:
                var sqlDeleteAll = "DELETE FROM CodingSessions;";
                DatabaseHelper.Connection.Execute(sqlDeleteAll);
                AnsiConsole.Markup("[green]All record are deleted successfully.[/]\nPress any key to continue...");
                break;
        }
    }
}
