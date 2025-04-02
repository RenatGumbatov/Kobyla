using Kobyla.area;

namespace Kobyla.commands;

public class Teleport : Command
{
    public static readonly string[] KeyWords = ["t", "teleport"];
    public Teleport(Game game) : base(game)
    {
        HelpText = "Teleports to given position. Arguments: int x, int y";
        PossibleAmountOfArguments.Add(2);
    }

    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
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

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}