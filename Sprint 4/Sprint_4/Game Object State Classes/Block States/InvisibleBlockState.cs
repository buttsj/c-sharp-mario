using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class InvisibleBlockState : IBlockState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;

        public InvisibleBlockState()
        {
            factory = new SpriteFactory();
            sprite = new NullSprite();
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, 16, 16);
        }
        public void Update(GameTime gameTime, Block block)
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }
        public void Reaction(Block block)
        {
            block.state = new GenericBlockState(SpriteFactory.sprites.usedBlock);
        }
    }
}

