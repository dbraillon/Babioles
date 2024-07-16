using Babioles.Entities;
using Microsoft.Xna.Framework.Input;

namespace Babioles;

public static class KeyboardStateExtensions
{
    public static Instructions GetInstructions(this KeyboardState keyboardState)
    {
        var instructions = default(Instructions);
        if (keyboardState.IsKeyDown(Keys.Z)) instructions |= Instructions.Up;
        if (keyboardState.IsKeyDown(Keys.D)) instructions |= Instructions.Right;
        if (keyboardState.IsKeyDown(Keys.S)) instructions |= Instructions.Down;
        if (keyboardState.IsKeyDown(Keys.Q)) instructions |= Instructions.Left;
        if (keyboardState.IsKeyDown(Keys.K)) instructions |= Instructions.A;
        if (keyboardState.IsKeyDown(Keys.L)) instructions |= Instructions.B;
        return instructions;
    }
}
