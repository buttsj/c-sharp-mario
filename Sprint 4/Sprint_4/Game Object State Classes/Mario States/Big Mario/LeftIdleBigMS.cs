using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftIdleBigMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
        
        public LeftIdleBigMS(Mario mario){
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftIdleMarioBig);
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
            mario.state = new LeftJumpingBigMS(mario);
        }
        public void Down()
        {
            mario.state = new LeftCrouchingBigMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftMovingBigMS(mario);
        }
        public void GoRight()
        {
            mario.state = new RightMovingBigMS(mario);
        }
        public void Idle()
        {

        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            // null
        }
        public void MakeSmallMario()
        {
            mario.TransitionState(mario.state, new LeftIdleSmallMS(mario));
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftIdleFireMS(mario));
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
