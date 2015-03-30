using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class EnemyGroundState :IEnemyPhysicsState
    {
        Vector2 oldPos;

        public EnemyGroundState(Enemy item)
        {
            item.velocity = new Vector2(item.velocity.X, 0);
            oldPos = item.position;
        }
        public void Update(Enemy enemy, GameTime gameTime)
        {
            if ((enemy.position.Y - oldPos.Y) > (float).5) { 
                enemy.physState = new EnemyFallingState(enemy);
            }
            oldPos = enemy.position;
        }
    }
}
