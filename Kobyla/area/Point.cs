using Kobyla.units;

namespace Kobyla.area;

public struct Point(int x, int y) : IEquatable<Point>
{
    public int X = x, Y = y;

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
    
    public Point[] GetPointsNeighbours()
    {
        Point[] neighbours = new Point[8];
        neighbours[0] = new Point(x-1, y-1);
        neighbours[1] = new Point(x-1, y);
        neighbours[2] = new Point(x-1, y+1);
        neighbours[3] = new Point(x, y-1);
        neighbours[4] = new Point(x, y+1);
        neighbours[5] = new Point(x+1, y-1);
        neighbours[6] = new Point(x+1, y);
        neighbours[7] = new Point(x+1, y+1);
        return neighbours;
    }

    public Point moveToDirection(Direction direction)
    {
        var newPosition = GetCopy();
        switch (direction)
        {
            case Direction.Right:
                newPosition.X += 1;
                break;
            case Direction.Down:
                newPosition.Y += 1;
                break;
            case Direction.Left:
                newPosition.X += -1;
                break;
            case Direction.Up:
                newPosition.Y += -1;
                break;
        }
        return newPosition;
    }

    public Point GetCopy()
    {
        return new Point(X, Y);
    }

    private sealed class XYEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point x, Point y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public int GetHashCode(Point obj)
        {
            return HashCode.Combine(obj.X, obj.Y);
        }
    }

    public static IEqualityComparer<Point> XYComparer { get; } = new XYEqualityComparer();

    public bool Equals(Point other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}