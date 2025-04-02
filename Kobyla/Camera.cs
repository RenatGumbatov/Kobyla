using System.Text;
using Kobyla.area;
using Kobyla.cells;

namespace Kobyla;

public class Camera(Game game)
{
    public String FogOfWarString(int x, int y, int width, int height)
    {
        var pointsToShow = PaintBucketTool(new Point(x,y), game.CurrentMap.Cells, width, height);
        IncreaseBorder(pointsToShow);
        return HashSetToString(pointsToShow, new Point(x, y), game.CurrentMap.Cells, width, height);
    }

    public HashSet<Point> PaintBucketTool(Point point, Cell[,] map, int width, int height)
    {
        var result = new HashSet<Point>();
        var toCheck = new HashSet<Point>();
        var pointsChecked = new HashSet<Point>();
        
        var startPoint = new Point(point.X - width / 2, point.Y - height / 2);
        
        var pointCell = (Terrain) map[point.X, point.Y];
        var cellHeight = pointCell.Height;
        result.Add(point);
        pointsChecked.Add(point);

        do
        {
            toCheck.Clear();
            foreach (var p in result)
            {
                foreach (var neighbour in p.GetPointsNeighbours())
                {
                    if (neighbour.X < 0 || neighbour.Y < 0) continue;
                    if (neighbour.X < startPoint.X || neighbour.Y < startPoint.Y) continue;
                    if (neighbour.X >= width+startPoint.X  || neighbour.Y >= height+startPoint.Y) continue;
                    if (neighbour.X >= game.CurrentMap.Width || neighbour.Y >= game.CurrentMap.Height) continue; // Disable for tests
                    if (!pointsChecked.Contains(neighbour)) toCheck.Add(neighbour);
                }
            }

            foreach (var p in toCheck)
            {
                if(ReferenceEquals(null, map[p.X, p.Y])) continue;
                if (map[p.X, p.Y] is not Terrain)
                {
                    pointsChecked.Add(p);
                    continue;
                }
                var cell = (Terrain) map[p.X, p.Y];
                pointsChecked.Add(p);
                if (cellHeight >= cell.Height)
                    result.Add(p);
            }
        } while (toCheck.Count > 0);
        return result;
    }

    private void IncreaseBorder(HashSet<Point> points)
    {
        var pointsToAdd = new HashSet<Point>();
        foreach (var p in points)
        {
            foreach (var neighbour in p.GetPointsNeighbours())
            {
                if (neighbour.X < 0 || neighbour.Y < 0) continue;
                if (neighbour.X >= game.CurrentMap.Width || neighbour.Y >= game.CurrentMap.Height) continue;
                pointsToAdd.Add(neighbour);
            }
        }
        points.UnionWith(pointsToAdd);
    }

    // Generated via ChatGPT
    private string HashSetToString(HashSet<Point> points, Point center, Cell[,] map, int width, int height)
    {
        StringBuilder sb = new StringBuilder();
    
        int startX = center.X - width / 2;
        int startY = center.Y - height / 2;
    
        for (int y = startY; y < startY + height; y++)
        {
            for (int x = startX; x < startX + width; x++)
            {
                if (points.Contains(new Point(x, y)))
                { 
                    sb.Append(map[x, y].GetSymbol());
                }
                else if (x < -1 || y < -1 || x > game.CurrentMap.Width || y > game.CurrentMap.Height)
                {
                    sb.Append('$');
                }
                else
                {
                    sb.Append(' '); // Hide non-matching cells
                }
            }
            sb.AppendLine();
        }
    
        return sb.ToString();
    }
}