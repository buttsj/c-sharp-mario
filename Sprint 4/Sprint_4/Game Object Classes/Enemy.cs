using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Sprint4
{
    public class Enemy
    {
        public IEnemyState state;
        public bool isDead = false;
        public enum Enemies { Dino, Koopa, Bill, SmashedDino}
        public bool right = false, left = true;
        public float xpos = 0, ypos = 0;
        Game1 game;
        SoundEffectInstance hurtFX;

        public Enemy(Game1 game, Enemy.Enemies type, Vector2 position)
        {
            if (type == Enemy.Enemies.Bill)
            {
                state = new BanzaiBillState(game);
            }
            if (type == Enemy.Enemies.Dino)
            {
                state = new LeftTallDinoState(game);
            }
            if (type == Enemy.Enemies.Koopa)
            {
                state = new LeftWalkingShellessKS(game);
            }
            if (type == Enemy.Enemies.SmashedDino)
            {
                state = new LeftSmashedDinoState(game);
            }
            xpos = position.X;
            ypos = position.Y;
            this.game = game;
            hurtFX = this.game.soundManager.enemyDamage.CreateInstance();
        }
        public void GoLeft()
        {
            state.GoLeft(this);
            left = true;
            right = false;
        }
        public void GoRight()
        {
            state.GoRight(this);
            left = false;
            right = true;
        }
        public void TakeDamage()
        {
            state.TakeDamage(this);
            if (hurtFX.State == SoundState.Stopped)
            {
                hurtFX.Play();
            }
        }
        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            if (left)
            {
                state.GoLeft(this);
            }
            else
            {
                state.GoRight(this);
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
        public Rectangle GetRectangle()
        {
            return state.GetRectangle(new Vector2(xpos, ypos));
        }
    }
}
