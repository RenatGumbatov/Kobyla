namespace Kobyla.cells;

public class TerrainCell(int height) : Cell
{
    public override char GetSymbol()
    {
        if (Unit != null) return Unit.Symbol;
        char[] brightness = ['-', '\'', ':', '^', '=', '+', '*', '#', '%', '@'];
        return brightness[height];
    }
}