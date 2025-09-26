using LudoGameClasses;

namespace LudoGameInterfaces;

public interface IArea
{
    public IPlayer Owner { get; }
    public List<IPosition> Path { get; }
}