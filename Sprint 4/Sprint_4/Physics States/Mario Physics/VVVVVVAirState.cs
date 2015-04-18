using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class VVVVVVAirState :IMarioPhysicsState
    {
        public Vector2 speedDecayRate = new Vector2((float)0.73, (float)0.70);
        float positionDtAdjust = 10;
        int gravity = 4;
        Mario mario;

        public VVVVVVAirState(Mario mario, int sign)
        {
            this.mario = mario;
            gravity *= sign;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity *= speedDecayRate;
            mario.position.Y += gravity;
            if (Game1.GetInstance().level.collision.standingBlocks.Count > 0)
            {
                mario.physState = new VVVVVVGroundState(mario, mario.gravityDirection);
            }
        }
        public void Run() {
        }
        public void Flip() {
        }
    }
}
