using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class IdleCommand : ICommands
    {
        Mario mario;
        public IdleCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Idle();
        }
    }
}
