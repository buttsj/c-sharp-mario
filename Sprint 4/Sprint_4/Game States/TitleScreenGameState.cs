using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class TitleScreenGameState :IGameState
    {
        Game1 game;
        SpriteFont font;
        int logoTimer = 270;
        bool setLogo = false;
        SpriteFactory factory;
        IAnimatedSprite logo;

        public TitleScreenGameState()
        {
            factory = new SpriteFactory();
            logo = factory.build(SpriteFactory.sprites.title);
            SoundManager.StopMusic();
            SoundManager.PlaySong(SoundManager.songs.title);
            game = Game1.GetInstance();
            font = Game1.gameContent.Load<SpriteFont>(StringHolder.hudPauseFont);
            game.keyboardController = new PauseMenuKeyController();
            game.gamepadController = new PauseMenuGamepadController();
        }

        public void Update(GameTime gameTime)
        {
            game.level.Update(gameTime);
            game.keyboardController.Update();
            game.gamepadController.Update();
            logoTimer--;
            if (logoTimer <= 0)
            {
                setLogo = true;
                logo.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Press Start", new Vector2(130, 430), Color.Black);
            game.level.Draw(spriteBatch);
            if (setLogo)
            {
                logo.Draw(spriteBatch, new Vector2(100, 280));
            }
        }
    }
}
