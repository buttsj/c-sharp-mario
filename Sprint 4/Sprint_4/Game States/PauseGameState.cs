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

        public PauseGameState()
        {
            Game1.GetInstance().isPaused = true;
            Game1.GetInstance().keyboardController = new PauseMenuKeyController();
            SoundManager.pause.Play();
        }

        public void Update(GameTime gameTime)
        {
            inputBuffer--;
            if (inputBuffer <= 0)
            {
                Game1.GetInstance().keyboardController.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GetInstance().level.Draw(spriteBatch);
        }
    }
}
