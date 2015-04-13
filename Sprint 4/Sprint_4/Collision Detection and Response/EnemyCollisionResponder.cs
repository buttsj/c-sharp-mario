using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class EnemyCollisionResponder
    {
        Game1 game;
        int bounce = -10;
        
        public EnemyCollisionResponder(Game1 game)
        {
            this.game = game;
        }
        public void MarioEnemyCollide(Mario mario, Enemy enemy)
        {
            Rectangle marioRect = mario.state.GetBoundingBox(new Vector2(mario.position.X, mario.position.Y));
            Rectangle enemyRect = enemy.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(marioRect, enemyRect);
            if (intersection.Height > intersection.Width)
            {
                if (!mario.isStar)
                {
                    mario.TakeDamage();
                }
                else
                {
                    enemy.TakeDamage();
                    game.gameHUD.Score += ValueHolder.enemyHurtPoints;
                }
            }
            else
            {
                if (marioRect.Bottom > enemyRect.Top && marioRect.Bottom < enemyRect.Bottom)
                {
                    enemy.TakeDamage();
                    game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Enemy);
                    game.gameHUD.Score += ValueHolder.enemyHurtPoints * game.gameHUD.pointMultiplier;
                    mario.velocity.Y = bounce;
                    game.gameHUD.pointMultiplier++;
                }
                else
                {
                    if (!mario.isStar)
                    {
                        mario.TakeDamage();
                    }
                    else
                    {
                        enemy.TakeDamage();
                        game.gameHUD.Score += ValueHolder.enemyHurtPoints;
                    }
                }
            }
        }
        public void EnemyEnemyCollide(Enemy enemy1, Enemy enemy2)
        {
            Rectangle enemy1Rect = enemy1.GetBoundingBox();
            Rectangle enemy2Rect = enemy2.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(enemy1Rect, enemy2Rect);
            if (intersection.Height > intersection.Width)
            {
                if (enemy1Rect.Right > enemy2Rect.Left && enemy1Rect.Right < enemy2Rect.Right)
                {
                    enemy1.position.X -= intersection.Width;
                    enemy1.GoLeft();
                    enemy2.GoRight();
                }
                else
                {
                    enemy1.position.X += intersection.Width;
                    enemy1.GoRight();
                    enemy2.GoLeft();
                }
            }
          
        }
    }
}
