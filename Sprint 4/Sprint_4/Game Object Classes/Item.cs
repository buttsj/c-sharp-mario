using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class Item : ICollectable 
    {
        Game1 game;
        public IAnimatedSprite sprite { get; set; }
        public bool isCoin { get; set; }
        public bool isSpawning { get; set; }
        private int spawnTimer = 0;
        private bool left = true;
        public Vector2 position;

        public Item(Game1 game, IAnimatedSprite sprite, Vector2 location)
        {
            this.sprite = sprite;
            this.game = game;
            position = location;
            isCoin = false;
            isSpawning = false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
        public void GoLeft()
        {
            position.X--;
            left = true;
        }
        public void GoRight()
        {
            position.X++;
            left = false;
        }
        public void Update(GameTime gametime)
        {
            if (!isSpawning)
            {
                position.Y++;
                sprite.Update(gametime);
                if (left)
                {
                    GoLeft();
                }
                else
                {
                    GoRight();
                }
            }
            else
            {
                position.Y-=(float).3;
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
            if (!isCoin)
            {
                game.level.levelItems.Add(this);
                spawnTimer = 50;
                game.soundManager.itemSpawn.Play();
            }
            else
            {
                game.soundManager.coinCollect.Play();
            }
        }
    }
}
