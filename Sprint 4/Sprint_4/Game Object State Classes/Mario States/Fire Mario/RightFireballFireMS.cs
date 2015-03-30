using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightFireballFireMS : IMarioState
    {
        Mario mario;
        IAnimatedSprite sprite;


        public RightFireballFireMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightFireballMarioFire);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void TakeDamage()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new RightIdleSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new RightJumpingFireMS(mario);
        }
        public void Down()
        {
            mario.state = new RightCrouchingFireMS(mario);
        }
        public void GoLeft()
        {
            mario.state = new LeftFireballFireMS(mario);
        }
        public void GoRight()
        {
            mario.state = new RightMovingFireMS(mario);
        }
        public void Idle()
        {
          
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
            mario.state = new RightIdleBigMS(mario);
        }
        public void MakeSmallMario()
        {
            mario.state = new RightIdleSmallMS(mario);
        }
        public void MakeFireMario()
        {
            mario.state = new RightIdleFireMS(mario);
        }
        public void MakeFireballMario()
        {
            // null
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}
