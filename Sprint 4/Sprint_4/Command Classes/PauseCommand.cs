using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class PauseCommand : ICommands
    {
        Game1 game;
        public PauseCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.isPaused)
            {
                game.gameState = new PlayGameState(game);
                game.isPaused = false;
            }
            else
            {
                game.gameState = new PauseGameState(game);
            }
        }
    }
}
