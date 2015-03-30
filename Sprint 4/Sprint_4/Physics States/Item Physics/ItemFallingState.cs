using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class ItemFallingState : ICollectablePhysicsState
    {
        Vector2 fallingVelocityDecayRate = new Vector2((float).90, 1);
        Vector2 fallingVelocity = new Vector2(0, (float)1.2);
        float positionDtAdjust = 50;
        Vector2 oldPos;
        float maxVelocity = 15;

        public ItemFallingState(ICollectable item)
        {
            oldPos = item.position;
        }
        public void Update(ICollectable item, GameTime gameTime)
        {
            item.position += item.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            item.velocity += fallingVelocity;
            item.velocity *= fallingVelocityDecayRate;
            if (item.velocity.Y > maxVelocity){
                 item.velocity = new Vector2(item.velocity.X, maxVelocity);
            }
            if ((item.position.Y - oldPos.Y) < (float).5)
            {
                item.physState = new ItemGroundState(item);
            }
            oldPos = item.position;
        }
    }
}
