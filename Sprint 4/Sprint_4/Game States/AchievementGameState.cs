using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class AchievementGameState :IGameState
    {
        Game1 game;
        public GUI menu;
        int inputBuffer = 10;

        public AchievementGameState()
        {
            game = Game1.GetInstance();
            menu = new GUI(game);
            menu.options.Add(new KeyValuePair<ICommands, String>(new LoadMenuCommand(), "Back"));
            menu.currentCommand = menu.options[0].Key;
            game.keyboardController = new TitleKeyController(menu);
            game.gamepadController = new TitlePadController();
        }

        public void Update(GameTime gameTime)
        {
            game.level.Update(gameTime);
            inputBuffer--;
            if (inputBuffer <= 0)
            {
                game.keyboardController.Update();
                game.gamepadController.Update();
                inputBuffer = 10;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
            menu.Draw(spriteBatch);
        }
    }
}
