namespace Babioles.Entities;

public class Square(Color color)
{
    public Color Color { get; set; } = color;
    public Position Position { get; set; }
}
