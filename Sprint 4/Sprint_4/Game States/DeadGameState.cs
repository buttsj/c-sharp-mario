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
        Mario mario;
        int pauseTimer = 30, upTimer = 30, downTimer = 180;
        int positionChange = 5;

        public DeadGameState(Mario mario)
        {
            game = Game1.GetInstance();
            this.mario = mario;
            SoundManager.StopMusic();
            SoundManager.death.Play();
            mario.isDead = true;
        }

        public void Update(GameTime gameTime)
        {
            if (pauseTimer > 0)
            {
                pauseTimer--;
            }
            if (pauseTimer <= 0 && upTimer > 0)
            {
                upTimer--;
                mario.position.Y-=positionChange;
            }
            if (upTimer <= 0 && downTimer > 0)
            {
                mario.position.Y+=positionChange;
                downTimer--;
            }
            if (downTimer <= 0)
            {
                if (game.lives > 0)
                {
                    game.gameState = new LivesScreenGameState();
                }
                else
                {
                    game.gameState = new GameOverState();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
