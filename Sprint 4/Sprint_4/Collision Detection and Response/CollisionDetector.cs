using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class CollisionDetector
    {
        Game1 game;
        IAnimatedSprite starSprite;
        ISpriteFactory factory = new SpriteFactory();
        public List<Block> destroyedBlocks = new List<Block>();
        public List<Item> obtainedItems = new List<Item>();
        public ItemCollisionResponder itemResponder;
        public EnemyCollisionResponder enemyResponder;
        public BlockCollisionResponder blockResponder;
        public FireballCollisionResponder fireballResponder;
        public List<Block> standingBlocks;

        public CollisionDetector(Game1 game)
        {
            this.game = game;
            starSprite = factory.build(SpriteFactory.sprites.star);
            itemResponder = new ItemCollisionResponder(game);
            blockResponder = new BlockCollisionResponder(game);
            enemyResponder = new EnemyCollisionResponder(game);
            fireballResponder = new FireballCollisionResponder(game);
            standingBlocks = new List<Block>();
        }

        public void Detect(Mario mario, List<Fireball> levelFireballs, List<Enemy> levelEnemies,
            List<Block> levelBlocks, List<Item> levelItems)
        {
            standingBlocks = new List<Block>();
            Rectangle marioRect = mario.state.getRectangle(new Vector2(mario.position.X, mario.position.Y));
            foreach (Enemy enemy in levelEnemies)
            {
                if (!enemy.isDead && mario.invicibilityFrames ==0)
                {
                    Rectangle enemyRect = enemy.GetRectangle();
                    if (marioRect.Intersects(enemyRect))
                    {
                        enemyResponder.MarioEnemyCollide(mario, enemy);
                    }
                }
              foreach (Fireball fireball in levelFireballs)
              {
                  if (!enemy.isDead)
                  {
                      Rectangle enemyRect = enemy.GetRectangle();
                      Rectangle fireballRect = fireball.GetRectangle();
                      if (fireballRect.Intersects(enemyRect))
                      {
                          fireballResponder.EnemyFireballCollide(enemy, fireball);
                      }
                  }
              }               
              
            }
            foreach (Item item in levelItems)
            {
                Rectangle itemRect = item.GetRectangle();
                if (marioRect.Intersects(itemRect) && !item.isSpawning)
                {
                    obtainedItems.Add(item);
                    itemResponder.MarioItemCollide(item, mario);
                }
            }

            foreach (Block block in levelBlocks)
            {
                Rectangle blockRect = block.GetRectangle();
                if (marioRect.Intersects(blockRect))
                {
                    blockResponder.MarioBlockCollide(mario, block, destroyedBlocks, standingBlocks);
                }

                foreach (Fireball fireball in levelFireballs)
                { 
                    Rectangle fireballRect = fireball.GetRectangle();
                    if(fireballRect.Intersects(blockRect))
                    {
                        fireballResponder.BlockFireballCollide(block, fireball);
                    }
                }               
              
            }

            foreach (Block block in levelBlocks)
            {
                Rectangle blockRect = block.GetRectangle();
                foreach (Item item in levelItems)
                {
                    Rectangle itemRect = item.GetRectangle();
                    if (blockRect.Intersects(itemRect) && !item.isSpawning)
                    {
                        blockResponder.ItemBlockCollide(item, block);
                    }
                }
            }

            foreach (Enemy enemy in levelEnemies)
            {
                    Rectangle enemyRect = enemy.GetRectangle();
                    foreach (Block block in levelBlocks)
                    {
                        Rectangle blockRect = block.GetRectangle();
                        if (blockRect.Intersects(enemyRect))
                        {
                            blockResponder.EnemyBlockCollide(enemy, block);
                        }
                    }

                    foreach (Enemy otherEnemy in levelEnemies)
                    {
                        Rectangle otherEnemyRect = enemy.GetRectangle();
                        if (otherEnemy != enemy && enemyRect.Intersects(otherEnemyRect))
                        {
                            enemyResponder.EnemyEnemyCollide(enemy, otherEnemy);
                        }
                    }
                
            }

            foreach (Item obtainedItem in obtainedItems)
            {
                levelItems.Remove(obtainedItem);
            }
            foreach (Block destroyedBlock in destroyedBlocks)
            {
                levelBlocks.Remove(destroyedBlock);
            }
        }
    }
}
