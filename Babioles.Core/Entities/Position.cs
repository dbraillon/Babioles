namespace Babioles.Entities;

public readonly struct Position(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public Position Left()
    {
        return new Position(X - 1, Y);
    }

    public Position Right()
    {
        return new Position(X + 1, Y);
    }

    public Position Up()
    {
        return new Position(X, Y - 1);
    }

    public Position Down()
    {
        return new Position(X, Y + 1);
    }
}
