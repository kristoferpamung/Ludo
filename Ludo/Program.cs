using LudoGameClasses;
using LudoGameEnums;
using LudoGameInterfaces;

Player player1 = new("windah", ColorState.RED);
Player player2 = new("zeta", ColorState.GREEN);
Player player3 = new("kobo", ColorState.YELLOW);
Player player4 = new("windah", ColorState.BLUE);

List<IPlayer> players = [player1, player2, player3, player4];

Board board = new();
Dice dice = new();
GameController gc = new();

LudoModel lm = new(players, board, dice, gc);

lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[1], new Position(2, 6), 2);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[0], new Position(1, 6), 1);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[2], new Position(3, 6), 3);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[3], new Position(4, 6), 0);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);