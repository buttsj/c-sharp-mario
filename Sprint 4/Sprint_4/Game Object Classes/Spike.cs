using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Sprint4
{
    public class Spike
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        public Vector2 position;

        public Spike(Vector2 location, bool up)
        {
            factory = new SpriteFactory();
            if(up)
            {
                sprite = factory.build(SpriteFactory.sprites.upSpike);
            }
            else
            {
                sprite = factory.build(SpriteFactory.sprites.downSpike);
            }
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
