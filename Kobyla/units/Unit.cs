using Kobyla.area;

namespace Kobyla.units;

public abstract class Unit
{
    public Point position;
    public char Symbol;
    protected Game game;

    protected Unit(Point position, Game game)
    {
        this.position = position;
        this.game = game;
    }

    public abstract void Update();

    public void MoveTo(Point point)
    {
        position = point;
    }
}