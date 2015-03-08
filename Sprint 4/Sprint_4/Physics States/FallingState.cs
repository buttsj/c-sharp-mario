using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class FallingState :IMarioPhysicsState
    {
        Game1 game;
        public Vector2 speedDecayRate = new Vector2((float)0.85, (float)0.85);
        public FallingState(Game1 game)
        {
            this.game = game;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / (float)50.0);
            mario.velocity += new Vector2((float)0, (float)1.2);
            if(game.level.collision.standingBlocks.Count > 0)
            {
                mario.physState = new GroundState(mario, game);
            }
        }
    }
}
