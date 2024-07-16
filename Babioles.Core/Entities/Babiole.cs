namespace Babioles.Entities;

public abstract class Babiole
{
    public abstract Color Color { get; }
    public abstract Shape Shape { get; }

    public Direction Direction { get; protected set; }
    public Position Position { get; protected set; }

    public Square Square1 { get; }
    public Square Square2 { get; }
    public Square Square3 { get; }
    public Square Square4 { get; }

    public static Babiole Create(Shape shape, Position position)
    {
        return shape switch
        {
            Shape.I => new BabioleI(position),
            Shape.J => new BabioleJ(position),
            Shape.L => new BabioleL(position),
            Shape.O => new BabioleO(position),
            Shape.S => new BabioleS(position),
            Shape.T => new BabioleT(position),
            Shape.Z => new BabioleZ(position),
            _ => throw new NotImplementedException(shape.ToString())
        };
    }

    protected Babiole(Position position)
    {
        Position = position;
        Square1 = new(Color);
        Square2 = new(Color);
        Square3 = new(Color);
        Square4 = new(Color);

        FaceUp();
    }

    public abstract void FaceUp();
    public abstract void FaceRight();
    public abstract void FaceDown();
    public abstract void FaceLeft();

    public void Face(Direction direction)
    {
        if (direction == Direction.Up) FaceUp();
        else if (direction == Direction.Right) FaceRight();
        else if (direction == Direction.Down) FaceDown();
        else if (direction == Direction.Left) FaceLeft();
        else throw new NotImplementedException(direction.ToString());
    }

    public void MoveUp()
    {
        Position = Position.Up();

        Square1.Position = Square1.Position.Up();
        Square2.Position = Square2.Position.Up();
        Square3.Position = Square3.Position.Up();
        Square4.Position = Square4.Position.Up();
    }

    public void MoveRight()
    {
        Position = Position.Right();

        Square1.Position = Square1.Position.Right();
        Square2.Position = Square2.Position.Right();
        Square3.Position = Square3.Position.Right();
        Square4.Position = Square4.Position.Right();
    }

    public void MoveDown()
    {
        Position = Position.Down();

        Square1.Position = Square1.Position.Down();
        Square2.Position = Square2.Position.Down();
        Square3.Position = Square3.Position.Down();
        Square4.Position = Square4.Position.Down();
    }

    public void MoveLeft()
    {
        Position = Position.Left();

        Square1.Position = Square1.Position.Left();
        Square2.Position = Square2.Position.Left();
        Square3.Position = Square3.Position.Left();
        Square4.Position = Square4.Position.Left();
    }

    public bool Overlaps(Playfield playfield)
    {
        return
            playfield.IsOutOrNotEmpty(Square1.Position) ||
            playfield.IsOutOrNotEmpty(Square2.Position) ||
            playfield.IsOutOrNotEmpty(Square3.Position) ||
            playfield.IsOutOrNotEmpty(Square4.Position);
    }
}
