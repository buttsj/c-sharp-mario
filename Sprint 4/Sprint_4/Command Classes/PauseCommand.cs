using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class PauseCommand : ICommands
    {
        public PauseCommand()
        {
        }
        public void Execute()
        {
            if (Game1.GetInstance().isPaused)
            {
                Game1.GetInstance().gameState = new SuperMarioGameState();
                Game1.GetInstance().isPaused = false;
            }
            else
            {
                Game1.GetInstance().gameState = new PauseGameState();
            }
        }
    }
}
