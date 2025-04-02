namespace Kobyla.commands;

public abstract class Command
{
    protected Game Game;
    protected List<int> PossibleAmountOfArguments;
    public string HelpText = "Help Text not written yet";

    protected Command(Game game)
    {
        Game = game;
        PossibleAmountOfArguments = [];
    }

    public abstract void Execute(string[] args);

    protected bool AmountOfArgumentsWarning(int amountOfArguments, string[] commandKeyWords)
    {
        if (PossibleAmountOfArguments.Contains(amountOfArguments)) return false;
        Game.ConsoleUI.Messages.AddMessage(new Message("!ERROR! Command ["+commandKeyWords.ToStringArray()+"] can have ["+PossibleAmountOfArguments.ToStringList()+"] amount of arguments", 50));
        return true;
    }
    
    public abstract string[] getKeyWords();
}

public static class ListExtensions
{
    public static string ToStringList<T>(this List<T> list, string separator = ", ")
    {
        return string.Join(separator, list);
    }
}

public static class StringArrayExtensions
{
    public static string ToStringArray(this string[] array, string separator = ", ")
    {
        return string.Join(separator, array);
    }
}