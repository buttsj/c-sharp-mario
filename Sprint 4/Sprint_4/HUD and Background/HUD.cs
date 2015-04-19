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
        public Texture2D Achievement { get; set; }
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
        public Color textColor = Color.Black;
        public SpriteFont Paused;
        public int pointMultiplier = 1;
        bool changedMusic = false;
        public bool gameEnded = false;
        public bool hideAch = true;
        public bool PausedCheck = false;

        public HUD(Game1 game)
        {
            this.game = game;
            Coins = 0;
            Lives = 3;
            Score = 0;
            Time = ValueHolder.startingTime;
        }

        public void LoadContent()
        {
            CoinSprite = Game1.gameContent.Load<Texture2D>(StringHolder.hudCoinSprite);
            CoinsFont = Game1.gameContent.Load<SpriteFont>(StringHolder.hudCoinFont);
            LivesSprite = Game1.gameContent.Load<Texture2D>(StringHolder.hudLivesSprite);
            LivesFont = Game1.gameContent.Load<SpriteFont>(StringHolder.hudLivesFont);
            TimeSprite = Game1.gameContent.Load<Texture2D>(StringHolder.hudTimeSprite);
            TimeFont = Game1.gameContent.Load<SpriteFont>(StringHolder.hudTimeFont);
            ScoreFont = Game1.gameContent.Load<SpriteFont>(StringHolder.hudScoreFont);
            Paused = Game1.gameContent.Load<SpriteFont>(StringHolder.hudPauseFont);
        }

        public void Update(GameTime gameTime)
        {
            if (Coins == ValueHolder.maxCoins)
            {
                Coins = 0;
                Lives++;
            }
            if (Coins == 20)
            {
                game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Coins);
            }
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= countDuration && !game.isVictory)
            {
                Time--;
                currentTime -= countDuration;
            }
            if (Time == ValueHolder.hurryTime && !changedMusic && !gameEnded)
            {
                changedMusic = true;
                SoundManager.StopMusic();
                SoundManager.PlaySong(SoundManager.songs.overworldFast);
            }
            if (Time == 0 && !gameEnded)
            {
                game.level.mario.state.MakeDeadMario();
                Game1.GetInstance().gameState = new DeadGameState(game.level.mario);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CoinSprite, ValueHolder.coinSpritePos, Color.White);
            spriteBatch.DrawString(CoinsFont, "" + Coins, ValueHolder.coinTextPos, textColor);
            spriteBatch.Draw(LivesSprite, ValueHolder.livesSpritePos, Color.White);
            spriteBatch.DrawString(LivesFont, "X    " + Lives, ValueHolder.livesTextPos, textColor);
            spriteBatch.Draw(TimeSprite, ValueHolder.timeSpritePos, Color.White);
            spriteBatch.DrawString(TimeFont, "" + Time, ValueHolder.timeTextPos, textColor);
            spriteBatch.DrawString(ScoreFont, "" + Score, ValueHolder.scoreTextPos, textColor);
            if (PausedCheck)
            {
                spriteBatch.DrawString(Paused, StringHolder.pausedMessaged, game.gameCamera.CenterScreen + 
                    ValueHolder.textPosition, Color.Black);
            }
            if (!hideAch)
            {
                spriteBatch.Draw(Achievement, new Rectangle(200, 50, 400, 60), Color.White);
            }
        }
    }
}