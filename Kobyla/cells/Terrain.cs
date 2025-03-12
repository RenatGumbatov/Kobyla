namespace Kobyla.cells;

public class Terrain(int height) : Cell
{
    private readonly char[] _brightness = ['-', '\'', ':', '^', '=', '+', '*', '#', '%', '@'];
    public override char GetSymbol()
    {
        return Unit != null ? Unit.Symbol : _brightness[height];
    }
}