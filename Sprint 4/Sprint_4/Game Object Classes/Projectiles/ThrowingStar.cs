using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Sprint4
{
    public class ThrowingStar
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        public bool left = true;
        public bool down = true;
        public Vector2 position;
        public int throwingStarLifespan = 150;
        int gravityTime = 110;
        int moveRate = 3;

        public ThrowingStar(Vector2 location, bool left)
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.throwingStar);
            position = location;
            this.left = left;            
        }

        public void GoLeft()
        {
            position.X -= moveRate;
            left = true;
        }
        public void GoRight()
        {
            position.X += moveRate;
            left = false;
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (throwingStarLifespan != 0)
            {
                throwingStarLifespan--;
                if (left)
                {
                    GoLeft();
                }
                else
                {
                    GoRight();
                }
            }
            if (throwingStarLifespan < gravityTime)
            {
                position.Y += 0.2f;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position, Color.White);
        }
        public Rectangle GetBoundingBox()
        {
            return sprite.GetBoundingBox(position);
        }
    }
}
