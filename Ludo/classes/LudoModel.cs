using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class LudoModel
{
    public List<IPlayer> players;
    public IBoard board;
    public Dice dice;
    public IPlayer? currentPlayerTurn;
    public GameController gameController;
    public LudoModel(List<IPlayer> players, IBoard board, Dice dice, GameController gameController)
    {
        this.players = players;
        this.board = board;
        this.dice = dice;
        this.gameController = gameController;

        // Setup board
        this.gameController.SetupBoard(board);
    }

    public void Start()
    {
        ConsoleColor[] consoleColors = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue];
        IPlayer firstTurn = gameController.FirstTurn(players);
        currentPlayerTurn = firstTurn;
        Console.Write($"First Turn: ");
        Console.BackgroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" {currentPlayerTurn.Name} ");
        Console.ResetColor();
        Console.WriteLine();
        Console.Write("Press [Enter] to continue");
        Console.ReadLine();
        Console.Clear();

        gameController.AddPlayerPieceIntoBoard(board, players);

        bool isGameOver = false;
        while (!isGameOver)
        {
            /* Display Board */
            gameController.DisplayBoard(board, players);
            Console.WriteLine();

            Console.Write("It's ");
            Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
            Console.Write($"{currentPlayerTurn.Name}");
            Console.ResetColor();
            Console.Write("'s turn to roll the dice\n");
            Console.Write("Press [Enter] to roll the dice");
            Console.ReadLine();

            /* Roll Dice */
            gameController.RollDice(dice);
            Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
            Console.WriteLine(dice.DiceValue);
            Console.ResetColor();

            /* Playable Player Piece */
            bool[] playablePieceArray = gameController.CheckPlayablePieces(currentPlayerTurn, dice.DiceValue);
            List<IPiece> playablePiece = [];
            for (int i = 0; i < playablePieceArray.Length; i++)
            {
                if (playablePieceArray[i])
                {
                    playablePiece.Add(currentPlayerTurn.PlayerPieces[i]);
                }
            }

            bool hasPlayablePiece = false;
            if (playablePiece.Count >= 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You can move a piece 😁");
                Console.ResetColor();
                foreach (IPiece piece in playablePiece)
                {
                    hasPlayablePiece = true;
                    Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
                    Console.WriteLine($"Piece {piece.Id}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No playable pieces available 😞");
                Console.ResetColor();
            }

            int selectedPiece = 0;

            if (hasPlayablePiece)
            {
                Console.Write("Select a piece to move: ");
                bool isValidPiece = false;
                while (!isValidPiece)
                {
                    string? isValidString = Console.ReadLine();
                    if (int.TryParse(isValidString, out int isValidInt))
                    {
                        int indexOfSelectedPlayablePiece = playablePiece.FindIndex(piece => piece.Id == isValidInt);

                        if (indexOfSelectedPlayablePiece >= 0)
                        {
                            selectedPiece = currentPlayerTurn.PlayerPieces.FindIndex(piece => piece.Id == playablePiece[indexOfSelectedPlayablePiece].Id);
                            isValidPiece = true;
                        }
                        else
                        {
                            printInvalidInputMessage("Please enter a valid Piece");

                        }
                    }
                    else
                    {
                        printInvalidInputMessage("Your input not valid");

                    }
                }
                gameController.MovePlayerPiece(board, currentPlayerTurn, (int)dice.DiceValue + 1, selectedPiece);
                // gameController.AddPlayerPieceIntoBoard(board, players);
            }
            Console.WriteLine("Press [Enter] to continue");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
            currentPlayerTurn = gameController.NextTurn(currentPlayerTurn, players);
        }
    }
    void printInvalidInputMessage(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" {message} ");
        Console.ResetColor();
    }
}

