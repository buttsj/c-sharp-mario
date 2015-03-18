using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftCrouchingFireMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;
       

        public LeftCrouchingFireMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftCrouchingMarioFire);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }
        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new LeftCrouchingSmallMS(game));
        }
        public void Up()
        {
            game.level.mario.state = new LeftIdleFireMS(game);
        }
        public void Down()
        {
            game.level.mario.position.Y++;
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            game.level.mario.state = new RightCrouchingFireMS(game);
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
            game.level.mario.state = new LeftCrouchingBigMS(game);
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new LeftCrouchingSmallMS(game);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeFireballMario()
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
