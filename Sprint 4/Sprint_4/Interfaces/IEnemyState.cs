using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IEnemyState
    {
        void Update(Enemy enemy, GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        Rectangle GetBoundingBox(Vector2 location);
        void TakeDamage(Enemy enemy);
        void GoLeft(Enemy enemy);
        void GoRight(Enemy enemy);
    }
}
