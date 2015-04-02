using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class JumpingState : IMarioPhysicsState
    {
        public Vector2 speedDecayRate = new Vector2((float)0.75, (float)0.80);
        public static int maxJumpHeight = 125, jumpHeight = 0, heightIncrement = 7;
        double minJumpingVelocity = -.1;
        float positionXDtAdjust = 40;
        float positionYDtAdjust = 17;
        double maxJumpVelocity = -1.5;

        public JumpingState()
        {
        }
        public void Update(Mario mario, GameTime gameTime)
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
                mario.physState = new FallingState();
                mario.marioHeight = 0;
            }
        }
        public void Run() { }
    }
}
