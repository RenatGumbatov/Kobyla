namespace Kobyla.commands.horseCommands;

public class HoldKnees : Command
{
    public HoldKnees(Game game) : base(game)
    {
        PossibleAmountOfArguments.Add(0);
        HelpText = "Grants immunity to sudden stops and bucking. Increases stress. Args: none";
    }

    public static readonly string[] KeyWords = ["HoldKnees", "hold", "h"];

    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}