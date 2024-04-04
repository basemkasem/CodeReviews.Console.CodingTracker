namespace CodingTracker.basemkasem;

internal class UserInput
{
    internal void MainMenu()
    {
        CodingController codingController = new();
        bool closeApp = false;

        while (!closeApp)
        {
            Console.WriteLine("\t=============");
            Console.WriteLine("\t  Main Menu");
            Console.WriteLine("\t=============");
            Console.WriteLine("\nChoose an option from the list: ");
            Console.WriteLine("0. Close the application.");
            Console.WriteLine("1. View a record.");
            Console.WriteLine("2. Add a record.");
            Console.WriteLine("3. Update a record.");
            Console.WriteLine("4. Delete a record.");

            Console.Write("\nPlease Enter the number of your choice: ");
            string? readInput = Console.ReadLine();
            while (string.IsNullOrEmpty(readInput)) 
            {
                Console.Write("\nPlease Enter a valid number: ");
                readInput = Console.ReadLine();
            }
            readInput = readInput.Trim();

            switch(readInput)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    codingController.ReadOperation();
                    break;
                case "2":
                    codingController.CreatOperation();
                    break;
                case "3":
                    codingController.UpdateOperation();
                    break;
                case "4":
                    codingController.DeleteOperation();
                    break;
                default:
                    Console.WriteLine("\nYou entered a wrong value. Please try again.");
                    break;
            }
        }
    }

    internal void GetDateInput() { }
    internal void GetDurationInput() { }
}
