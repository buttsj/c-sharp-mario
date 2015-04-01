using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sprint4
{
    public sealed class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager gameContent;
        public IController keyboardController;
        public IController gamepadController;
        public IGameState gameState;
        public Level level;
        public static SoundManager soundManager;
        public Camera gameCamera;
        public bool isPaused = false;
        public int coins = 0, lives = 3;
        private static Game1 sInstance = new Game1();
        public BackgroundHolder background;

        public HUD gameHUD;

        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameContent = Content;
        }

        protected override void Initialize()
        {
            soundManager = new SoundManager(this);
            gameCamera = new Camera(GraphicsDevice.Viewport, this);
            level = new Level(this, "/Maps/Map.csv");
            gameState = new PlayGameState();
            keyboardController = new KeyboardController(level.mario);
            gamepadController = new GamepadController(level.mario);
            gameHUD = new HUD(this);
            background = new BackgroundHolder();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameHUD.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            gameState.Update(gameTime);
            gameHUD.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            background.Draw(spriteBatch);
            gameHUD.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, gameCamera.GetViewMatrix());
            gameState.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static Game1 GetInstance()
        {
            return sInstance;
        }
    }
}
