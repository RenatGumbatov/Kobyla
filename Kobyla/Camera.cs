using Kobyla.commands;

namespace Kobyla;

public class Camera
{
    private Game game;
    private int zoomLevel;

    public Camera(Game game)
    {
        this.game = game;
    }

    public string ZoomedInString(int x, int y, int width, int height)
    {
        //Offset camera center
        x -= width / 2;
        y -= height / 2;
        //Get view
        var output = "";
        for (int i = y; i < height+y; i++)
        {
            for (int j = x; j < width+x; j++)
            {
                if (IsInRange(j, 0, game.CurrentMap.Width-1) && IsInRange(i, 0, game.CurrentMap.Height-1))
                {
                    output += game.CurrentMap.Cells[j, i].GetSymbol();
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

    private static bool IsInRange(int value, int min, int max)
    {
        return value >= min && value <= max;
    }
}