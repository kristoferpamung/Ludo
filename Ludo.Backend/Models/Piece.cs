using Ludo.Backend.Enums;

namespace Ludo.Backend.Models;

public struct Piece
{
    public int ID { get; }
    public ColorState ColorState { get; }
    public Position Position { get; }
    public PieceState PieceState { get; } = PieceState.IN_HOME;
    public Piece(int id, ColorState colorState, Position position)
    {
        ID = id;
        ColorState = colorState;
        Position = position;
    }
}