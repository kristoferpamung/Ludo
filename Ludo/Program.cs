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
lm.gameController.MovePlayerPiece(lm.board, lm.players[1], 3, 2);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[0], 4, 1);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[2], 5, 3);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[3], 1, 0);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();
lm.gameController.MovePlayerPiece(lm.board, lm.players[3], 4, 0);
lm.gameController.OnPlayerPieceMove(lm.board, players);
lm.gameController.DisplayBoard(lm.board);
Console.WriteLine();