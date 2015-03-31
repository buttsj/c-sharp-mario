using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightMovingBigMS : IMarioState
    {
        Mario mario;
        IAnimatedSprite sprite;

        public RightMovingBigMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightMovingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightMovingSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new RightJumpingBigMS(mario);
        }
        public void Down()
        {
            mario.state = new RightCrouchingBigMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftMovingBigMS(mario);
        }
        public void GoRight()
        {
            mario.position.X++;
        }
        public void Idle()
        {
            mario.state = new RightIdleBigMS(mario);
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
            mario.TransitionState(mario.state, new RightMovingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new RightMovingFireMS(mario));
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
