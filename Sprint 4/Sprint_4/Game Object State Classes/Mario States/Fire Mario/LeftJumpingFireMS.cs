using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftJumpingFireMS : IMarioState
    {
        Mario mario;
        IAnimatedSprite sprite;
        
        public LeftJumpingFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftJumpingMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new LeftJumpingSmallMS(mario));
        }
        public void Up()
        {
            mario.position.Y--;
        }
        public void Down()
        {
            mario.state = new LeftIdleFireMS(mario);
        }
        public void GoLeft()
        {
            mario.position.X--;
        }
        public void GoRight()
        {
            mario.state = new RightJumpingFireMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleFireMS(mario);
        }
        public void Land()
        {
            mario.state = new LeftMovingFireMS(mario);
        }
        public void MakeBigMario()
        {
            mario.state = new LeftJumpingBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new LeftJumpingSmallMS(mario);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeFireballMario()
        {
            // null
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
