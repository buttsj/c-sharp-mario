using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class FallingState : IMarioPhysicsState
    {
        private Mario mario;
        private Vector2 fallingVelocityDecayRate = new Vector2((float).90, 1);
        private Vector2 fallingVelocity = new Vector2(0, (float)1.2);
        private float positionDtAdjust = 50;

        public FallingState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = true;
            mario.isJumping = false;
        }

        public void Update(GameTime gameTime)
        {
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity += fallingVelocity;
            mario.velocity *= fallingVelocityDecayRate;
            if (mario.velocity.Y > mario.maxVelocity.Y){
                mario.velocity.Y = mario.maxVelocity.Y;
            }
            if(Game1.GetInstance().level.collision.standingBlocks.Count > 0 ||
                Game1.GetInstance().level.collision.standingPipes.Count > 0)
            {
                mario.physState = new GroundState(mario);
            }
        }
        public void Run() { }
        public void Flip() { }
    }
}
