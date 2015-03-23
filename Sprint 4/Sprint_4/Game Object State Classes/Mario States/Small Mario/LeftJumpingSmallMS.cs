using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftJumpingSmallMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;
        
        public LeftJumpingSmallMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftJumpingMarioSmall);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            game.level.mario.state = new DeadMS(game);
        }
        public void Up()
        {

        }
        public void Down()
        {
            game.level.mario.state = new LeftCrouchingSmallMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.position.X--;
        }
        public void GoRight()
        {
            game.level.mario.state = new RightJumpingSmallMS(game);
        }
        public void Idle()
        {
            game.level.mario.state = new LeftIdleSmallMS(game);
        }
        public void Land()
        {
            game.level.mario.state = new LeftMovingSmallMS(game);
        }
        public void MakeBigMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new LeftJumpingBigMS(game));
        }
        public void MakeSmallMario()
        {
            // null
        }
        public void MakeFireMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new LeftJumpingFireMS(game));
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
