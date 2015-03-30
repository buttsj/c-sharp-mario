using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LivesScreenGameState :IGameState
    {
        int timer = 150;
        SpriteFont font, font2;

        public LivesScreenGameState()
        {
            Game1.GetInstance().lives--;
            font = Game1.GetInstance().Content.Load<SpriteFont>("SpriteFont1");
            font2 = Game1.GetInstance().Content.Load<SpriteFont>("SpriteFont2");
            Game1.GetInstance().keyboardController = new PauseMenuKeyController();
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                Game1.GetInstance().level = new Level(Game1.GetInstance(), "/Maps/Map.csv");
                Game1.GetInstance().gameState = new PlayGameState();
            }
            Game1.GetInstance().keyboardController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GetInstance().GraphicsDevice.Clear(Color.Black);
            Game1.GetInstance().gameCamera.LookAt(Game1.GetInstance().gameCamera.Origin);
            spriteBatch.DrawString(font, "Lives: " + Game1.GetInstance().lives, new Vector2(Game1.GetInstance().gameCamera.Origin.X - 40, Game1.GetInstance().gameCamera.Origin.Y + 110), Color.White);
            if (Game1.GetInstance().lives < 2)
            {
                spriteBatch.DrawString(font2, "What's wrong?", new Vector2(Game1.GetInstance().gameCamera.Origin.X - 100, Game1.GetInstance().gameCamera.Origin.Y + 30), Color.White);
                spriteBatch.DrawString(font2, "Too ", new Vector2(Game1.GetInstance().gameCamera.Origin.X + 10, Game1.GetInstance().gameCamera.Origin.Y + 200), Color.White);
                spriteBatch.DrawString(font2, "hard ", new Vector2(Game1.GetInstance().gameCamera.Origin.X + 45, Game1.GetInstance().gameCamera.Origin.Y + 200), Color.Red);
                spriteBatch.DrawString(font2, "for you?", new Vector2(Game1.GetInstance().gameCamera.Origin.X + 90, Game1.GetInstance().gameCamera.Origin.Y + 200), Color.White);
            }
        }
    }
}
