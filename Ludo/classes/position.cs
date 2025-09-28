using LudoGameInterfaces;

namespace LudoGameClasses;

public struct Position : IPosition
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Position(int y, int x)
    {
        X = x;
        Y = y;
    }
}