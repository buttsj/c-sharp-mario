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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public IController keyboardController;
        public IController gamepadController;
        public static ContentManager gameContent;
        public Level level;
        CollisionTests tester;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameContent = Content;
        }

        protected override void Initialize()
        {
            keyboardController = new KeyboardController(this);
            gamepadController = new GamepadController(this);
            level = new Level(this, "/Maps/Map.csv", false);            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //tester = new CollisionTests(this);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //tester.Test();
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            //gamepadController.Update();
            level.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            level.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
