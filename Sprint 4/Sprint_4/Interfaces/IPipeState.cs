using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IPipeState
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Eat(Mario mario, Pipe pipe);
        void Puke(Mario mario, Pipe pipe);
        Rectangle GetBoundingBox(Vector2 location);
    }
}
