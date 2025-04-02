using Kobyla.units;

namespace Kobyla.commands.horseCommands;

public class PullReigns : Command
{
    public PullReigns(Game game) : base(game)
    {
        PossibleAmountOfArguments.Add(1);
        HelpText = "Turns the horse to direction. Increases stress. Args: left (l), right (r), both (b)";
    }
    public static readonly string[] KeyWords = ["PullReigns", "Pull", "R"];

    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
        var direction = args[0].Trim();
        if (direction is "l" or "left")
            Game.Player.Horse.PullReigns(Direction.Left);
        if (direction is "r" or "right") 
            Game.Player.Horse.PullReigns(Direction.Right);
        if (direction is "b" or "both")
            Game.Player.Horse.PullReigns(Direction.None);
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}