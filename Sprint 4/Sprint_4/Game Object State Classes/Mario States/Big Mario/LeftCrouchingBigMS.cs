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
        IAnimatedSprite sprite;
        
        public LeftCrouchingBigMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.leftCrouchingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new LeftCrouchingSmallMS(mario));
        }
        public void Up()
        {
            mario.state = new LeftIdleBigMS(mario);          
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
            mario.state = new RightCrouchingBigMS(mario);            
        }
        public void Idle()
        {
            mario.state = new LeftIdleBigMS(mario);            
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
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new LeftCrouchingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new LeftCrouchingFireMS(mario));
        }

        public void MakeFireballMario()
        {
            
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
