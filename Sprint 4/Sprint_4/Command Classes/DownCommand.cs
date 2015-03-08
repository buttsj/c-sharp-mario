using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class DownCommand : ICommands
    {
        Game1 game;
        public DownCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.level.mario.Down();
        }
    }
}
