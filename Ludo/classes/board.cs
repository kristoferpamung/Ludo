using System.IO.Compression;
using LudoGameEnums;

namespace LudoGameClasses;

public class Board
{
    public Square[,] Grid { get; set; } = new Square[15, 15];
}