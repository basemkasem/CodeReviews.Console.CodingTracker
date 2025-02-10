using System.Configuration;
using System.Collections.Specialized;
using Spectre.Console;
using CodingTracker;

DatabaseHelper.CreateTable();

AnsiConsole.Markup("Welcome to [green]coding tracker[/] application.\n");

while(true)
{
    var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
                .Title("What would you like to do?")
                .AddChoices(Enum.GetValues<MenuOptions>())
        );

    switch (option)
    {
        case MenuOptions.AddSession:
            SessionController.AddSession();
            break;
        case MenuOptions.ShowSessions:
            SessionController.ShowSessions();
            break;
        case MenuOptions.UpdateSession:
            SessionController.UpdateSession();
            break;
        case MenuOptions.DeleteSession:
            SessionController.DeleteSession();
            break;
        case MenuOptions.Exit:
            Environment.Exit(0);
            break;
    }
    Console.ReadKey();
    Console.Clear();
}