using LudoGameEnums;

namespace LudoGameInterfaces;

public interface ISquare
{
    public IPosition Position { get; }
    public ColorState ColorState { get; set; }
    public bool IsSafeZone { get; set; }
    public bool IsFinish { get; set; }
    public bool IsArrowEntry { get; set; }
    public bool IsStart { get; set; }
    public bool IsHome { get; set; }
    public bool IsPath { get; set; }
    public List<IPiece> Pieces { get; set; }
}