using Kobyla.area;

namespace Kobyla.units;

public class Deer : Unit, IOnAreaCollision
{
    public Area HitBox;
    public Deer(Point position, Game game) : base(position, game)
    { 
        HitBox = new Area(game, new Rectangle(new Point(position.X-1, position.Y-1), new Point(position.X+1, position.Y-1)), this, this);
    }

    public const char Symbol = 'D';

    public override void Update()
    {
        HitBox.Shape = new Rectangle(new Point(Position.X - 1, Position.Y - 1),
            new Point(Position.X + 1, Position.Y - 1));
        if (Game.Frame % 10 == 0)
        {
            var newPosition = new Point(Position.X, Position.Y);
            var neighbours = newPosition.GetPointsNeighbours();
            Random random = new Random();
            newPosition = neighbours[random.Next(neighbours.Length)];
            TeleportTo(newPosition); 
        }
    }

    public override char GetSymbol()
    {
        return Symbol;
    }

    public void OnAreaCollision(Area area, List<Unit> unitsCollidedWith)
    {
        throw new Exception("This should happen");
    }

    public void CheckCollision()
    {
    }
}