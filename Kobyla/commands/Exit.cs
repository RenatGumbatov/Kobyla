namespace Kobyla.commands;

public class Exit(Game game) : Command(game)
{
    public override void Execute()
    {
        Environment.Exit(0);
    }
}