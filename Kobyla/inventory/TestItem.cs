namespace Kobyla.inventory;

public class TestItem : Item
{
    public TestItem(Game game) : base(game)
    {
        Name = "TestItem";
        RemoveOnUse = true;
    }

    public override void Use()
    {
        Console.WriteLine("TestItem used");
    }
}