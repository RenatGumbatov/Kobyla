namespace Kobyla.units;

public enum Direction
{
    Right,
    Down,
    Left,
    Up,
    None
}

public static class DirectionExtensions
{
    public static Direction GetLeftDirection(Direction turnningDirection)
    {
        switch (turnningDirection)
        {
            case Direction.Right:
                return Direction.Up;
            case Direction.Up:
                return Direction.Left;
            case Direction.Left:
                return Direction.Down;
            case Direction.Down:
                return Direction.Right;
            case Direction.None:
                return Direction.None;
        }
        throw new Exception("Invalid direction");
    }
    
    public static Direction GetRightDirection(Direction turnningDirection)
    {
        switch (turnningDirection)
        {
            case Direction.Right:
                return Direction.Down;
            case Direction.Up:
                return Direction.Right;
            case Direction.Left:
                return Direction.Up;
            case Direction.Down:
                return Direction.Left;
            case Direction.None:
                return Direction.None;
        }
        throw new Exception("Invalid direction");
    }
}