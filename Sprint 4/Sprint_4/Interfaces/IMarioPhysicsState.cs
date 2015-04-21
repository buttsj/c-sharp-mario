using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IMarioPhysicsState
    {
        void Update(GameTime gameTime);
        void Run();
        void Flip();
    }
}
