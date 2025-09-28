using LudoGameEnums;
using LudoGameInterfaces;

namespace LudoGameClasses;

public class Area : IArea
{
    public IPlayer Owner { get; private set; }
    public List<IPosition> Path { get; private set; } = [];

    public Area(IPlayer owner)
    {
        Owner = owner;
        if (owner.ColorState == ColorState.RED)
        {
            Path = [
                
            ];
        }

        if (owner.ColorState == ColorState.GREEN)
        {
            Path = [
                
            ];
        }
        if (owner.ColorState == ColorState.YELLOW)
        {
            Path = [
                
            ];
        }
        if (owner.ColorState == ColorState.BLUE)
        {
            Path = [
                
            ];
        }
    }
}