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
        public bool isPaused = false, isVictory = false, isGameOver = false, isVVVVVV = false, isTitle = true;
        private static Game1 sInstance = new Game1();
        public BackgroundHolder background;
        public HUD gameHUD;
        public AchievementsManager ach;

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
            gameHUD = new HUD(this);
            level = new Level(StringHolder.levelOne);
            keyboardController = new KeyboardController(level.mario);
            gamepadController = new GamepadController(level.mario);
            gameState = new TitleScreenGameState();
            background = new BackgroundHolder();
            ach = new AchievementsManager(this);
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
            ach.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            background.Draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, gameCamera.GetViewMatrix());
            gameState.Draw(spriteBatch);
            spriteBatch.End();

            if (!isTitle && !isVVVVVV)
            {
                spriteBatch.Begin();
                gameHUD.Draw(spriteBatch);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        public static Game1 GetInstance()
        {
            return sInstance;
        }
    }
}
