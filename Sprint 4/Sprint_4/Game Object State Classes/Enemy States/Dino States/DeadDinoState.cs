using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class DeadDinoState : IEnemyState
    {
        IAnimatedSprite sprite;
        
        public DeadDinoState()
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftDeadDino);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage(Enemy enemy)
        {
            // null
        }
        public void GoLeft(Enemy enemy)
        {
            //null
        }
        public void GoRight(Enemy enemy)
        {
            //null
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {
            enemy.deathAnimationTimer--;
            if (enemy.deathAnimationTimer <= 0)
            {
                enemy.state = new NullEnemyState();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
