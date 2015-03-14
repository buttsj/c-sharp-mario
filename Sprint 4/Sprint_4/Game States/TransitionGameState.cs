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
            timer--;
            if (currentState == prevState && timer%5 == 0)
            {
                currentState = newState;
                game.level.mario.state = newState;
            }
            else if(timer %5 == 0 && currentState == newState)
            { 
                currentState = prevState;
                game.level.mario.state = prevState;
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
