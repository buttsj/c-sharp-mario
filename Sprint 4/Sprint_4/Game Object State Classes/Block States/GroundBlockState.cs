using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class GroundBlockState : IBlockState
    {
        Game1 game;
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        
        public GroundBlockState(Game1 game)
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.ground);
            this.game = game;
        }

        public Rectangle GetRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
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