using Kobyla.units;

namespace Kobyla.cells;

public abstract class Cell
{
    protected Unit Unit = null!;

    public abstract char GetSymbol();
}