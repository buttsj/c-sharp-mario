using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class RightWalkingShellessKS : IEnemyState
    {
        Game1 game;
        IAnimatedSprite sprite;
        
        public RightWalkingShellessKS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightWalkShellessKoopa);
            this.game = game;
        }
        public Rectangle GetRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage(Enemy enemy)
        {
            enemy.state = new DeadShellessKS(game);
            enemy.isDead = true;
        }
        public void GoLeft(Enemy enemy)
        {
            enemy.state = new LeftWalkingShellessKS(game);
        }
        public void GoRight(Enemy enemy)
        {
            enemy.xpos++;
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
