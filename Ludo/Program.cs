using LudoGameClasses;
using LudoGameEnums;

Player player1 = new("windah", ColorState.RED);
Player player2 = new("zeta", ColorState.GREEN);
Player player3 = new("kobo", ColorState.YELLOW);
Player player4 = new("windah", ColorState.BLUE);

List<Player> players = [player1, player2, player3, player4];

Board board = new();
Dice dice = new();
GameController gc = new();

LudoModel lm = new(players, board, dice, gc);

lm.gameController.DisplayBoard(lm.board);