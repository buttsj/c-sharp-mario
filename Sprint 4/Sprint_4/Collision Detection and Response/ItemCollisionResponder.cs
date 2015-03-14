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
        public void MarioItemCollide(Item item, Mario mario)
        {
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.star)).GetType()))
            {
                mario.marioIsStar = true;
                game.soundManager.PlaySong(SoundManager.songs.star);
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.superMushroom)).GetType()))
            {
                mario.MakeBigMario();
                game.soundManager.PlaySoundEffect(SoundManager.sfx.grow);
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.fireFlower)).GetType()))
            {
                mario.MakeFireMario();
                game.soundManager.PlaySoundEffect(SoundManager.sfx.grow);
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.coin)).GetType()))
            {
                game.soundManager.PlaySoundEffect(SoundManager.sfx.coin);
                //coinCount++
            }
            if (item.sprite.GetType().Equals((factory.build(SpriteFactory.sprites.oneUpMushroom)).GetType()))
            {
                game.soundManager.PlaySoundEffect(SoundManager.sfx.oneUp);
                //lifeCount++
            }
        }
    }
}

