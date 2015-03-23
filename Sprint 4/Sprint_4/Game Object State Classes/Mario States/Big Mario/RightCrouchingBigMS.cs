using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightCrouchingBigMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;
        

        public RightCrouchingBigMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightCrouchingMarioBig);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightCrouchingSmallMS(game));
        }
        public void Up()
        {
            game.level.mario.state = new RightIdleBigMS(game);
        }
        public void Down()
        {
            game.level.mario.position.Y++;
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftCrouchingBigMS(game);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
            game.level.mario.state = new RightIdleBigMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            // null
        }
        public void MakeSmallMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightCrouchingSmallMS(game));
        }
        public void MakeFireMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightMovingFireMS(game));
        }
        public void MakeFireballMario()
        {
            
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
