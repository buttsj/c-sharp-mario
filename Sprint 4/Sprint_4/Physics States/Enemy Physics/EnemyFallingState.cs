using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class EnemyFallingState : IEnemyPhysicsState
    {
        Vector2 fallingVelocityDecayRate = new Vector2((float).90, 1);
        Vector2 fallingVelocity = new Vector2(0, (float)1.2);
        float positionDtAdjust = 50;
        Vector2 oldPos;
        float maxVelocity = 15;

        public EnemyFallingState(Enemy enemy)
        {
            oldPos = enemy.position;
        }
        public void Update(Enemy enemy, GameTime gameTime)
        {
            enemy.position += enemy.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            enemy.velocity += fallingVelocity;
            enemy.velocity *= fallingVelocityDecayRate;
            if (enemy.velocity.Y > maxVelocity){
                 enemy.velocity = new Vector2(enemy.velocity.X, maxVelocity);
            }
            if ((enemy.position.Y - oldPos.Y) < (float).5)
            {
                enemy.physState = new EnemyGroundState(enemy);
            }
            oldPos = enemy.position;
        }
    }
}
