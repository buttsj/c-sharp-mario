using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class SetFireCommand : ICommands
    {
        Game1 game;
        public SetFireCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.level.mario.MakeFireMario();
        }
    }
}
