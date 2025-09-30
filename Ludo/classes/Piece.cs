using System.Data.Common;
using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public struct Piece : IPiece
{
    public byte Id { get; private set; }
    public ColorState ColorState { get; set; }
    public IPosition Position { get; set; }
    public PieceState PieceState { get; set; } = PieceState.IN_HOME;
    public Piece(ColorState colorState, IPosition position, byte id)
    {
        ColorState = colorState;
        Position = position;
        Id = id;
    }
}