using Kobyla.area;

namespace Kobyla.commands;

public class Move : Command
{
    public static readonly string[] KeyWords = ["m", "move"];
    
    private readonly Game _game;

    public Move(Game game) : base(game)
    {
        _game = game;
        HelpText = "Moves";
        PossibleAmountOfArguments.Add(0);
    }

    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
        _game.Player.TeleportTo(new Point(_game.Player.Position.X+1, _game.Player.Position.Y));
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}