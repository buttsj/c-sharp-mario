using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class LevelBuilder
    {
        public Dictionary<string, SpriteFactory.sprites> itemDictionary =  new Dictionary<string, SpriteFactory.sprites>();
        public Dictionary<string, BlockFactory.BlockType> blockDictionary = new Dictionary<string, BlockFactory.BlockType>();
        public Dictionary<string, EnemyFactory.EnemyType> enemyDictionary = new Dictionary<string, EnemyFactory.EnemyType>();
        public Dictionary<string, SpriteFactory.sprites> backgroundDictionary = new Dictionary<string, SpriteFactory.sprites>();
        Game1 game;
        ISpriteFactory factory;
        BlockFactory blockFactory;
        EnemyFactory enemyFactory;

        public LevelBuilder(Game1 game)
        {
            factory = new SpriteFactory();
            blockFactory = new BlockFactory(game);
            enemyFactory = new EnemyFactory(game);
            itemDictionary.Add("F", SpriteFactory.sprites.fireFlower);
            itemDictionary.Add("C", SpriteFactory.sprites.coin);
            itemDictionary.Add("SM", SpriteFactory.sprites.superMushroom);
            itemDictionary.Add("1U", SpriteFactory.sprites.oneUpMushroom);
            itemDictionary.Add("*", SpriteFactory.sprites.star);
            backgroundDictionary.Add("bush1", SpriteFactory.sprites.bush1);
            backgroundDictionary.Add("bush2", SpriteFactory.sprites.bush2);
            backgroundDictionary.Add("bush3", SpriteFactory.sprites.bush3);
            blockDictionary.Add("Pi", BlockFactory.BlockType.pipe);
            enemyDictionary.Add("Koop", EnemyFactory.EnemyType.Koopa);
            enemyDictionary.Add("Tdin", EnemyFactory.EnemyType.Dino);
            enemyDictionary.Add("Bill", EnemyFactory.EnemyType.Bill);
            enemyDictionary.Add("Sdin", EnemyFactory.EnemyType.SmashedDino);
            blockDictionary.Add("Wing", BlockFactory.BlockType.winged);
            blockDictionary.Add("X", BlockFactory.BlockType.used);
            blockDictionary.Add("?", BlockFactory.BlockType.question);
            blockDictionary.Add("!", BlockFactory.BlockType.exclamation);
            blockDictionary.Add("B", BlockFactory.BlockType.brick);
            blockDictionary.Add("g", BlockFactory.BlockType.ground);
            blockDictionary.Add("l", BlockFactory.BlockType.leftEdge);
            blockDictionary.Add("r", BlockFactory.BlockType.rightEdge);
            blockDictionary.Add("?SM", BlockFactory.BlockType.quesMush);
            blockDictionary.Add("?C", BlockFactory.BlockType.quesCoin);
            blockDictionary.Add("?1U", BlockFactory.BlockType.ques1up);
            blockDictionary.Add("?*", BlockFactory.BlockType.quesStar);
            blockDictionary.Add("?F", BlockFactory.BlockType.quesFlower);
            this.game = game;
        }

        public void Build(string fileName, List<BasicEnemy> levelEnemies, 
            List<Block> levelBlocks, List<ICollectable> levelItems,
            List<KeyValuePair<IAnimatedSprite, Vector2>> levelBackgroundObjects)
        {
            float xCoord =0, yCoord = 0;
            StreamReader sr;
            sr = File.OpenText(game.Content.RootDirectory + fileName);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                yCoord+=16;
                xCoord = 0;
                string[] words = line.Split(',');
                for (int i = 0; i < words.Length; i++)
                { 
                    if(itemDictionary.ContainsKey(words[i]))
                    {
                        ICollectable item = new Item(game, factory.build(itemDictionary[words[i]]), new Vector2(xCoord, yCoord));
                        levelItems.Add(item);
                    }
                    if (backgroundDictionary.ContainsKey(words[i]))
                    {
                        KeyValuePair<IAnimatedSprite, Vector2> item = new KeyValuePair<IAnimatedSprite,
                            Vector2>(factory.build(backgroundDictionary[words[i]]), new Vector2(xCoord, yCoord));
                        levelBackgroundObjects.Add(item);
                    }
                    if (blockDictionary.ContainsKey(words[i]))
                    {
                        Block block = blockFactory.build(blockDictionary[words[i]], new Vector2(xCoord, yCoord));
                        levelBlocks.Add(block);
                    }
                    if (enemyDictionary.ContainsKey(words[i]))
                    {
                       BasicEnemy enemy = enemyFactory.build(enemyDictionary[words[i]], new Vector2(xCoord, yCoord));
                       levelEnemies.Add(enemy);
                    }
                    xCoord+=16;
                }
            }
        }

    }
}
