namespace Kobyla.area;

public struct Point(int x, int y)
{
    public int X = x, Y = y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}