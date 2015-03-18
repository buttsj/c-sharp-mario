using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightJumpingBigMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;
       

        public RightJumpingBigMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightJumpingMarioBig);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightJumpingSmallMS(game));
        }
        public void Up()
        {
            game.level.mario.position.Y--;
        }
        public void Down()
        {
            game.level.mario.state = new RightIdleBigMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftJumpingBigMS(game);
        }
        public void GoRight()
        {
            game.level.mario.position.X++;
        }
        public void Idle()
        {
            game.level.mario.state = new RightIdleBigMS(game);
        }
        public void Land()
        {
            game.level.mario.state = new RightMovingBigMS(game);
        }
        public void MakeBigMario()
        {
            // null
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new RightJumpingSmallMS(game);
        }
        public void MakeFireMario()
        {
            game.level.mario.state = new RightJumpingFireMS(game);
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
