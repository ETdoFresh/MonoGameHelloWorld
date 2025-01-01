﻿﻿﻿﻿﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameEngineLibrary;
using System;

namespace MonoGameHelloWorld;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _rectangleTexture;
    private SpriteFont _font;
    private SceneManager _sceneManager;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void OnExiting(object sender, Microsoft.Xna.Framework.ExitingEventArgs args)
    {
        Console.WriteLine("Game successfully quit");
        base.OnExiting(sender, args);
    }

    protected override void Initialize()
    {
        _sceneManager = new SceneManager();
        
        // Create initial scene
        var mainScene = _sceneManager.CreateScene("MainScene");
        // TODO: Add game objects to the scene

        _sceneManager.LoadScene("MainScene");

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        // Create a 100x100 white rectangle texture
        _rectangleTexture = new Texture2D(GraphicsDevice, 100, 100);
        Color[] data = new Color[100 * 100];
        for (int i = 0; i < data.Length; i++) data[i] = Color.White;
        _rectangleTexture.SetData(data);
        _font = Content.Load<SpriteFont>("MyFont");
    }

    protected override void Update(GameTime gameTime)
    {
        var activeScene = _sceneManager.GetActiveScene();
        // TODO: Update game objects in the active scene

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        // Draw rectangle at position (200, 150)
        _spriteBatch.Draw(_rectangleTexture, new Vector2(200, 150), Color.Red);
        _spriteBatch.DrawString(_font, "Hello World", new Vector2(100, 100), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }

}
