using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ItemCollisionResponder
    {
        Game1 game;

        public ItemCollisionResponder(Game1 game)
        {
            this.game = game;
        }
        public void MarioItemCollide(ICollectable item, Mario mario)
        {
            if (item.GetType().Equals(new Star(item.position).GetType()))
            {
                mario.isStar = true;
                game.gameHUD.Score += ValueHolder.itemCollectPoints;
                if (!mario.isNinja) SoundManager.PlaySong(SoundManager.songs.star);
            }
            if (item.GetType().Equals(new Ninja(item.position).GetType()))
            {
                mario.MakeNinjaMario();
                mario.isNinja = true;
                game.gameHUD.Score += ValueHolder.itemCollectPoints;
                SoundManager.PlaySong(SoundManager.songs.ninja);
            }
            if (item.GetType().Equals(new SuperMushroom(item.position).GetType()))
            {
                mario.MakeBigMario();
                game.gameHUD.Score += ValueHolder.itemCollectPoints;
                SoundManager.grow.Play();
                game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Mushroom);
            }
            if (item.GetType().Equals(new FireFlower(item.position).GetType()))
            {
                mario.MakeFireMario();
                game.gameHUD.Score += ValueHolder.itemCollectPoints;
                SoundManager.grow.Play();
            }
            if (item.GetType().Equals(new Coin(item.position).GetType()))
            {
                SoundManager.coinCollect.Play();
                game.gameHUD.Coins++;
                game.gameHUD.Score += ValueHolder.coinCollectPoints;
            }
            if (item.GetType().Equals(new OneUpMushroom(item.position).GetType()))
            {
                SoundManager.oneUp.Play();
                game.gameHUD.Lives++;
                game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Life);
            }
        }
    }
}

