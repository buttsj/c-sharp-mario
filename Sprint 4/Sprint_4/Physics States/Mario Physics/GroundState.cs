using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class GroundState :IMarioPhysicsState
    {
        public Vector2 speedDecayRate = new Vector2((float)0.73, (float)0.70);
        float positionDtAdjust = 40;
        Mario mario;

        public GroundState(Mario mario)
        {
            mario.Land();
            mario.velocity.Y = 0;
            this.mario = mario;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.velocity.Y = 0;
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);

            mario.velocity *= speedDecayRate;
            if (Game1.GetInstance().level.collision.standingBlocks.Count == 0)
            {
                mario.physState = new FallingState();
            } 
        }
        public void Run()
        {
            if (mario.velocity.X > mario.minVelocity.X && mario.velocity.X < mario.maxVelocity.X)
            {
                mario.velocity.X *= (float)1.3;
                mario.state.Sprite.UpdateSpeed--;
            }
        }
    }
}
