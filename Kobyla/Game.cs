using Kobyla.maps;
using Kobyla.units;
using Point = Kobyla.area.Point;

namespace Kobyla;

public class Game
{
    public Map CurrentMap;
    public List<Unit> Units = [];

    public Game()
    {
        Units.Add(new Player(new Point(0, 0), this));
        CurrentMap = new Map(@"maps/map1.txt", this);
        CurrentMap.Init();
    }

    public void Update()
    {
        foreach (var unit in Units)
        {
            unit.Update();
        }
    }

    public Player GetPlayer()
    {
        return Units.OfType<Player>().First();
    }
}