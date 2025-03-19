namespace Kobyla.commands;

public abstract class Command
{
    protected ConsoleUI ConsoleUI;
    protected Game Game;
    protected Command(Game game, ConsoleUI consoleUI)
    {
        Game = game;
        ConsoleUI = consoleUI;
    }

    public abstract void Execute(string[] args);
}