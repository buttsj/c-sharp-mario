using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class LoadMenuCommand : ICommands
    {
        public LoadMenuCommand()
        {
        }
        public void Execute()
        {
            Game1.GetInstance().gameState = new TitleScreenGameState();
            Game1.GetInstance().isTitle = true;
        }
    }
}
