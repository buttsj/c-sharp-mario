using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class VVVVVVAirState : IMarioPhysicsState
    {
        private Mario mario;
        private float speedDecayRate = .73f;
        private float positionDtAdjust = 10;
        private int gravityStrength = 4;

        public VVVVVVAirState(Mario mario, int sign)
        {
            this.mario = mario;
            gravityStrength *= sign;
        }

        public void Update(GameTime gameTime)
        {
            mario.position.X += mario.velocity.X * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity.X *= speedDecayRate;
            mario.position.Y += gravityStrength;
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
