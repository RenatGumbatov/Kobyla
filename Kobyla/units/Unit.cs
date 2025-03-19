using Kobyla.area;

namespace Kobyla.units;

public abstract class Unit
{
    public Point Position;
    public char Symbol;
    protected Game game;

    protected Unit(Point position, Game game)
    {
        Position = position;
        this.game = game;
    }

    public abstract void Update();

    public void TeleportTo(Point point)
    {
        var cellToMoveTo = game.CurrentMap.Cells[point.X, point.Y];
        if (cellToMoveTo.IsWall) return;
        var cellMovingFrom = game.CurrentMap.Cells[Position.X, Position.Y];
        cellToMoveTo.Unit = this;
        Position = point;
        cellMovingFrom.Unit = null!;
    }
}