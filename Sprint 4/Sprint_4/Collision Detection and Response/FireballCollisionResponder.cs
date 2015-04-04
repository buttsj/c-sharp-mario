using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FireballCollisionResponder
    {
        Game1 game;
        Mario mario;
       
        public FireballCollisionResponder(Mario mario, Game1 game)
        {
            this.game = game;
            this.mario = mario;
        }
        
        public void EnemyFireballCollide(Enemy enemy, Fireball fireball)
        {
            enemy.TakeDamage();
            game.level.deadFireballs.Add(fireball);
            mario.fireballCount--;
            game.gameHUD.Score += 100;
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
            if (!block.state.GetType().Equals((new GenericBlockState(SpriteFactory.sprites.ground).GetType())))
            {
                game.level.deadFireballs.Add(fireball);
                mario.fireballCount--;
            }
        }        
    }
}
