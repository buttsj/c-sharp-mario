using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class VVVVVVAirState :IMarioPhysicsState
    {
        Vector2 fallingVelocityDecayRate = new Vector2((float).90, 1);
        Vector2 fallingVelocity = new Vector2(0, (float)1.2);
        int gravity = 3;
        Mario mario;

        public VVVVVVAirState(int sign, Mario mario)
        {
            this.mario = mario;
            gravity = this.gravity * sign;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position.Y += gravity;
            if (Game1.GetInstance().level.collision.standingBlocks.Count > 0)
            {
                mario.physState = new VVVVVVGroundState(mario, gravity / 3);
            }
        }
        public void Run() {
        }
        public void Flip() { 
        }
    }
}
