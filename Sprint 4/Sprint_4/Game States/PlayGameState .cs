using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class PlayGameState :IGameState
    {
        int gameStateTransitionBuffer = 5;

        public PlayGameState()
        {
            Game1.GetInstance().keyboardController = new KeyboardController();
        }
        public void Update(GameTime gameTime)
        {
            if (gameStateTransitionBuffer > 0)
            {
                gameStateTransitionBuffer--;
            }
            else
            {
                Game1.GetInstance().keyboardController.Update();
                Game1.GetInstance().gamepadController.Update();
                Game1.GetInstance().level.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GetInstance().level.Draw(spriteBatch);   
        }
    }
}
