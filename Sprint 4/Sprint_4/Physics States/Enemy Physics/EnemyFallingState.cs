using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class EnemyFallingState : IEnemyPhysicsState
    {
        private Vector2 fallingVelocityDecayRate = new Vector2((float).90, 1);
        private Vector2 fallingVelocity = new Vector2(0, (float)1.2);
        private float positionDtAdjust = 50;
        private Vector2 oldPos;
        private float maxVelocity = 15;
        private float positionDifference = .5f;

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
            if ((enemy.position.Y - oldPos.Y) < positionDifference)
            {
                enemy.physState = new EnemyGroundState(enemy);
            }
            oldPos = enemy.position;
        }
    }
}
