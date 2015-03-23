using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftFireballFireMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;


        public LeftFireballFireMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftFireballMarioFire);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new LeftIdleSmallMS(game));
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
            game.level.mario.state = new LeftMovingFireMS(game);            
        }
        public void GoRight()
        {
            game.level.mario.state = new RightFireballFireMS(game);
        }
        public void Idle()
        {
             
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            game.level.mario.state = new LeftIdleBigMS(game);
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new LeftIdleSmallMS(game);
        }
        public void MakeFireMario()
        {
            game.level.mario.state = new LeftIdleFireMS(game);
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
