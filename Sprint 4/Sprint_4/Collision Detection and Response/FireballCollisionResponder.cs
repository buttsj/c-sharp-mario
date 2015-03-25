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
            enemy.TakeDamage();
            fireball.state = new NullFireballState(game);
            game.level.deadFireballs.Add(fireball);
            game.level.mario.fireballCount--;
        }

        public void BlockFireballCollide(Block block, Fireball fireball)
        {
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle fireballRect = fireball.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(blockRect, fireballRect);
            if (fireballRect.Bottom > blockRect.Top && fireballRect.Bottom < blockRect.Bottom)
            {
                fireball.position.Y = fireball.position.Y - intersection.Height;
            }
            if (!block.state.GetType().Equals((new GroundBlockState(game).GetType())))
            {
                fireball.state = new NullFireballState(game);
                game.level.deadFireballs.Add(fireball);
                game.level.mario.fireballCount--;

            }
        }        
    }
}
