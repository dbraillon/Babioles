namespace Babioles.Entities;

public class BabioleO(Position position) : Babiole(position)
{
    public override Color Color => Color.Yellow;
    public override Shape Shape => Shape.O;

    public override void FaceUp()
    {
        Direction = Direction.Up;

        Square1.Position = Position.Up();
        Square2.Position = Position.Up().Right();
        Square3.Position = Position;
        Square4.Position = Position.Right();
    }

    public override void FaceRight()
    {
        Direction = Direction.Right;

        Square1.Position = Position.Up();
        Square2.Position = Position.Up().Right();
        Square3.Position = Position;
        Square4.Position = Position.Right();
    }

    public override void FaceDown()
    {
        Direction = Direction.Down;

        Square1.Position = Position.Up();
        Square2.Position = Position.Up().Right();
        Square3.Position = Position;
        Square4.Position = Position.Right();
    }

    public override void FaceLeft()
    {
        Direction = Direction.Left;

        Square1.Position = Position.Up();
        Square2.Position = Position.Up().Right();
        Square3.Position = Position;
        Square4.Position = Position.Right();
    }
}
