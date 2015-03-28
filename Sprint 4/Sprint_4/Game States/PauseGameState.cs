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
        Game1 game;
        int inputBuffer = 10;

        public PauseGameState(Game1 game)
        {
            game.isPaused = true;
            this.game = game;
            game.keyboardController = new PauseMenuKeyController(game);
            game.soundManager.pause.Play();
        }

        public void Update(GameTime gameTime)
        {
            inputBuffer--;
            if (inputBuffer <= 0)
            {
                game.keyboardController.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);

        }
    }
}
