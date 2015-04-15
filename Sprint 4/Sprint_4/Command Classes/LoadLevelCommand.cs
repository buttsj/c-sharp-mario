using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class LoadLevelCommand : ICommands
    {
        String levelName;
        public LoadLevelCommand(String levelName)
        {
            this.levelName = levelName;
        }
        public void Execute()
        {
            Game1.GetInstance().gameState = new PlayGameState();
            SoundManager.PlaySong(SoundManager.songs.overworld);
            Game1.GetInstance().isTitle = false;
        }
    }
}
