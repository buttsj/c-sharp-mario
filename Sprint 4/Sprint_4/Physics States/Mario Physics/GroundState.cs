using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class GroundState :IMarioPhysicsState
    {
        private Mario mario;
        private Vector2 speedDecayRate = new Vector2((float)0.73, (float)0.70);
        private float positionDtAdjust = 40;
        private double runMultiplier = 1.4;

        public GroundState(Mario mario)
        {
            mario.state.Land();
            mario.velocity.Y = 0;
            this.mario = mario;
            Game1.GetInstance().gameHUD.pointMultiplier = 1;
            mario.isJumping = false;
            mario.isFalling = false;
        }
        public void Update(GameTime gameTime)
        {
            mario.velocity.Y = 0;
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);

            mario.velocity *= speedDecayRate;
            if (Game1.GetInstance().level.collision.standingBlocks.Count == 0 &&
                Game1.GetInstance().level.collision.standingPipes.Count == 0)
            {
                mario.physState = new FallingState(mario);
            } 
        }
        public void Run()
        {
            if (mario.velocity.X > mario.minVelocity.X && mario.velocity.X < mario.maxVelocity.X)
            {
                mario.velocity.X *= (float)runMultiplier;
                mario.state.Sprite.UpdateSpeed-=2;
            }
        }
        public void Flip() { }
    }
}
