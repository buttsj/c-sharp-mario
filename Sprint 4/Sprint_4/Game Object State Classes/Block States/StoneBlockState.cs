using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class BrickBlockState : IBlockState
    {
        IAnimatedSprite sprite;
        int bumpAnimTimer = 0;
        bool isBumped = false;

        public BrickBlockState()
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.brickBlock);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void Update(GameTime gameTime, Block block)
        {
            sprite.Update(gameTime);
            if (bumpAnimTimer > 0)
            {
                bumpAnimTimer--;
            }
            else if (isBumped && bumpAnimTimer <=0)
            {
                bumpAnimTimer = 0;
                block.position.Y+=2;
                isBumped = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }

        public void Reaction(Block block)
        {
            if (!isBumped)
            {
                block.position.Y -= 2;
                bumpAnimTimer = 7;
                isBumped = true;
            }
        }
    }
}