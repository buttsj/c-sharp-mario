using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class RightIdleBigMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
        
        public RightIdleBigMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightIdleMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightIdleSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new RightJumpingBigMS(mario);
        }
        public void Down()
        {
            mario.state = new RightCrouchingBigMS(mario);
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
            mario.TransitionState(mario.state, new RightIdleSmallMS(mario));
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new RightIdleFireMS(mario));
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
