using Babioles.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics.CodeAnalysis;

namespace Babioles;

public class MonoGame : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager GraphicsDeviceManager { get; }

    private SpriteBatch SpriteBatch { get; set; }
    private Dictionary<Entities.Color, Texture2D> SquareTextures { get; } = [];
    private SpriteFont FramerateFont { get; set; }

    private float HorizontalScaling { get; set; }
    private float VerticalScaling { get; set; }

    private Game Game { get; set; }

    public MonoGame()
    {
        GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Game = new Game();

        var maxHeight = 32f * Game.Playfield.Height;
        VerticalScaling = GraphicsDevice.PresentationParameters.BackBufferHeight / maxHeight;
        HorizontalScaling = VerticalScaling;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        SquareTextures.Add(Entities.Color.Blue, Content.Load<Texture2D>("blue_square"));
        SquareTextures.Add(Entities.Color.Cyan, Content.Load<Texture2D>("cyan_square"));
        SquareTextures.Add(Entities.Color.Gray, Content.Load<Texture2D>("gray_square"));
        SquareTextures.Add(Entities.Color.Green, Content.Load<Texture2D>("green_square"));
        SquareTextures.Add(Entities.Color.Orange, Content.Load<Texture2D>("orange_square"));
        SquareTextures.Add(Entities.Color.Purple, Content.Load<Texture2D>("purple_square"));
        SquareTextures.Add(Entities.Color.Red, Content.Load<Texture2D>("red_square"));
        SquareTextures.Add(Entities.Color.Yellow, Content.Load<Texture2D>("yellow_square"));
        FramerateFont = Content.Load<SpriteFont>("framerate");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        Game?.Update(Keyboard.GetState().GetInstructions());

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

        SpriteBatch?.Begin(transformMatrix: Matrix.CreateScale(HorizontalScaling, VerticalScaling, 1.0f));
        SpriteBatch?.DrawFramerate(gameTime, FramerateFont);
        SpriteBatch?.DrawScoringSystem(Game.ScoringSystem, FramerateFont);
        SpriteBatch?.DrawPlayfield(Game.Playfield, SquareTextures);
        SpriteBatch?.DrawNextQueue(Game.NextQueue, SquareTextures);
        SpriteBatch?.DrawBabiole(Game.Babiole, SquareTextures);
        SpriteBatch?.End();

        base.Draw(gameTime);
    }
}
