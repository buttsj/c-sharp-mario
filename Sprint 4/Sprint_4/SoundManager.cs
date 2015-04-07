using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
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
        public static Song athletic, star, overworld, underground, placeHolderSong, overworldFast;
        public static SoundEffect coinCollect, brickBreak, grow, shrink, blockHit, oneUp, enemyDamage, jump, itemSpawn,
            pause, death, gameOver, fireball, launch, clear;
            
        public enum songs{athletic, star, overworld, underground, overworldFast}
        public SoundManager(Game1 game){
            this.game = game;
            jump = game.Content.Load<SoundEffect>("Sound/SFX/SFX Jump");
            athletic = game.Content.Load<Song>("Sound/Music/Map BGM");
            star = game.Content.Load<Song>("Sound/Music/Star BGM");
            death = game.Content.Load<SoundEffect>("Sound/SFX/Player Down");
            coinCollect = game.Content.Load<SoundEffect>("Sound/SFX/SFX coin collect");
            brickBreak = game.Content.Load<SoundEffect>("Sound/SFX/SFX Brick Break");
            itemSpawn = game.Content.Load<SoundEffect>("Sound/SFX/SFX item spawn");
            grow = game.Content.Load<SoundEffect>("Sound/SFX/SFX Grow");
            shrink = game.Content.Load<SoundEffect>("Sound/SFX/SFX shrink");
            blockHit = game.Content.Load<SoundEffect>("Sound/SFX/SFX land");
            oneUp = game.Content.Load<SoundEffect>("Sound/SFX/SFX 1up");
            pause = game.Content.Load<SoundEffect>("Sound/SFX/menu");
            enemyDamage = game.Content.Load<SoundEffect>("Sound/SFX/SFX Enemy damage");
            placeHolderSong = game.Content.Load<Song>("Sound/Music/Star BGM");
            gameOver = game.Content.Load<SoundEffect>("Sound/Music/Game Over");
            fireball = game.Content.Load<SoundEffect>("Sound/SFX/fireball");
            launch = game.Content.Load<SoundEffect>("Sound/SFX/BillLaunch");
            overworld = game.Content.Load<Song>("Sound/Music/Overworld BGM");
            underground = game.Content.Load<Song>("Sound/Music/Underground BGM");
            clear = game.Content.Load<SoundEffect>("Sound/Music/Course Clear Fanfare");
            overworldFast = game.Content.Load<Song>("Sound/Music/OverworldTimeRunningOut");
        }
        public static void PlaySong(SoundManager.songs song)
        {
            if (song == SoundManager.songs.athletic)
            {
                placeHolderSong = athletic;
            }
            if (song == SoundManager.songs.star)
            {
                placeHolderSong = star;
            }
            if (song == SoundManager.songs.overworld)
            {
                placeHolderSong = overworld;
            }
            if (song == SoundManager.songs.underground)
            {
                placeHolderSong = underground;
            }
            if (song == SoundManager.songs.overworldFast)
            {
                placeHolderSong = overworldFast;
            }
            MediaPlayer.Play(placeHolderSong);
            MediaPlayer.IsRepeating = true;
        }
        public static void StopMusic()
        {
            MediaPlayer.Stop();
        }
    }
}
