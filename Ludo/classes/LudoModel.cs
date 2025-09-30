using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class LudoModel
{
    public List<IPlayer> players;
    public IBoard board;
    public Dice dice;
    public IPlayer? currentTurn;
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
        IPlayer firstTurn = gameController.FirstTurn(players);
        currentTurn = firstTurn;
        Console.WriteLine("First Turn : " + currentTurn.Name);
        Thread.Sleep(2000);
        Console.Clear();
        gameController.OnPlayerPieceMove(board, players);
        while (true)
        {
            gameController.DisplayBoard(board, players);
            Thread.Sleep(1500);
            Console.Clear();
            gameController.DisplayBoard(board, players);
            break;
        }
    }
}