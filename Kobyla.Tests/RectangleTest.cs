using Kobyla.area;

namespace Kobyla;

public class RectangleTest
{
    [Test]
    public void Test1()
    {
        var rectangle = new Rectangle(new Point(0, 0), new Point(0, 0));
        var result = rectangle.GetPoints();
        var expectation = new List<Point>();
        expectation.Add(new Point(0, 0));
        Assert.That(result, Is.EqualTo(expectation));
    }

    [Test]
    public void Test2()
    {
        var rectangle = new Rectangle(new Point(0, 0), new Point(1, 1));
        var result = rectangle.GetPoints();
        var expectation = new List<Point>();
        expectation.Add(new Point(0, 0));
        expectation.Add(new Point(0, 1));
        expectation.Add(new Point(1, 0));
        expectation.Add(new Point(1, 1));

        Assert.That(result, Is.EqualTo(expectation));
    }

    [Test]
    public void Test3()
    {
        var rectangle = new Rectangle(new Point(0, 0), new Point(1, 0));
        var result = rectangle.IsInArea(new Point(0, 0));
        Assert.That(result, Is.True);
        result = rectangle.IsInArea(new Point(1, 0));
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Test4()
    {
        var rectangle = new Rectangle(new Point(10, 0), new Point(100, 0));
        var result = rectangle.IsInArea(new Point(0, 0));
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void Test5()
    {
        var rectangle = new Rectangle(new Point(10, 0), new Point(100, 0));
        var result = rectangle.IsInArea(new Point(100, 0));
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void Test6()
    {
        var rectangle = new Rectangle(new Point(10, 0), new Point(100, 1));
        var result = rectangle.IsInArea(new Point(99, 1));
        Assert.That(result, Is.True);
    }
}