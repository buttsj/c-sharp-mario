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
        Game1 game;
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        
        public LeftSmashedDinoState(Game1 game)
        {
            factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.walkingLeftSquishedDino);
            this.game = game;
        }
        public Rectangle GetRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }
        public void TakeDamage(Enemy enemy)
        {
            enemy.state = new DeadDinoState(game);
            enemy.isDead = true;
            enemy.position.Y += 8;
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.position.X-=(float)1.5;
        }
        public void GoRight(Enemy enemy)
        {
            enemy.state = new RightSmashedDinoState(game);
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
