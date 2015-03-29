using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface ICollectable
    {
        Rectangle GetBoundingBox();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
        void GoLeft();
        void GoRight();
        void Spawn();
        bool isCoin { get; set; }
        bool isSpawning { get; set; }
        IAnimatedSprite sprite { get; set; }
    }
}
