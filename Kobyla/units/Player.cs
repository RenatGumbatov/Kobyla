using Kobyla.area;
using Kobyla.commands;
using Kobyla.maps;
using Inventory = Kobyla.inventory.Inventory;

namespace Kobyla.units;

public class Player : Unit
{
    public Inventory Inventory;
    public Horse Horse;
    public Player(Point position, Inventory inventory, Game game) : base(position, game)
    {
        Symbol = 'P';
        Inventory = inventory;
        Horse = new Horse(game);
    }

    public override void Update()
    {
        CheckAreaCollision();
        Horse.Update();
    }

    private void CheckAreaCollision()
    {
        var areas = GetCollision(game.CurrentMap.TeleportAreas.Keys.ToList());
        game.ConsoleUI.Messages.AddMessage(new Message(areas.Count.ToString(), 1000, true));
        foreach (var area in areas)
        {
            switch (area.Type)
            {
                case AreaType.TeleportArea:
                    var nextLevel = game.CurrentMap.TeleportAreas[area];
                    game.CurrentMap = new Map("maps/" + nextLevel, game);
                    game.CurrentMap.Init();
                    break;
                default:
                    break;
            }
        }
    }

    private List<Area> GetCollision(List<Area> areas)
    {
        List<Area> result = new List<Area>();
        foreach (var area in areas)
        {
            if (area.IsInArea(Position))
            {
                result.Add(area);
            }
        }
        return result;
    }
}