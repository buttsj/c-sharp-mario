using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class FallingState :IMarioPhysicsState
    {
        Vector2 fallingVelocityDecayRate = new Vector2((float).90, 1);
        Vector2 fallingVelocity = new Vector2(0, (float)1.2);
        float positionDtAdjust = 50;

        public FallingState()
        {
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity += fallingVelocity;
            mario.velocity *= fallingVelocityDecayRate;
            if (mario.velocity.Y > mario.maxVelocity.Y){
                mario.velocity.Y = mario.maxVelocity.Y;
            }
            if(Game1.GetInstance().level.collision.standingBlocks.Count > 0)
            {
                mario.physState = new GroundState(mario);
            }
        }
    }
}
