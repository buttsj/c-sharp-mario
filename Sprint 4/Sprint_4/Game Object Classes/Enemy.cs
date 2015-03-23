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
        int deathTimer = 15;
        public enum Enemies { Dino, Koopa, Bill, SmashedDino}
        public bool right = false, left = true;
        public Vector2 position;
        Game1 game;
        SoundEffectInstance hurtFX;

        public Enemy(Game1 game, Enemy.Enemies type, Vector2 location)
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
            position = location;
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
            position.Y++;
            state.Update(gameTime);
            if (left)
            {
                state.GoLeft(this);
            }
            else
            {
                state.GoRight(this);
            }
            if (isDead)
            {
                deathTimer--;
            }
            if (deathTimer <= 0)
            {
                state = new NullEnemyState();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, position);
        }
        public Rectangle GetBoundingBox()
        {
            return state.GetBoundingBox(position);
        }
    }
}
