using Babioles.Entities;

namespace Babioles.AdvancedSystems;

/// <summary>
/// Super Move System refers to the mechanism that controls how pieces move and interact with the game field.
/// </summary>
/// <param name="Playfield">The playfield.</param>
public class SuperMoveSystem(
    Playfield Playfield)
{
    public bool TryFall(Babiole babiole)
    {
        babiole.MoveDown();

        if (babiole.Overlaps(Playfield))
        {
            babiole.MoveUp();
            return false;
        }

        return true;
    }

    public bool TryShiftLeft(Babiole babiole)
    {
        babiole.MoveLeft();

        if (babiole.Overlaps(Playfield))
        {
            babiole.MoveRight();
            return false;
        }

        return true;
    }

    public bool TryShiftRight(Babiole babiole)
    {
        babiole.MoveRight();

        if (babiole.Overlaps(Playfield))
        {
            babiole.MoveLeft();
            return false;
        }

        return true;
    }
}
