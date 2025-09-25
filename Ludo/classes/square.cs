using System.Drawing;
using LudoGameEnums;

namespace LudoGameClasses;

public class Square
{
    public Position Position { get; private set; }
    public ColorState ColorState { get; set; }
    public bool IsSafeZone { get; set; } = false;
    public bool IsFinish { get; set; } = false;
    public bool IsArrowEntry { get; set; } = false;
    public Square(Position position)
    {
        Position = position;
    }
}