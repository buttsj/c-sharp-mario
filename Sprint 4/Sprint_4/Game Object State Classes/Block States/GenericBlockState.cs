using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class GenericBlockState : IBlockState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        
        public GenericBlockState(SpriteFactory.sprites sprite)
        {
            factory = new SpriteFactory();
            this.sprite = factory.build(sprite);
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
            sprite.Draw(spriteBatch, location);
        }
        public void Reaction(Block block)
        {
            //null
        }
    }
}