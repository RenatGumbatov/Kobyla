using System.Text;
using Kobyla.commands.horseCommands;

namespace Kobyla.commands;

public class ConsoleUI
{
    public readonly Dictionary<string[], Command> Commands = new();
    public readonly Messages Messages = new();

    private void InitCommands(Game game)
    {
        Commands.Add(Exit.KeyWords, new Exit(game));
        // Commands.Add(Move.KeyWords, new Move(game));
        Commands.Add(Inventory.KeyWords, new Inventory(game));
        // Commands.Add(Teleport.KeyWords, new Teleport(game));
        Commands.Add(Help.KeyWords, new Help(game));
        Commands.Add(Use.KeyWords, new Use(game));
        
        //Horse commands
        Commands.Add(HoldKnees.KeyWords, new HoldKnees(game));
        Commands.Add(PullReigns.KeyWords, new PullReigns(game));
        Commands.Add(ReleaseReigns.KeyWords, new ReleaseReigns(game));
        Commands.Add(Spur.KeyWords, new Spur(game));
    }
    public void Start()
    {
        var game = new Game(this);
        var camera = new Camera(game);
        
        InitCommands(game);
        while (true) // Game loop
        {
            game.Update();
            var toPrint = "";
            var cameraWidth = 120;
            var cameraHeight = 30;
            toPrint += camera.FogOfWarString(game.Player.Position.X, game.Player.Position.Y, cameraWidth, cameraHeight) + Environment.NewLine;
            Messages.AddMessage(new Message(game.Player.Horse.ToString(), 0, false));
            toPrint += Messages + Environment.NewLine;
            toPrint += ">> ";
            Messages.Update();
            FastConsolePrint(toPrint, cameraWidth, cameraHeight);
            var line = "";
            if (Console.KeyAvailable)
            {
                ClearCurrentConsoleLine();
                Console.WriteLine("!!! PAUSED !!!");
                Console.Write(">> "); 
                line = Console.ReadLine();
            }
            ReadCommand(line);
            Thread.Sleep(16);
        }
    }

    private void ReadCommand(string? line)
    {
        if (line is "" or null) return;
        var splitLine = line.Split(" ");
        var commandName = splitLine[0].Trim();
        var args = splitLine[1..];
        var success = false;
        foreach (var commands in Commands)
        {
            foreach (var commandKeyWord in commands.Key)
            {
                if (commandName.Equals(commandKeyWord, StringComparison.CurrentCultureIgnoreCase))
                {
                    success = true;
                    commands.Value.Execute(args);
                }
            }
        }

        if (!success)
        {
            Messages.AddMessage(new Message("No " + commandName + " command found."));
        }
    }
    
    private static void ClearCurrentConsoleLine()
    {
        var currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        for (int i = 0; i < Console.WindowWidth; i++)
            Console.Write(" ");
        Console.SetCursorPosition(0, currentLineCursor);
    }

    //https://stackoverflow.com/questions/29920056/c-sharp-something-faster-than-console-write
    private static void FastConsolePrint(string input, int width, int height)
    {
        //some sample text
        // byte[] buffer = Enumerable.Repeat((byte)'=', width * height).ToArray();
        byte[] buffer = Encoding.ASCII.GetBytes(input);
        //because output appends, ensure the window is reset
        Console.SetCursorPosition(0, 0);
        using Stream stdout = Console.OpenStandardOutput(width * height);
        Console.Clear();
        stdout.Write(buffer, 0, buffer.Length);
    }
}