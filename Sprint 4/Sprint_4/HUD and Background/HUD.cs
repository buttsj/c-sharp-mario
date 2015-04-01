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

        public float countDuration = 1f;
        public float currentTime = 0f;
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
            if (Coins > 99)
            {
                Coins -= 99;
                Lives++;
            }
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= countDuration)
            {
                Time--;
                currentTime -= countDuration;
            }
            if (Time == 100)
            {
                // Play fast paced music
            }
            if (Time == 0)
            {
                // Kill Mario
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
