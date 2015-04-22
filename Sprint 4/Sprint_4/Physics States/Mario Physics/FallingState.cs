using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FallingState : IMarioPhysicsState
    {
        private Mario mario;
        private Vector2 fallingVelocityDecayRate = new Vector2(.73f, 1);
        private Vector2 fallingVelocity = new Vector2(0, .85f);
        private float positionDtAdjust = 40;

        public FallingState(Mario mario)
        {
            this.mario = mario;
            mario.state.Fall();
            mario.isFalling = true;
            mario.isJumping = false;
        }

        public void Update(GameTime gameTime)
        {
            mario.velocity += fallingVelocity;
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
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
