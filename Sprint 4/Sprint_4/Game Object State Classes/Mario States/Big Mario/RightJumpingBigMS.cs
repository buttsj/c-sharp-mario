using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightJumpingBigMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
       
        public RightJumpingBigMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightJumpingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }
        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightJumpingSmallMS(mario));
        }
        public void Up()
        {
        }
        public void Down()
        {
            mario.state = new RightIdleBigMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftJumpingBigMS(mario);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
            mario.state = new RightIdleBigMS(mario);
        }
        public void Land()
        {
            mario.state = new RightMovingBigMS(mario);
        }
        public void Fall()
        {
            mario.state = new RightFallingBigMS(mario);
        }
        public void MakeBigMario()
        {
            // null
        }
        public void MakeSmallMario()
        {
            mario.TransitionState(mario.state, new RightJumpingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new RightJumpingFireMS(mario));
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
