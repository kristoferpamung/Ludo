using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class Player : IPlayer
{
    public string Name { get; private set; }
    public ColorState ColorState { get; private set; }
    public List<IPiece> PlayerPieces { get; set; } = [];
    public List<IPosition> PlayerHomePositions { get; private set; } = [];
    public List<IPosition> PlayerPathPositions { get; private set; } = [];
    public Player(string name, ColorState colorState)
    {
        Name = name;
        ColorState = colorState;
        if (ColorState == ColorState.RED)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(2,2)),
                new Piece(ColorState, new Position(2,3)),
                new Piece(ColorState, new Position(3,3)),
                new Piece(ColorState, new Position(3,2))
                ];
            PlayerHomePositions = [
                new Position(2,2),
                new Position(2,3),
                new Position(3,3),
                new Position(3,2)
            ];
            PlayerPathPositions = [
                new Position(6,1),
                new Position(6,2),
                new Position(6,3),
                new Position(6,4),
                new Position(6,5),
                new Position(5,6),
                new Position(4,6),
                new Position(3,6),
                new Position(2,6),
                new Position(1,6),
                new Position(0,6),
                new Position(0,7),
                new Position(0,8),
                new Position(1,8),
                new Position(2,8),
                new Position(3,8),
                new Position(4,8),
                new Position(5,8),
                new Position(6,9),
                new Position(6,10),
                new Position(6,11),
                new Position(6,12),
                new Position(6,13),
                new Position(6,14),
                new Position(7,14),
                new Position(8,14),
                new Position(8,13),
                new Position(8,12),
                new Position(8,11),
                new Position(8,10),
                new Position(8,9),
                new Position(9,8),
                new Position(10,8),
                new Position(11,8),
                new Position(12,8),
                new Position(13,8),
                new Position(14,8),
                new Position(14,7),
                new Position(14,6),
                new Position(13,6),
                new Position(12,6),
                new Position(11,6),
                new Position(10,6),
                new Position(9,6),
                new Position(8,5),
                new Position(8,4),
                new Position(8,3),
                new Position(8,2),
                new Position(8,1),
                new Position(8,0),
                new Position(7,0),
                new Position(7,1),
                new Position(7,2),
                new Position(7,3),
                new Position(7,4),
                new Position(7,5),
                new Position(7,6)
            ];
        }
        if (ColorState == ColorState.GREEN)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(2,11)),
                new Piece(ColorState, new Position(2,12)),
                new Piece(ColorState, new Position(3,12)),
                new Piece(ColorState, new Position(3,11))
                ];
            PlayerHomePositions = [
                new Position(2,11),
                new Position(2,12),
                new Position(3,12),
                new Position(3,11)
            ];
            PlayerPathPositions = [
                new Position(1,8),
                new Position(2,8),
                new Position(3,8),
                new Position(4,8),
                new Position(5,8),
                new Position(6,9),
                new Position(6,10),
                new Position(6,11),
                new Position(6,12),
                new Position(6,13),
                new Position(6,14),
                new Position(7,14),
                new Position(8,14),
                new Position(8,13),
                new Position(8,12),
                new Position(8,11),
                new Position(8,10),
                new Position(8,9),
                new Position(9,8),
                new Position(10,8),
                new Position(11,8),
                new Position(12,8),
                new Position(13,8),
                new Position(14,8),
                new Position(14,7),
                new Position(14,6),
                new Position(13,6),
                new Position(12,6),
                new Position(11,6),
                new Position(10,6),
                new Position(9,6),
                new Position(8,5),
                new Position(8,4),
                new Position(8,3),
                new Position(8,2),
                new Position(8,1),
                new Position(8,0),
                new Position(7,0),
                new Position(6,0),
                new Position(6,1),
                new Position(6,2),
                new Position(6,3),
                new Position(6,4),
                new Position(6,5),
                new Position(5,6),
                new Position(4,6),
                new Position(3,6),
                new Position(2,6),
                new Position(1,6),
                new Position(0,6),
                new Position(0,7),
                new Position(1,7),
                new Position(2,7),
                new Position(3,7),
                new Position(4,7),
                new Position(5,7),
                new Position(6,7)
            ];
        }
        if (ColorState == ColorState.YELLOW)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(11,11)),
                new Piece(ColorState, new Position(11,12)),
                new Piece(ColorState, new Position(12,12)),
                new Piece(ColorState, new Position(12,11))
                ];
            PlayerHomePositions = [
                new Position(11,11),
                new Position(11,12),
                new Position(12,12),
                new Position(12,11)
            ];
            PlayerPathPositions = [
                new Position(8,13),
                new Position(8,12),
                new Position(8,11),
                new Position(8,10),
                new Position(8,9),
                new Position(9,8),
                new Position(10,8),
                new Position(11,8),
                new Position(12,8),
                new Position(13,8),
                new Position(14,8),
                new Position(14,7),
                new Position(14,6),
                new Position(13,6),
                new Position(12,6),
                new Position(11,6),
                new Position(10,6),
                new Position(9,6),
                new Position(8,5),
                new Position(8,4),
                new Position(8,3),
                new Position(8,2),
                new Position(8,1),
                new Position(8,0),
                new Position(7,0),
                new Position(6,0),
                new Position(6,1),
                new Position(6,2),
                new Position(6,3),
                new Position(6,4),
                new Position(6,5),
                new Position(5,6),
                new Position(4,6),
                new Position(3,6),
                new Position(2,6),
                new Position(1,6),
                new Position(0,6),
                new Position(0,7),
                new Position(0,8),
                new Position(1,8),
                new Position(2,8),
                new Position(3,8),
                new Position(4,8),
                new Position(5,8),
                new Position(6,9),
                new Position(6,10),
                new Position(6,11),
                new Position(6,12),
                new Position(6,13),
                new Position(6,14),
                new Position(7,14),
                new Position(7,13),
                new Position(7,12),
                new Position(7,11),
                new Position(7,10),
                new Position(7,9),
                new Position(7,8)
            ];
        }
        if (ColorState == ColorState.BLUE)
        {
            PlayerPieces = [
                new Piece(ColorState, new Position(11,2)),
                new Piece(ColorState, new Position(11,3)),
                new Piece(ColorState, new Position(12,3)),
                new Piece(ColorState, new Position(12,2))
                ];
            PlayerHomePositions = [
                new Position(11,2),
                new Position(11,3),
                new Position(12,3),
                new Position(12,2)
            ];
            PlayerPathPositions = [
                new Position(13,6),
                new Position(12,6),
                new Position(11,6),
                new Position(10,6),
                new Position(9,6),
                new Position(8,5),
                new Position(8,4),
                new Position(8,3),
                new Position(8,2),
                new Position(8,1),
                new Position(8,0),
                new Position(7,0),
                new Position(6,0),
                new Position(6,1),
                new Position(6,2),
                new Position(6,3),
                new Position(6,4),
                new Position(6,5),
                new Position(5,6),
                new Position(4,6),
                new Position(3,6),
                new Position(2,6),
                new Position(1,6),
                new Position(0,6),
                new Position(0,7),
                new Position(0,8),
                new Position(1,8),
                new Position(2,8),
                new Position(3,8),
                new Position(4,8),
                new Position(5,8),
                new Position(6,9),
                new Position(6,10),
                new Position(6,11),
                new Position(6,12),
                new Position(6,13),
                new Position(6,14),
                new Position(7,14),
                new Position(8,14),
                new Position(8,13),
                new Position(8,12),
                new Position(8,11),
                new Position(8,10),
                new Position(8,9),
                new Position(9,8),
                new Position(10,8),
                new Position(11,8),
                new Position(12,8),
                new Position(13,8),
                new Position(14,8),
                new Position(14,7),
                new Position(13,7),
                new Position(12,7),
                new Position(11,7),
                new Position(10,7),
                new Position(9,7),
                new Position(8,7)
            ];
        }
    }
}