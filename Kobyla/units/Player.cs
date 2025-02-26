using Kobyla.area;
using Kobyla.maps;

namespace Kobyla.units;

public class Player : Unit
{
    public Player(Point position, Game game) : base(position, game)
    {
    }

    public override void Update()
    {
        var area = getCollision(game.CurrentMap.TeleportAreas.Keys.ToList());
        if (area == null) return;
        var nextLevel = game.CurrentMap.TeleportAreas[area];
        game.CurrentMap = new Map("maps/" + nextLevel, game);
        game.CurrentMap.Init();
    }

    public Area getCollision(List<Area> areas)
    {
        foreach (var area in areas)
        {
            if (area.IsInArea(position))
            {
                return area;
            }
        }
        return null!;
    }
}