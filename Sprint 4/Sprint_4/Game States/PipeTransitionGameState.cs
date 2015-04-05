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
        public enum direction {goDown, riseOut, enterLeft, enterRight, fallOut}
        direction mode;

        public PipeTransitionGameState(direction direction)
        {
            game = Game1.GetInstance();
            game.isPaused = true;
            mode = direction;
        }

        public void Update(GameTime gameTime)
        {
            if (mode == direction.goDown)
            {
                game.level.mario.position.Y++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
