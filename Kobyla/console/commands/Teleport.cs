using Kobyla.area;

namespace Kobyla.commands;

public class Teleport : Command
{
    public Teleport(Game game, ConsoleUI consoleUI) : base(game, consoleUI)
    {
    }

    public override void Execute(string[] args)
    {
        try
        {
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);
            Game.Player.TeleportTo(new Point(x,y));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}