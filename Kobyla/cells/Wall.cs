namespace Kobyla.cells;

public class Wall : Cell, IGetSymbol
{
    public const char Symbol = 'X';
    public override char GetSymbol()
    {
        return Symbol;
    }

    public override Cell GetCopy()
    {
        throw new NotImplementedException();
    }
}