using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class TestQuitCommand : ICommands
    {
        Game1 game;

        public TestQuitCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Exit();
        }
    }
}
