using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint4
{
    class RightTallDinoState : IEnemyState
    {
        Game1 game;
        IAnimatedSprite sprite;
        
        public RightTallDinoState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.walkingRightDino);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage(Enemy enemy)
        {
            enemy.state = new RightSmashedDinoState(game);
            enemy.position.Y += 16;
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.state = new LeftTallDinoState(game);
        }
        public void GoRight(Enemy enemy)
        {
            enemy.position.X++;
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
