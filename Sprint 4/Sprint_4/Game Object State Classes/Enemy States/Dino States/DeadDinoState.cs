using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class DeadDinoState : IEnemyState
    {
        Game1 game;
        IAnimatedSprite sprite;
        
        public DeadDinoState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftDeadDino);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage(BasicEnemy enemy)
        {
            // null
        }
        public void GoLeft(BasicEnemy enemy)
        {
            //null
        }
        public void GoRight(BasicEnemy enemy)
        {
            //null
        }

        public void Update(GameTime gameTime)
        {
            //null
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
