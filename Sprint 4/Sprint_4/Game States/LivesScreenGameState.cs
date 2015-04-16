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
            game.gameHUD.Lives--;
            font = game.Content.Load<SpriteFont>(StringHolder.bigTextFont);
            game.keyboardController = new PauseMenuKeyController();
            game.gameHUD.Time = ValueHolder.startingTime;
            game.gameHUD.textColor = ValueHolder.blackScreenText;
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                game.level = new Level(StringHolder.levelOne);
                game.gameState = new SuperMarioGameState();
                game.gameHUD.textColor = ValueHolder.normalScreenText;
            }
            game.keyboardController.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(game.gameCamera.CenterScreen);
            spriteBatch.DrawString(font, StringHolder.livesText + game.gameHUD.Lives, game.gameCamera.CenterScreen + 
                ValueHolder.textPosition, Color.White);
        }
    }
}
