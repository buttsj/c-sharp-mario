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
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
        
        public LeftJumpingSmallMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftJumpingMarioSmall);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.state = new DeadMS(mario);
        }
        public void Up()
        {
        }
        public void Down()
        {
            mario.state = new LeftCrouchingSmallMS(mario);
        }
        public void GoLeft()
        {
            mario.position.X--;
        }
        public void GoRight()
        {
            mario.state = new RightJumpingSmallMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleSmallMS(mario);
        }
        public void Land()
        {
            mario.state = new LeftMovingSmallMS(mario);
        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new LeftJumpingBigMS(mario));
        }
        public void MakeSmallMario()
        {
            // null
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftJumpingFireMS(mario));
        }
        public void MakeFireballMario()
        {
            
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Flip() { }
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
