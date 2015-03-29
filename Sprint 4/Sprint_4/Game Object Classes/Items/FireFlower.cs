using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FireFlower : ICollectable 
    {
        Game1 game;
        public IAnimatedSprite sprite { get; set; }
        public bool isSpawning { get; set; }
        private int spawnTimer = 0;
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }
        ISpriteFactory factory = new SpriteFactory();

        public FireFlower(Game1 game, Vector2 location)
        {
            this.sprite = sprite;
            this.game = game;
            position = location;
            isSpawning = false;
            sprite = factory.build(SpriteFactory.sprites.fireFlower);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
        }
        public void Update(GameTime gametime)
        {
            if (!isSpawning)
            {
                sprite.Update(gametime);
            }
            else
            {
                position = new Vector2(position.X, position.Y - (float).3);
                spawnTimer--;
                if (spawnTimer == 0)
                {
                    isSpawning = false;
                }
            }
        }

        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }

        public void Spawn(){
            isSpawning = true;
            game.level.levelItems.Add(this);
            spawnTimer = 50;
            game.soundManager.itemSpawn.Play();
        }
    }
}
