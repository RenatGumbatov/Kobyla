namespace Kobyla.inventory;

public class Apple(Game game) : Item(game)
{
    private readonly int _healthAmount = 20;
    public override void Use()
    {
        Game.Player.Horse.Health += _healthAmount;
    }
}