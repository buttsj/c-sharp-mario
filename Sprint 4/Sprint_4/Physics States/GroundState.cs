using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class GroundState :IMarioPhysicsState
    {
        Game1 game;
        public Vector2 speedDecayRate = new Vector2((float)0.73, (float)0.70);
        float positionDtAdjust = 40;

        public GroundState(Mario mario, Game1 game)
        {
            this.game = game;
            mario.Land();
            mario.velocity.Y = 0; 
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.velocity.Y = 0;
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);

            mario.velocity *= speedDecayRate;
            if (game.level.collision.standingBlocks.Count == 0)
            {
                mario.physState = new FallingState(game);
            } 
        }
    }
}
