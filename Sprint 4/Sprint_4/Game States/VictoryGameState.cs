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
        int slowFrames = 3;
        RightCommand right;

        public VictoryGameState()
        {
            game = Game1.GetInstance();
            game.isVictory = true;
            SoundManager.StopMusic();
            SoundManager.clear.Play();
            right = new RightCommand(game.level.mario);
            game.gameHUD.gameEnded = true;
            game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Level);
        }

        public void Update(GameTime gameTime)
        {
            game.gameHUD.Update(gameTime);
            if (walkTimer > 0)
            {
                if (slowFrames == ValueHolder.slowdownRate)
                {
                    right.Execute();
                    game.level.Update(gameTime);
                    slowFrames = 0;
                }
                slowFrames++;
            }
            else
            {
                game.level.mario.MakeVictoryMario();
            }
            walkTimer--;

            if (game.gameHUD.Time > 0)
            {
                game.gameHUD.Time--;
                game.gameHUD.Score += ValueHolder.remainingTimePoints;
            }            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
