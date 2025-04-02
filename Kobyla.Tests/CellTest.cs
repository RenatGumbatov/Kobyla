using Kobyla.area;

namespace Kobyla;

public class CellTest
{
    [Test]
    public void Test1()
    {
        var point = new Point(0,0);
        var neighbors = point.GetPointsNeighbours();
        Assert.That(neighbors, Has.Length.EqualTo(8));
    }

    [Test]
    public void Test2()
    {
        var point = new Point(1,1);
        var neighbors = point.GetPointsNeighbours();
        Assert.That(neighbors, Does.Contain(new Point(0,0)));
        Assert.That(neighbors, Does.Contain(new Point(1,0)));
        Assert.That(neighbors, Does.Contain(new Point(2,0)));
        Assert.That(neighbors, Does.Contain(new Point(0,1)));
        Assert.That(neighbors, Does.Contain(new Point(2,1)));
        Assert.That(neighbors, Does.Contain(new Point(0,2)));
        Assert.That(neighbors, Does.Contain(new Point(1,2)));
        Assert.That(neighbors, Does.Contain(new Point(2,2)));
    }
}