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
        IAnimatedSprite sprite;

        public RightMovingSmallMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightMovingMarioSmall);
            this.mario = mario;
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.state = new DeadMS(mario);
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
            mario.position.X++;
        }
        public void Idle()
        {
            mario.state = new RightIdleSmallMS(mario);
        }
        public void Land()
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
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
