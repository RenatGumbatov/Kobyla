namespace Kobyla.area;

public class Rectangle(Point p1, Point p2) : Shape
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

    public override List<Point> GetPoints()
    {
        var result = new List<Point>();
        for (int x = P1.X; x <= P2.X; x++)
        {
            for (int y = P1.Y; y <= P2.Y; y++)
            {
                result.Add(new Point(x, y));
            }
        }
        return result;
    }
}