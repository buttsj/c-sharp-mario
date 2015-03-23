using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class FireballState : IFireballState
    {
        Game1 game;
        IAnimatedSprite sprite;
        ISpriteFactory factory;

        public FireballState(Game1 game)
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.fireball);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        
        public void GoLeft(Fireball fireball)
        {
            fireball.position.X -= (float)2;
        }
        public void GoRight(Fireball fireball)
        {
            fireball.position.X += (float)2;
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
