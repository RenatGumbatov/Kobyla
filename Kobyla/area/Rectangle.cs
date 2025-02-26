namespace Kobyla.area;

public class Rectangle(Point p1, Point p2) : Area
{
    public Point P1 = p1, P2 = p2;

    public override bool IsInArea(area.Point point)
    {
        var left = Math.Min(P1.X, P2.X);
        var right = Math.Max(P1.X, P2.X);
        var top = Math.Min(P1.Y, P2.Y);
        var bottom = Math.Max(P1.Y, P2.Y);
        return point.X >= left && point.X <= right && point.Y >= top && point.Y <= bottom;
    }
}