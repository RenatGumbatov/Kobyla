using Kobyla.area;

namespace Kobyla.commands;

public class Move(Game game, ConsoleUI consoleUI) : Command(game, consoleUI)
{
    private readonly Game _game = game;

    public override void Execute(string[] args)
    {
        _game.Player.TeleportTo(new Point(_game.Player.Position.X+1, _game.Player.Position.Y));
    }
}