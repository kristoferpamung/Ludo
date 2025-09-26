using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class Player : IPlayer
{
    public string Name { get; private set; }
    public ColorState ColorState { get; private set; }
    public List<IPiece>? PlayerPieces { get; set; }
    public Player(string name, ColorState colorState)
    {
        Name = name;
        ColorState = colorState;
        if (ColorState == ColorState.RED)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(2,2)),
                new Piece(ColorState, new Position(2,3)),
                new Piece(ColorState, new Position(3,3)),
                new Piece(ColorState, new Position(3,2))
                ];
        }
        if (ColorState == ColorState.GREEN)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(2,11)),
                new Piece(ColorState, new Position(2,12)),
                new Piece(ColorState, new Position(3,12)),
                new Piece(ColorState, new Position(3,11))
                ];
        }
        if (ColorState == ColorState.YELLOW)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(11,11)),
                new Piece(ColorState, new Position(11,12)),
                new Piece(ColorState, new Position(12,12)),
                new Piece(ColorState, new Position(12,11))
                ];
        }
        if (ColorState == ColorState.BLUE)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(11,2)),
                new Piece(ColorState, new Position(11,3)),
                new Piece(ColorState, new Position(12,3)),
                new Piece(ColorState, new Position(12,2))
                ];
        }
    }
}