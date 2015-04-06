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
        private int starTimer = ValueHolder.maxStarTime;
        private int fireballTimer = ValueHolder.fireballDelay;
        public int fireballCount = 0;
        public int invicibilityFrames = 0;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 maxVelocity = new Vector2((float)6, (float)17);
        public Vector2 minVelocity = new Vector2((float) -6, (float)-3.5);
        public int marioHeight = 0;
        SoundEffectInstance jumpFX;
        SpriteFactory factory;

        public Mario(Vector2 position)
        {
            state = new RightIdleSmallMS(this);
            physState = new GroundState(this);
            this.position = position;
            jumpFX = SoundManager.jump.CreateInstance();
            factory = new SpriteFactory();
        }

        public void Run()
        {
            physState.Run();
        }

        public void TakeDamage()
        {
            state.TakeDamage();
            if (!isDead)
            {
                SoundManager.shrink.Play();
                invicibilityFrames = ValueHolder.maxInvinciblityTime;
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
                velocity.Y -= ValueHolder.initialJumpingVelocity;
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
                velocity.X -= ValueHolder.walkingVelocity;
            }
            isLeft = true;
        }

        public void GoRight()
        {
            state.GoRight();
            if (velocity.X < maxVelocity.X && !isCrouch)
            {
                velocity.X += ValueHolder.walkingVelocity;
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

        public void MakeVictoryMario()
        {
            if (isFire)
            {
                state.Sprite = factory.build(SpriteFactory.sprites.victoryMarioFire);
            }
            else if (isBig)
            {
                state.Sprite = factory.build(SpriteFactory.sprites.victoryMarioBig);
            }
            else
            {
                state.Sprite = factory.build(SpriteFactory.sprites.victoryMarioSmall);
            }
        }

        public void MakeFireballMario()
        {
            state.MakeFireballMario();
            isFireball = true;
            if (fireballCount < ValueHolder.maxFireballs && isFire)
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
                starTimer = ValueHolder.maxStarTime;
                SoundManager.PlaySong(SoundManager.songs.athletic);
            }
            if (position.Y > ValueHolder.fallingMarioBoundary)
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
                fireballTimer = ValueHolder.fireballDelay;                
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

        public void TransitionState(IMarioState prevState, IMarioState newState)
        {
            Game1.GetInstance().gameState = new TransitionGameState(this, prevState, newState);
        }
       }
    }

