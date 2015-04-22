using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Trampoline
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        public Vector2 position;

        public Trampoline(Vector2 location)
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.trampoline);
            position = location;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }
    }
}
