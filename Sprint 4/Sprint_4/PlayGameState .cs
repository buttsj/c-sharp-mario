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
        Game1 game;
        public PlayGameState(Game1 game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {
            game.keyboardController.Update();
            //gamepadController.Update();
            game.level.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
        }
    }
}
