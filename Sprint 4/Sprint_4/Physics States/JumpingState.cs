using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class JumpingState : IMarioPhysicsState
    {
        Game1 game;
        public Vector2 speedDecayRate = new Vector2((float)0.75, (float)0.80);
        public static int maxJumpHeight = 120, jumpHeight = 0;
        public JumpingState(Game1 game)
        {
            this.game = game;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position.Y += mario.velocity.Y * ((float)gameTime.ElapsedGameTime.Milliseconds / (float)15.0);
            mario.position.X += mario.velocity.X * ((float)gameTime.ElapsedGameTime.Milliseconds / (float)40.0);
            mario.velocity *= speedDecayRate;
            mario.marioHeight += 7;
            if (mario.velocity.Y > -1.5) { mario.velocity.Y =0; }
            if (mario.velocity.Y > -.1 || mario.marioHeight > maxJumpHeight)
            {
                mario.physState = new FallingState(game);
                mario.marioHeight = 0;
            }
        }
    }
}
