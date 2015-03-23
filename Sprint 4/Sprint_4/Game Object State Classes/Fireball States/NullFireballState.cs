using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class NullFireballState : IFireballState
    {
        Game1 game;
        IAnimatedSprite sprite;
        ISpriteFactory factory;

        public NullFireballState(Game1 game)
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.fireball);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 position)
        {
            return new Rectangle(0, 0, 0, 0);
        }
        
        public void GoLeft(Fireball fireball)
        {
            // null
        }
        public void GoRight(Fireball fireball)
        {
            // null
        }

        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }
    }
}

