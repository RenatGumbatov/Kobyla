namespace Kobyla.commands;

public class Inventory(Game game, ConsoleUI consoleUI) : Command(game, consoleUI)
{
    public override void Execute(string[] args)
    {
        consoleUI.Messages.AddMessage(new Message(game.Player.Inventory.ToString(), 1000));
    }
}