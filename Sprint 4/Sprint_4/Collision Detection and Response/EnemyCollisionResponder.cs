using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class EnemyCollisionResponder
    {
        ISpriteFactory factory = new SpriteFactory();
        Game1 game;
        public EnemyCollisionResponder(Game1 game)
        {
            this.game = game;
        }
        public void MarioEnemyCollide(Mario mario, Enemy enemy)
        {
            Rectangle marioRect = mario.state.getRectangle(new Vector2(mario.position.X, mario.position.Y));
            Rectangle enemyRect = enemy.GetRectangle();
            Rectangle intersection = Rectangle.Intersect(marioRect, enemyRect);
            if (intersection.Height > intersection.Width)
            {
                if (!mario.marioIsStar)
                {
                    mario.TakeDamage(enemy);
                }
                else
                {
                    enemy.TakeDamage();
                }
            }
            else
            {
                if (marioRect.Bottom > enemyRect.Top && marioRect.Bottom < enemyRect.Bottom)
                {
                    enemy.TakeDamage();
                    mario.velocity.Y = -10;
                }
                else
                {
                    if (!mario.marioIsStar)
                    {
                        mario.TakeDamage(enemy);
                    }
                    else
                    {
                        enemy.TakeDamage();
                    }
                }
            }
        }
    }
}
