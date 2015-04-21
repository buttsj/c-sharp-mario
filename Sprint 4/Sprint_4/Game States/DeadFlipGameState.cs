using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class DeadFlipGameState :IGameState
    {
        Game1 game;
        Mario mario;
        int timer = 20;

        public DeadFlipGameState(Mario mario)
        {
            game = Game1.GetInstance();
            this.mario = mario;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                mario.Respawn();
                game.gameState = new VVVVVVGameState();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
