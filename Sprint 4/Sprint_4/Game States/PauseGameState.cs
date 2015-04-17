using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class PauseGameState :IGameState
    {
        int inputBuffer = 10;
        Game1 game;

        public PauseGameState()
        {
            game = Game1.GetInstance();
            game.isPaused = true;
            game.keyboardController = new PauseMenuKeyController();
            game.gamepadController = new PauseMenuGamepadController();
            SoundManager.pause.Play();
            game.gameHUD.PausedCheck = true;
        }

        public void Update(GameTime gameTime)
        {
            inputBuffer--;
            if (inputBuffer <= 0)
            {
                game.keyboardController.Update();
                game.gamepadController.Update();
                inputBuffer = 10;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
