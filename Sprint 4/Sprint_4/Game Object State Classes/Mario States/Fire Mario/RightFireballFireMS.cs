using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightFireballFireMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;


        public RightFireballFireMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightFireballMarioFire);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }
        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightIdleSmallMS(game));
        }
        public void Up()
        {
            game.level.mario.state = new RightIdleFireMS(game);
        }
        public void Down()
        {
            game.level.mario.state = new RightCrouchingFireMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftFireballFireMS(game);
        }
        public void GoRight()
        {
            game.level.mario.state = new RightMovingFireMS(game);   
        }
        public void Idle()
        {
            game.level.mario.state = new RightIdleFireMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            game.level.mario.state = new RightIdleBigMS(game);
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new RightIdleSmallMS(game);
        }
        public void MakeFireMario()
        {
            game.level.mario.state = new RightIdleFireMS(game);
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
