using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Sprint4
{
    public class AchievementsManager
    {
        private Dictionary<AchievementType, Achievement> achievementKeeper;
        private SoundEffectInstance achFX;
        private int achTimer = ValueHolder.achTimer;
        Game1 game;

        public enum AchievementType
        {
            Life,
            Enemy,
            Coins,
            Death,
            Fireball,
            Mushroom,
            Level
        }

        public void AchievementUnlocked(Achievement ach)
        {
            achTimer = ValueHolder.achTimer;
            if (achFX.State == SoundState.Stopped)
            {
                achFX.Play();
            }
            ach.isUnlocked = true;
            game.gameHUD.Achievement = ach.image;
            game.gameHUD.hideAch = false;
            ValueHolder.achRemaining--;
        }

        public AchievementsManager(Game1 game)
        {
            achFX = SoundManager.achUnlocked.CreateInstance();
            this.game = game;
            achievementKeeper = new Dictionary<AchievementType, Achievement>();
            achievementKeeper.Add(AchievementType.Level, new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("Achievements/achievementBeatLevel"), unlockCheck = 1, unlockMark = 0 });
            achievementKeeper.Add(AchievementType.Coins, new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("Achievements/achievementCoins"), unlockCheck = 20, unlockMark = 0 });
            achievementKeeper.Add(AchievementType.Mushroom, new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("Achievements/achievementEat"), unlockCheck = 1, unlockMark = 0 });
            achievementKeeper.Add(AchievementType.Death, new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("Achievements/achievementFall"), unlockCheck = 1, unlockMark = 0 });
            achievementKeeper.Add(AchievementType.Fireball, new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("Achievements/achievementFireball"), unlockCheck = 1, unlockMark = 0 });
            achievementKeeper.Add(AchievementType.Enemy, new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("Achievements/achievementEnemy"), unlockCheck = 1, unlockMark = 0 });
            achievementKeeper.Add(AchievementType.Life, new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("Achievements/achievementLife"), unlockCheck = 1, unlockMark = 0 });
            ValueHolder.achRemaining = achievementKeeper.Count();
        }

        public void AchievementAdjustment(AchievementType ach)
        {
            if (!achievementKeeper[ach].isUnlocked)
            {
                achievementKeeper[ach].unlockMark++;
                if (achievementKeeper[ach].unlockCheck == achievementKeeper[ach].unlockMark)
                {
                    AchievementUnlocked(achievementKeeper[ach]);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!game.gameHUD.hideAch)
            {
                achTimer--;
                if (achTimer == 0)
                {
                    game.gameHUD.hideAch = true;
                    achTimer = ValueHolder.achTimer;
                }
            }
        }
    }
}
