using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class RunCommand : ICommands
    {
        public RunCommand()
        {
        }
        public void Execute()
        {
            Game1.GetInstance().level.mario.Run();
        }
    }
}
