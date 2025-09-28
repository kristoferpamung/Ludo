using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class LudoModel
{
    public List<IPlayer> players;
    public IBoard board;
    public Dice dice;
    public Player? currentTurn;
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
}