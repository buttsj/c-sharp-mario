using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightFallingSmallMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
        ISpriteFactory factory;
        
        public RightFallingSmallMS(Mario mario)
        {
            factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightFallingMarioSmall);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            MakeDeadMario();
        }
        public void Up()
        {
        }
        public void Down()
        {
        }
        public void GoLeft()
        {
            mario.state = new LeftFallingSmallMS(mario);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
        }
        public void Land()
        {
            mario.state = new RightMovingSmallMS(mario);
        }
        public void Fall()
        {
        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new RightFallingBigMS(mario));
        }
        public void MakeSmallMario()
        {
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
