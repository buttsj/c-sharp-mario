using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ResetSceneCommand : ICommands
    {
        public ResetSceneCommand()
        {
        }

        public void Execute()
        {
            Game1.GetInstance().level = new Level(Game1.GetInstance(), "/Maps/MapCleaned.csv");
            Game1.GetInstance().gameState = new PlayGameState();
        }
    }
}
