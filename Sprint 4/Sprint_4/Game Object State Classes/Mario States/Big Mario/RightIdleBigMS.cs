using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class RightIdleBigMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;
        

        public RightIdleBigMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightIdleMarioBig);
            this.game = game;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightIdleSmallMS(game));
        }
        public void Up()
        {
            game.level.mario.state = new RightJumpingBigMS(game);
        }
        public void Down()
        {
            game.level.mario.state = new RightCrouchingBigMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftMovingBigMS(game);
        }
        public void GoRight()
        {
            game.level.mario.state = new RightMovingBigMS(game);
        }
        public void Idle()
        {

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
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightIdleSmallMS(game));
        }
        public void MakeFireMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightIdleFireMS(game));
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
