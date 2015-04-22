using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightMovingSmallMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }

        public RightMovingSmallMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightMovingMarioSmall);
            this.mario = mario;
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            if (Game1.GetInstance().isVVVVVV)
            {
                mario.state = new DeadFlipMS(mario);
            }
            else
            {
                mario.state = new DeadMS(mario);
            }
        }
        public void Up()
        {
            mario.state = new RightJumpingSmallMS(mario);
        }
        public void Down()
        {
            mario.state = new RightCrouchingSmallMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftMovingSmallMS(mario);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
            mario.state = new RightIdleSmallMS(mario);
        }
        public void Land()
        {
        }
        public void Fall()
        {
        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new RightMovingBigMS(mario));
        }
        public void MakeSmallMario()
        {
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new RightMovingFireMS(mario));
        }
        public void MakeFireballMario()
        {
           
        }
        public void MakeNinjaMario()
        {
            mario.TransitionState(mario.state, new RightMovingBigMS(mario));
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Flip() 
        {
            mario.state = new RightMovingSmallFlipMS(mario);
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }
    }
}
