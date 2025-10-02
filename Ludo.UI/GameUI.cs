namespace Ludo.UI;

public class GameUI
{
    private readonly ConsoleColor[] _consoleColors = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue];
    public GameUI()
    {

    }

    private void ClearConsole()
    {
        Console.Clear();
    }

    private void DisplayMainMenu()
    {
        ClearConsole();
        string titleGame = "    -----------------||   LUDO GAME   ||-----------------      ";
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine(titleGame);
        Console.ResetColor();

        Console.WriteLine("Main Menu : ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Start Game");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("2. Exit");
        Console.ResetColor();
    }

    private void printInvalidInputMessage(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" {message} ");
        Console.ResetColor();
    }

    private int GetMenuSelection()
    {
        while (true)
        {
            Console.Write("Enter your choice (1 or 2): ");
            string? userInputString = Console.ReadLine();
            if (int.TryParse(userInputString, out int userInputInt) && (userInputInt == 1 || userInputInt == 1))
            {
                return userInputInt;
            }
            printInvalidInputMessage("Please choice 1 or 2");
        }
    }

    private int GetNumberOfPlayer()
    {
        while (true)
        {
            Console.Write("Enter the number of players (2-4): ");
            string? numberOfPlayersString = Console.ReadLine();
            if (int.TryParse(numberOfPlayersString, out int numberOfPlayersInt) && numberOfPlayersInt >= 2 && numberOfPlayersInt <= 4)
            {
                return numberOfPlayersInt;
            }
            printInvalidInputMessage("Please input between 2 and 4");

        }
    }

    private List<int> CreatePlayer(int count)
    {
        List<int> players = [];
        return players;
    }
}