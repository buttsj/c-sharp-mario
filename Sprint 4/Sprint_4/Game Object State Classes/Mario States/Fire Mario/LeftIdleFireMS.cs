using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftIdleFireMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
       
        public LeftIdleFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftIdleMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new LeftIdleSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new LeftJumpingFireMS(mario);
        }
        public void Down()
        {
            mario.state = new LeftCrouchingFireMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftMovingFireMS(mario);
        }
        public void GoRight()
        {
            mario.state = new RightMovingFireMS(mario);
        }
        public void Idle()
        {

        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            mario.state = new LeftIdleBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new LeftIdleSmallMS(mario);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeFireballMario()
        {
            mario.state = new LeftFireballFireMS(mario);
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
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
