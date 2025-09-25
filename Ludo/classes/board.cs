using System.IO.Compression;
using LudoGameEnums;

namespace LudoGameClasses;

public class Board
{
    public Square[,] Grid { get; set; } = new Square[15, 15];
    public void InitializeBoard()
    {
        for (int x = 0; x <= 14; x++)
        {
            for (int y = 0; y <= 14; y++)
            {
                Position position = new(x, y);
                Square square = new(position);

                //Home
                if (x <= 5 && y <= 5)
                {
                    square.ColorState = ColorState.RED;

                }
                else if (x <= 5 && y >= 9)
                {
                    square.ColorState = ColorState.GREEN;
                }
                else if (x >= 9 && y <= 5)
                {
                    square.ColorState = ColorState.BLUE;
                }
                else if (x >= 9 && y >= 9)
                {
                    square.ColorState = ColorState.YELLOW;
                }
                else
                {
                    square.ColorState = ColorState.WHITE;
                }

                // Finish
                if (x >= 6 && x <= 8 && y >= 6 && y <= 8)
                {
                    square.ColorState = ColorState.GREY;
                    if (x == 6 && y == 7)
                    {
                        square.ColorState = ColorState.GREEN;
                        square.IsFinish = true;
                    }

                    if (x == 7 && y == 8)
                    {
                        square.ColorState = ColorState.YELLOW;
                        square.IsFinish = true;
                    }
                    if (x == 8 && y == 7)
                    {
                        square.ColorState = ColorState.BLUE;
                        square.IsFinish = true;
                    }
                    if (x == 7 && y == 6)
                    {
                        square.ColorState = ColorState.RED;
                        square.IsFinish = true;
                    }
                }
                //Safe Zone
                if (x == 13 && y == 6)
                {
                    square.ColorState = ColorState.BLUE;
                    square.IsSafeZone = true;
                }
                if (x == 6 && y == 1)
                {
                    square.ColorState = ColorState.RED;
                    square.IsSafeZone = true;
                }
                if (x == 1 && y == 8)
                {
                    square.ColorState = ColorState.GREEN;
                    square.IsSafeZone = true;
                }
                if (x == 8 && y == 13)
                {
                    square.ColorState = ColorState.YELLOW;
                    square.IsSafeZone = true;
                }
                if (x >= 1 && x <= 5 && y == 7)
                {
                    square.ColorState = ColorState.GREEN;
                    square.IsSafeZone = true;
                }
                if (x >= 9 && x <= 13 && y == 7)
                {
                    square.ColorState = ColorState.BLUE;
                }
                if (x == 7 && y >= 1 && y <= 5)
                {
                    square.ColorState = ColorState.RED;
                }
                if (x == 7 && y >= 9 && y <= 13)
                {
                    square.ColorState = ColorState.YELLOW;
                }

                // Arrow Entry
                if (x == 0 && y == 7)
                {
                    square.ColorState = ColorState.GREEN;
                    square.IsArrowEntry = true;
                }
                if (x == 7 && y == 0)
                {
                    square.ColorState = ColorState.RED;
                    square.IsArrowEntry = true;
                }
                if (x == 7 && y == 14)
                {
                    square.ColorState = ColorState.YELLOW;
                    square.IsArrowEntry = true;
                }
                if (x == 14 && y == 7)
                {
                    square.ColorState = ColorState.BLUE;
                    square.IsArrowEntry = true;
                }
                Grid[x, y] = square;
            }
        }
    }
    public void DisplayBoard()
    {
        for (int x = 0; x <= 14; x++)
        {
            for (int y = 0; y <= 14; y++)
            {
                if (Grid[x, y].ColorState == ColorState.RED)
                {
                    if (Grid[x, y].IsArrowEntry)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" > ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" R ");
                    }
                }
                else if (Grid[x, y].ColorState == ColorState.BLUE)
                {
                    if (Grid[x, y].IsArrowEntry)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" ^ ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" B ");
                    }
                }
                else if (Grid[x, y].ColorState == ColorState.GREEN)
                {
                    if (Grid[x, y].IsArrowEntry)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" v ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" G ");
                    }
                }
                else if (Grid[x, y].ColorState == ColorState.YELLOW)
                {
                    if (Grid[x, y].IsArrowEntry)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" < ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" Y ");
                    }
                }
                else if (Grid[x, y].ColorState == ColorState.WHITE)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" 0 ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" 0 ");
                }

                // if (Grid[x, y].ColorState == ColorState.YELLOW && Grid[x, y].IsArrowEntry)
                // {
                //     Console.ForegroundColor = ConsoleColor.Yellow;
                //     Console.Write(" < ");
                // }
                // if (Grid[x, y].ColorState == ColorState.RED && Grid[x, y].IsArrowEntry)
                // {
                //     Console.ForegroundColor = ConsoleColor.Yellow;
                //     Console.Write(" > ");
                // }
                // if (Grid[x, y].ColorState == ColorState.GREEN && Grid[x, y].IsArrowEntry)
                // {
                //     Console.ForegroundColor = ConsoleColor.Green;
                //     Console.Write(" v ");
                // }
                // if (Grid[x, y].ColorState == ColorState.BLUE && Grid[x, y].IsArrowEntry)
                // {
                //     Console.ForegroundColor = ConsoleColor.Blue;
                //     Console.Write(" ^ ");
                // }

            }
            Console.Write('\n');
        }
    }
}