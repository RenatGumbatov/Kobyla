﻿using Kobyla.area;
using Inventory = Kobyla.inventory.Inventory;

namespace Kobyla.units;

public class Player : Unit
{
    public const char Symbol = 'P';
    
    public Inventory Inventory;
    public Horse Horse;
    
    public Player(Point position, Inventory inventory, Game game) : base(position, game)
    {
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

    public override char GetSymbol()
    {
        return Symbol;
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