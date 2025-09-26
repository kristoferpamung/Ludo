using LudoGameEnums;

namespace LudoGameClasses;

public class Piece
{
    public ColorState ColorState { get; set; }
    public Position Position { get; set; }
    public PieceState PieceState { get; set; } = PieceState.IN_HOME;
    public Piece(ColorState colorState, Position position)
    {
        ColorState = colorState;
        Position = position;
    }
}