using LudoGameEnums;

namespace LudoGameInterfaces;

public interface IPiece
{
    public ColorState ColorState { get; set; }
    public IPosition Position { get; set; }
    public PieceState PieceState { get; set; }
}