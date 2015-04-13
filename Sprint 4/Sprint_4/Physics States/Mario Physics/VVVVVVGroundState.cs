using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class VVVVVVGroundState :IMarioPhysicsState
    {
        int gravity = 1;
        Mario mario;

        public VVVVVVGroundState(Mario mario, int gravity)
        {
            this.mario = mario;
            this.gravity *= gravity;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position.Y += gravity;
        }
        public void Run() 
        {
        }
        public void Flip() {
            gravity = -gravity;
            mario.physState = new VVVVVVAirState(gravity, mario);
        }
    }
}
