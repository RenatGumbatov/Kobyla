namespace Kobyla.area;

public abstract class Shape
{
    public abstract bool IsInArea(Point point);
    public abstract List<Point> GetPoints();
}