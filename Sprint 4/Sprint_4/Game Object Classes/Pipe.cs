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
        public IPipeState state { get; set; }
        public Pipe exitPipe { get; set; }

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
        public void Eat(Mario mario)
        {
            state.Eat(mario, this);
        }
        public void Puke(Mario mario)
        {
            state.Puke(mario, this);
        }
        public void Chew(Mario mario)
        {
            state.Chew(mario);
        }
        public void Gag(Mario mario)
        {
            state.Gag(mario);
        }
        public Rectangle GetBoundingBox()
        {
            return state.GetBoundingBox(position);
        }
    }
}
