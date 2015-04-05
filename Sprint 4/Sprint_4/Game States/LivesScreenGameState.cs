using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LivesScreenGameState :IGameState
    {
        int timer = 150;
        SpriteFont font;
        Game1 game;

        public LivesScreenGameState()
        {
            game = Game1.GetInstance();
            Game1.GetInstance().gameHUD.Lives--;
            font = game.Content.Load<SpriteFont>("Fonts/SpriteFont1");
            game.keyboardController = new PauseMenuKeyController();
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                game.level = new Level(game, "/Maps/MapCleaned.csv");
                game.gameState = new PlayGameState();
                game.gameHUD.Time = ValueHolder.timerStart;
            }
            game.keyboardController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.CenterScreen);
            spriteBatch.DrawString(font, "Lives: " + game.gameHUD.Lives, game.gameCamera.CenterScreen + ValueHolder.textPosition, Color.White);
        }
    }
}
