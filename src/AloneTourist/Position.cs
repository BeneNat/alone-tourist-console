namespace AloneTourist;

public class Position
{
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Position Move(Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Position(X, Y - 1),
            Direction.Down => new Position(X, Y + 1),
            Direction.Left => new Position(X - 1, Y),
            Direction.Right => new Position(X + 1, Y),
            _ => this
        };
    }

    public override bool Equals(object obj) => obj is Position p && p.X == X && p.Y == Y;
    public override int GetHashCode() => HashCode.Combine(X, Y);
    public override string ToString() => $"({X}, {Y})";
}