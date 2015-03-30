using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class QuitCommand : ICommands
    {

        public QuitCommand()
        {
        }

        public void Execute()
        {
            Game1.GetInstance().Exit();
        }
    }
}
