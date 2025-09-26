using LudoGameInterfaces;

namespace LudoGameClasses;

public struct Position : IPosition
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}