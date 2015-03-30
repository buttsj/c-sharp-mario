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
        int timer = 50;
        IMarioState prevState, newState, currentState;
        public TransitionGameState(IMarioState prevState, IMarioState newState)
        {
            this.prevState = prevState;
            this.newState = newState;
            currentState = prevState;
        }
        public void Update(GameTime gameTime)
        {
            Rectangle prevRect = prevState.GetBoundingBox(Game1.GetInstance().level.mario.position);
            Rectangle newRect = newState.GetBoundingBox(Game1.GetInstance().level.mario.position);
            timer--;
            if (currentState == prevState && timer%5 == 0)
            {
                currentState = newState;
                Game1.GetInstance().level.mario.state = newState;
                Game1.GetInstance().level.mario.position.Y -= (newRect.Height - prevRect.Height);
            }
            else if(timer %5 == 0 && currentState == newState)
            { 
                currentState = prevState;
                Game1.GetInstance().level.mario.state = prevState;
                Game1.GetInstance().level.mario.position.Y += (newRect.Height - prevRect.Height);
            }
            if (timer <= 0)
            {
                Game1.GetInstance().level.mario.state = newState;
                Game1.GetInstance().gameState = new PlayGameState();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Game1.GetInstance().level.Draw(spriteBatch);
        }
    }
}
