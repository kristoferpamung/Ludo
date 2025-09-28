using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public struct Piece : IPiece
{
    public ColorState ColorState { get; set; }
    public IPosition Position { get; set; }
    public PieceState PieceState { get; set; } = PieceState.IN_HOME;
    public Piece(ColorState colorState, IPosition position)
    {
        ColorState = colorState;
        Position = position;
    }
}