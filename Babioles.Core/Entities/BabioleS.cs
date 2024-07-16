namespace Babioles.Entities;

public class BabioleS(Position position) : Babiole(position)
{
    public override Color Color => Color.Green;
    public override Shape Shape => Shape.S;

    public override void FaceUp()
    {
        Direction = Direction.Up;

        Square1.Position = Position.Left();
        Square2.Position = Position;
        Square3.Position = Position.Up();
        Square4.Position = Position.Up().Right();
    }

    public override void FaceRight()
    {
        Direction = Direction.Right;

        Square1.Position = Position.Up();
        Square2.Position = Position;
        Square3.Position = Position.Right();
        Square4.Position = Position.Right().Down();
    }

    public override void FaceDown()
    {
        Direction = Direction.Down;

        Square1.Position = Position.Right();
        Square2.Position = Position;
        Square3.Position = Position.Down();
        Square4.Position = Position.Down().Left();
    }

    public override void FaceLeft()
    {
        Direction = Direction.Left;

        Square1.Position = Position.Down();
        Square2.Position = Position;
        Square3.Position = Position.Left();
        Square4.Position = Position.Left().Up();
    }
}
