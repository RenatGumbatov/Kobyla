using Kobyla.area;

namespace Kobyla.commands;

public class MoveToTeleportArea(Game game) : Command(game)
{
    public override void Execute()
    {
        game.GetPlayer().MoveTo(new Point(game.GetPlayer().position.X + 1, game.GetPlayer().position.Y));
    }
}