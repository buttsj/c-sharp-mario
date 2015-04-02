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
        public int Score { get; set; }
        public Texture2D LivesSprite { get; set; }
        public Texture2D CoinSprite { get; set; }
        public Texture2D TimeSprite { get; set; }
        public SpriteFont CoinsFont { get; set; }
        public SpriteFont LivesFont { get; set; }
        public SpriteFont TimeFont { get; set; }
        public SpriteFont ScoreFont { get; set; }

        public float countDuration = 1f;
        public float currentTime = 0f;
        public Game1 game;

        public HUD(Game1 game)
        {
            this.game = game;
            Coins = game.coins;
            Lives = game.lives;
            Score = 0;
            Time = 999;
        }

        public void LoadContent()
        {
            CoinSprite = game.Content.Load<Texture2D>("HUD Sprites/HUDCoinSprite");
            CoinsFont = game.Content.Load<SpriteFont>("HUD Fonts/CoinsFont");
            LivesSprite = game.Content.Load<Texture2D>("HUD Sprites/HUDMario");
            LivesFont = game.Content.Load<SpriteFont>("HUD Fonts/LivesFont");
            TimeSprite = game.Content.Load<Texture2D>("HUD Sprites/TimeSprite");
            TimeFont = game.Content.Load<SpriteFont>("HUD Fonts/TimeFont");
            ScoreFont = game.Content.Load<SpriteFont>("HUD Fonts/ScoreFont");
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
            spriteBatch.Draw(CoinSprite, new Rectangle(650, 30, 53, 25), Color.White);
            spriteBatch.DrawString(CoinsFont, "" + Coins, new Vector2(750, 26), Color.Black);
            spriteBatch.Draw(LivesSprite, new Rectangle(30, 30, 132, 29), Color.White);
            spriteBatch.DrawString(LivesFont, "X    " + Lives, new Vector2(60, 55), Color.Black);
            spriteBatch.Draw(TimeSprite, new Rectangle(500, 30, 82, 25), Color.White);
            spriteBatch.DrawString(TimeFont, "" + Time, new Vector2(530, 55), Color.Black);
            spriteBatch.DrawString(ScoreFont, "" + Score, new Vector2(650, 55), Color.Black);
        }
    }
}
