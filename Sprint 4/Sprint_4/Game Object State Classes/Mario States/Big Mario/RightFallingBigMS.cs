using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightFallingBigMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
        ISpriteFactory factory;
        
        public RightFallingBigMS(Mario mario)
        {
            factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightFallingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            mario.TransitionState(mario.state, new RightFallingSmallMS(mario));
        }
        public void Up()
        {
        }
        public void Down()
        {
        }
        public void GoLeft()
        {
            mario.state = new LeftFallingBigMS(mario);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
        }
        public void Land()
        {
            mario.state = new RightMovingBigMS(mario);
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
            mario.TransitionState(mario.state, new RightFallingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new RightFallingFireMS(mario));
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
