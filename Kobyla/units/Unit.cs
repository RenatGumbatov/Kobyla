using Kobyla.area;
using Kobyla.cells;

namespace Kobyla.units;

public abstract class Unit : IGetSymbol
{
    public Point Position;
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
        if (point.X < 0 || point.Y < 0) return;
        if (point.X >= Game.CurrentMap.Width || point.Y >= Game.CurrentMap.Height) return;
        
        var cellToMoveTo = Game.CurrentMap.Cells[point.X, point.Y];
        if (cellToMoveTo is Wall) return;
        if (!ReferenceEquals(cellToMoveTo.Unit, null)) return;
        
        var cellMovingFrom = Game.CurrentMap.Cells[Position.X, Position.Y];
        cellToMoveTo.Unit = this;
        Position = point;
        cellMovingFrom.Unit = null!;
    }

    public abstract char GetSymbol();
}