using System.Data.Common;
using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class GameController
{
    public void SetupBoard(IBoard board)
    {
        for (int y = 0; y <= 14; y++)
        {
            for (int x = 0; x <= 14; x++)
            {
                Position position = new(y, x);
                Square square = new(position);

                if (y == 0)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.RED;
                    }
                    if (x == 6 || x == 8)
                    {
                        square.IsPath = true;
                    }
                    if (x == 7)
                    {
                        square.IsPath = true;
                        square.IsArrowEntry = true;
                        square.ColorState = ColorState.GREEN;
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.GREEN;
                    }
                }

                if (y == 1)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.RED;
                    }
                    if (x >= 6 && x <= 8)
                    {
                        square.IsPath = true;
                        if (x == 7 || x == 8)
                        {
                            square.ColorState = ColorState.GREEN;
                            if (x == 8)
                            {
                                square.IsStart = true;
                                square.IsSafeZone = true;
                            }
                        }
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.GREEN;
                    }
                }

                if (y == 2)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.RED;
                        if (x == 2 || x == 3)
                        {
                            square.IsHome = true;
                        }
                    }
                    if (x >= 6 && x <= 8)
                    {
                        square.IsPath = true;
                        if (x == 6)
                        {
                            square.IsSafeZone = true;
                        }
                        if (x == 7)
                        {
                            square.ColorState = ColorState.GREEN;
                        }
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.GREEN;
                        if (x == 11 || x == 12)
                        {
                            square.IsHome = true;
                        }
                    }
                }

                if (y == 3)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.RED;
                        if (x == 2 || x <= 3)
                        {
                            square.IsHome = true;
                        }
                    }
                    if (x == 6 || x == 8)
                    {
                        square.IsPath = true;
                    }
                    if (x == 7)
                    {
                        square.ColorState = ColorState.GREEN;
                        square.IsPath = true;
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.GREEN;
                        if (x == 11 || x == 12)
                        {
                            square.IsHome = true;
                        }
                    }
                }

                if (y == 4 || y == 5)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.RED;
                    }
                    if (x == 6 || x == 8)
                    {
                        square.IsPath = true;
                    }
                    if (x == 7)
                    {
                        square.IsPath = true;
                        square.ColorState = ColorState.GREEN;
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.GREEN;
                    }
                }

                if (y == 6)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.IsPath = true;
                        if (x == 1)
                        {
                            square.IsStart = true;
                            square.ColorState = ColorState.RED;
                        }
                    }
                    if (x == 7)
                    {
                        square.ColorState = ColorState.GREEN;
                        square.IsFinish = true;
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.IsPath = true;
                        if (x == 12)
                        {
                            square.IsSafeZone = true;
                        }
                    }
                }
                if (y == 7)
                {
                    if (x == 0 || x == 14)
                    {
                        square.IsPath = true;
                        square.IsArrowEntry = true;
                        if (x == 0)
                        {
                            square.ColorState = ColorState.RED;
                        }
                        else
                        {
                            square.ColorState = ColorState.YELLOW;
                        }
                    }
                    if (x >= 1 && x <= 6)
                    {
                        square.ColorState = ColorState.RED;
                        if (x == 6)
                        {
                            square.IsFinish = true;
                        }
                        else
                        {
                            square.IsPath = true;
                        }
                    }
                    if (x >= 8 && x <= 13)
                    {
                        square.ColorState = ColorState.YELLOW;
                        if (x == 8)
                        {
                            square.IsFinish = true;
                        }
                        else
                        {
                            square.IsPath = true;
                        }
                    }
                }
                if (y == 8)
                {
                    if ((x >= 0 && x <= 5) || (x >= 9 && x <= 14))
                    {
                        square.IsPath = true;
                        if (x == 2)
                        {
                            square.IsSafeZone = true;
                        }
                        if (x == 13)
                        {
                            square.IsStart = true;
                            square.ColorState = ColorState.YELLOW;
                        }
                    }
                    if (x == 7)
                    {
                        square.IsFinish = true;
                        square.ColorState = ColorState.BLUE;
                    }
                }
                if (y == 9 || y == 10)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.BLUE;
                    }
                    if (x >= 6 && x <= 8)
                    {
                        square.IsPath = true;
                        if (x == 7)
                        {
                            square.ColorState = ColorState.BLUE;
                        }
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.YELLOW;
                    }
                }
                if (y == 11)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.BLUE;
                        if (x == 2 || x == 3)
                        {
                            square.IsHome = true;
                        }
                    }
                    if (x >= 6 && x <= 8)
                    {
                        square.IsPath = true;
                        if (x == 7)
                        {
                            square.ColorState = ColorState.BLUE;
                        }
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.YELLOW;
                        if (x == 12 || x == 13)
                        {
                            square.IsHome = true;
                        }
                    }
                }
                if (y == 12)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.BLUE;
                        if (x == 2 || x == 3)
                        {
                            square.IsHome = true;
                        }
                    }
                    if (x >= 6 && x <= 8)
                    {
                        square.IsPath = true;
                        if (x == 7)
                        {
                            square.ColorState = ColorState.BLUE;
                        }
                        if (x == 8)
                        {
                            square.IsSafeZone = true;
                        }
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.YELLOW;
                        if (x == 12 || x == 13)
                        {
                            square.IsHome = true;
                        }
                    }
                }

                if (y == 13)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.BLUE;
                    }
                    if (x >= 6 && x <= 8)
                    {
                        square.IsPath = true;
                        if (x == 6 || x == 7)
                        {
                            square.ColorState = ColorState.BLUE;
                            if (x == 6)
                            {
                                square.IsStart = true;
                            }
                        }
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.YELLOW;
                    }
                }

                if (y == 14)
                {
                    if (x >= 0 && x <= 5)
                    {
                        square.ColorState = ColorState.BLUE;
                    }
                    if (x >= 6 && x <= 8)
                    {
                        square.IsPath = true;
                        if (x == 7)
                        {
                            square.ColorState = ColorState.BLUE;
                            square.IsArrowEntry = true;
                        }
                    }
                    if (x >= 9 && x <= 14)
                    {
                        square.ColorState = ColorState.YELLOW;
                    }
                }

                board.Grid[y, x] = square;
            }
        }
    }
    public void DisplayBoard(IBoard board)
    {
        for (int y = 0; y <= 14; y++)
        {
            for (int x = 0; x <= 14; x++)
            {
                if (board.Grid[y, x].ColorState == ColorState.RED)
                {
                    if (board.Grid[y, x].IsArrowEntry)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" > ");
                        Console.ResetColor();
                    }
                    else if (board.Grid[y, x].Pieces.Count > 0)
                    {
                        Console.Write(" P ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" R ");
                        Console.ResetColor();
                    }
                }
                else if (board.Grid[y, x].ColorState == ColorState.BLUE)
                {
                    if (board.Grid[y, x].IsArrowEntry)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" ^ ");
                        Console.ResetColor();
                    }
                    else if (board.Grid[y, x].Pieces.Count > 0)
                    {
                        Console.Write(" P ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" B ");
                        Console.ResetColor();
                    }
                }
                else if (board.Grid[y, x].ColorState == ColorState.GREEN)
                {
                    if (board.Grid[y, x].IsArrowEntry)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" v ");
                        Console.ResetColor();
                    }
                    else if (board.Grid[y, x].Pieces.Count > 0)
                    {
                        Console.Write(" P ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" G ");
                        Console.ResetColor();
                    }
                }
                else if (board.Grid[y, x].ColorState == ColorState.YELLOW)
                {
                    if (board.Grid[y, x].IsArrowEntry)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" < ");
                        Console.ResetColor();

                    }
                    else if (board.Grid[y, x].Pieces.Count > 0)
                    {
                        Console.Write(" P ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(" Y ");
                        Console.ResetColor();

                    }
                }
                else
                {
                    if (!board.Grid[y, x].IsPath)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("   ");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (board.Grid[y, x].Pieces.Count > 0)
                        {
                            Console.Write(" P ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" 0 ");
                            Console.ResetColor();
                        }
                    }
                }
            }
            Console.Write('\n');
        }
    }
    public void OnPlayerPieceMove(IBoard board, List<IPlayer> players)
    {
        for (int y = 0; y <= 14; y++)
        {
            for (int x = 0; x <= 14; x++)
            {
                foreach (IPlayer player in players)
                {
                    foreach (IPiece piece in player.PlayerPieces)
                    {
                        if (piece.Position.Y == y && piece.Position.X == x)
                        {
                            board.Grid[y, x].Pieces.Add(piece);
                        }
                    }
                }
            }
        }
    }
    public void MovePlayerPiece(IBoard board, IPlayer player, int step, int numberOfPiece)
    {
        for (int y = 0; y <= 14; y++)
        {
            for (int x = 0; x <= 14; x++)
            {
                board.Grid[y, x].Pieces.RemoveAll(piece =>
                piece.ColorState == player.PlayerPieces[numberOfPiece].ColorState &&
                piece.Position.X == player.PlayerPieces[numberOfPiece].Position.X &&
                piece.Position.Y == player.PlayerPieces[numberOfPiece].Position.Y &&
                piece.PieceState == player.PlayerPieces[numberOfPiece].PieceState
                );
            }
        }

        int indexOfPiecePosition = player.PlayerPathPositions.FindIndex(position =>
                position.X == player.PlayerPieces[numberOfPiece].Position.X &&
                position.Y == player.PlayerPieces[numberOfPiece].Position.Y);

        if (indexOfPiecePosition != -1)
        {
            player.PlayerPieces[numberOfPiece].Position = player.PlayerPathPositions[indexOfPiecePosition + step];
        }
        else
        {
            player.PlayerPieces[numberOfPiece].Position = player.PlayerPathPositions[0];
            player.PlayerPieces[numberOfPiece].PieceState = PieceState.ON_BOARD;
        }
    }
    public void RollDice(Dice dice)
    {
        Random m = new();
        int[] numbers = [0, 1, 2, 3, 4, 5, 5];
        int result = numbers[m.Next(numbers.Length)];
        dice.DiceValue = (DiceValue)result;
    }
    public List<IPiece> CheckPlayablePieces(IPlayer player, DiceValue diceValue)
    {
        List<int> currentPosition = [];
        foreach (IPiece piece in player.PlayerPieces)
        {
            int indexOfPiecePosition = player.PlayerPathPositions.FindIndex(position =>
                position.X == piece.Position.X &&
                position.Y == piece.Position.Y);
            if (indexOfPiecePosition >= 1)
            {
                currentPosition.Add(indexOfPiecePosition);
            }
        }

        List<int> pieceNotNearFinish = currentPosition.FindAll(p => p + (int)diceValue <= player.PlayerPathPositions.Count - 1);

        if (pieceNotNearFinish.Count >= 1)
        {
            List<IPiece> pieces = [];
            if (diceValue == DiceValue.ENAM)
            {
                foreach (int i in pieceNotNearFinish)
                {
                    pieces.Add(player.PlayerPieces[i]);
                }
                return pieces;
            }
            else
            {
                foreach (int i in pieceNotNearFinish)
                {
                    pieces.Add(player.PlayerPieces[i]);
                }
                return player.PlayerPieces.FindAll(piece => piece.PieceState == PieceState.ON_BOARD);
            }
        }
        else
        {
            return [];
        }
    }
}