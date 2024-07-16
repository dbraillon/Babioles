namespace Babioles.Entities;

[Flags]
public enum Instructions
{
    Up = 1,
    Right = 2,
    Down = 4,
    Left = 8,
    A = 16,
    B = 32
}
