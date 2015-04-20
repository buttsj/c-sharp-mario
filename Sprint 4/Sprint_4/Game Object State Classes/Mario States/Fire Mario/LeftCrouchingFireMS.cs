using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftCrouchingFireMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
       
        public LeftCrouchingFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftCrouchingMarioFire);
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
            mario.state = new LeftIdleFireMS(mario);
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
            mario.state = new RightCrouchingFireMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleFireMS(mario);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
        }
        public void MakeSmallMario()
        {
            mario.state = new LeftCrouchingSmallMS(mario);
        }
        public void MakeFireMario()
        {
            // null
        }
        public void MakeFireballMario()
        {
            // null
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
