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
        Game1 game;

        public LivesScreenGameState()
        {
            game = Game1.GetInstance();
            Game1.GetInstance().lives--;
            font = game.Content.Load<SpriteFont>("SpriteFont1");
            font2 = game.Content.Load<SpriteFont>("SpriteFont2");
            game.keyboardController = new PauseMenuKeyController();
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                game.level = new Level(game, "/Maps/Map.csv");
                game.gameState = new PlayGameState();
            }
            game.keyboardController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.CenterScreen);
            spriteBatch.DrawString(font, "Lives: " + game.lives, new Vector2(game.gameCamera.CenterScreen.X - 40, game.gameCamera.CenterScreen.Y + 110), Color.White);
            if (game.lives < 1)
            {
                spriteBatch.DrawString(font2, "What's wrong?", new Vector2(game.gameCamera.CenterScreen.X - 100, game.gameCamera.CenterScreen.Y + 30), Color.White);
                spriteBatch.DrawString(font2, "Too ", new Vector2(game.gameCamera.CenterScreen.X + 10, game.gameCamera.CenterScreen.Y + 200), Color.White);
                spriteBatch.DrawString(font2, "hard ", new Vector2(game.gameCamera.CenterScreen.X + 45, game.gameCamera.CenterScreen.Y + 200), Color.Red);
                spriteBatch.DrawString(font2, "for you?", new Vector2(game.gameCamera.CenterScreen.X + 90, game.gameCamera.CenterScreen.Y + 200), Color.White);
            }
        }
    }
}
