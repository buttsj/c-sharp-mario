using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightMovingFireMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }

        public RightMovingFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightMovingMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightMovingSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new RightJumpingFireMS(mario);
        }
        public void Down()
        {
            mario.state = new RightCrouchingFireMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftMovingFireMS(mario);
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

        }
        public void MakeBigMario()
        {
            mario.state = new RightMovingBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new RightMovingSmallMS(mario);
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
        public void Flip() { }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}
