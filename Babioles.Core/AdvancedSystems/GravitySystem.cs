using Babioles.Entities;

namespace Babioles.AdvancedSystems;

/// <summary>
/// The gravity system determines how and when the Babiole move down the playfield. There are three types of drops:<br/>
/// - Natural Gravity: This is the default behavior where pieces fall one row at a time at a constant rate.<br/>
/// - Soft Drop: Players can accelerate the fall of the Babiole by holding down a specific key. This allows for faster placement of pieces but still follows the natural gravity rules.<br/>
/// - Hard Drop: This instantly drops the Tetrimino to the bottom of the playfield. It’s a quick way to place pieces but doesn’t allow for any adjustments once the piece starts falling.
/// </summary>
/// <param name="Playfield">The playfield.</param>
/// <param name="SuperMoveSystem">Babiole's move system.</param>
/// <param name="G">
/// G stands for Gravity. Gravity determines how quickly the Babioles descend on the playfield. It’s measured in units of G, where:<br/>
/// - 1G means the piece moves down one cell per frame.<br/>
/// - 0.1G means the piece moves down one cell every 10 frames.<br/>
/// For example, with 60 FPS, 0,01667G means the piece moves down one cell per second.
/// </param>
public class GravitySystem(
    Playfield Playfield, 
    SuperMoveSystem SuperMoveSystem,
    float G = 0.01667f)
{
    private float Counter { get; set; } = 0f;
    private bool HoldHardDrop { get; set; } = false;

    public void SetG(float g) => G = g;

    public bool TryFall(Babiole babiole, Instructions instructions)
    {
        return instructions switch
        {
            var type when type.HasFlag(Instructions.Up) && !HoldHardDrop => TryHardDrop(babiole),
            var type when type.HasFlag(Instructions.Up) && HoldHardDrop => TryDrop(babiole),
            var type when type.HasFlag(Instructions.Down) && !HoldHardDrop => TrySoftDrop(babiole),
            var type when type.HasFlag(Instructions.Down) && HoldHardDrop => TryDrop(babiole),
            _ => TryDropAndReset(babiole)
        };
    }

    public bool TryDropAndReset(Babiole babiole)
    {
        HoldHardDrop = false;

        return TryDrop(babiole);
    }

    public bool TryDrop(Babiole babiole)
    {
        Counter += G;

        return TryMoveDown(babiole);
    }

    public bool TrySoftDrop(Babiole babiole)
    {
        Counter += 20 * G;

        return TryMoveDown(babiole);
    }

    public bool TryHardDrop(Babiole babiole)
    {
        HoldHardDrop = true;
        Counter += Playfield.Height;

        return TryMoveDown(babiole);
    }

    private bool TryMoveDown(Babiole babiole)
    {
        if (Counter >= 1f)
        {
            var count = (int)(Counter / 1f);

            Counter = 0f;

            for (var i = 0;  i < count; i++)
            {
                if (!SuperMoveSystem.TryFall(babiole))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
