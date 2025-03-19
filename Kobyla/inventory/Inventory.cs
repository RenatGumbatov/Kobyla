namespace Kobyla.inventory;

public class Inventory
{
    private Dictionary<Item, Item> _inventory = new();

    public void UseItem(string itemName)
    {
        foreach (var item in _inventory)
        {
            if (item.Key.Name.Equals(itemName))
            {
                if (item.Value.Amount >= 1)
                {
                    item.Value.Use();
                    if (item.Value.RemoveOnUse) _inventory[item.Key].Amount--;
                }
                else
                {
                    if (item.Value.RemoveOnUse) _inventory.Remove(item.Key);
                }
            }
        }
    }
    public void AddItem(Item item)
    {
        if (_inventory.ContainsKey(item))
        {
            _inventory[item].Amount++;
        }
        else
        {
            _inventory.Add(item, item);
        }
    }
    
    public override string ToString()
    {
        var result = "";
        if (_inventory.Count == 0) return "No items in your inventory!";
        foreach (var item in _inventory)
        {
            result += $"{item.Key.Name}: {item.Value.Amount}\n"; 
        }
        return result;
    }
}