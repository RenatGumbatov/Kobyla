namespace Kobyla.commands.horseCommands;

public class ReleaseReigns : Command
{
    public ReleaseReigns(Game game) : base(game)
    {
        PossibleAmountOfArguments.Add(0);
        HelpText = "Straightens the move direction. Decreases stress. Args: none";
    }
    public static readonly string[] KeyWords = ["ReleaseReigns", "Release", "RR"];
    public override void Execute(string[] args)
    {
        Game.Player.Horse.ReleaseReigns();
    }

    public override string[] getKeyWords()
    {
        return KeyWords;
    }
}