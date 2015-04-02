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
        SpriteFont font;
        Game1 game;
        Vector2 textPosition = new Vector2(-40, 110);

        public LivesScreenGameState()
        {
            game = Game1.GetInstance();
            Game1.GetInstance().lives--;
            font = game.Content.Load<SpriteFont>("Fonts/SpriteFont1");
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
            spriteBatch.DrawString(font, "Lives: " + game.lives, game.gameCamera.CenterScreen + textPosition, Color.White);
        }
    }
}
