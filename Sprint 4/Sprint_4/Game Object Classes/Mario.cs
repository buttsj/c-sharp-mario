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
        public ThrowingStar throwingStar;
        public bool isStar = false, isBig = false, isFire = false, 
            isDead = false, isCrouch = false, isFireball = false, isLeft = false, isNinja = false, isFalling = false, isJumping = false;
        private int starTimer = ValueHolder.maxStarTime;
        private int ninjaTimer = ValueHolder.maxNinjaTime;
        private int projectileTimer = ValueHolder.projectileDelay;
        public int fireballCount = 0;
        public int throwingStarCount = 0;
        public int invicibilityFrames = 0;
        public int gravityDirection = 1;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 maxVelocity = new Vector2(6, 15);
        public Vector2 minVelocity = new Vector2(-6, -3.5f);
        public int marioHeight = 0;        
        private SoundEffectInstance jumpFX;
        private SpriteFactory factory;
        private int modVal = 5;

        public Mario(Vector2 position)
        {
            state = new RightIdleSmallMS(this);
            physState = new GroundState(this);
            this.position = position;
            jumpFX = SoundManager.jump.CreateInstance();
            factory = new SpriteFactory();
        }

        public void TakeDamage()
        {
            state.TakeDamage();
            if (!isDead)
            {
                SoundManager.shrink.Play();
                invicibilityFrames = ValueHolder.maxInvinciblityTime;
            }
            if (isNinja)
            {
                SoundManager.PlaySong(SoundManager.songs.overworld);
            }
            isFireball = false;
            isBig = false;
            isFire = false;
            isNinja = false;
        }

        public void Jump()
        {
            if (velocity.Y > minVelocity.Y && !isFalling)
            {
                physState = new JumpingState(this);
                velocity.Y -= ValueHolder.jumpingVelocity;
                if (jumpFX.State == SoundState.Stopped)
                {
                    jumpFX.Play();
                }
            }
            state.Up();
        }

        public void Crouch()
        {
            state.Down();
            velocity.Y+=.1f;
            isCrouch = true;
        }

        public void GoLeft()
        {
            if (!isCrouch)
            {
            state.GoLeft();
                if (velocity.X > minVelocity.X)
            {
                velocity.X -= ValueHolder.walkingVelocity;
            }
            }
            isLeft = true;
        }

        public void GoRight()
        {
            if (!isCrouch)
            {
            state.GoRight();
                if (velocity.X < maxVelocity.X)
            {
                velocity.X += ValueHolder.walkingVelocity;
            }
            }
            isLeft = false;
        }

        public void Idle()
        {
            if ((velocity.X < ValueHolder.rightMarioIdlingRange.X && velocity.X > ValueHolder.leftMarioIdlingRange.X) &&
            (velocity.Y < ValueHolder.rightMarioIdlingRange.Y && velocity.Y > ValueHolder.leftMarioIdlingRange.Y) &&
            !isFalling)
            {
                state.Idle();
                isCrouch = false;
            }
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
            if (isNinja)
            {
                SoundManager.PlaySong(SoundManager.songs.overworld);
            }
            isBig = true;
            isFire = true;
            isFireball = false;
            isNinja = false;
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
            isNinja = false;
            if (fireballCount < ValueHolder.maxFireballs && isFire)
            {
                if (projectileTimer == 0)
                {
                    if (isLeft)
                    {
                        fireball = new Fireball(new Vector2(position.X - ValueHolder.projectileXSpawn, position.Y +
                            ValueHolder.projectileYSpawn), true);
                    }
                    else
                    {
                        fireball = new Fireball(new Vector2(position.X + ValueHolder.projectileXSpawn, position.Y +
                            ValueHolder.projectileYSpawn), false);
                    }
                    Game1.GetInstance().level.levelFireballs.Add(fireball);
                    fireballCount++;
                }
            }           
        }
        public void MakeNinjaMario()
        {
            state.MakeNinjaMario();
            if (throwingStarCount < ValueHolder.maxThrowingStars)
            {
                if (projectileTimer == 0)
                {
                    if (isLeft)
                    {
                        throwingStar = new ThrowingStar(new Vector2(position.X - ValueHolder.projectileXSpawn, position.Y +
                            ValueHolder.projectileYSpawn), true);
                    }
                    else
                    {
                        throwingStar = new ThrowingStar(new Vector2(position.X + ValueHolder.projectileXSpawn, position.Y +
                            ValueHolder.projectileYSpawn), false);
                    }
                    Game1.GetInstance().level.levelThrowingStars.Add(throwingStar);
                    throwingStarCount++;
                }
            }
            isBig = true;            
        }

       
        public void TransitionState(IMarioState prevState, IMarioState newState)
        {
            Game1.GetInstance().gameState = new TransitionGameState(this, prevState, newState);
        }

        public void Respawn()
        {
            state = new RightIdleSmallMS(this);
            position = Game1.GetInstance().level.checkpoint;
        }

        public void Update(GameTime gameTime, Game1 game)
        {            
            if (starTimer != 0 & isStar)
            {
                starTimer--;
            }
            if (ninjaTimer != 0 & isNinja)
            {
                ninjaTimer--;
            }
            if (invicibilityFrames != 0)
            {
                invicibilityFrames--;
            }
            if (starTimer == 0)
            {
                isStar = false;
                starTimer = ValueHolder.maxStarTime;
                if (!isNinja) SoundManager.PlaySong(SoundManager.songs.overworld);
                else SoundManager.PlaySong(SoundManager.songs.ninja);
            }
            if (ninjaTimer == 0)
            {
                isNinja = false;
                ninjaTimer = ValueHolder.maxNinjaTime;
                if (!isStar) SoundManager.PlaySong(SoundManager.songs.overworld);
                else SoundManager.PlaySong(SoundManager.songs.star);
            }
            if (position.Y > ValueHolder.fallingMarioBoundary)
            {
                state = new DeadMS(this);
                game.ach.AchievementAdjustment(AchievementsManager.AchievementType.Death);
            }         
                        
            if (projectileTimer != 0 )
            {
                projectileTimer--;
            }
            else
            {
                projectileTimer = ValueHolder.projectileDelay;                
            }           
            state.Update(gameTime);
            physState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            if (isStar && starTimer % modVal != 0)
            {
                state.Draw(spriteBatch, position, Color.Gold);
            }
            if (invicibilityFrames % modVal != 0)
            {
                state.Draw(spriteBatch, position, Color.White);
            }
            if (!isStar && !isNinja && invicibilityFrames == 0)
            {
                state.Draw(spriteBatch, position, Color.White);
            }
            if (isNinja)
            {
                if (ninjaTimer % modVal != 0) state.Draw(spriteBatch, position, Color.DarkSlateGray);
                else state.Draw(spriteBatch, position, Color.IndianRed);
            }
            
         }
       
       }
    }

