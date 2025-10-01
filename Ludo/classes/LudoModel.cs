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

        gameController.OnPlayerPieceMove(board, players);
        
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
            bool[] playablePiece = gameController.CheckPlayablePieces(currentPlayerTurn, dice.DiceValue);
            foreach (bool playable in playablePiece)
            {
                Console.WriteLine(playable);
            }
            
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
            currentPlayerTurn = gameController.NextTurn(currentPlayerTurn, players);
        }
    }
}