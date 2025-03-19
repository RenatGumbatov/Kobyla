namespace Kobyla.commands;

public class Exit(Game game, ConsoleUI consoleUI) : Command(game, consoleUI)
{
    public override void Execute(string[] args)
    {
        Environment.Exit(0);
    }
}