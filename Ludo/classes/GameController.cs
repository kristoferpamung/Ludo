using LudoGameEnums;

namespace LudoGameClasses;

public class GameController
{
    public void SetupBoard(Board board, List<Player> players)
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
                    if (x >= 2 && x <= 3 && y >= 2 && x <= 3)
                    {
                        square.IsHome = true;
                    }
                }
                else if (x <= 5 && y >= 9)
                {
                    square.ColorState = ColorState.GREEN;
                    if (x >= 2 && x <= 3 && y >= 11 && y <= 12)
                    {
                        square.IsHome = true;
                    }
                }
                else if (x >= 9 && y <= 5)
                {
                    square.ColorState = ColorState.BLUE;
                    if (x >= 12 && x <= 13 && y >= 2 && y <= 3)
                    {
                        square.IsHome = true;
                    }
                }
                else if (x >= 9 && y >= 9)
                {
                    if (x >= 12 && x <= 13 && y >= 11 && y <= 12)
                    {
                        square.IsHome = true;
                    }
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
                //Start
                if (x == 13 && y == 6)
                {
                    square.ColorState = ColorState.BLUE;
                    square.IsStart = true;
                    square.IsSafeZone = true;
                }
                if (x == 6 && y == 1)
                {
                    square.ColorState = ColorState.RED;
                    square.IsStart = true;
                    square.IsSafeZone = true;
                }
                if (x == 1 && y == 8)
                {
                    square.ColorState = ColorState.GREEN;
                    square.IsStart = true;
                    square.IsSafeZone = true;
                }
                if (x == 8 && y == 13)
                {
                    square.ColorState = ColorState.YELLOW;
                    square.IsStart = true;
                    square.IsSafeZone = true;
                }
                if (x >= 1 && x <= 5 && y == 7)
                {
                    square.ColorState = ColorState.GREEN;
                    square.IsStart = true;
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

                // Safe Zone *
                if (x == 8 && y == 2)
                {
                    square.IsSafeZone = true;
                }

                if (x == 2 && y == 6)
                {
                    square.IsSafeZone = true;
                }

                if (x == 6 && y == 12)
                {
                    square.IsSafeZone = true;
                }

                if (x == 12 && y == 8)
                {
                    square.IsSafeZone = true;
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

                // Player Dice
                foreach (Player player in players)
                {
                    foreach (Piece piece in player.PlayerPieces!)
                    {
                        if (piece.Position.X == x && piece.Position.Y == y)
                        {
                            square.Pieces.Add(piece);
                        }
                    }
                }
                board.Grid[x, y] = square;
            }
        }
    }
    public void DisplayBoard(Board board)
    {
        for (int x = 0; x <= 14; x++)
        {
            for (int y = 0; y <= 14; y++)
            {
                if (board.Grid[x, y].ColorState == ColorState.RED)
                {
                    if (board.Grid[x, y].IsArrowEntry)
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
                else if (board.Grid[x, y].ColorState == ColorState.BLUE)
                {
                    if (board.Grid[x, y].IsArrowEntry)
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
                else if (board.Grid[x, y].ColorState == ColorState.GREEN)
                {
                    if (board.Grid[x, y].IsArrowEntry)
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
                else if (board.Grid[x, y].ColorState == ColorState.YELLOW)
                {
                    if (board.Grid[x, y].IsArrowEntry)
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
                else if (board.Grid[x, y].ColorState == ColorState.WHITE)
                {
                    if (board.Grid[x, y].IsSafeZone)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" 0 ");
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" 0 ");
                }

                foreach (Piece piece in board.Grid[x, y].Pieces)
                {
                    if (piece.Position.X == x && piece.Position.Y == y)
                    {
                        Console.Write(" P ");
                    }
                }
            }
            Console.Write('\n');
        }
    }
}