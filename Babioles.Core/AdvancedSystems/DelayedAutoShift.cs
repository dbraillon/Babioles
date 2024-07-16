using Babioles.Entities;

namespace Babioles.AdvancedSystems;

/// <summary>
/// Delayed Auto Shift or DAS refers to the mechanism that controls how pieces move sideways when you hold down the left or right key.<br/>
/// This feature helps players control the movement of pieces more precisely, especially at higher speeds.
/// </summary>
/// <param name="SuperMoveSystem">Babiole's move system.</param>
/// <param name="InitialDelay">The delay before the piece starts moving continuously.</param>
/// <param name="AutoShiftDelay">The delay between two moves when auto shift is on.</param>
public class DelayedAutoShift(
    SuperMoveSystem SuperMoveSystem, 
    int InitialDelay = 10, 
    int AutoShiftDelay = 2)
{
    private int InitialDelayCounter { get; set; } = 0;
    private int AutoShiftDelayCounter { get; set; } = 0;
    private bool HoldDownLeft { get; set; } = false;
    private bool HoldDownRight { get; set; } = false;

    public bool TryShift(Babiole babiole, Instructions instructions)
    {
        return instructions switch
        {
            var type when type.HasFlag(Instructions.Left) => TryShiftLeft(babiole),
            var type when type.HasFlag(Instructions.Right) => TryShiftRight(babiole),
            _ => Reset()
        };
    }

    public bool TryShiftLeft(Babiole babiole)
    {
        HoldDownRight = false;
        var result = TryShift(babiole, HoldDownLeft, SuperMoveSystem.TryShiftLeft);
        HoldDownLeft = true;
        return result;
    }

    public bool TryShiftRight(Babiole babiole)
    {
        HoldDownLeft = false;
        var result = TryShift(babiole, HoldDownRight, SuperMoveSystem.TryShiftRight);
        HoldDownRight = true;
        return result;
    }

    private bool TryShift(Babiole babiole, bool holdDownLeftOrRight, Func<Babiole, bool> tryShiftFunc)
    {
        if (holdDownLeftOrRight)
        {
            if (InitialDelayCounter <= 0)
            {
                if (AutoShiftDelayCounter <= 0)
                {
                    AutoShiftDelayCounter = AutoShiftDelay;

                    return tryShiftFunc.Invoke(babiole);
                }
                else
                {
                    AutoShiftDelayCounter--;

                    return false;
                }
            }
            else
            {
                InitialDelayCounter--;

                return false;
            }
        }
        else
        {
            InitialDelayCounter = InitialDelay;

            return tryShiftFunc.Invoke(babiole);
        }
    }

    public bool Reset()
    {
        InitialDelayCounter = 0;
        AutoShiftDelayCounter = 0;
        HoldDownLeft = false;
        HoldDownRight = false;
        return true;
    }
}
