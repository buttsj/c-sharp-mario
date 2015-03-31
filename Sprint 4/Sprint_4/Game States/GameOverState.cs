using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class GameOverState :IGameState
    {
        Game1 game;
        SpriteFont font;

        public GameOverState()
        {
            font = game.Content.Load<SpriteFont>("SpriteFont1");
            game = Game1.GetInstance();
            SoundManager.StopMusic();
            SoundManager.gameOver.Play();
        }

        public void Update(GameTime gameTime)
        {
            //have a selection to try again
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.CenterScreen);
            spriteBatch.DrawString(font, "Game Over", new Vector2(game.gameCamera.CenterScreen.X - 40, game.gameCamera.CenterScreen.Y + 110), Color.White);
        }
    }
}
