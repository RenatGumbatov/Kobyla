namespace Kobyla.commands;

public class ConsoleUI
{
    private readonly Dictionary<string, Command> _commands = new();

    private void InitCommands(Game game)
    {
        _commands.Add("exit", new Exit(game));
        _commands.Add("move", new MoveToTeleportArea(game));
    }
    public void Start()
    {
        Game game = new Game();
        InitCommands(game);
        while (true)
        {
            Console.WriteLine(game.CurrentMap.ZoomedInString(game.GetPlayer().position.X,game.GetPlayer().position.Y,120,30));
            
            var line = "";
            if (Console.KeyAvailable)
            {
                line = Console.ReadLine();
            }
            
            // Read commands
            if (_commands.ContainsKey(line!.Trim()))
            {
                var command = _commands[line.Trim()];
                command.Execute();
            }
            game.Update();
            Thread.Sleep(16);
            Console.Clear();
        }
    }
}