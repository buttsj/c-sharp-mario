using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IBlockState
    {
        void Update(GameTime gameTime, Block block);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Reaction(Block block);
        Rectangle GetRectangle(Vector2 location);
    }
}
