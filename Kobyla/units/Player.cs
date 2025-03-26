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
        foreach (var area in Areas)
        {
            area.Update();
        }
        Horse.Update();
    }

    private void CheckAreaCollision()
    {

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

    public override string ToString()
    {
        return $"Player: {Position}, Inventory: {Inventory}, Horse: {Horse}";
    }
}