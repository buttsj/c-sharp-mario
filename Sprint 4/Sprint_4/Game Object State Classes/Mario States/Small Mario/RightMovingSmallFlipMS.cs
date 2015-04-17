using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightMovingSmallFlipMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }

        public RightMovingSmallFlipMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightMovingMarioFlip);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.state = new DeadFlipMS(mario);
        }
        public void Up()
        {
            mario.state = new LeftJumpingSmallMS(mario);
        }
        public void Down()
        {
            mario.state = new LeftCrouchingSmallMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftMovingSmallFlipMS(mario);
        }
        public void GoRight()
        {
            mario.position.X++;
        }
        public void Idle()
        {
            mario.state = new RightIdleSmallFlipMS(mario);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new LeftMovingBigMS(mario));
        }
        public void MakeSmallMario()
        {
            // no-op
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftMovingFireMS(mario));
        }
        public void MakeFireballMario()
        {
            
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Flip() 
        {
            mario.state = new RightMovingSmallMS(mario);
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}
