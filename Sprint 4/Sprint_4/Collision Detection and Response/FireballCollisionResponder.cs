using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FireballCollisionResponder
    {
        ISpriteFactory factory = new SpriteFactory();
        Game1 game;
        public FireballCollisionResponder(Game1 game)
        {
            this.game = game;
        }
        public void MarioFireballCollide(Mario mario, Fireball fireball)
        {
            Rectangle marioRect = mario.state.getRectangle(new Vector2(mario.position.X, mario.position.Y));
            Rectangle fireballRect = fireball.GetRectangle();
            Rectangle intersection = Rectangle.Intersect(marioRect, fireballRect);
            if (intersection.Height > intersection.Width)
            {
                if (!mario.marioIsStar)
                {
                    //rework this collision detection, as it makes the game brutally hard.
                    mario.TakeDamage();
                }                
            }
            else
            {
               if (!mario.marioIsStar)
               {
                    mario.TakeDamage();
               }                    
                
            }
        }
        public void EnemyFireballCollide(Enemy enemy, Fireball fireball)
        {
            Rectangle enemyRect = enemy.GetRectangle();
            Rectangle fireballRect = fireball.GetRectangle();
            Rectangle intersection = Rectangle.Intersect(enemyRect, fireballRect);
            if (intersection.Height > intersection.Width)
            {
                if (enemyRect.Right > fireballRect.Left && enemyRect.Right < fireballRect.Right)
                {
                    enemy.TakeDamage();
                }
                else
                {
                    enemy.TakeDamage();
                }
            }

        }

        public void BlockFireballCollide(Block block, Fireball fireball)
        {
            Rectangle blockRect = block.GetRectangle();
            Rectangle fireballRect = fireball.GetRectangle();
            Rectangle intersection = Rectangle.Intersect(blockRect, fireballRect);
            if (intersection.Height > intersection.Width)
            {
                if (blockRect.Right > fireballRect.Left && blockRect.Right < fireballRect.Right)
                {
                    block.Reaction();
                }
                else
                {
                    block.Reaction();
                }
            }

        }

        
    }
}
