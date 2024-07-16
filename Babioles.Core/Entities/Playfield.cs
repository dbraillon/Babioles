namespace Babioles.Entities;

public class Playfield
{
    public int Height { get; }
    public int Width { get; }
    public Color[,] Squares { get; }

    public static Playfield Create() => new(22, 10);

    protected Playfield(int height, int width)
    {
        Height = height;
        Width = width;
        Squares = new Color[width, height];

        for (var x = 0; x < Width; x++)
        {
            for (var y = 0; y < Height; y++)
            {
                Squares[x, y] = Color.Gray;
            }
        }
    }

    public bool IsEmpty(Position position)
    {
        return Squares[position.X, position.Y] == Color.Gray;
    }

    public bool IsOut(Position position)
    {
        return
            position.X < 0 || position.X >= Width ||
            position.Y < 0 || position.Y >= Height;
    }

    public bool IsOutOrNotEmpty(Position position)
    {
        return IsOut(position) || !IsEmpty(position);
    }

    public void Lock(Babiole babiole)
    {
        Squares[babiole.Square1.Position.X, babiole.Square1.Position.Y] = babiole.Square1.Color;
        Squares[babiole.Square2.Position.X, babiole.Square2.Position.Y] = babiole.Square2.Color;
        Squares[babiole.Square3.Position.X, babiole.Square3.Position.Y] = babiole.Square3.Color;
        Squares[babiole.Square4.Position.X, babiole.Square4.Position.Y] = babiole.Square4.Color;
    }

    public int ClearCompletedLines()
    {
        var count = 0;

        for (var y = 0; y < Height; y++)
        {
            var lineCleared = true;

            for (var x = 0; x < Width; x++)
            {
                if (Squares[x, y] == Color.Gray)
                {
                    lineCleared = false;
                    break;
                }
            }

            if (lineCleared)
            {
                count++;

                for (var yy = y; yy >= 0; yy--)
                {
                    for (var x = 0; x < Width; x++)
                    {
                        Squares[x, yy] = yy == 0 ? Color.Gray : Squares[x, yy - 1];
                    }
                }
            }
        }

        return count;
    }
}
