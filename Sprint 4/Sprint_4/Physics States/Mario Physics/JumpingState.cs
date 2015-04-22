using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class JumpingState : IMarioPhysicsState
    {
        private Mario mario;
        private Vector2 speedDecayRate = new Vector2(.78f, .5f);
        private static int maxJumpHeight = 150;
        private static int heightIncrement = 7;
        private double minJumpingVelocity = -.005;
        private double maxJumpVelocity = -1;
        private float positionXDtAdjust = 40;
        private float positionYDtAdjust = 17;

        public JumpingState(Mario mario)
        {
            this.mario = mario;
            mario.isJumping = true;
        }

        public void Update(GameTime gameTime)
        {
            mario.position.Y += mario.velocity.Y * ((float)gameTime.ElapsedGameTime.Milliseconds / positionYDtAdjust);
            mario.position.X += mario.velocity.X * ((float)gameTime.ElapsedGameTime.Milliseconds / positionXDtAdjust);
            mario.velocity *= speedDecayRate;
            mario.marioHeight += heightIncrement;
            if (mario.velocity.Y > maxJumpVelocity) { 
                mario.velocity.Y =0; 
            }
            if (mario.velocity.Y > minJumpingVelocity || mario.marioHeight > maxJumpHeight)
            {
                mario.physState = new FallingState(mario);
                mario.marioHeight = 0;
            }
        }
        public void Run() { }
        public void Flip() { }
    }
}
