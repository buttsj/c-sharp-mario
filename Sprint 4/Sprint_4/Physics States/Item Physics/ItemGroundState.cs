using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ItemGroundState : ICollectablePhysicsState
    {
        private Vector2 oldPos;
        private float positionDifference = .5f;

        public ItemGroundState(ICollectable item)
        {
            item.velocity = new Vector2(item.velocity.X, 0);
            oldPos = item.position;
        }
        public void Update(ICollectable item, GameTime gameTime)
        {
            if ((item.position.Y - oldPos.Y) > positionDifference) { 
                item.physState = new ItemFallingState(item);
            }
            oldPos = item.position;
        }
    }
}
