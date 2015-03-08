using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    interface ISpriteFactory
    {
        IAnimatedSprite build(SpriteFactory.sprites sprite);
    }
}
