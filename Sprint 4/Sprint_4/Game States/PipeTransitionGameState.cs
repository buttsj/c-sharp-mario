using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class PipeTransitionGameState :IGameState
    {
        int pipeTimer = 100;
        Game1 game;

        public PipeTransitionGameState()
        {
            game = Game1.GetInstance();
            game.isPaused = true;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
