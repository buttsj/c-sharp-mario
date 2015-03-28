using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class NullCommand : ICommands
    {
        Game1 game;
        public NullCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
        }
    }
}
