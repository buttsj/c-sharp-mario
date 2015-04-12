using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class VVVVVVPhysState :IMarioPhysicsState
    {
        Vector2 fallingVelocityDecayRate = new Vector2((float).90, 1);
        Vector2 fallingVelocity = new Vector2(0, (float)1.2);
        float positionDtAdjust = 50;
        int gravity = 1;

        public VVVVVVPhysState()
        {
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position.Y += gravity;
        }
        public void Run() { }
        public void Flip() { 
            gravity = -gravity;
        }
    }
}
