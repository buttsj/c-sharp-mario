using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Pipe
    {
        public Vector2 position;
        IPipeState state;

        public Pipe(IPipeState state, Vector2 location)
        {
            this.state = state;
            position = location;
        }
        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
        public void Eat()
        {
            state.Eat();
        }
        public void Puke()
        {
            state.Puke();
        }
        public Rectangle GetBoundingBox()
        {
            return state.GetBoundingBox(position);
        }
    }
}
