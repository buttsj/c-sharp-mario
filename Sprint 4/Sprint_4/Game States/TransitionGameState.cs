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
        Mario mario;
        int timer = 50, timeMod = 5;
        IMarioState prevState, newState, currentState;
        public TransitionGameState(Mario mario, IMarioState prevState, IMarioState newState)
        {
            game = Game1.GetInstance();
            this.mario = mario;
            this.prevState = prevState;
            this.newState = newState;
            currentState = prevState;
        }
        public void Update(GameTime gameTime)
        {
            game.gameHUD.Update(gameTime);
            Rectangle prevRect = prevState.GetBoundingBox(mario.position);
            Rectangle newRect = newState.GetBoundingBox(mario.position);
            timer--;
            if (currentState == prevState && timer % timeMod == 0)
            {
                currentState = newState;
                mario.state = newState;
                mario.position.Y -= (newRect.Height - prevRect.Height);
            }
            else if(timer % timeMod == 0 && currentState == newState)
            { 
                currentState = prevState;
                mario.state = prevState;
                mario.position.Y += (newRect.Height - prevRect.Height);
            }
            if (timer <= 0)
            {
                mario.position.Y -= (newRect.Height - prevRect.Height);
                mario.state = newState;
                game.gameState = new SuperMarioGameState();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
