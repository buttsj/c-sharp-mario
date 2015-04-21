using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    public class NullSprite : IAnimatedSprite
    {
        public int UpdateSpeed { get; set; }
        public NullSprite()
        {
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return new Rectangle(0, 0, 0, 0);
        }
        public void Update(GameTime gametime) { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }
    }
}
