using Ludo.Backend.Enums;

namespace Ludo.Backend.Models;

public class Player
{
    public string Name { get; } = "";
    public ColorState ColorState { get; }
    public List<Piece> Pieces { get; } = [];
    public List<Position> HomePositions { get; } = [];
    public List<Position> PathPositions { get; } = [];

    public Player(string name, ColorState colorState)
    {
        Name = name;
        ColorState = colorState;
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        if (ColorState == ColorState.RED)
        {

        }
        if (ColorState == ColorState.GREEN)
        {

        }
        if (ColorState == ColorState.YELLOW)
        {

        }
        if (ColorState == ColorState.BLUE)
        {

        }
    }
}