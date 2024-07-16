using Babioles.Entities;

namespace Babioles.AdvancedSystems;

/// <summary>
/// Super Rotation System or SRS refers to the mechanism that controls how pieces rotate and interact with the game field.
/// </summary>
/// <param name="Playfield">The playfield.</param>
public class SuperRotationSystem(
    Playfield Playfield)
{
    public bool TryRotateClockwise(Babiole babiole)
    {
        var oldDirection = babiole.Direction;
        var nextDirection = babiole.Direction switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => throw new NotImplementedException(babiole.Direction.ToString())
        };

        babiole.Face(nextDirection);

        if (babiole.Overlaps(Playfield))
        {
            babiole.Face(oldDirection);
            return false;
        }

        return true;
    }

    public bool TryRotateAnticlockwise(Babiole babiole)
    {
        var oldDirection = babiole.Direction;
        var nextDirection = babiole.Direction switch
        {
            Direction.Up => Direction.Left,
            Direction.Right => Direction.Up,
            Direction.Down => Direction.Right,
            Direction.Left => Direction.Down,
            _ => throw new NotImplementedException(babiole.Direction.ToString())
        };

        babiole.Face(nextDirection);

        if (babiole.Overlaps(Playfield))
        {
            babiole.Face(oldDirection);
            return false;
        }

        return true;
    }
}
