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
        GUI menu;

        public TitleScreenGameState()
        {
            factory = new SpriteFactory();
            logo = factory.build(SpriteFactory.sprites.title);
            SoundManager.StopMusic();
            SoundManager.PlaySong(SoundManager.songs.title);
            game = Game1.GetInstance();
            menu = new GUI(game);
            game.keyboardController = new TitleKeyController(menu);
            game.gamepadController = new TitlePadController();
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
            game.level.Draw(spriteBatch);
            if (setLogo)
            {
                logo.Draw(spriteBatch, new Vector2(100, 280));
            }
            menu.Draw(spriteBatch);
        }
    }
}
