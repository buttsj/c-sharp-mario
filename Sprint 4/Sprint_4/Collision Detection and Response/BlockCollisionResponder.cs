using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class BlockCollisionResponder
    {
        ISpriteFactory factory = new SpriteFactory();
        Game1 game;
        SoundEffectInstance hitBlock;


        public BlockCollisionResponder(Game1 game)
        {
            this.game = game;
            hitBlock = game.soundManager.land.CreateInstance();
        }
        
        public void MarioBlockCollide(Mario mario, Block block, List<Block> destroyedBlocks, List<Block> standingBlocks)
        {
            Rectangle marioRect = mario.state.GetBoundingBox(new Vector2(mario.position.X, mario.position.Y));
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(marioRect, blockRect);

            if (intersection.Height > intersection.Width)
            {
                if (marioRect.Right > blockRect.Left && marioRect.Right < blockRect.Right)
                {
                    mario.position.X -= intersection.Width;
                }
                else
                {
                    mario.position.X += intersection.Width;
                }
            }
            else if (intersection.Height < intersection.Width)
            {
                if (marioRect.Bottom > blockRect.Top && marioRect.Bottom < blockRect.Bottom)
                {  
                    if (!mario.physState.GetType().Equals((new JumpingState(game)).GetType()))
                    {
                        mario.velocity.Y = 0;
                    }
                    if (intersection.Height > 1)
                    {
                        mario.position.Y -= intersection.Height;
                    }
                    standingBlocks.Add(block);
                }
                else
                {
                    mario.position.Y = mario.position.Y + intersection.Height;
                    block.Reaction();
                    mario.physState = new FallingState(game);
                    mario.marioHeight = 0;
                    if (block.state.GetType().Equals(new BrickBlockState(game).GetType()) && mario.marioIsBig)
                    {
                        destroyedBlocks.Add(block);
                        game.soundManager.PlaySoundEffect(SoundManager.sfx.brick);
                    }
                }
            }
        }

        public void ItemBlockCollide(Item item, Block block)
        {
            Rectangle itemRect = item.GetBoundingBox();
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(itemRect, blockRect);
            if (intersection.Height > intersection.Width)
            {
                if (itemRect.Right > blockRect.Left && itemRect.Right < blockRect.Right)
                {
                    item.position.X= item.position.X - intersection.Width;
                    item.GoLeft();
                }
                else
                {
                    item.position.X = item.position.X + intersection.Width;
                    item.GoRight();
                }
            }
            else
            {
                if (itemRect.Bottom > blockRect.Top && itemRect.Bottom < blockRect.Bottom)
                {
                    item.position.Y = item.position.Y - intersection.Height;
                }
                else
                {
                    item.position.Y = item.position.Y + intersection.Height;
                }
            }
        }

        public void EnemyBlockCollide(Enemy enemy, Block block)
        {
            Rectangle enemyRect = enemy.GetBoundingBox();
            Rectangle blockRect = block.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(enemyRect, blockRect);
            if (intersection.Height > intersection.Width)
            {
                if (enemyRect.Right > blockRect.Left && enemyRect.Right < blockRect.Right)
                {
                    enemy.position.X = enemy.position.X - intersection.Width;
                    enemy.GoLeft();
                }
                else
                {
                    enemy.position.X = enemy.position.X + intersection.Width;
                    enemy.GoRight();
                }
            }
            else
            {
                if (enemyRect.Bottom > blockRect.Top && enemyRect.Bottom < blockRect.Bottom)
                {
                    enemy.position.Y = enemy.position.Y - intersection.Height;
                }
                else
                {
                    enemy.position.Y = enemy.position.Y + intersection.Height;
                }
            }
        }
    }
}
