using LudoGameClasses;
using LudoGameEnums;

namespace LudoGameInterfaces;

public interface IPlayer
{
    public string Name { get; }
    public ColorState ColorState { get; }
    public List<IPiece>? PlayerPieces { get; set; }
}