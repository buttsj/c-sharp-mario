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
        public IEnemyPhysicsState physState;
        public bool isDead = false, isMagic = false;
        public int deathAnimationTimer = 15;
        public bool left = true;
        public Vector2 position;
        public Vector2 velocity;
        SoundEffectInstance hurtFX;

        public Enemy(Vector2 location, IEnemyState state)
        {
            position = location;
            this.state = state;
            hurtFX = SoundManager.enemyDamage.CreateInstance();
            physState = new EnemyGroundState(this);
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
            state.Update(this, gameTime);
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
