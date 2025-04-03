using Kobyla.commands;

namespace Kobyla.inventory;

public class Apple : Item
{
    private readonly int _healthAmount = 20;

    public Apple(Game game) : base(game)
    {
        Name = "Apple";
    }

    public override void Use()
    {
        Game.ConsoleUI.Messages.AddMessage(new Message("Apple has been used!"));
        Game.Player.Horse.Health += _healthAmount;
    }
}