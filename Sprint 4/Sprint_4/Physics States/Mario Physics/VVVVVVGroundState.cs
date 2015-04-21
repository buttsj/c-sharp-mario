using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class VVVVVVGroundState : IMarioPhysicsState
    {
        private Mario mario;
        private float speedDecayRate = .73f;
        private float positionDtAdjust = 10;
        private int positionShift = 7;
        private int gravityStrength = 3;

        public VVVVVVGroundState(Mario mario, int sign)
        {
            this.mario = mario;
            gravityStrength*=sign;
        }

        public void Update(GameTime gameTime)
        {
            mario.position.X += mario.velocity.X * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity.X *= speedDecayRate;
            mario.position.Y += gravityStrength;
        }

        public void Run() 
        {
        }

        public void Flip() {
            SoundManager.flip.Play();
            mario.state.Flip();
            mario.gravityDirection = -mario.gravityDirection;
            mario.position.Y += positionShift*mario.gravityDirection;
            mario.physState = new VVVVVVAirState(mario, mario.gravityDirection);
        }
    }
}
