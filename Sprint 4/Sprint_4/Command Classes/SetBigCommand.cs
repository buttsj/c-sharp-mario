using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class SetBigCommand : ICommands
    {
        Game1 game;
        public SetBigCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.level.mario.MakeBigMario();
        }
    }
}
