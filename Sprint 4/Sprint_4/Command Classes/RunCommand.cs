using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class RunCommand : ICommands
    {
        Mario mario;
        public RunCommand(Mario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario.Run();
        }
    }
}
