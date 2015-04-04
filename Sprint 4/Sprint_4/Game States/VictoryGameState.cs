using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class VictoryGameState :IGameState
    {
        Game1 game;
        int walkTimer = 433;
        int slowMo = 3;
        RightCommand right;

        public VictoryGameState()
        {
            game = Game1.GetInstance();
            game.isVictory = true;
            SoundManager.StopMusic();
            SoundManager.clear.Play();
            right = new RightCommand(game.level.mario);
        }

        public void Update(GameTime gameTime)
        {
            if (walkTimer > 0)
            {
                if (slowMo == 3)
                {
                    right.Execute();
                    game.level.Update(gameTime);
                    slowMo = 0;
                }
                slowMo++;
            }
            else
            {
                game.level.mario.MakeVictoryMario();
            }
            walkTimer--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
