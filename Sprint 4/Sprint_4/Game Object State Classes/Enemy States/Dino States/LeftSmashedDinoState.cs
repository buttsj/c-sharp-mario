using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class LeftSmashedDinoState : IEnemyState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        
        public LeftSmashedDinoState()
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.walkingLeftSquishedDino);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void TakeDamage(Enemy enemy)
        {
            enemy.state = new DeadDinoState();
            enemy.isDead = true;
            enemy.position.Y += 8;
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.position.X-=(float)1.5;
        }
        public void GoRight(Enemy enemy)
        {
            enemy.state = new RightSmashedDinoState();
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {
            enemy.position.Y++;
            enemy.physState.Update(enemy, gameTime);
            sprite.Update(gameTime);
            if (enemy.left)
            {
                enemy.GoLeft();
            }
            else
            {
                enemy.GoRight();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
