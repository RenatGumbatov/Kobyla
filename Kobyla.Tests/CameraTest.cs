using System.Collections.ObjectModel;
using Kobyla.area;
using Kobyla.cells;

namespace Kobyla;

public class CameraTest
{

    [Test]
    public void Test1()
    {
        /* Map
         * 11111
         * 11111
         * 11111
         * 11111
         * 11111
         *
         * Result
         * 11111
         * 11111
         * 11111
         * 11111
         * 11111
         */
        var cells = new Cell[5,5];
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                cells[x, y] = new Terrain(1);
            }
        }
        var expectation = new HashSet<Point>();
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                expectation.Add(new Point(x, y));
            }
        }
        Camera camera = new Camera(null);
        var result = camera.PaintBucketTool(new Point(0,0), cells, 5,5);
        Assert.That(result.SetEquals(expectation));
    }

    [Test]
    public void Test2()
    {
        /* Map
         * 11122
         * 11222
         * 12222
         * 22222
         * 22222
         *
         * Result
         * 111
         * 11
         * 1
         *
         * 
         */
        
        var cells = new Cell[5,5];
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                cells[x, y] = new Terrain(2);
            }
        }
        cells[0,0] = new Terrain(1);
        cells[1,0] = new Terrain(1);
        cells[2,0] = new Terrain(1);
        cells[0,1] = new Terrain(1);
        cells[1,1] = new Terrain(1);
        cells[0,2] = new Terrain(1);
        var expectation = new HashSet<Point>();
        expectation.Add(new Point(0,0));
        expectation.Add(new Point(1,0));
        expectation.Add(new Point(2,0));
        expectation.Add(new Point(0,1));
        expectation.Add(new Point(1,1));
        expectation.Add(new Point(0,2));
        Camera camera = new Camera(null);
        var result = camera.PaintBucketTool(new Point(0,0), cells, 5,5);
        Assert.That(result.SetEquals(expectation));
    }
    
    [Test]
    public void Test3()
    {
        /* Map
         * 6666666
         * 6661666
         * 6611166
         * 6661666
         * 6666666
         *
         * Result
         *  1
         * 111
         *  1
         */
        
        var cells = new Cell[100,50];
        for (int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                cells[x, y] = new Terrain(6);
            }
        }
        cells[25,25] = new Terrain(1);
        cells[26,25] = new Terrain(1);
        cells[24,25] = new Terrain(1);
        cells[25,26] = new Terrain(1);
        cells[25,24] = new Terrain(1);
        var expectation = new HashSet<Point>();
        expectation.Add(new Point(25,25));
        expectation.Add(new Point(26,25));
        expectation.Add(new Point(24,25));
        expectation.Add(new Point(25,26));
        expectation.Add(new Point(25,24));
        Camera camera = new Camera(null);
        var result = camera.PaintBucketTool(new Point(25,25), cells, 100,50);
        Assert.That(result.SetEquals(expectation));
    }

    private static string ToStringCellArray(Cell[,] cells, int width, int height)
    {
        var output = "";
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                output += cells[x, y].GetSymbol() ;
            }
            output += "\n";
        }
        return output;
    }
}