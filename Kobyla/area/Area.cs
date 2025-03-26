using Kobyla.commands;
using Kobyla.units;

namespace Kobyla.area;

public class Area
{
    public Area(Game game, Shape shape, Unit parent, IOnAreaCollision onAreaCollision)
    {
        Game = game;
        Shape = shape;
        Parent = parent;
        OnAreaCollision = onAreaCollision;
    }

    public Unit Parent { get; set; }
    public IOnAreaCollision OnAreaCollision { get; set; }
    public Shape Shape { get; set; }
    private Game Game { get; set; }

    public void Update()
    {
        List<Point> points = Shape.GetPoints();
        List<Unit> units = new List<Unit>();
        foreach (var point in points)
        {
            Unit unit = Game.CurrentMap.Cells[point.X, point.Y].Unit;
            if (!ReferenceEquals(null, unit))
            {
                units.Add(unit);
            }
        }
        if (units.Count > 0) OnAreaCollision.OnAreaCollision(this, units);
    }
    public bool IsInArea(Point point) => Shape.IsInArea(point);
}