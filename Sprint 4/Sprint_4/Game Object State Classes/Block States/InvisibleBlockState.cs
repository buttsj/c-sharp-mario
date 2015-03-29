using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class InvisibleBlockState : IBlockState
    {
        Game1 game;
        IAnimatedSprite sprite;
        ISpriteFactory factory;

        public InvisibleBlockState(Game1 game)
        {
            this.game = game;
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
            block.state = new UsedBlockState(game);
        }
    }
}

