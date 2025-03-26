namespace Kobyla.cells;

public class Terrain(int height) : Cell
{
    private static readonly char[] Brightness = ['-', '\'', ':', '^', '=', '+', '*', '#', '%', '@'];
    public override char GetSymbol()
    {
        if (ReferenceEquals(null, Unit)) {
            return Brightness[int.Clamp(height,0,Brightness.Length-1)];
        }
        return Unit.Symbol;
    }

    public override Cell GetCopy()
    {
        return new Terrain(height);
    }
}