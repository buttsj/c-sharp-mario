using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class Item
    {
        public Vector2 position = new Vector2(0, 0);
        bool left = true;
        Game1 game;
        public IAnimatedSprite sprite;
        public bool isSpawning = false;
        int spawnTimer = 0;
        public bool isCoin = false;

        public Item(Game1 game, IAnimatedSprite sprite)
        {
            this.sprite = sprite;
            this.game = game;
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
        public Rectangle GetRectangle()
        {
            return sprite.GetRectangle(position);
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
