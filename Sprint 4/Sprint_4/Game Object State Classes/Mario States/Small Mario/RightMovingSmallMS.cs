using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightMovingSmallMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;

        public RightMovingSmallMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightMovingMarioSmall);
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
            game.level.mario.state = new RightJumpingSmallMS(game);
        }
        public void Down()
        {
            game.level.mario.state = new RightCrouchingSmallMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftMovingSmallMS(game);
        }
        public void GoRight()
        {
            game.level.mario.position.X++;
        }
        public void Idle()
        {
            game.level.mario.state = new RightIdleSmallMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightMovingBigMS(game));
        }
        public void MakeSmallMario()
        {
            // no-op
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
