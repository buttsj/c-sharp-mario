using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ThrowingStarCollisionResponder
    {
        Game1 game;
        Mario mario;

        public ThrowingStarCollisionResponder(Mario mario, Game1 game)
        {
            this.game = game;
            this.mario = mario;
        }

        public void EnemyThrowingStarCollide(Enemy enemy, ThrowingStar throwingStar)
        {
            enemy.TakeDamage();
            game.level.deadThrowingStars.Add(throwingStar);
            mario.throwingStarCount--;
            game.gameHUD.Score += ValueHolder.enemyHurtPoints;
        }

        public void BlockThrowingStarCollide(Block block, ThrowingStar throwingStar)
        {
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle throwingStarRect = throwingStar.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(blockRect, throwingStarRect);
            if (throwingStarRect.Bottom > blockRect.Top && throwingStarRect.Bottom < blockRect.Bottom)
            {
                throwingStar.position.Y = throwingStar.position.Y - intersection.Height;                
            }
            if (!block.state.GetType().Equals((new GenericBlockState(SpriteFactory.sprites.ground).GetType())))
            {
                game.level.deadThrowingStars.Add(throwingStar);
                mario.throwingStarCount--;
            }
        }
    }
}
