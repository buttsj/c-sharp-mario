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
        int timer = 50;
        IMarioState prevState, newState, currentState;
        public TransitionGameState(Game1 game, IMarioState prevState, IMarioState newState)
        {
            this.game = game;
            this.prevState = prevState;
            this.newState = newState;
            currentState = prevState;
        }
        public void Update(GameTime gameTime)
        {
            Rectangle prevRect = prevState.GetBoundingBox(game.level.mario.position);
            Rectangle newRect = newState.GetBoundingBox(game.level.mario.position);
            timer--;
            if (currentState == prevState && timer%5 == 0)
            {
                currentState = newState;
                game.level.mario.state = newState;
                game.level.mario.position.Y -= (newRect.Height - prevRect.Height);
            }
            else if(timer %5 == 0 && currentState == newState)
            { 
                currentState = prevState;
                game.level.mario.state = prevState;
                game.level.mario.position.Y += (newRect.Height - prevRect.Height);
            }
            if (timer <= 0)
            {
                game.level.mario.state = newState;
                game.gameState = new PlayGameState(game);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
