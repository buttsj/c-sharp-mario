using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class NullEnemyState :IEnemyState
    {
        public Rectangle GetBoundingBox(Vector2 position)
        {
            return new Rectangle(0, 0, 0, 0);
        }
        public void TakeDamage(BasicEnemy hurtEnemy)
        {
        }
        public void GoLeft(BasicEnemy enemy)
        {
            // null
        }
        public void GoRight(BasicEnemy enemy)
        {
            // null
        }

        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }
    }
    }

