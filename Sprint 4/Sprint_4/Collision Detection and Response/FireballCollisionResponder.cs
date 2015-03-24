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
        
        public void EnemyFireballCollide(Enemy enemy, Fireball fireball)
        {
            Rectangle enemyRect = enemy.GetBoundingBox();
            Rectangle fireballRect = fireball.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(enemyRect, fireballRect);
            if (intersection.Height > intersection.Width)
            {
                enemy.TakeDamage();
                fireball.state = new NullFireballState(game);
                game.level.mario.fireballCount--;
            }
            else
            {
                enemy.TakeDamage();
                fireball.state = new NullFireballState(game);
                game.level.mario.fireballCount--;
            }

        }

        public void BlockFireballCollide(Block block, Fireball fireball)
        {
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle fireballRect = fireball.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(blockRect, fireballRect);
            if (intersection.Height > intersection.Width)
            {                
                fireball.state = new NullFireballState(game);
                game.level.mario.fireballCount--;                
            }
            else
            {                
                fireball.state = new NullFireballState(game);
                game.level.mario.fireballCount--; 
            }
        }        
    }
}
