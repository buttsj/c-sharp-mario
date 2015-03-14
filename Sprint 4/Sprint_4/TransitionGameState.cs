using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class TransitionGameState :IGameState
    {
        Game1 game;
        public TransitionGameState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {
            //mario's transition animation. His previous and future state should be used to swap between 
            //in the animation. Lasts ~2 seconds, then goes back to playState. Everything else is frozen.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
