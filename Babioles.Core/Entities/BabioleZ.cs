namespace Babioles.Entities;

public class BabioleZ(Position position) : Babiole(position)
{
    public override Color Color => Color.Red;
    public override Shape Shape => Shape.Z;

    public override void FaceUp()
    {
        Direction = Direction.Up;

        Square1.Position = Position.Up().Left();
        Square2.Position = Position.Up();
        Square3.Position = Position;
        Square4.Position = Position.Right();
    }

    public override void FaceRight()
    {
        Direction = Direction.Right;

        Square1.Position = Position.Right().Up();
        Square2.Position = Position.Right();
        Square3.Position = Position;
        Square4.Position = Position.Down();
    }

    public override void FaceDown()
    {
        Direction = Direction.Down;

        Square1.Position = Position.Down();
        Square2.Position = Position.Down().Right();
        Square3.Position = Position;
        Square4.Position = Position.Left();
    }

    public override void FaceLeft()
    {
        Direction = Direction.Left;

        Square1.Position = Position.Left().Down();
        Square2.Position = Position.Left();
        Square3.Position = Position;
        Square4.Position = Position.Up();
    }
}
