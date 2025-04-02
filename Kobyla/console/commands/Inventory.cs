namespace Kobyla.commands;

public class Inventory : Command
{
    public Inventory(Game game) : base(game)
    {
        PossibleAmountOfArguments.Add(0);
        HelpText = "Lists all inventory items.";
    }

    public static readonly string[] KeyWords = ["Inventory", "i"];
    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
        Game.ConsoleUI.Messages.AddMessage(new Message(Game.Player.Inventory.ToString(), 100));
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}