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
        Game1 game;
        int timer = 200;
        SpriteFont font;

        public LivesScreenGameState(Game1 game)
        {
            this.game = game;
            game.lives--;
            font = game.Content.Load<SpriteFont>("SpriteFont1");
            game.keyboardController = new PauseMenuKeyController(game);
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
               game.level = new Level(game, "/Maps/Map.csv");
               game.gameState = new PlayGameState(game);
            }
            game.keyboardController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.Origin);
            spriteBatch.DrawString(font, "Lives: " + game.lives, new Vector2(game.gameCamera.Origin.X-40, game.gameCamera.Origin.Y+110), Color.White);
        }
    }
}
