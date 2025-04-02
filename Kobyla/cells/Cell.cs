using Kobyla.units;

namespace Kobyla.cells;

public abstract class Cell
{
    public Unit Unit;

    public abstract char GetSymbol();
    public abstract Cell GetCopy();
}