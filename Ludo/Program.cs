
using LudoGameClasses;
using LudoGameEnums;
using LudoGameInterfaces;

/* Main Menu */
string titleGame = "    -----------------||   LUDO GAME   ||-----------------      ";
Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(titleGame);
Console.ResetColor();

Console.WriteLine("Main Menu : ");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("1. Start Game");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("2. Exit");
Console.ResetColor();

/* Handle user input in the menu */
bool isUserInputValidInMenu = false;
int userInput = 0;
while (!isUserInputValidInMenu)
{
    Console.Write("Enter your choice (1 or 2): ");
    string? userInputString = Console.ReadLine();

    if (int.TryParse(userInputString, out int userInputInt))
    {
        if (userInputInt == 1 || userInputInt == 2)
        {
            userInput = userInputInt;
            isUserInputValidInMenu = true;
        }
        else
        {
            printInvalidInputMessage("Please choice 1 or 2");
        }
    }
    else
    {
        printInvalidInputMessage("Your input not valid! try again");
    }

}

/* Handle user input for number of players */
bool isNumberOfPlayersValid = false;
int numberOfPlayers = 0;
if (userInput == 1)
{
    while (!isNumberOfPlayersValid)
    {
        Console.Write("Enter the number of players (2-4): ");
        string? numberOfPlayersString = Console.ReadLine();
        if (int.TryParse(numberOfPlayersString, out int numberOfPlayersInt))
        {
            if (numberOfPlayersInt > 1 && numberOfPlayersInt < 5)
            {
                numberOfPlayers = numberOfPlayersInt;
                isNumberOfPlayersValid = true;
            }
            else
            {
                printInvalidInputMessage("Please input between 2 and 4");
            }
        }
        else
        {
            printInvalidInputMessage("Your input not valid! try again");
        }
    }
}

/* Clear Console Content */
Console.Clear();

/* Setup Players */
Console.BackgroundColor = ConsoleColor.DarkBlue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(titleGame);
Console.ResetColor();
Console.WriteLine("Setup Players");

List<IPlayer> players = [];
List<ConsoleColor> consoleColors = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue];

for (int i = 0; i < numberOfPlayers; i++)
{
    bool isNameOfPlayerValid = false;
    while (!isNameOfPlayerValid)
    {
        Console.BackgroundColor = consoleColors[i];
        Console.Write($" ");
        Console.ResetColor();
        Console.Write($"Enter Player {i + 1}'s name: ");
        string? playerName = Console.ReadLine();
        if (!string.IsNullOrEmpty(playerName))
        {
            IPlayer player = new Player(playerName, (ColorState)i);
            players.Add(player);
            isNameOfPlayerValid = true;
        }
        else
        {
            printInvalidInputMessage("Please enter a valid player name.");
        }
    }
}

/* Show the list of all players */
Console.WriteLine();
Console.WriteLine("List of players:");

/*Explore using Chat GPT */
Console.WriteLine("{0,-5} {1,-15} {2,-10}", "No", "Name", "Color");
Console.WriteLine(new string('-', 35));
for (int i = 0; i < players.Count; i++)
{
    Console.Write("{0,-5} {1,-15}", $"{i + 1}.", players[i].Name);
    Console.BackgroundColor = consoleColors[i];
    Console.Write("{0,-10}", "  ");
    Console.ResetColor();
    Console.WriteLine();
}

/* Enter for continue */
Console.Write("\nPress enter to continue....");
Console.ReadLine();
Console.Clear();

/* Instantiate Game Model */

LudoModel ludoModel = new(players, new Board(), new Dice(), new GameController());
ludoModel.Start();

void printInvalidInputMessage(string message)
{
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($" {message} ");
    Console.ResetColor();
}

// using LudoGameClasses;
// using LudoGameEnums;
// using LudoGameInterfaces;

// LudoModel lm = new([new Player("windah", ColorState.RED), new Player("zeta", ColorState.GREEN)], new Board(), new Dice(), new GameController());

// IPlayer currentTurn = lm.gameController.FirstTurn(lm.players);
// lm.currentTurn = currentTurn;

// while (true)
// {
//     Console.WriteLine(lm.currentTurn.Name);
//     IPlayer nextTurn = lm.gameController.NextTurn(lm.currentTurn, lm.players);
//     lm.currentTurn = nextTurn;
//     Console.ReadLine();
//     Console.WriteLine(lm.currentTurn!.Name);
// }