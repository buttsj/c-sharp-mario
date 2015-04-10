using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftCrouchingSmallMS : IMarioState
    {

        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
       

        public LeftCrouchingSmallMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftCrouchingMarioSmall);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.state = new DeadMS(mario);
        }
        public void Up()
        {
            mario.state = new LeftIdleSmallMS(mario);
        }
        public void Down()
        {
            mario.position.Y++;
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            mario.state = new RightCrouchingSmallMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleSmallMS(mario);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new LeftCrouchingBigMS(mario));
        }
        public void MakeSmallMario()
        {
            // null
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftCrouchingFireMS(mario));
        }
        public void MakeFireballMario()
        {
            
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
