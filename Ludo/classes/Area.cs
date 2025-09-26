using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class Area : IArea
{
    public IPlayer Owner { get; private set; }
    public List<IPosition> Path { get; private set; }

    public Area(IPlayer owner)
    {
        Owner = owner;
        if (owner.ColorState == ColorState.RED)
        {
            Path = [
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

        if (owner.ColorState == ColorState.GREEN)
        {
            Path = [
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
    }
}