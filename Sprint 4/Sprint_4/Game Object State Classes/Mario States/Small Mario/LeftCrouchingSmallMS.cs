using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftCrouchingSmallMS : IMarioState
    {

        Game1 game;
        IAnimatedSprite sprite;
       

        public LeftCrouchingSmallMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftCrouchingMarioSmall);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage()
        {
            game.level.mario.state = new DeadMS(game);
        }
        public void Up()
        {
            game.level.mario.state = new LeftIdleSmallMS(game);
        }
        public void Down()
        {
            game.level.mario.position.Y++;
        }
        public void GoLeft()
        {
            game.level.mario.position.X--;
        }
        public void GoRight()
        {
            game.level.mario.state = new RightCrouchingSmallMS(game);
        }
        public void Idle()
        {
            game.level.mario.state = new LeftIdleSmallMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            game.level.mario.state = new LeftCrouchingBigMS(game);
        }
        public void MakeSmallMario()
        {
            // null
        }
        public void MakeFireMario()
        {
            game.level.mario.state = new LeftCrouchingFireMS(game);
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
