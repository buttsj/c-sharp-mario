using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class BrickBlockState : IBlockState
    {
        Game1 game;
        IAnimatedSprite sprite;
        int bumpAnimTimer = 0;
        bool isBumped = false;

        public BrickBlockState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.brickBlock);
            this.game = game;
        }
        public Rectangle GetRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
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
            sprite.Draw(spriteBatch, location);
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