using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class SoundManager
    {
        Game1 game;
        public Song athletic, star, placeHolderSong;
        public SoundEffect coinCollect, brickBreak, grow, shrink, land, oneUp, enemyDamage, jump, placeHolderFX;
            
        public enum songs{athletic, star}
        public enum sfx{coin, brick, grow, shrink, land, oneUp, enemyDamage, jump}
        public SoundManager(Game1 game){
            this.game = game;
            jump = game.Content.Load<SoundEffect>("Sound/SFX/SFX Jump");
            athletic = game.Content.Load<Song>("Sound/Music/Map BGM");
            star = game.Content.Load<Song>("Sound/Music/Star BGM");
            coinCollect = game.Content.Load<SoundEffect>("Sound/SFX/SFX coin collect");
            brickBreak = game.Content.Load<SoundEffect>("Sound/SFX/SFX Brick Break");
            grow = game.Content.Load<SoundEffect>("Sound/SFX/SFX Grow");
            shrink = game.Content.Load<SoundEffect>("Sound/SFX/SFX shrink");
            land = game.Content.Load<SoundEffect>("Sound/SFX/SFX land");
            oneUp = game.Content.Load<SoundEffect>("Sound/SFX/SFX 1up");
            enemyDamage = game.Content.Load<SoundEffect>("Sound/SFX/SFX Enemy damage");
            placeHolderFX = game.Content.Load<SoundEffect>("Sound/SFX/SFX Enemy damage");
            placeHolderSong = game.Content.Load<Song>("Sound/Music/Star BGM");
        }
        public void PlaySong(SoundManager.songs song)
        {
            if (song == SoundManager.songs.athletic)
            {
                placeHolderSong = athletic;
            }
            if (song == SoundManager.songs.star)
            {
                placeHolderSong = star;
            }
            MediaPlayer.Play(placeHolderSong);
            MediaPlayer.IsRepeating = true;
        }
        public void PlaySoundEffect(SoundManager.sfx fx)
        {
            if (fx == SoundManager.sfx.brick)
            {
                placeHolderFX = brickBreak;
            }
            if (fx == SoundManager.sfx.coin)
            {
                placeHolderFX = coinCollect;
            }
            if (fx == SoundManager.sfx.enemyDamage)
            {
                placeHolderFX = enemyDamage;
            }
            if (fx == SoundManager.sfx.grow)
            {
                placeHolderFX = grow;
            }
            if (fx == SoundManager.sfx.land)
            {
                placeHolderFX = land;
            }
            if (fx == SoundManager.sfx.oneUp)
            {
                placeHolderFX = oneUp;
            }
            if (fx == SoundManager.sfx.shrink)
            {
                placeHolderFX = shrink;
            }
            placeHolderFX.Play();
        }
    }
}
