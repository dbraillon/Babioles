using Babioles.Entities;

namespace Babioles.AdvancedSystems;

/// <summary>
/// Next Queue is a feature that shows to the player the upcoming Babioles that will enter the playfield.<br/>
/// This allows the player to plan their moves in advance and strategize more effectively.
/// </summary>
/// <param name="Size">The number of Babiole shown to the player.</param>
public class NextQueue(
    int Size = 4)
{
    private RandomGenerator RandomGenerator { get; } = new();
    private Queue<Shape> Queue { get; } = new Queue<Shape>();

    public IEnumerable<Shape> GetQueue()
    {
        EnsureQueueIsFilled();

        return Queue.Take(Size);
    }

    public Shape Dequeue()
    {
        EnsureQueueIsFilled();

        return Queue.Dequeue();
    }

    private void EnsureQueueIsFilled()
    {
        var queueCount = Queue.Count;
        var queueSize = Size + 1;
        if (queueCount >= queueSize) return;

        for (var i = queueCount; i < queueSize; i++)
        {
            Queue.Enqueue(RandomGenerator.NextPiece());
        }
    }
}
