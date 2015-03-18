using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class Mario
    {
        Game1 game;
        public IMarioState state;
        public IMarioPhysicsState physState;
        public bool marioIsStar = false, marioIsBig = false, marioIsFire = false, isDead = false, isCrouch = false;
        private int starTimer = 1000;
        public int invicibilityFrames = 0;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 maxVelocity = new Vector2((float)6, (float)17);
        public Vector2 minVelocity = new Vector2((float) -6, (float)-3.5);
        public int marioHeight = 0;
        SoundEffectInstance jumpFX;

        public Mario(Game1 game, Vector2 position)
        {
            state = new RightIdleSmallMS(game);
            physState = new GroundState(this, game);
            this.game = game;
            this.position = position;
            jumpFX = game.soundManager.jump.CreateInstance();
        }

        public void Run()
        {
            if (velocity.X > minVelocity.X && velocity.X < maxVelocity.X)
            {
                velocity.X *= (float)1.3;
            }
        }

        public void TakeDamage()
        {
            state.TakeDamage();
            if (!isDead)
            {
                game.soundManager.shrink.Play();
                invicibilityFrames = 100;
            }
            marioIsBig = false;
            marioIsFire = false;
        }

        public void Up()
        {
            //mario needs to have an initial velocity, which slows as he gets higher. Max height is based on the time
            //it takes for his velocity to reach 0.
            if (velocity.Y > minVelocity.Y && physState.GetType() != (new FallingState(game)).GetType())
            {
                physState = new JumpingState(game);
                velocity.Y -= (float)2;
                if (jumpFX.State == SoundState.Stopped)
                {
                    jumpFX.Play();
                }
            }
            state.Up();
        }

        public void Down()
        {
            state.Down();
            velocity.Y++;
            isCrouch = true;
        }

        public void GoLeft()
        {
            state.GoLeft();
            if (velocity.X > minVelocity.X && !isCrouch)
            {
                velocity.X -= (float).3;
            }
        }

        public void GoRight()
        {
            state.GoRight();
            if (velocity.X < maxVelocity.X && !isCrouch)
            {
                velocity.X += (float).3;
            }
        }

        public void Idle()
        {
            state.Idle();
            isCrouch = false;
        }

        public void Land()
        {
            state.Land();
        }

        public void MakeBigMario()
        {
            if (!marioIsFire)
            {
                state.MakeBigMario();
            }
            marioIsBig = true;
            marioIsFire = false;
        }

        public void MakeFireMario()
        {
            state.MakeFireMario();
            marioIsBig = true;
            marioIsFire = true;
        }

        public void MakeFireballMario()
        {
            state.MakeFireballMario();
            marioIsBig = true;
            marioIsFire = true;
        }
        public void Update(GameTime gameTime)
        {
            if (starTimer != 0 & marioIsStar)
            {
                starTimer--;
            }
            if (invicibilityFrames != 0)
            {
                invicibilityFrames--;
            }
            if (starTimer == 0)
            {
                marioIsStar = false;
                starTimer = 1000;
                game.soundManager.PlaySong(SoundManager.songs.athletic);
            }
            if (position.Y > 500)
            {
                state = new DeadMS(game);
            }
            state.Update(gameTime);
            physState.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (marioIsStar && starTimer % 5 != 0)
            {
                state.Draw(spriteBatch, position);
            }
            if (invicibilityFrames % 5 != 0)
            {
                state.Draw(spriteBatch, position);
            }
            if (!marioIsStar && invicibilityFrames ==0)
            {
                state.Draw(spriteBatch, position);
            }
         }
       }
    }

