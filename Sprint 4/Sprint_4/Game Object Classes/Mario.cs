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
        public IMarioState state;
        public IMarioPhysicsState physState;
        public Fireball fireball;
        public bool isStar = false, isBig = false, isFire = false, 
            isDead = false, isCrouch = false, isFireball = false, isLeft = false;
        private int starTimer = 1000;
        private int fireballTimer = 10;
        public int fireballCount = 0;
        public int invicibilityFrames = 0;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 maxVelocity = new Vector2((float)6, (float)17);
        public Vector2 minVelocity = new Vector2((float) -6, (float)-3.5);
        public int marioHeight = 0;
        SoundEffectInstance jumpFX;

        public Mario(Vector2 position)
        {
            state = new RightIdleSmallMS(this);
            physState = new GroundState(this);
            this.position = position;
            jumpFX = SoundManager.jump.CreateInstance();
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
                SoundManager.shrink.Play();
                invicibilityFrames = 100;
            }
            isFireball = false;
            isBig = false;
            isFire = false;
        }

        public void Up()
        {
            if (velocity.Y > minVelocity.Y && physState.GetType() != (new FallingState()).GetType())
            {
                physState = new JumpingState();
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
            isLeft = true;
        }

        public void GoRight()
        {
            state.GoRight();
            if (velocity.X < maxVelocity.X && !isCrouch)
            {
                velocity.X += (float).3;
            }
            isLeft = false;
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
            if (!isFire)
            {
                state.MakeBigMario();
                isFire = false;
            }
            else
            {
                isFire = true;
            }            
            isBig = true;          
            isFireball = false;
        }

        public void MakeFireMario()
        {
            state.MakeFireMario();
            isBig = true;
            isFire = true;
            isFireball = false;
        }

        public void MakeFireballMario()
        {
            state.MakeFireballMario();
            isFireball = true;
            if (fireballCount < 3 && isFire)
            {
                if (fireballTimer == 0)
                {
                    if (isLeft)
                    {
                        fireball = new Fireball(new Vector2(position.X - 5, position.Y + 3), true);
                    }
                    else
                    {
                        fireball = new Fireball(new Vector2(position.X + 5, position.Y + 3), false);
                    }
                    Game1.GetInstance().level.levelFireballs.Add(fireball);
                    fireballCount++;
                }
            }           
        }
        public void Update(GameTime gameTime)
        {            
            if (starTimer != 0 & isStar)
            {
                starTimer--;
            }
            if (invicibilityFrames != 0)
            {
                invicibilityFrames--;
            }
            if (starTimer == 0)
            {
                isStar = false;
                starTimer = 1000;
                SoundManager.PlaySong(SoundManager.songs.athletic);
            }
            if (position.Y > 500)
            {
                state = new DeadMS(this);
            }         
                        
            if (fireballTimer != 0 )
            {
                fireballTimer--;
                isFireball = false;                
            }
            else
            {
                fireballTimer = 10;                
            }           
            state.Update(gameTime);
            physState.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isStar && starTimer % 5 != 0)
            {
                state.Draw(spriteBatch, position);
            }
            if (invicibilityFrames % 5 != 0)
            {
                state.Draw(spriteBatch, position);
            }
            if (!isStar && invicibilityFrames ==0)
            {
                state.Draw(spriteBatch, position);
            }
         }
       }
    }

