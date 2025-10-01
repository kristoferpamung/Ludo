using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class LudoModel
{
    public List<IPlayer> players;
    public List<IPlayer> playerWinnerOrders = [];
    public IBoard board;
    public Dice dice;
    public IPlayer? currentPlayerTurn;
    public GameController gameController;
    public LudoModel(List<IPlayer> players, IBoard board, Dice dice, GameController gameController)
    {
        this.players = players;
        this.board = board;
        this.dice = dice;
        this.gameController = gameController;

        // Setup board
        this.gameController.SetupBoard(board);
    }

    public void Start()
    {
        ConsoleColor[] consoleColors = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue];
        IPlayer firstTurn = gameController.FirstTurn(players);
        currentPlayerTurn = firstTurn;
        Console.Write($"First Turn: ");
        Console.BackgroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" {currentPlayerTurn.Name} ");
        Console.ResetColor();
        Console.WriteLine();
        Console.Write("Press [Enter] to continue");
        Console.ReadLine();
        Console.Clear();

        gameController.AddPlayerPieceIntoBoard(board, players);

        bool isGameOver = false;
        while (!isGameOver)
        {
            /* Display Board */
            gameController.DisplayBoard(board, players);
            Console.WriteLine();

            Console.Write("It's ");
            Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
            Console.Write($"{currentPlayerTurn.Name}");
            Console.ResetColor();
            Console.Write("'s turn to roll the dice\n");
            Console.Write("Press [Enter] to roll the dice");
            Console.ReadLine();

            /* Roll Dice */
            gameController.RollDice(dice);
            Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
            Console.WriteLine(dice.DiceValue);
            Console.ResetColor();

            /* Playable Player Piece */
            bool[] playablePieceArray = gameController.CheckPlayablePieces(currentPlayerTurn, dice.DiceValue);
            List<IPiece> playablePiece = [];
            for (int i = 0; i < playablePieceArray.Length; i++)
            {
                if (playablePieceArray[i])
                {
                    playablePiece.Add(currentPlayerTurn.PlayerPieces[i]);
                }
            }

            bool hasPlayablePiece = false;
            if (playablePiece.Count >= 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You can move a piece 😁");
                Console.ResetColor();
                foreach (IPiece piece in playablePiece)
                {
                    hasPlayablePiece = true;
                    Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
                    Console.WriteLine($"Piece {piece.Id}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No playable pieces available 😞");
                Console.ResetColor();
            }

            int selectedPiece = 0;

            if (hasPlayablePiece)
            {
                bool isValidPiece = false;
                while (!isValidPiece)
                {
                    Console.Write("Select a piece to move: ");

                    string? isValidString = Console.ReadLine();
                    if (int.TryParse(isValidString, out int isValidInt))
                    {
                        int indexOfSelectedPlayablePiece = playablePiece.FindIndex(piece => piece.Id == isValidInt);

                        if (indexOfSelectedPlayablePiece >= 0)
                        {
                            selectedPiece = currentPlayerTurn.PlayerPieces.FindIndex(piece => piece.Id == playablePiece[indexOfSelectedPlayablePiece].Id);
                            isValidPiece = true;
                        }
                        else
                        {
                            printInvalidInputMessage("Please enter a valid Piece");

                        }
                    }
                    else
                    {
                        printInvalidInputMessage("Your input not valid");

                    }
                }
                gameController.MovePlayerPiece(currentPlayerTurn, (int)dice.DiceValue + 1, selectedPiece);
                gameController.AddPlayerPieceIntoBoard(board, players);
                gameController.CheckCollision(currentPlayerTurn.PlayerPieces[selectedPiece], board, players);
                gameController.AddPlayerPieceIntoBoard(board, players);
            }
            if (gameController.CheckPlayerWinner(board, currentPlayerTurn))
            {
                playerWinnerOrders.Add(currentPlayerTurn);
                players.RemoveAll(player => player.Name == currentPlayerTurn.Name);
                currentPlayerTurn = gameController.NextTurn(currentPlayerTurn, players);
                Console.WriteLine($"{currentPlayerTurn.Name} Win");
            }
            else
            {
                Thread.Sleep(2000);
                Console.ResetColor();
                Console.Clear();

                if (!(dice.DiceValue == DiceValue.ENAM))
                {
                    currentPlayerTurn = gameController.NextTurn(currentPlayerTurn, players);
                }
            }
            if (players.Count == 1)
            {
                playerWinnerOrders.Add(players[0]);
                isGameOver = true;
            }
        }
    }

    public void GameOver()
    {
        ConsoleColor[] consoleColors = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue];
        Console.WriteLine("{0,-5} {1,-15} {2,-10}", "Winner", "Name", "Color");
        for (int i = 0; i < playerWinnerOrders.Count; i++)
        {
            Console.Write("{0,-5} {1,-15}", $"{i + 1}.", players[i].Name);
            Console.BackgroundColor = consoleColors[(int)players[i].ColorState];
            Console.Write("{0,-10}", "  ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    public void DemoGameOver()
    {
        players[0].PlayerPieces[0].Position = players[0].PlayerPathPositions[56];
        players[0].PlayerPieces[0].PieceState = PieceState.IN_GOAL;
        players[0].PlayerPieces[1].Position = players[0].PlayerPathPositions[56];
        players[0].PlayerPieces[1].PieceState = PieceState.IN_GOAL;
        players[0].PlayerPieces[2].Position = players[0].PlayerPathPositions[56];
        players[0].PlayerPieces[2].PieceState = PieceState.IN_GOAL;
        players[0].PlayerPieces[3].Position = players[0].PlayerPathPositions[54];
        players[0].PlayerPieces[3].PieceState = PieceState.ON_BOARD;

        players[1].PlayerPieces[0].Position = players[0].PlayerPathPositions[56];
        players[1].PlayerPieces[0].PieceState = PieceState.IN_GOAL;
        players[1].PlayerPieces[1].Position = players[0].PlayerPathPositions[56];
        players[1].PlayerPieces[1].PieceState = PieceState.IN_GOAL;
        players[1].PlayerPieces[2].Position = players[0].PlayerPathPositions[56];
        players[1].PlayerPieces[2].PieceState = PieceState.IN_GOAL;
        players[1].PlayerPieces[3].Position = players[0].PlayerPathPositions[54];
        players[1].PlayerPieces[3].PieceState = PieceState.ON_BOARD;

        players[2].PlayerPieces[0].Position = players[0].PlayerPathPositions[56];
        players[2].PlayerPieces[0].PieceState = PieceState.IN_GOAL;
        players[2].PlayerPieces[1].Position = players[0].PlayerPathPositions[56];
        players[2].PlayerPieces[1].PieceState = PieceState.IN_GOAL;
        players[2].PlayerPieces[2].Position = players[0].PlayerPathPositions[56];
        players[2].PlayerPieces[2].PieceState = PieceState.IN_GOAL;
        players[2].PlayerPieces[3].Position = players[0].PlayerPathPositions[54];
        players[2].PlayerPieces[3].PieceState = PieceState.ON_BOARD;

        players[3].PlayerPieces[0].Position = players[0].PlayerPathPositions[56];
        players[3].PlayerPieces[0].PieceState = PieceState.IN_GOAL;
        players[3].PlayerPieces[1].Position = players[0].PlayerPathPositions[56];
        players[3].PlayerPieces[1].PieceState = PieceState.IN_GOAL;
        players[3].PlayerPieces[2].Position = players[0].PlayerPathPositions[56];
        players[3].PlayerPieces[2].PieceState = PieceState.IN_GOAL;
        players[3].PlayerPieces[3].Position = players[0].PlayerPathPositions[54];
        players[3].PlayerPieces[3].PieceState = PieceState.ON_BOARD;


        ConsoleColor[] consoleColors = [ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue];
        IPlayer firstTurn = gameController.FirstTurn(players);
        currentPlayerTurn = firstTurn;
        Console.Write($"First Turn: ");
        Console.BackgroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($" {currentPlayerTurn.Name} ");
        Console.ResetColor();
        Console.WriteLine();
        Console.Write("Press [Enter] to continue");
        Console.ReadLine();
        Console.Clear();

        gameController.AddPlayerPieceIntoBoard(board, players);

        bool isGameOver = false;
        while (!isGameOver)
        {
            /* Display Board */
            gameController.DisplayBoard(board, players);
            Console.WriteLine();

            Console.Write("It's ");
            Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
            Console.Write($"{currentPlayerTurn.Name}");
            Console.ResetColor();
            Console.Write("'s turn to roll the dice\n");
            Console.Write("Press [Enter] to roll the dice");
            Console.ReadLine();

            /* Roll Dice */
            gameController.RollDice(dice);
            Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
            Console.WriteLine(dice.DiceValue);
            Console.ResetColor();

            /* Playable Player Piece */
            bool[] playablePieceArray = gameController.CheckPlayablePieces(currentPlayerTurn, dice.DiceValue);
            List<IPiece> playablePiece = [];
            for (int i = 0; i < playablePieceArray.Length; i++)
            {
                if (playablePieceArray[i])
                {
                    playablePiece.Add(currentPlayerTurn.PlayerPieces[i]);
                }
            }

            bool hasPlayablePiece = false;
            if (playablePiece.Count >= 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("You can move a piece 😁");
                Console.ResetColor();
                foreach (IPiece piece in playablePiece)
                {
                    hasPlayablePiece = true;
                    Console.ForegroundColor = consoleColors[(int)currentPlayerTurn.ColorState];
                    Console.WriteLine($"Piece {piece.Id}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No playable pieces available 😞");
                Console.ResetColor();
            }

            int selectedPiece = 0;
            bool isCollision = false;
            if (hasPlayablePiece)
            {
                bool isValidPiece = false;
                while (!isValidPiece)
                {
                    Console.Write("Select a piece to move: ");

                    string? isValidString = Console.ReadLine();
                    if (int.TryParse(isValidString, out int isValidInt))
                    {
                        int indexOfSelectedPlayablePiece = playablePiece.FindIndex(piece => piece.Id == isValidInt);

                        if (indexOfSelectedPlayablePiece >= 0)
                        {
                            selectedPiece = currentPlayerTurn.PlayerPieces.FindIndex(piece => piece.Id == playablePiece[indexOfSelectedPlayablePiece].Id);
                            isValidPiece = true;
                        }
                        else
                        {
                            printInvalidInputMessage("Please enter a valid Piece");

                        }
                    }
                    else
                    {
                        printInvalidInputMessage("Your input not valid");

                    }
                }
                gameController.MovePlayerPiece(currentPlayerTurn, (int)dice.DiceValue + 1, selectedPiece);
                gameController.AddPlayerPieceIntoBoard(board, players);
                isCollision = gameController.CheckCollision(currentPlayerTurn.PlayerPieces[selectedPiece], board, players);
                gameController.AddPlayerPieceIntoBoard(board, players);
            }
            if (gameController.CheckPlayerWinner(board, currentPlayerTurn))
            {
                playerWinnerOrders.Add(currentPlayerTurn);
                players.RemoveAll(player => player.Name == currentPlayerTurn.Name);
                currentPlayerTurn = gameController.NextTurn(currentPlayerTurn, players);
                Console.WriteLine($"{currentPlayerTurn.Name} Win");
            }
            else
            {
                Thread.Sleep(2000);
                Console.ResetColor();
                Console.Clear();

                if (!(dice.DiceValue == DiceValue.ENAM) || !isCollision)
                {
                    currentPlayerTurn = gameController.NextTurn(currentPlayerTurn, players);
                }
            }
            if (players.Count == 1)
            {
                playerWinnerOrders.Add(players[0]);
                isGameOver = true;
            }
        }
    }
    void printInvalidInputMessage(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" {message} ");
        Console.ResetColor();
    }
}

