using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Sprint4
{
    public class CollisionTests
    {
        public List<Enemy> levelEnemies = new List<Enemy>();
        public List<Block> levelBlocks = new List<Block>();
        public List<Item> levelItems = new List<Item>();
        SpriteFactory factory = new SpriteFactory();
        StreamWriter fileOut = new StreamWriter("collisionDebug.txt");
        Game1 game;
        Vector2 starting = new Vector2(250, 450);
        public CollisionTests(Game1 game)
        {
            this.game = game;
        }
        public void SmallMarioEnemySideCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            CollisionDetector collision = new CollisionDetector(game);
            Enemy enemy = new Enemy(game, Enemy.Enemies.Dino, new Vector2(245, 450));
            levelEnemies.Add(enemy);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if ((new DeadMS(game).GetType()) == game.level.mario.state.GetType())
            {
                fileOut.WriteLine("SmallMarioEnemySideCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("SmallMarioEnemySideCollision: Failed");
            }
        }

        public void SmallMarioEnemyBottomCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            CollisionDetector collision = new CollisionDetector(game);
            Enemy enemy = new Enemy(game, Enemy.Enemies.Dino, new Vector2(250, 440));
            levelEnemies.Add(enemy);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if ((new DeadMS(game).GetType()) == game.level.mario.state.GetType())
            {
                fileOut.WriteLine("SmallMarioEnemyBottomCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("SmallMarioEnemyBottomCollision: Failed");
            }
        }

        public void SmallMarioMushroomCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            CollisionDetector collision = new CollisionDetector(game);
            IAnimatedSprite mushroom = factory.build(SpriteFactory.sprites.superMushroom);
            Item item = new Item(mushroom);
            item.xpos = 250;
            item.ypos = 450;
            levelItems.Add(item);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if ((new RightIdleBigMS(game).GetType()) == game.level.mario.state.GetType())
            {
                fileOut.WriteLine("SmallMarioMushroomCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("SmallMarioMushroomCollision: Failed");
            }
        }

        public void SmallMarioFlowerCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            CollisionDetector collision = new CollisionDetector(game);
            IAnimatedSprite flower = factory.build(SpriteFactory.sprites.fireFlower);
            Item item = new Item(flower);
            item.xpos = 250;
            item.ypos = 450;
            levelItems.Add(item);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if ((new RightIdleFireMS(game).GetType()) == game.level.mario.state.GetType())
            {
                fileOut.WriteLine("SmallMarioFlowerCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("SmallMarioFlowerCollision: Failed");
            }
        }

        public void BigMarioFlowerCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            game.level.mario.MakeBigMario();
            CollisionDetector collision = new CollisionDetector(game);
            IAnimatedSprite flower = factory.build(SpriteFactory.sprites.fireFlower);
            Item item = new Item(flower);
            item.xpos = 250;
            item.ypos = 450;
            levelItems.Add(item);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if ((new RightIdleFireMS(game).GetType()) == game.level.mario.state.GetType())
            {
                fileOut.WriteLine("BigMarioFlowerCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("BigMarioFlowerCollision: Failed");
            }
        }

        public void MarioStarCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            CollisionDetector collision = new CollisionDetector(game);
            IAnimatedSprite star = factory.build(SpriteFactory.sprites.star);
            Item item = new Item(star);
            item.xpos = 250;
            item.ypos = 450;
            levelItems.Add(item);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if (game.level.mario.marioIsStar)
            {
                fileOut.WriteLine("MarioStarCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("MarioStarCollision: Failed");
            }
        }

        public void MarioCoinCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            levelItems = new List<Item>();
            CollisionDetector collision = new CollisionDetector(game);
            IAnimatedSprite coin = factory.build(SpriteFactory.sprites.coin);
            Item item = new Item(coin);
            item.xpos = 250;
            item.ypos = 450;
            levelItems.Add(item);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if (levelItems == new List<Item>())
            {
                fileOut.WriteLine("MarioCoinCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("MarioCoinCollision: Failed");
            }
        }

        public void Mario1UpCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            levelItems = new List<Item>();
            CollisionDetector collision = new CollisionDetector(game);
            IAnimatedSprite oneUp = factory.build(SpriteFactory.sprites.oneUpMushroom);
            Item item = new Item(oneUp);
            item.xpos = 250;
            item.ypos = 450;
            levelItems.Add(item);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if (levelItems == new List<Item>())
            {
                fileOut.WriteLine("Mario1UpCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("Mario1UpCollision: Failed");
            }
        }

        public void BigMarioBrickBlockBottomCollision()
        {
            //arrange
            game.level.mario = new Mario(game, starting);
            CollisionDetector collision = new CollisionDetector(game);
            Block block = new Block(game, Block.BlockType.brick, new Vector2(250, 445));
            levelBlocks.Add(block);
            //act
            collision.Detect(game.level.mario, levelEnemies, levelBlocks, levelItems);
            //assert
            if (new List<Block>() == levelBlocks)
            {
                fileOut.WriteLine("BigMarioBrickBottomCollision: Passed");
            }
            else
            {
                fileOut.WriteLine("BigMarioBrickBottomCollision: Failed");
            }
        }

        public void Test()
        {
            using (fileOut){
            SmallMarioEnemySideCollision();
            SmallMarioEnemyBottomCollision();
            SmallMarioMushroomCollision();
            SmallMarioFlowerCollision();
            BigMarioFlowerCollision();
            MarioStarCollision();
            MarioCoinCollision();
            Mario1UpCollision();
            BigMarioBrickBlockBottomCollision();
            }
            game.level = new Level(game, "/Maps/Map.csv", false);
        }
    }
}
