using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class AchievementMenuGameState :IGameState
    {
        Game1 game;
        public GUI menu;
        int inputBuffer = 0;
        Texture2D achCoins;
        Texture2D achFall;
        Texture2D achFireball;
        Texture2D achHitEnemy;
        Texture2D achLevel;
        Texture2D achLife;
        Texture2D achMushroom;
        SpriteFont font;

        public AchievementMenuGameState()
        {
            game = Game1.GetInstance();
            menu = new GUI(game);
            menu.options.Add(new KeyValuePair<ICommands, String>(new LoadMenuCommand(), "Back"));
            menu.currentCommand = menu.options[0].Key;
            game.keyboardController = new TitleKeyController(menu);
            game.gamepadController = new TitlePadController(menu);
            achCoins = Game1.gameContent.Load<Texture2D>("Achievements/achCoins");
            achFall = Game1.gameContent.Load<Texture2D>("Achievements/achFall");
            achFireball = Game1.gameContent.Load<Texture2D>("Achievements/achFireball");
            achHitEnemy = Game1.gameContent.Load<Texture2D>("Achievements/achHitEnemy");
            achLife = Game1.gameContent.Load<Texture2D>("Achievements/achLife");
            achLevel = Game1.gameContent.Load<Texture2D>("Achievements/achLevel");
            achMushroom = Game1.gameContent.Load<Texture2D>("Achievements/achMushroom");
            font = Game1.gameContent.Load<SpriteFont>("Fonts/SpriteFont1");
            menu.textStartingPosition.Y += 25;
            menu.coinStartingPosition.Y += 25;
        }

        public void Update(GameTime gameTime)
        {
            game.level.Update(gameTime);
            inputBuffer++;
            if (inputBuffer > 6)
            {
                game.keyboardController.Update();
                game.gamepadController.Update();
                inputBuffer = 0;
            }
            menu.Update();
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Coins].isUnlocked)
            {
                achCoins = game.ach.achievementKeeper[AchievementsManager.AchievementType.Coins].greyImage;
            }
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Death].isUnlocked)
            {
                achFall = game.ach.achievementKeeper[AchievementsManager.AchievementType.Death].greyImage;
            }
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Fireball].isUnlocked)
            {
                achFireball = game.ach.achievementKeeper[AchievementsManager.AchievementType.Fireball].greyImage;
            }
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Enemy].isUnlocked)
            {
                achHitEnemy = game.ach.achievementKeeper[AchievementsManager.AchievementType.Enemy].greyImage;
            }
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Level].isUnlocked)
            {
                achLevel = game.ach.achievementKeeper[AchievementsManager.AchievementType.Level].greyImage;
            }
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Life].isUnlocked)
            {
                achLife = game.ach.achievementKeeper[AchievementsManager.AchievementType.Life].greyImage;
            }
            if (game.ach.achievementKeeper[AchievementsManager.AchievementType.Mushroom].isUnlocked)
            {
                achMushroom = game.ach.achievementKeeper[AchievementsManager.AchievementType.Mushroom].greyImage;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.level.Draw(spriteBatch);
            menu.Draw(spriteBatch);
            spriteBatch.Draw(achCoins, new Rectangle(84, 250, 75, 51), Color.White);
            spriteBatch.Draw(achFall, new Rectangle(160, 250, 75, 51), Color.White);
            spriteBatch.Draw(achFireball, new Rectangle(236, 250, 75, 51), Color.White);
            spriteBatch.Draw(achHitEnemy, new Rectangle(84, 302, 75, 51), Color.White);
            spriteBatch.Draw(achLevel, new Rectangle(160, 302, 75, 51), Color.White);
            spriteBatch.Draw(achLife, new Rectangle(236, 302, 75, 51), Color.White);
            spriteBatch.Draw(achMushroom, new Rectangle(160, 354, 75, 51), Color.White);
            spriteBatch.DrawString(font, "Achievements unlocked: " + ValueHolder.achGained + " out of 7", game.gameCamera.CenterScreen + new Vector2(-360, 225), Color.Black);
        }
    }
}