using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class LeftTallDinoState : IEnemyState
    {
        Game1 game;
        IAnimatedSprite sprite;
        
        public LeftTallDinoState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.walkingLeftDino);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void TakeDamage(Enemy enemy)
        {
            enemy.state = new LeftSmashedDinoState(game);
            enemy.position.Y += 16;
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.position.X--;
        }
        public void GoRight(Enemy enemy)
        {
            enemy.state = new RightTallDinoState(game);
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
