using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Sprint4
{
    public class BasicEnemy
    {
        public IEnemyState state;
        public bool isDead = false;
        int deathAnimationTimer = 15;
        public bool left = true;
        public Vector2 position;
        Game1 game;
        SoundEffectInstance hurtFX;

        public BasicEnemy(Game1 game, Vector2 location, IEnemyState state)
        {
            this.game = game;
            position = location;
            this.state = state;
            hurtFX = this.game.soundManager.enemyDamage.CreateInstance();
        }
        public void GoLeft()
        {
            state.GoLeft(this);
            left = true;
        }
        public void GoRight()
        {
            state.GoRight(this);
            left = false;
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
                deathAnimationTimer--;
            }
            if (deathAnimationTimer <= 0)
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
