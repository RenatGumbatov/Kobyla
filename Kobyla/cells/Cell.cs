using Kobyla.units;

namespace Kobyla.cells;

public abstract class Cell
{
    public Unit Unit = null!;
    public bool IsWall; 
    public bool CanBeJumped;

    public abstract char GetSymbol();
    public abstract Cell GetCopy();
}