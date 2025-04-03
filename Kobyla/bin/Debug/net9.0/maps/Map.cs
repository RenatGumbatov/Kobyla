using System.Text.RegularExpressions;
using Kobyla.area;
using Kobyla.cells;
using Kobyla.commands;
using Kobyla.units;
using Inventory = Kobyla.inventory.Inventory;

namespace Kobyla.maps
{
    public class Map : IOnAreaCollision
    {
        private string _filePath;
        private readonly Game _game;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Cell[,] Cells { private set; get; }
        public List<Unit> Units = [];
        public Dictionary<Area, String> TeleportAreas = [];

        public Map(string filePath, Game game)
        {
            _filePath = filePath;
            _game = game;
            Cells = null!;
        }

        public void Init()
        {
            ReadFile(_filePath);
        }

        public void ReadFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var beginLine = 0;
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (Regex.IsMatch(line, @"areaToNextMap=[\d]+,[\d]+,[\d]+,[\d]+;mapName=[a-zA-Z0-9]+[.]txt"))
                {
                    var variables = line.Split(';');
                    var stringsCoords = variables[0].Split('=')[1].Split(',');
                    var mapName = variables[1].Split('=')[1];
                    Point p1 = new Point(int.Parse(stringsCoords[0]), int.Parse(stringsCoords[1]));
                    Point p2 = new Point(int.Parse(stringsCoords[2]), int.Parse(stringsCoords[3]));
                    Area area = new Area(_game, new Rectangle(p1,p2), null, this);
                    TeleportAreas.Add(area, mapName);
                }

                if (char.IsDigit(line[0]))
                {
                    beginLine = i;
                    break;
                }
            }

            ReadMapData(lines, beginLine);
        }

        private void ReadMapData(string[] lines, int linesBeforeMap)
        {
            Cell lastCell = null!;
            
            Height = lines.Length-linesBeforeMap;
            Width = lines[linesBeforeMap].Length; 
            Cells = new Cell[Width, Height];

            for (int y = 0; y < Height; y++)
            {
                var line = lines[y+linesBeforeMap];
                for (int x = 0; x < Width; x++)
                {
                    Cells[x, y] = CreateCell(line[x], lastCell, new Point(x, y));
                    lastCell = Cells[x, y];
                }
            }
        }

        private Cell CreateCell(char c, Cell backupCell, Point unitPosition)
        {
            Cell cell = null!;
            if (char.IsDigit(c))
            {
                cell = new Terrain(c - '0');
            }
            switch (c)
            {
                case Player.Symbol:
                {
                    cell = backupCell.GetCopy();
                    var player = new Player(unitPosition, new Inventory(_game), _game);
                    cell.Unit = player;
                    Units.Add(player);
                    _game.Player = player;
                    break;
                }
                case Wall.Symbol:
                    cell = new Wall();
                    break;
                case Deer.Symbol:
                    cell = backupCell.GetCopy();
                    var deer = new Deer(unitPosition, _game);
                    cell.Unit = deer;
                    Units.Add(deer);
                    break;
            }
            return cell;
        }

        public override string ToString()
        {
            var output = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    output += Cells[x, y].GetSymbol() ;
                }
                output += "\n";
            }
            return output;
        }

        public void OnAreaCollision(Area area, List<Unit> unitsCollidedWith)
        {
            
            var nextLevel = TeleportAreas[area];
            if (nextLevel == "map4.txt ") _game.Win("You got back to the stables!");

            _game.CurrentMap = new Map("maps/" + nextLevel, _game);
            _game.CurrentMap.Init();
        }

        public void CheckCollision()
        {
            foreach (var area in TeleportAreas.Keys)
            {
                area.Update();
            }
        }
    }
}