using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightJumpingSmallMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }

        public RightJumpingSmallMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.rightJumpingMarioSmall);
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
        }
        public void Down()
        {
            mario.state = new RightIdleSmallMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftJumpingSmallMS(mario);
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
            mario.state = new RightIdleSmallMS(mario);
        }
        public void Land()
        {
            mario.state = new RightMovingSmallMS(mario);
        }
        public void Fall()
        {
            mario.state = new RightFallingSmallMS(mario);
        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new RightJumpingBigMS(mario));
        }
        public void MakeSmallMario()
        {
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
            mario.TransitionState(mario.state, new RightJumpingBigMS(mario));
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
