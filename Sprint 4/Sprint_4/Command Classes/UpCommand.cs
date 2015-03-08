using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class UpCommand : ICommands
    {
        Game1 game;
        public UpCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.level.mario.Up();
        }
    }
}
