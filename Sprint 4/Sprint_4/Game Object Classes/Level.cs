using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Sprint4
{
    public class Level
    {
        Game1 game;
        public Mario mario;
        public LevelBuilder builder;
        public List<Enemy> levelEnemies = new List<Enemy>();
        public List<Block> levelBlocks = new List<Block>();
        public List<Item> levelItems = new List<Item>();
        public List<KeyValuePair<IAnimatedSprite, Vector2>> levelBackgrounds = new List<KeyValuePair<IAnimatedSprite, Vector2>>();
        public CollisionDetector collision;
        public SoundManager soundManager;
        public Texture2D background;
        
        public Level(Game1 game, string fileName, bool haveSound)
        {
            this.game = game;
            mario = new Mario(this.game, new Vector2(250, 444));
            builder = new LevelBuilder(game);
            builder.Build(fileName, levelEnemies, levelBlocks, levelItems, levelBackgrounds);
            collision = new CollisionDetector(game);
            soundManager = new SoundManager(game);
            //soundManager.PlaySong(SoundManager.songs.athletic);
            background = game.Content.Load<Texture2D>("background");
        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in levelEnemies)
            {
                enemy.Update(gameTime);
            }
            foreach (Item item in levelItems)
            {
                item.Update(gameTime);
            }
            foreach (Block blockUpdater in levelBlocks)
            {
                blockUpdater.Update(gameTime);
            }
            collision.Detect(mario, levelEnemies, levelBlocks, levelItems);
            mario.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            foreach (Enemy enemy in levelEnemies)
            {
                enemy.Draw(spriteBatch, new Vector2(enemy.xpos, enemy.ypos));
            }
            foreach (Item item in levelItems)
            {
                item.Draw(spriteBatch);
            }
            foreach (KeyValuePair<IAnimatedSprite, Vector2> backgroundObject in levelBackgrounds)
            {
                backgroundObject.Key.Draw(spriteBatch, backgroundObject.Value);
            }
            foreach (Block blockDrawer in levelBlocks)
            {
                blockDrawer.Draw(spriteBatch, new Vector2(blockDrawer.xpos, blockDrawer.ypos));
            }
            mario.Draw(spriteBatch);
        }
    }
}
