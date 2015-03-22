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
                fireball.state = new NullFireballState(game);
            }
            else
            {
               if (!mario.marioIsStar)
               {
                    mario.TakeDamage();                    
               }
               fireball.state = new NullFireballState(game);
            }
        }
        public void EnemyFireballCollide(Enemy enemy, Fireball fireball)
        {
            Rectangle enemyRect = enemy.GetRectangle();
            Rectangle fireballRect = fireball.GetRectangle();
            Rectangle intersection = Rectangle.Intersect(enemyRect, fireballRect);
            if (intersection.Height > intersection.Width)
            {
                enemy.TakeDamage();
                fireball.state = new NullFireballState(game);
            }
            else
            {
                enemy.TakeDamage();
                fireball.state = new NullFireballState(game);
            }

        }

        public void BlockFireballCollide(Block block, Fireball fireball)
        {
            Rectangle blockRect = block.GetRectangle();
            Rectangle fireballRect = fireball.GetRectangle();
            Rectangle intersection = Rectangle.Intersect(blockRect, fireballRect);
            if (intersection.Height > intersection.Width)
            {
                block.Reaction();
                fireball.state = new NullFireballState(game);
            }
            else
            {
                block.Reaction();
                fireball.state = new NullFireballState(game);
            }
        }        
    }
}
