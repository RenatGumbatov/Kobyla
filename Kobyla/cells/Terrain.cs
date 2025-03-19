namespace Kobyla.cells;

public class Terrain(int height) : Cell
{
    private static readonly char[] Brightness = ['-', '\'', ':', '^', '=', '+', '*', '#', '%', '@'];
    public override char GetSymbol()
    {
        return Unit != null ? Unit.Symbol : Brightness[height];
    }

    public override Cell GetCopy()
    {
        return new Terrain(height);
    }
}