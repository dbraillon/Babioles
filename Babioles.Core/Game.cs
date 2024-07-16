using Babioles.AdvancedSystems;
using Babioles.Entities;

namespace Babioles;

/// <summary>
/// Represents a game of Babioles !
/// </summary>
public class Game
{
    public Playfield Playfield { get; private set; }
    public NextQueue NextQueue { get; private set; }
    public SuperMoveSystem SuperMoveSystem { get; private set; }
    public SuperRotationSystem SuperRotationSystem { get; private set; }
    public DelayedAutoShift DelayedAutoShift { get; private set; }
    public PreventAutoRotation PreventAutoRotation { get; private set; }
    public GravitySystem GravitySystem { get; private set; }
    public ScoringSystem ScoringSystem { get; private set; }
    public Babiole? Babiole { get; private set; }
    public bool HasEnded { get; private set; }

    public Game()
    {
        Playfield = Playfield.Create();
        NextQueue = new NextQueue();
        SuperMoveSystem = new SuperMoveSystem(Playfield);
        SuperRotationSystem = new SuperRotationSystem(Playfield);
        DelayedAutoShift = new DelayedAutoShift(SuperMoveSystem);
        PreventAutoRotation = new PreventAutoRotation(SuperRotationSystem);
        GravitySystem = new GravitySystem(Playfield, SuperMoveSystem);
        ScoringSystem = new ScoringSystem(GravitySystem);
    }

    public void Update(Instructions instructions)
    {
        if (HasEnded) return;

        GetNewBabioleIfNecessary();
        MakeBabioleShift(instructions);
        MakeBabioleRotate(instructions);
        if (MakeBabioleFall(instructions))
        {
            Score(CheckLineClear());
        }
        CheckBlockOut();
    }

    private void GetNewBabioleIfNecessary()
    {
        if (Babiole is not null) return;

        Babiole = Babiole.Create(NextQueue.Dequeue(), new Position(Playfield.Width / 2, 1));
    }

    private void MakeBabioleShift(Instructions instructions)
    {
        if (Babiole is null) return;

        DelayedAutoShift.TryShift(Babiole, instructions);
    }

    private void MakeBabioleRotate(Instructions instructions)
    {
        if (Babiole is null) return;

        PreventAutoRotation.TryRotate(Babiole, instructions);
    }

    private bool MakeBabioleFall(Instructions instructions)
    {
        if (Babiole is null) return false;

        if (!GravitySystem.TryFall(Babiole, instructions))
        {
            Playfield.Lock(Babiole);
            Babiole = null;
            return true;
        }

        return false;
    }

    private int CheckLineClear()
    {
        return Playfield.ClearCompletedLines();
    }

    private void Score(int lineClearedCount)
    {
        ScoringSystem.Score(lineClearedCount);
    }

    private void CheckBlockOut()
    {
        if (Babiole is null) return;
        
        if (Babiole.Overlaps(Playfield))
        {
            HasEnded = true;
        }
    }
}
