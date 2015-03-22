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
        public Dictionary<string, Block.BlockType> blockDictionary = new Dictionary<string, Block.BlockType>();
        public Dictionary<string, Enemy.Enemies> enemyDictionary = new Dictionary<string, Enemy.Enemies>();
        public Dictionary<string, SpriteFactory.sprites> backgroundDictionary = new Dictionary<string, SpriteFactory.sprites>();
        Game1 game;
        ISpriteFactory factory;

        public LevelBuilder(Game1 game)
        {
            factory = new SpriteFactory();
            itemDictionary.Add("F", SpriteFactory.sprites.fireFlower);
            itemDictionary.Add("C", SpriteFactory.sprites.coin);
            itemDictionary.Add("SM", SpriteFactory.sprites.superMushroom);
            itemDictionary.Add("1U", SpriteFactory.sprites.oneUpMushroom);
            itemDictionary.Add("*", SpriteFactory.sprites.star);
            backgroundDictionary.Add("bush1", SpriteFactory.sprites.bush1);
            backgroundDictionary.Add("bush2", SpriteFactory.sprites.bush2);
            backgroundDictionary.Add("bush3", SpriteFactory.sprites.bush3);
            blockDictionary.Add("Pi", Block.BlockType.pipe);
            enemyDictionary.Add("Koop", Enemy.Enemies.Koopa);
            enemyDictionary.Add("Tdin", Enemy.Enemies.Dino);
            enemyDictionary.Add("Bill", Enemy.Enemies.Bill);
            enemyDictionary.Add("Sdin", Enemy.Enemies.SmashedDino);
            blockDictionary.Add("Wing", Block.BlockType.winged);
            blockDictionary.Add("X", Block.BlockType.used);
            blockDictionary.Add("?", Block.BlockType.question);
            blockDictionary.Add("!", Block.BlockType.exclamation);
            blockDictionary.Add("B", Block.BlockType.brick);
            blockDictionary.Add("g", Block.BlockType.ground);
            blockDictionary.Add("l", Block.BlockType.leftEdge);
            blockDictionary.Add("r", Block.BlockType.rightEdge);
            blockDictionary.Add("!SM", Block.BlockType.exMush);
            this.game = game;
        }

        public void Build(string fileName, List<Enemy> levelEnemies, 
            List<Block> levelBlocks, List<Item> levelItems,
            List<KeyValuePair<IAnimatedSprite, Vector2>> levelBackgrounds)
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
                        Item item = new Item(game, factory.build(itemDictionary[words[i]]));
                        item.position.X = xCoord;
                        item.position.Y = yCoord;
                        levelItems.Add(item);
                    }
                    if (backgroundDictionary.ContainsKey(words[i]))
                    {
                        KeyValuePair<IAnimatedSprite, Vector2> item = new KeyValuePair<IAnimatedSprite,
                            Vector2>(factory.build(backgroundDictionary[words[i]]), new Vector2(xCoord, yCoord));
                        levelBackgrounds.Add(item);
                    }
                    if (blockDictionary.ContainsKey(words[i]))
                    {
                        Block block = new Block(game, blockDictionary[words[i]], new Vector2(xCoord, yCoord));
                        levelBlocks.Add(block);
                    }
                    if (enemyDictionary.ContainsKey(words[i]))
                    {
                       Enemy enemy = new Enemy(game, enemyDictionary[words[i]], new Vector2(xCoord, yCoord));
                       levelEnemies.Add(enemy);
                    }
                    xCoord+=16;
                }
            }
        }

    }
}
