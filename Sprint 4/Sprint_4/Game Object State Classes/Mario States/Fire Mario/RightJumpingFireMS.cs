using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightJumpingFireMS : IMarioState
    {
        Mario mario;
        IAnimatedSprite sprite;
       

        public RightJumpingFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightJumpingMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightJumpingSmallMS(mario));
        }
        public void Up()
        {
            mario.position.Y--;
        }
        public void Down()
        {
            mario.state = new RightIdleFireMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftJumpingFireMS(mario);
        }
        public void GoRight()
        {
            mario.position.X++;
        }
        public void Idle()
        {
            mario.state = new RightIdleFireMS(mario);
        }
        public void Land()
        {
            mario.state = new RightMovingFireMS(mario);
        }
        public void MakeBigMario()
        {
            mario.state = new RightJumpingBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new RightJumpingSmallMS(mario);
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
