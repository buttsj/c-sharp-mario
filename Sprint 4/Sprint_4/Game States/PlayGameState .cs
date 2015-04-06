using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class PlayGameState :IGameState
    {
        int gameStateTransitionBuffer = 5;
        Game1 game;
        Texture2D gate;

        public PlayGameState()
        {
            game = Game1.GetInstance();
            game.keyboardController = new KeyboardController(game.level.mario);
            game.gamepadController = new GamepadController(game.level.mario);
            gate = Game1.gameContent.Load<Texture2D>("Items/gate");
        }
        public void Update(GameTime gameTime)
        {
            if (gameStateTransitionBuffer > 0)
            {
                gameStateTransitionBuffer--;
            }
            else
            {
                game.keyboardController.Update();
                game.gamepadController.Update();
                game.level.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
            spriteBatch.Draw(gate, new Rectangle((int)game.level.exitPosition.X, (int)game.level.exitPosition.Y, 48, 145), Color.White);
        }
    }
}
