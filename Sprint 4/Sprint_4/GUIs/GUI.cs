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
        public List<KeyValuePair<ICommands, String>> options { get; set; }
        public ICommands currentCommand { get; set; }
        int selection = 0, menuNumber = 0;
        SpriteFont font;
        Vector2 adjust = new Vector2(0, 15);
        SpriteFactory factory;
        IAnimatedSprite coin;
        int buffer = 0;
        public Vector2 textStartingPosition = new Vector2(160, 380);
        public Vector2 coinStartingPosition = new Vector2(140, 385);

        public GUI(Game1 game)
        {
            this.game = game;
            options = new List<KeyValuePair<ICommands, String>>();
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
                if (selection >= options.Count)
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
                    selection = options.Count-1;
                }
                currentCommand = options[selection].Key;
            }
        }

        public void Select()
        {
            if (buffer >= 10)
            {
                buffer = 0;
                currentCommand.Execute();
            }
        }

        public void Update()
        {
            buffer++;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<ICommands, String> pair in options)
            {
                spriteBatch.DrawString(font, pair.Value, textStartingPosition + (adjust* menuNumber), Color.Black);
                menuNumber++;
            }
            coin.Draw(spriteBatch, coinStartingPosition + (adjust * selection), Color.White);
            menuNumber = 0;
        }
    }
}
