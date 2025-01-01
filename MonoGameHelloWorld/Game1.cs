﻿﻿﻿﻿﻿﻿﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameHelloWorld;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _whitePixel;
    private SpriteFont _font;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        // Create a 1x1 white pixel texture
        _whitePixel = new Texture2D(GraphicsDevice, 1, 1);
        _whitePixel.SetData(new[] { Color.White });
        
        // Load the default font
        _font = Content.Load<SpriteFont>("DefaultFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        // Draw a simple rectangle
        var rect = new Rectangle(100, 100, 200, 100);
        _spriteBatch.Draw(_whitePixel, rect, Color.Green);
        
        // Draw Hello World centered on screen
        string text = "Hello World";
        Vector2 textSize = _font.MeasureString(text);
        Vector2 textPosition = new Vector2(
            (GraphicsDevice.Viewport.Width - textSize.X) / 2,
            (GraphicsDevice.Viewport.Height - textSize.Y) / 2);
        _spriteBatch.DrawString(_font, text, textPosition, Color.White);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
