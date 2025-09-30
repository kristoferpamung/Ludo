
// using LudoGameClasses;
// using LudoGameEnums;
// using LudoGameInterfaces;

// string titleGame = "    -----------------||   LUDO GAME   ||-----------------      ";
// Console.BackgroundColor = ConsoleColor.Blue;
// Console.WriteLine(titleGame);
// Console.ResetColor();

// Console.WriteLine("Main Menu : ");
// Console.ForegroundColor = ConsoleColor.Green;
// Console.WriteLine("1. Start Game");
// Console.ForegroundColor = ConsoleColor.Red;
// Console.WriteLine("2. Exit");
// Console.ResetColor();
// Console.Write("Enter your choice (1 or 2): ");
// string? userInputString = Console.ReadLine();

// /* Players */
// List<IPlayer> players = [];
// if (int.TryParse(userInputString, out int userInput))
// {
//     if (userInput == 1)
//     {
//         Console.Write("Enter the number of players (2-4): ");
//         string? numberOfPlayerString = Console.ReadLine();
//         if (int.TryParse(numberOfPlayerString, out int numberOfPlayer))
//         {
//             if (numberOfPlayer > 1 && numberOfPlayer < 5)
//             {
//                 for (int i = 0; i < numberOfPlayer; i++)
//                 {
//                     Console.Write($"Enter Player {i + 1}'s name: ");
//                     string? name = Console.ReadLine();
//                     if (name != null)
//                     {
//                         Player player = new(name, (ColorState)i);
//                         players.Add(player);
//                     }
//                 }
//             }
//             else
//             {
//                 Console.WriteLine("Only enter 2 to 4");
//             }
//         }
//         else
//         {
//             Console.WriteLine("Input not valid!");
//         }
//     }
//     else if (userInput == 2)
//     {
//         Console.WriteLine("Bye-bye...");
//         return;
//     }
//     else
//     {
//         Console.WriteLine("Only enter 1 or 2");
//     }
// }
// else
// {
//     Console.WriteLine("Input not valid!");
// }

// LudoModel game = new(players, new Board(), new Dice(), new GameController());
// game.Start();

using LudoGameClasses;
using LudoGameEnums;
using LudoGameInterfaces;

LudoModel lm = new([new Player("windah", ColorState.RED), new Player("zeta", ColorState.GREEN)], new Board(), new Dice(), new GameController());

IPlayer currentTurn = lm.gameController.FirstTurn(lm.players);
lm.currentTurn = currentTurn;

while (true)
{
    Console.WriteLine(lm.currentTurn.Name);
    IPlayer nextTurn = lm.gameController.NextTurn(lm.currentTurn, lm.players);
    lm.currentTurn = nextTurn;
    Console.ReadLine();
    Console.WriteLine(lm.currentTurn!.Name);
}