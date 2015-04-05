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
        public enum direction {goIn, comeOut}
        direction mode;

        public PipeTransitionGameState(direction direction, Pipe pipe)
        {
            game = Game1.GetInstance();
            game.isPaused = true;
            mode = direction;
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
