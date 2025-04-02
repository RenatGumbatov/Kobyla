using Kobyla.units;

namespace Kobyla.commands.horseCommands;

public class Spur : Command
{
    public Spur(Game game) : base(game)
    {
        PossibleAmountOfArguments.Add(1);
        HelpText = "Spurs the horse to suggest a direction. Increases stress. Args: Left (l), Right (r), Both (b)";
    }
    
    public static readonly string[] KeyWords = ["Spur", "S"];
    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
        var direction = args[0].Trim();
        if (direction is "l" or "left")
            Game.Player.Horse.Spur(Direction.Left);
        if (direction is "r" or "right") 
            Game.Player.Horse.Spur(Direction.Right);
        if (direction is "b" or "both")
            Game.Player.Horse.Spur(Direction.None);
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}