using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftJumpingBigMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
        ISpriteFactory factory;
        
        public LeftJumpingBigMS(Mario mario)
        {
            factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftJumpingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new LeftJumpingSmallMS(mario));
        }
        public void Up()
        {
        }
        public void Down()
        {
            mario.state = new LeftIdleBigMS(mario);
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            mario.state = new RightJumpingBigMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleBigMS(mario);
        }
        public void Land()
        {
            mario.state = new LeftMovingBigMS(mario);
        }
        public void Fall()
        {
            mario.state = new LeftFallingBigMS(mario);
        }
        public void MakeBigMario()
        {
            // null
        }
        public void MakeSmallMario()
        {
            mario.TransitionState(mario.state, new LeftJumpingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftJumpingFireMS(mario));
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
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }
    }
}
