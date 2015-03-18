using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class FireballCommand : ICommands
    {
        Game1 game;
        public FireballCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.level.mario.MakeFireballMario();
        }
    }
}

