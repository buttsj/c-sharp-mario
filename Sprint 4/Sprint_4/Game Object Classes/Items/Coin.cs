using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class Coin : ICollectable 
    {
        Game1 game;
        public IAnimatedSprite sprite { get; set; }
        public bool isSpawning { get; set; }
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }
        ISpriteFactory factory = new SpriteFactory();

        public Coin(Game1 game, Vector2 location)
        {
            this.sprite = sprite;
            this.game = game;
            position = location;
            isSpawning = false;
            sprite = factory.build(SpriteFactory.sprites.coin);
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
            sprite.Update(gametime);
        }

        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }

        public void Spawn(){
            game.soundManager.coinCollect.Play();
        }
    }
}
