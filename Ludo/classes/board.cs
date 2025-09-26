

using LudoGameInterfaces;

namespace LudoGameClasses;

public class Board : IBoard
{
    public ISquare[,] Grid { get; set; } = new ISquare[15, 15];

}