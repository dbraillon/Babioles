using Babioles.AdvancedSystems;
using Babioles.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Babioles;

public static class SpriteBatchExtensions
{
    public static void DrawFramerate(this SpriteBatch spriteBatch, GameTime gameTime, SpriteFont font)
    {
        var framerate = 1 / gameTime.ElapsedGameTime.TotalSeconds;

        spriteBatch.DrawString(font, $"Framerate {framerate:N2}", new Vector2(1000, 10), Microsoft.Xna.Framework.Color.Black);
    }

    public static void DrawScoringSystem(this SpriteBatch spriteBatch, ScoringSystem scoringSystem, SpriteFont font)
    {
        spriteBatch.DrawString(font, $"Score : {scoringSystem.Points}", new Vector2(500, 10), Microsoft.Xna.Framework.Color.Black);
        spriteBatch.DrawString(font, $"Level : {scoringSystem.Level}", new Vector2(500, 30), Microsoft.Xna.Framework.Color.Black);
    }

    public static void DrawPlayfield(this SpriteBatch spriteBatch, Playfield playfield, Dictionary<Entities.Color, Texture2D> squareTextures)
    {
        for (var x = 0; x < playfield.Width; x++)
        {
            for (var y = 0; y < playfield.Height; y++)
            {
                var square = playfield.Squares[x, y];
                var squareTexture = squareTextures[square];
                if (squareTexture is null) continue;

                var position = new Vector2(squareTexture.Width * x, squareTexture.Height * y);

                spriteBatch.Draw(squareTexture, position, Microsoft.Xna.Framework.Color.White);
            }
        }
    }

    public static void DrawNextQueue(this SpriteBatch spriteBatch, NextQueue nextQueue, Dictionary<Entities.Color, Texture2D> squareTextures)
    {
        var y = 2;

        foreach (var shape in nextQueue.GetQueue())
        {
            var babiole = Babiole.Create(shape, new Position(12, y));

            spriteBatch.DrawBabiole(babiole, squareTextures);

            y += 3;
        }
    }

    public static void DrawBabiole(this SpriteBatch spriteBatch, Babiole? babiole, Dictionary<Entities.Color, Texture2D> squareTextures)
    {
        if (babiole is null) return;

        var texture = squareTextures[babiole.Color];
        var color = Microsoft.Xna.Framework.Color.White;

        spriteBatch.Draw(
            texture: texture,
            babiole.Square1.Position.ToVector2(),
            color: color
        );
        spriteBatch.Draw(
            texture: texture,
            babiole.Square2.Position.ToVector2(),
            color: color
        );
        spriteBatch.Draw(
            texture: texture,
            babiole.Square3.Position.ToVector2(),
            color: color
        );
        spriteBatch.Draw(
            texture: texture,
            babiole.Square4.Position.ToVector2(),
            color: color
        );
    }

    public static Vector2 ToVector2(this Position position)
    {
        var textureHeight = 32;
        var textureWidth = 32;

        return new Vector2(position.X * textureWidth, position.Y * textureHeight);
    }
}
