using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ResetSceneCommand : ICommands
    {
        Game1 game;
        public ResetSceneCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.level = new Level(game, "/Maps/Map.csv");
        }
    }
}
