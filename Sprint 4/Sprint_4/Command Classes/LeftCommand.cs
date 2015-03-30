using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class LeftCommand : ICommands
    {
        public LeftCommand()
        {
        }

        public void Execute()
        {
            Game1.GetInstance().level.mario.GoLeft();   
        }
    }
}
