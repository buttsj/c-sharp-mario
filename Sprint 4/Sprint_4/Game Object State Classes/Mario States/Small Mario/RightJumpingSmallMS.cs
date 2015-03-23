using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightJumpingSmallMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;

        public RightJumpingSmallMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightJumpingMarioSmall);
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
            game.level.mario.state = new RightIdleSmallMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftJumpingSmallMS(game);
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
            game.level.mario.state = new RightMovingSmallMS(game);
        }
        public void MakeBigMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightJumpingBigMS(game));
        }
        public void MakeSmallMario()
        {
            // null
        }
        public void MakeFireMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightJumpingFireMS(game));
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
