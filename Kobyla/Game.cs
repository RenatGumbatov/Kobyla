using Kobyla.commands;
using Kobyla.maps;
using Kobyla.units;

namespace Kobyla;

public class Game
{
    public Player Player;
    public Map CurrentMap;
    public int Frame;
    public ConsoleUI ConsoleUI { get; private set; }
    
    public bool Running = false;

    public Game(ConsoleUI consoleUI)
    {
        ConsoleUI = consoleUI;
        Player = null!;
        CurrentMap = new Map("maps/map1.txt", this);
        CurrentMap.Init();
    }

    public void Update()
    {
        Frame++;
        foreach (var unit in CurrentMap.Units)
        {
            unit.Update();
        }
        CurrentMap.CheckCollision(); // Teleport areas 
    }

    public void GameOver(String message)
    {
        Console.WriteLine("\n _____                        _____                \n|  __ \\                      |  _  |               \n| |  \\/ __ _ _ __ ___   ___  | | | |_   _____ _ __ \n| | __ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__|\n| |_\\ \\ (_| | | | | | |  __/ \\ \\_/ /\\ V /  __/ |   \n \\____/\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|   \n                                                   \n                                                   \n");
        Console.WriteLine(message);
        Environment.Exit(0);
    }

    public void Win(String message)
    {
        Console.WriteLine("\n /$$     /$$                        /$$      /$$ /$$           /$$\n|  $$   /$$/                       | $$  /$ | $$|__/          | $$\n \\  $$ /$$//$$$$$$  /$$   /$$      | $$ /$$$| $$ /$$ /$$$$$$$ | $$\n  \\  $$$$//$$__  $$| $$  | $$      | $$/$$ $$ $$| $$| $$__  $$| $$\n   \\  $$/| $$  \\ $$| $$  | $$      | $$$$_  $$$$| $$| $$  \\ $$|__/\n    | $$ | $$  | $$| $$  | $$      | $$$/ \\  $$$| $$| $$  | $$    \n    | $$ |  $$$$$$/|  $$$$$$/      | $$/   \\  $$| $$| $$  | $$ /$$\n    |__/  \\______/  \\______/       |__/     \\__/|__/|__/  |__/|__/\n                                                                  \n                                                                  \n                                                                  \n");
        Console.WriteLine(message);
        Environment.Exit(0);
    }
}