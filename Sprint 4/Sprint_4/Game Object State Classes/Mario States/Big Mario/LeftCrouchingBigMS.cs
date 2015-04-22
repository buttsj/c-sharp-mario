using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftCrouchingBigMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
        
        public LeftCrouchingBigMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftCrouchingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new LeftCrouchingSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new LeftIdleBigMS(mario);          
        }
        public void Down()
        {        
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            mario.state = new RightCrouchingBigMS(mario);            
        }
        public void Idle()
        {
            mario.state = new LeftIdleBigMS(mario);            
        }
        public void Land()
        {
        }
        public void Fall()
        {
        }
        public void MakeBigMario()
        {
            // null
        }
        public void MakeSmallMario()
        {
            mario.TransitionState(mario.state, new LeftCrouchingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftCrouchingFireMS(mario));
        }

        public void MakeFireballMario()
        {
            
        }
        public void MakeNinjaMario()
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
