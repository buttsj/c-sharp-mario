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
            SoundManager.shrink.Play();
        }

        public void Update(GameTime gameTime)
        {
            game.gameHUD.Update(gameTime);
            if (pipeTimer > 0 && mode == direction.goIn)
            {
                pipe.Chew(game.level.mario);
            }
            else if (pipeTimer > 0 && mode == direction.comeOut)
            {
                pipe.Gag(game.level.mario);
            }
            else if(pipeTimer < 0 && mode == direction.goIn)
            {
                game.level.mario.position = pipe.exitPipe.position;
                game.gameCamera.LookAt(game.level.mario.position);
                game.level.isUnderground = !game.level.isUnderground;
                if (game.level.isUnderground)
                {
                    game.background.CurrentSprite = game.background.UndergroundSprite;
                    SoundManager.StopMusic();
                    SoundManager.PlaySong(SoundManager.songs.underground);
                    game.gameHUD.textColor = ValueHolder.blackScreenText;
                }
                else
                {
                    game.background.CurrentSprite = game.background.OverworldSprite;
                    SoundManager.StopMusic();
                    SoundManager.PlaySong(SoundManager.songs.overworld);
                    game.gameHUD.textColor = ValueHolder.normalScreenText;
                }
                game.gameState = new PipeTransitionGameState(direction.comeOut, pipe.exitPipe);
            }
            else if (pipeTimer < 0 && mode == direction.comeOut)
            {
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
