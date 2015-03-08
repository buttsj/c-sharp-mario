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
        public List<Block> standingBlocks;

        public CollisionDetector(Game1 game)
        {
            this.game = game;
            starSprite = factory.build(SpriteFactory.sprites.star);
            itemResponder = new ItemCollisionResponder(game);
            blockResponder = new BlockCollisionResponder(game);
            enemyResponder = new EnemyCollisionResponder(game);
            standingBlocks = new List<Block>();
        }

        public void Detect(Mario mario, List<Enemy> levelEnemies,
            List<Block> levelBlocks, List<Item> levelItems)
        {
            standingBlocks = new List<Block>();
            Rectangle marioRect = mario.state.getRectangle(new Vector2(mario.position.X, mario.position.Y));
            foreach (Enemy enemy in levelEnemies)
            {
                Rectangle enemyRect = enemy.GetRectangle();
                if (marioRect.Intersects(enemyRect))
                {
                    enemyResponder.MarioEnemyCollide(mario, enemy);
                }
            }
            foreach (Item item in levelItems)
            {
                Rectangle itemRect = item.GetRectangle();
                if (marioRect.Intersects(itemRect))
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
            }

            foreach (Block block in levelBlocks)
            {
                Rectangle blockRect = block.GetRectangle();
                foreach (Item item in levelItems)
                {
                    Rectangle itemRect = item.GetRectangle();
                    if (blockRect.Intersects(itemRect))
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
