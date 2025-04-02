namespace Kobyla.commands;

public class Help : Command
{
    public static readonly string[] KeyWords = {"Help"};
    public Help(Game game) : base(game)
    {
        PossibleAmountOfArguments.Add(0);
        PossibleAmountOfArguments.Add(1);
        HelpText = "";
    }

    public override void Execute(string[] args)
    {
        if (AmountOfArgumentsWarning(args.Length, KeyWords)) return;
        switch (args.Length)
        {
            case 0:
                var output = Environment.NewLine;
                foreach (var command in Game.ConsoleUI.Commands)
                {
                    if (command.Key.Equals(KeyWords)) continue;
                    output += "[" + command.Value.getKeyWords().ToStringArray() + "]: " + command.Value.HelpText + Environment.NewLine;
                }
                Game.ConsoleUI.Messages.AddMessage(new Message(output));
                break;
            case 1:
            {
                foreach (var command in Game.ConsoleUI.Commands)
                {
                    if (command.Key.Contains(args[0]))
                    {
                        Game.ConsoleUI.Messages.AddMessage(new Message("["+command.Value.getKeyWords().ToStringArray() + "]: " + command.Value.HelpText));
                    }
                }
                break;
            }
        }
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}