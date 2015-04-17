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
            Game1.GetInstance().level = new Level(levelName);
            if (levelName == StringHolder.levelOne)
            {
                Game1.GetInstance().gameState = new SuperMarioGameState();
                SoundManager.PlaySong(SoundManager.songs.overworld);
            }
            if (levelName == StringHolder.levelTwo)
            {
                Game1.GetInstance().gameState = new VVVVVVGameState();
                SoundManager.PlaySong(SoundManager.songs.vmusic);
            }
            Game1.GetInstance().isTitle = false;
        }
    }
}
