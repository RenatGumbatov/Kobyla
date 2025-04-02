namespace Kobyla.commands;

public class Exit : Command
{
    public Exit(Game game) : base(game)
    {
        HelpText = "Exits the game.";
    }

    public static readonly string[] KeyWords = {"exit"};
    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
        Environment.Exit(0);
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}