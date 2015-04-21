using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ProjectileCommand : ICommands
    {
        Mario mario;
        public ProjectileCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (mario.isFire)
            {
                mario.MakeFireballMario();
            }
            if(mario.isNinja && !mario.isFire)
            {
                mario.MakeNinjaMario();
            }
            
        }
    }
}

