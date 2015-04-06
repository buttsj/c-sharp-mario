using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class PipeTransitionGameState :IGameState
    {
        int pipeTimer = 30;
        Pipe pipe;
        Game1 game;
        public enum direction {goIn, comeOut}
        direction mode;

        public PipeTransitionGameState(direction direction, Pipe pipe)
        {
            game = Game1.GetInstance();
            game.isPaused = true;
            mode = direction;
            this.pipe = pipe;
        }

        public void Update(GameTime gameTime)
        {
            if (pipeTimer > 0 && mode == direction.goIn)
            {
                pipe.Chew();
            }
            else if (pipeTimer > 0 && mode == direction.comeOut)
            {
                pipe.Gag();
            }
            else
            {
                game.level = new Level(game, "/Maps/MapCleaned.csv");
                game.gameState = new PlayGameState();
            }
            pipeTimer--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
