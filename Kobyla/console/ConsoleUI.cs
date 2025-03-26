using System.Diagnostics;

namespace Kobyla.commands;

public class ConsoleUI
{
    private readonly Dictionary<string, Command> _commands = new();
    public readonly Messages Messages = new();

    private void InitCommands(Game game)
    {
        _commands.Add("exit", new Exit(game, this));
        _commands.Add("move", new Move(game, this));
        _commands.Add("inventory", new Inventory(game, this));
        _commands.Add("teleport", new Teleport(game, this));
    }
    public void Start()
    {
        Game game = new Game(this);
        Camera camera = new Camera(game);
        
        InitCommands(game);
        while (true) // Game loop
        {
            game.Update();
            Console.WriteLine(camera.ZoomedInString(game.Player.Position.X, game.Player.Position.Y,120,30));
            Console.WriteLine(Messages);
            Messages.Update();
            Console.Write(">>");
            var line = "";
            if (Console.KeyAvailable)
            {
                ClearCurrentConsoleLine();
                Console.WriteLine("!!! PAUSED !!!");
                Console.Write(">>"); 
                line = Console.ReadLine();
            }
            ReadCommand(line);
            Thread.Sleep(16);
            Console.Clear();
        }
    }

    private void ReadCommand(string? line)
    {
        if (line is "" or null) return;
        var splitLine = line.Split(" ");
        var commandName = splitLine[0].Trim();
        var args = splitLine[1..];
        if (!_commands.TryGetValue(commandName, out var command)) return;
        command.Execute(args);
    }
    
    private void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write(" ");
        Console.SetCursorPosition(0, currentLineCursor);
    }
}