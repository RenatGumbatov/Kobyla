using Kobyla.area;

namespace Kobyla.units;

public abstract class Unit
{
    public Point Position;
    public char Symbol;
    protected Game Game;
    protected List<Area> Areas = [];

    protected Unit(Point position, Game game)
    {
        Position = position;
        this.Game = game;
    }

    public abstract void Update();

    public void TeleportTo(Point point)
    {
        var cellToMoveTo = Game.CurrentMap.Cells[point.X, point.Y];
        if (cellToMoveTo.IsWall) return;
        var cellMovingFrom = Game.CurrentMap.Cells[Position.X, Position.Y];
        cellToMoveTo.Unit = this;
        Position = point;
        cellMovingFrom.Unit = null!;
    }
}