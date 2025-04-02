using Kobyla.units;

namespace Kobyla.cells;

public class Terrain(int height) : Cell, IGetSymbol
{
    public readonly int Height = height;
    private static readonly char[] Brightness = ['-', '\'', ':', '^', '=', '+', '*', '#', '%', '@'];
    public override char GetSymbol()
    {
        if (ReferenceEquals(null, Unit)) {
            return Brightness[int.Clamp(Height,0,Brightness.Length-1)];
        }
        return Unit.GetSymbol();
    }

    public override Cell GetCopy()
    {
        Cell copy = new Terrain(Height);
        copy.Unit = Unit;
        return copy;
    }
}