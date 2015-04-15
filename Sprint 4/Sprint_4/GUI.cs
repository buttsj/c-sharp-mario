using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class GUI
    {
        Game1 game;
        List<KeyValuePair<ICommands, String>> options = new List<KeyValuePair<ICommands, String>>();
        ICommands currentCommand;
        int selection = 0, n = 0;
        SpriteFont font;
        Vector2 adjust = new Vector2(0, 15);
        SpriteFactory factory;
        IAnimatedSprite coin;
        int buffer = 0;

        public GUI(Game1 game)
        {
            this.game = game;
            options.Add(new KeyValuePair<ICommands, String>(new LoadLevelCommand(StringHolder.levelOne), "Level 1"));
            options.Add(new KeyValuePair<ICommands, String>(new LoadLevelCommand(StringHolder.levelTwo), "Level 2"));
            options.Add(new KeyValuePair<ICommands, String>(new QuitCommand(), "Quit"));
            currentCommand = options[0].Key;
            font = Game1.gameContent.Load<SpriteFont>(StringHolder.hudPauseFont);
            factory = new SpriteFactory();
            coin = factory.build(SpriteFactory.sprites.coin);
        }
        public void Down()
        {
            if (buffer >= 10)
            {
                buffer = 0;
                selection++;
                if (selection > 2)
                {
                    selection = 0;
                }
                currentCommand = options[selection].Key;
            }
        }
        public void Up()
        {
            if (buffer >= 10)
            {
                buffer = 0;
                selection--;
                if (selection < 0)
                {
                    selection = 2;
                }
                currentCommand = options[selection].Key;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            buffer++;
            foreach (KeyValuePair<ICommands, String> pair in options)
            {
                spriteBatch.DrawString(font, pair.Value, new Vector2(160, 400) + (adjust* n), Color.Black);
                n++;
            }
            coin.Draw(spriteBatch, new Vector2(140, 405) + (adjust * selection));
            n = 0;
        }
    }
}
