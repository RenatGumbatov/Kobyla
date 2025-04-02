namespace Kobyla.commands;

public class Use : Command
{
    public Use(Game game) : base(game)
    {
        HelpText = "Uses an item from inventory. Args: itemName";
        PossibleAmountOfArguments.Add(1);
    }
    
    public static readonly string[] KeyWords = ["Use", "u"];

    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
        Game.Player.Inventory.UseItem(args[0]);
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}