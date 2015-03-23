using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IFireballState
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        Rectangle GetBoundingBox(Vector2 location);
        void GoLeft(Fireball fireball);
        void GoRight(Fireball fireball);
    }
}