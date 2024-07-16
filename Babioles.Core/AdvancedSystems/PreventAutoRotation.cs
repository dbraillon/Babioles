using Babioles.Entities;

namespace Babioles.AdvancedSystems;

/// <summary>
/// A system that prevents rotations to perform too quickly.
/// </summary>
/// <param name="SuperRotationSystem">Babiole's super rotation system.</param>
public class PreventAutoRotation(SuperRotationSystem SuperRotationSystem)
{
    private bool HoldRotate { get; set; } = false;

    public bool TryRotate(Babiole babiole, Instructions instructions)
    {
        return instructions switch
        {
            var type when type.HasFlag(Instructions.A) => TryRotateAnticlockwise(babiole),
            var type when type.HasFlag(Instructions.B) => TryRotateClockwise(babiole),
            _ => Reset()
        };
    }

    public bool TryRotateClockwise(Babiole babiole)
    {
        if (!HoldRotate)
        {
            HoldRotate = true;

            return SuperRotationSystem.TryRotateClockwise(babiole);
        }

        return true;
    }

    public bool TryRotateAnticlockwise(Babiole babiole)
    {
        if (!HoldRotate)
        {
            HoldRotate = true;

            return SuperRotationSystem.TryRotateAnticlockwise(babiole);
        }

        return true;
    }

    public bool Reset()
    {
        HoldRotate = false;

        return true;
    }
}
