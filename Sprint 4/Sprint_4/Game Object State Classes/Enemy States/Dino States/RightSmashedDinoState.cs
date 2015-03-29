using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class RightSmashedDinoState : IEnemyState
    {
        Game1 game;
        IAnimatedSprite sprite;
        
        public RightSmashedDinoState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.walkingRightSquishedDino);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage(Enemy enemy)
        {
            enemy.state = new DeadDinoState(game);
            enemy.isDead = true;
            enemy.position.Y += 8;
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.state = new LeftSmashedDinoState(game);
        }
        public void GoRight(Enemy enemy)
        {
            enemy.position.X+=(float)1.5;
        }

        public void Update(Enemy enemy, GameTime gameTime)
        {
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
