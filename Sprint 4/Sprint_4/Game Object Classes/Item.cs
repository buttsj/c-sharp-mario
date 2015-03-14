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
        public IAnimatedSprite sprite;
        public Item(IAnimatedSprite sprite)
        {
            this.sprite = sprite;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position);
        }
        public void GoLeft()
        {
            position.X--;
        }
        public void GoRight()
        {
            position.X++;
        }
        public void Update(GameTime gametime)
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
        public Rectangle GetRectangle()
        {
            return sprite.GetRectangle(position);
        }
    }
}
