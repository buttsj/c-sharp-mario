using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IEnemyPhysicsState
    {
        void Update(Enemy enemy, GameTime gameTime);
    }
}
