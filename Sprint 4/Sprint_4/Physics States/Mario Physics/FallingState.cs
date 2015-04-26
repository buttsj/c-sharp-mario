using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FallingState : IMarioPhysicsState
    {
        private Mario mario;
        private Vector2 fallingVelocityDecayRate = new Vector2(.76f, 1);
        private Vector2 fallingVelocity = new Vector2(0, .65f);
        private float positionDtAdjust = 40;
        int fallAnimTimer = 5;
        bool isFallingSprite = false;

        public FallingState(Mario mario)
        {
            this.mario = mario;
            mario.isFalling = true;
            mario.isJumping = false;
        }

        public void Update(GameTime gameTime)
        {
            fallAnimTimer--;
            if (fallAnimTimer < 0 && !isFallingSprite)
            {
                mario.state.Fall();
                isFallingSprite = true;
            }
            if (mario.velocity.Y < mario.maxVelocity.Y)
            {
                mario.velocity += fallingVelocity;
            }
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity *= fallingVelocityDecayRate;
            if(Game1.GetInstance().level.collision.standingBlocks.Count > 0 ||
                Game1.GetInstance().level.collision.standingPipes.Count > 0)
            {
                mario.physState = new GroundState(mario);
            }
            if (mario.position.Y > ValueHolder.fallingMarioBoundary)
            {
                mario.state = new DeadMS(mario);
                Game1.GetInstance().ach.AchievementAdjustment(AchievementsManager.AchievementType.Death);
            }       
        }
        public void Run() { }
        public void Flip() { }
    }
}
