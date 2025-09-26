using LudoGameEnums;

namespace LudoGameClasses;

public class LudoModel
{
    public List<Player> players;
    public Board board;
    public Dice dice;
    public Player? currentTurn;
    public GameController gameController;
    public LudoModel(List<Player> players, Board board, Dice dice, GameController gameController)
    {
        this.players = players;
        this.board = board;
        this.dice = dice;
        this.gameController = gameController;

        // Setup board
        this.gameController.SetupBoard(board, players);
    }
}