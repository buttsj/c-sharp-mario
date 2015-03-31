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
        int pauseTimer = 30, upTimer = 30, downTimer = 180;

        public DeadGameState()
        {
            game = Game1.GetInstance();
            SoundManager.StopMusic();
            SoundManager.death.Play();
            game.level.mario.isDead = true;
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
                game.level.mario.position.Y-=5;
            }
            if (upTimer <= 0 && downTimer > 0)
            {
                game.level.mario.position.Y+=5;
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
