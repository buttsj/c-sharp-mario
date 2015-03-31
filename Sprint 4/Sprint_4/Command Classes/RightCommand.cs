using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class RightCommand : ICommands
    {
        Mario mario;
        public RightCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.GoRight();
        }
    }
}
