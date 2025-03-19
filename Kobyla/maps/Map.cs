using System.Text.RegularExpressions;
using Kobyla.area;
using Kobyla.cells;
using Kobyla.inventory;
using Kobyla.units;

namespace Kobyla.maps
{
    public class Map
    {
        private readonly string _filePath;
        private readonly Game _game;
        private int _width, _height;
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
                    Area area = new Area(new Rectangle(p1,p2), AreaType.TeleportArea);
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
            
            _height = lines.Length-linesBeforeMap;
            _width = lines[linesBeforeMap].Length; 
            Cells = new Cell[_width, _height];

            for (int y = 0; y < _height; y++)
            {
                var line = lines[y+linesBeforeMap];
                for (int x = 0; x < _width; x++)
                {
                    Cells[x, y] = CreateCell(line[x], lastCell, new Point(x, y));
                    lastCell = Cells[x, y];
                }
            }
        }

        private Cell CreateCell(char c, Cell backupCell, Point playerPosition)
        {
            Cell cell = null!;
            if (char.IsDigit(c))
            {
                cell = new Terrain(int.Parse(c.ToString()));
            }
            else if (c == 'P')
            {
                cell = backupCell.GetCopy();
                Player player = new Player(playerPosition, new Inventory(), _game);
                cell.Unit = player;
                Units.Add(player);
                _game.Player = player;
            }
            return cell ?? throw new InvalidOperationException();
        }

        public string ZoomedInString(int x, int y, int width, int height)
        {
            var output = "";
            for (int i = y; i < height+y; i++)
            {
                for (int j = x; j < width+x; j++)
                {
                    if (IsInRange(j, 0, _width-1) && IsInRange(i, 0, _height-1))
                    {
                        output += Cells[j, i].GetSymbol();
                    }
                    else
                    {
                        output += " ";
                    }
                }

                output += Environment.NewLine;
            }
            return output;
        }

        public override string ToString()
        {
            var output = "";
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    output += Cells[x, y].GetSymbol() ;
                }
                output += "\n";
            }
            return output;
        }

        public static bool IsInRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}