using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FireballCommand : ICommands
    {
        Mario mario;
        public FireballCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.MakeFireballMario();
        }
    }
}

