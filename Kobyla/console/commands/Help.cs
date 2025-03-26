namespace Kobyla.commands;

public class Help : Command
{
    public Help(Game game, ConsoleUI consoleUI) : base(game, consoleUI)
    {
    }

    public override void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine();
        }
    }
}