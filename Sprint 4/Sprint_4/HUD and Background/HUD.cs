using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class HUD
    {
        public int Coins { get; set; }
        public int Lives { get; set; }
        public int Time { get; set; }
        public SpriteFont CoinsFont { get; set; }
        public SpriteFont LivesFont { get; set; }
        public SpriteFont TimeFont { get; set; }
        public Game1 game;

        public HUD(Game1 game)
        {
            this.game = game;
            Coins = game.coins;
            Lives = game.lives;
            Time = 999;
        }

        public void LoadContent()
        {
            CoinsFont = game.Content.Load<SpriteFont>("CoinsFont");
            LivesFont = game.Content.Load<SpriteFont>("LivesFont");
            TimeFont = game.Content.Load<SpriteFont>("TimeFont");
        }

        public void Update(GameTime gameTime)
        {
            Lives = game.lives;
            Coins = game.coins;
            int currentTime = (int)gameTime.ElapsedGameTime.TotalSeconds;
            int nextTime = (int)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime != nextTime)
            {
                Time--;
            }

            if (Coins > 99)
            {
                Coins -= 99;
                Lives++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(CoinsFont, "Coins: " + Coins, new Vector2(680, 30), Color.Black);
            spriteBatch.DrawString(LivesFont, "Lives: " + Lives, new Vector2(15, 30), Color.Black);
            spriteBatch.DrawString(TimeFont, "Timer: " + Time, new Vector2(550, 30), Color.Black);
        }
    }
}
