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
        public Vector2 speedDecayRate = new Vector2((float)0.73, (float)0.70);
        float positionDtAdjust = 10;
        int positionShift = 7;

        public VVVVVVGroundState(Mario mario, int sign)
        {
            this.mario = mario;
            gravity*=sign;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity *= speedDecayRate;
            mario.position.Y += gravity * ValueHolder.flipFallRate;
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
