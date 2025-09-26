using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class Square : ISquare
{
    public IPosition Position { get; private set; }
    public ColorState ColorState { get; set; }
    public bool IsSafeZone { get; set; } = false;
    public bool IsFinish { get; set; } = false;
    public bool IsArrowEntry { get; set; } = false;
    public bool IsStart { get; set; } = false;
    public bool IsHome { get; set; } = false;
    public List<IPiece> Pieces { get; set; } = [];
    public Square(IPosition position)
    {
        Position = position;
    }
}