namespace Babioles.AdvancedSystems;

/// <summary>
/// Scoring System rewards player with points for clearing lines. It also manage the level and set the gravity force accordingly.
/// </summary>
/// <param name="GravitySystem">Babiole's gravity system.</param>
public class ScoringSystem(
    GravitySystem GravitySystem)
{
    public int Level { get; private set; } = 1;
    public int Points { get; private set; } = 0;
    public int Lines { get; private set; } = 0;

    public static Dictionary<int, float> GravityCurve => new()
    {
        { 1, 0.01667f },
        { 2, 0.021017f },
        { 3, 0.026977f },
        { 4, 0.035256f },
        { 5, 0.04693f },
        { 6, 0.06361f },
        { 7, 0.0879f },
        { 8, 0.1236f },
        { 9, 0.1775f },
        { 10, 0.2598f },
        { 11, 0.388f },
        { 12, 0.59f },
        { 13, 0.92f },
        { 14, 1.46f },
        { 15, 2.36f },
        { 16, 3.91f },
        { 17, 6.61f },
        { 18, 11.43f },
        { 19, 20f },
    };

    public void Score(int lineCleared)
    {
        Points += lineCleared switch
        {
            1 => 1,
            2 => 3,
            3 => 5,
            4 => 8,
            _ => 0
        };
        Lines += lineCleared;

        Level = Lines / 10 + 1;
        if (Level < 1) Level = 1;
        if (Level > 19) Level = 19;

        GravitySystem.SetG(GravityCurve[Level]);
    }
}
