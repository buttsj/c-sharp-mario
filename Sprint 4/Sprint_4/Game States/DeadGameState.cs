using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class DeadGameState :IGameState
    {
        Game1 game;
        int pauseTimer = 30, upTimer = 30, downTimer = 180;

        public DeadGameState(Game1 game)
        {
            this.game = game;
            game.soundManager.PlaySong(SoundManager.songs.death);
        }

        public void Update(GameTime gameTime)
        {
            //mario's death animation, followed by respawning into playState. Nothing in the level moves
            //but mario. Have a dead keyboard? It only takes pause and quit inputs.
            if (pauseTimer > 0)
            {
                pauseTimer--;
            }
            if (pauseTimer <= 0 && upTimer > 0)
            {
                upTimer--;
                game.level.mario.position.Y-=5;
            }
            if (upTimer <= 0 && downTimer > 0)
            {
                game.level.mario.position.Y+=5;
                downTimer--;
            }
            if (downTimer <= 0)
            {
                game.gameState = new PlayGameState(game);
                game.level = new Level(game, "/Maps/Map.csv");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
