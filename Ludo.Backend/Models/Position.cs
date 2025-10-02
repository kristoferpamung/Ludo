namespace Ludo.Backend.Models;

public struct Position
{
    public int Y { get; }
    public int X { get; }

    public Position(int y, int x)
    {
        Y = y;
        X = x;
    }
}