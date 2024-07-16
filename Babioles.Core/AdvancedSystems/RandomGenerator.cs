using Babioles.Entities;

namespace Babioles.AdvancedSystems;

/// <summary>
/// The Random Generator is an algorithm used to generate the sequence of Babioles.<br/>
/// This algorithm ensures that all seven Babioles (I, J, L, O, S, T, Z) are used before any piece is repeated. This method is often referred to as the "bag" system.
/// </summary>
public class RandomGenerator
{
    private List<Shape> Bag { get; } = [];
    private Random Random { get; } = new();

    protected void FillBag()
    {
        Bag.AddRange(Enum.GetValues<Shape>());
    }

    public Shape NextPiece()
    {
        if (Bag.Count == 0)
        {
            FillBag();
        }

        var index = Random.Next(Bag.Count);
        var babiole = Bag[index];

        Bag.Remove(babiole);

        return babiole;
    }
}
