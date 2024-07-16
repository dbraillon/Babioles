namespace Babioles.Entities;

public class BabioleI(Position position) : Babiole(position)
{
    public override Color Color => Color.Cyan;
    public override Shape Shape => Shape.I;

    public override void FaceUp()
    {
        Direction = Direction.Up;

        Square1.Position = Position.Left();
        Square2.Position = Position;
        Square3.Position = Position.Right();
        Square4.Position = Position.Right().Right();
    }

    public override void FaceRight()
    {
        Direction = Direction.Right;

        Square1.Position = Position.Right().Up();
        Square2.Position = Position.Right();
        Square3.Position = Position.Right().Down();
        Square4.Position = Position.Right().Down().Down();
    }

    public override void FaceDown()
    {
        Direction = Direction.Down;

        Square1.Position = Position.Down().Left();
        Square2.Position = Position.Down();
        Square3.Position = Position.Down().Right();
        Square4.Position = Position.Down().Right().Right();
    }

    public override void FaceLeft()
    {
        Direction = Direction.Left;

        Square1.Position = Position.Up();
        Square2.Position = Position;
        Square3.Position = Position.Down();
        Square4.Position = Position.Down().Down();
    }
}
