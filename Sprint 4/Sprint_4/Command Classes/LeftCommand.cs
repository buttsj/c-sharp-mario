using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class LeftCommand : ICommands
    {
        Game1 game;
        public LeftCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.level.mario.GoLeft();   
        }
    }
}
