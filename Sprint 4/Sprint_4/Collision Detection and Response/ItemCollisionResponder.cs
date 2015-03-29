using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ItemCollisionResponder
    {
        ISpriteFactory factory = new SpriteFactory();
        Game1 game;
        public ItemCollisionResponder(Game1 game)
        {
            this.game = game;
        }
        public void MarioItemCollide(ICollectable item, Mario mario)
        {
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.star)).GetType()))
            {
                mario.marioIsStar = true;
                game.soundManager.PlaySong(SoundManager.songs.star);
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.superMushroom)).GetType()))
            {
                mario.MakeBigMario();
                game.soundManager.grow.Play();
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.fireFlower)).GetType()))
            {
                mario.MakeFireMario();
                game.soundManager.grow.Play();
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.coin)).GetType()))
            {
                game.soundManager.coinCollect.Play();
                game.coins++;
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.oneUpMushroom)).GetType()))
            {
                game.soundManager.oneUp.Play();
                game.lives++;
            }
        }
    }
}

