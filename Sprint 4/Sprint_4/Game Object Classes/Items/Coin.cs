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
        public IAnimatedSprite sprite { get; set; }
        public bool isSpawning { get; set; }
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }
        public ICollectablePhysicsState physState { get; set; }
        ISpriteFactory factory = new SpriteFactory();

        public Coin(Vector2 location)
        {
            this.sprite = sprite;
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
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }

        public void Spawn(){
            SoundManager.coinCollect.Play();
        }
    }
}
