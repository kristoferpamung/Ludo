using System.Data.Common;
using LudoGameEnums;

namespace LudoGameInterfaces;

public interface IPiece
{
    public byte Id { get; }
    public ColorState ColorState { get; set; }
    public IPosition Position { get; set; }
    public PieceState PieceState { get; set; }
}