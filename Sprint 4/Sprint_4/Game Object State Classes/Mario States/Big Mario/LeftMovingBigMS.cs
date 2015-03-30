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
        Mario mario;
        IAnimatedSprite sprite;

        public LeftMovingBigMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftMovingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new LeftMovingSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new LeftJumpingBigMS(mario);
        }
        public void Down()
        {
            mario.state = new LeftCrouchingBigMS(mario);
        }
        public void GoLeft()
        {
            mario.position.X--;
        }
        public void GoRight()
        {
            mario.state = new RightMovingBigMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleBigMS(mario);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
        }
        public void MakeSmallMario()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new RightMovingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new LeftMovingFireMS(mario));
        }
        public void MakeFireballMario()
        {
            
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
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
