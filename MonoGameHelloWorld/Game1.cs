﻿﻿﻿﻿﻿﻿﻿﻿﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameEngineLibrary;
using System;

namespace MonoGameHelloWorld;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;
    private SceneManager _sceneManager;
    private GameObject _rectangleObject;
    private GameObject _circleObject;
    private GameObject _triangleObject;

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
        
        // Create game objects
        _rectangleObject = new GameObject("RectangleObject");
        _circleObject = new GameObject("CircleObject");
        _triangleObject = new GameObject("TriangleObject");

        // Add components
        var rectangleRenderer = new ShapeRenderer(GraphicsDevice, _rectangleObject)
        {
            ShapeType = ShapeType.Rectangle,
            Color = Color.Red,
            Size = new Vector2(100, 100)
        };

        var circleRenderer = new ShapeRenderer(GraphicsDevice, _circleObject)
        {
            ShapeType = ShapeType.Circle,
            Color = Color.Green,
            Size = new Vector2(100, 100)
        };

        var triangleRenderer = new ShapeRenderer(GraphicsDevice, _triangleObject)
        {
            ShapeType = ShapeType.Triangle,
            Color = Color.Blue,
            Size = new Vector2(100, 100)
        };

        _rectangleObject.AddComponent(rectangleRenderer);
        _circleObject.AddComponent(circleRenderer);
        _triangleObject.AddComponent(triangleRenderer);

        // Add objects to scene
        mainScene.AddGameObject(_rectangleObject);
        mainScene.AddGameObject(_circleObject);
        mainScene.AddGameObject(_triangleObject);

        _sceneManager.LoadScene("MainScene");

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
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
        var rectRenderer = _rectangleObject.GetComponent<ShapeRenderer>();
        _spriteBatch.Draw(rectRenderer.Texture, new Vector2(200, 150), rectRenderer.Color);
        
        // Draw circle at position (400, 150)
        var circleRenderer = _circleObject.GetComponent<ShapeRenderer>();
        _spriteBatch.Draw(circleRenderer.Texture, new Vector2(400, 150), circleRenderer.Color);
        
        // Draw triangle at position (600, 150)
        var triangleRenderer = _triangleObject.GetComponent<ShapeRenderer>();
        _spriteBatch.Draw(triangleRenderer.Texture, new Vector2(600, 150), triangleRenderer.Color);
        
        _spriteBatch.DrawString(_font, "Hello World", new Vector2(100, 100), Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
