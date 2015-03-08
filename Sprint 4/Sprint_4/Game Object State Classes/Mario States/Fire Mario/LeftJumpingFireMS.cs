using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftJumpingFireMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;
        

        public LeftJumpingFireMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftJumpingMarioFire);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage()
        {
            game.level.mario.state = new LeftJumpingSmallMS(game);
        }
        public void Up()
        {
            game.level.mario.position.Y--;
        }
        public void Down()
        {
            game.level.mario.state = new LeftIdleFireMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.position.X--;
        }
        public void GoRight()
        {
            game.level.mario.state = new RightJumpingFireMS(game);
        }
        public void Idle()
        {
            game.level.mario.state = new LeftIdleFireMS(game);
        }
        public void Land()
        {
            game.level.mario.state = new LeftMovingFireMS(game);
        }
        public void MakeBigMario()
        {
            game.level.mario.state = new LeftJumpingBigMS(game);
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new LeftJumpingSmallMS(game);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeDeadMario()
        {
            game.level.mario.state = new DeadMS(game);
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
