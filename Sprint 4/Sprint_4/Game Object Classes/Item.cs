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
        public float xpos = 0, ypos = 0;
        public IAnimatedSprite sprite;
        public Item(IAnimatedSprite sprite)
        {
            this.sprite = sprite;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(xpos, ypos));
        }
        public void Update(GameTime gametime)
        {
            sprite.Update(gametime);
        }
        public Rectangle GetRectangle()
        {
            return sprite.GetRectangle(new Vector2(xpos, ypos));
        }
    }
}
