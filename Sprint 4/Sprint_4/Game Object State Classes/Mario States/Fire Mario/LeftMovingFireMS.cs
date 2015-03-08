using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftMovingFireMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;

        public LeftMovingFireMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftMovingMarioFire);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage()
        {
            game.level.mario.state = new LeftMovingSmallMS(game);
        }
        public void Up()
        {
            game.level.mario.state = new LeftJumpingFireMS(game);
        }
        public void Down()
        {
            game.level.mario.state = new LeftCrouchingFireMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.position.X--;
        }
        public void GoRight()
        {
            game.level.mario.state = new RightMovingFireMS(game);
        }
        public void Idle()
        {
            game.level.mario.state = new LeftIdleFireMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            game.level.mario.state = new LeftMovingBigMS(game);
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new LeftMovingSmallMS(game);
        }
        public void MakeFireMario()
        {
           //nop
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
