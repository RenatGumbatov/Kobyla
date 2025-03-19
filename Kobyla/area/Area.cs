namespace Kobyla.area;

public class Area
{
    public Area(Shape shape, AreaType type)
    {
        Shape = shape;
        Type = type;
    }

    public Shape Shape { get; set; }
    public AreaType Type { get; private set; }

    public bool IsInArea(Point point) => Shape.IsInArea(point);
}