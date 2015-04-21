using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class GameOverState :IGameState
    {
        Game1 game;
        SpriteFont font;

        public GameOverState()
        {
            game = Game1.GetInstance();
            game.isGameOver = true;
            font = game.Content.Load<SpriteFont>(StringHolder.bigTextFont);
            SoundManager.StopMusic();
            SoundManager.gameOver.Play();
            game.keyboardController = new PauseMenuKeyController();
            game.gamepadController = new PauseMenuGamepadController();
        }

        public void Update(GameTime gameTime)
        {
            game.keyboardController.Update();
            game.gamepadController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.CenterScreen);
            spriteBatch.DrawString(font, StringHolder.gameOverMessage, game.gameCamera.CenterScreen + ValueHolder.textPosition, 
                Color.White);
        }
    }
}
