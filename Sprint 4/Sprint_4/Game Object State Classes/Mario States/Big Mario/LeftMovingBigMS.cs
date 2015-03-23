using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftMovingBigMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;

        public LeftMovingBigMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftMovingMarioBig);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new LeftMovingSmallMS(game));
        }
        public void Up()
        {
            game.level.mario.state = new LeftJumpingBigMS(game);
        }
        public void Down()
        {
            game.level.mario.state = new LeftCrouchingBigMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.position.X--;
        }
        public void GoRight()
        {
            game.level.mario.state = new RightMovingBigMS(game);
        }
        public void Idle()
        {
            game.level.mario.state = new LeftIdleBigMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
           // no-op
        }
        public void MakeSmallMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightMovingSmallMS(game));
        }
        public void MakeFireMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new LeftMovingFireMS(game));
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
