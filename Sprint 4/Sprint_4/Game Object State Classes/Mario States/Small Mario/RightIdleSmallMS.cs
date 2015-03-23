using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class RightIdleSmallMS : IMarioState
    {

        Game1 game;
        IAnimatedSprite sprite;
        
        public RightIdleSmallMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightIdleMarioSmall);
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
            game.level.mario.state = new RightMovingSmallMS(game);
        }
        public void Idle()
        {

        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            game.gameState = new TransitionGameState(game, game.level.mario.state, new RightIdleBigMS(game));
        }
        public void MakeSmallMario()
        {
            // null
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
