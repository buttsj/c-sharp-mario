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
        public bool marioIsStar = false, marioIsBig = false, marioIsFire = false;
        private int starTimer = 1000;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 maxVelocity = new Vector2((float)2, (float)16);
        public Vector2 minVelocity = new Vector2((float) -2, (float)-5);
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

        public void TakeDamage()
        {
            state.TakeDamage();
            //game.soundManager.shrink.Play();
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
            //mario can still move left and right when in crouch state. Need to fix. The problem is that he's
            //in falling state due to his velocity, but if I turn that off he wont crouch.
            state.Down();
            velocity.Y++;
        }

        public void GoLeft()
        {
            state.GoLeft();
            if (velocity.X > minVelocity.X)
            {
                velocity.X -= (float).3;
            }
        }

        public void GoRight()
        {
            state.GoRight();
            if (velocity.X < maxVelocity.X)
            {
                velocity.X += (float).3;
            }
        }

        public void Idle()
        {
            state.Idle();
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

        public void Update(GameTime gameTime)
        {
            if (starTimer != 0 & marioIsStar)
            {
                starTimer--;
            }
            if (starTimer == 0)
            {
                marioIsStar = false;
                starTimer = 1000;
                game.soundManager.PlaySong(SoundManager.songs.athletic);
            }
            state.Update(gameTime);
            physState.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (marioIsStar & starTimer % 5 != 0)
            {
                state.Draw(spriteBatch, position);
            }
            if (!marioIsStar)
            {
                state.Draw(spriteBatch, position);
            }
         }
        }
    }

