using Kobyla.commands;
using Kobyla.inventory;

namespace Kobyla;

class Program
{
    static void Main()
    {
        // var console = new ConsoleUI();
        // console.Start();
        Game game = new Game();
        Inventory inventory = new Inventory();
        inventory.AddItem(new TestItem(game));
        Console.WriteLine(inventory);
        inventory.AddItem(new TestItem(game));
        Console.WriteLine(inventory);
        inventory.UseItem("TestItem");
        Console.WriteLine(inventory);
        inventory.UseItem("TestItem");
        Console.WriteLine(inventory);
        inventory.UseItem("TestItem");
        Console.WriteLine(inventory);
    }
}