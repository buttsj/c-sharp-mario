using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FireballCommand : ICommands
    {
        public FireballCommand()
        {
        }

        public void Execute()
        {
            Game1.GetInstance().level.mario.MakeFireballMario();
        }
    }
}

