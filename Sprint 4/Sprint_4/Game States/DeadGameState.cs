using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class DeadGameState :IGameState
    {
        Game1 game;
        public DeadGameState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {
            //mario's death animation, followed by respawning into playState. Nothing in the level moves
            //but mario. Have a dead keyboard? It only takes pause and quit inputs.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
