using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    public class PipeFactory
    {
        public enum PipeFacing
        {
            up, down, left, right
        }
        IPipeState state;

        public PipeFactory()
        {
        }
        
        public Pipe build(PipeFacing type, Vector2 location)
        {
            if (type == PipeFacing.up)
            {
                state = new UpPipeState();
            }
            if (type == PipeFacing.down)
            {
                state = new DownPipeState();
            }
            if (type == PipeFacing.left)
            {
                state = new LeftPipeState();
            }
            Pipe product = new Pipe(state, location);
            return product;
        }
    }
}
