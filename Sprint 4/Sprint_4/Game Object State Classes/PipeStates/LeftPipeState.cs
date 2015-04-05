using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftPipeState : IPipeState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        int animTimer = 100;
        
        public LeftPipeState()
        {
            factory = new SpriteFactory();
            this.sprite = factory.build(SpriteFactory.sprites.leftPipe);
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void Update(GameTime gameTime)
        {
            //null
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Eat()
        {
            //null
        }
        public void Puke()
        {

        }
    }
}