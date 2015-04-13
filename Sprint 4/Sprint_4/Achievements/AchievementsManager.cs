using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class AchievementsManager
    {
        private List<Achievement> achievements;
        private List<int> achievementKeeper;

        public void AchievementUnlocked(Achievement ach)
        {
            ach.isUnlocked = true;
        }

        public AchievementsManager()
        {
            achievementKeeper = new List<int>();
            achievements = new List<Achievement>();
            achievements.Add(new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("achievementBeatLevel") });
            achievements.Add(new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("achievementCoins") });
            achievements.Add(new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("achievementEat") });
            achievements.Add(new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("achievementFall") });
            achievements.Add(new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("achievementFireball") });
            achievements.Add(new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("achievementKoopa") });
            achievements.Add(new Achievement() { isUnlocked = false, image = Game1.gameContent.Load<Texture2D>("achievementLife") });
        }

    }
}
