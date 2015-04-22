using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class GroundBlockState : IBlockState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;

        public GroundBlockState()
        {
            factory = new SpriteFactory();
            this.sprite = factory.build(SpriteFactory.sprites.ground);
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void Update(GameTime gameTime, Block block)
        {
            //null
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }
        public void Reaction(Block block)
        {
            //null
        }
    }
}