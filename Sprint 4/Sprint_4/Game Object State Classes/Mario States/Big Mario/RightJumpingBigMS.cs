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
        IAnimatedSprite sprite;
       
        public RightJumpingBigMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightJumpingMarioBig);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }
        public void TakeDamage()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new RightJumpingSmallMS(mario));
        }
        public void Up()
        {
            mario.position.Y--;
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
            mario.position.X++;
        }
        public void Idle()
        {
            mario.state = new RightIdleBigMS(mario);
        }
        public void Land()
        {
            mario.state = new RightMovingBigMS(mario);
        }
        public void MakeBigMario()
        {
            // null
        }
        public void MakeSmallMario()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new RightJumpingSmallMS(mario));
        }
        public void MakeFireMario()
        {
            Game1.GetInstance().gameState = new TransitionGameState(mario.state, new RightJumpingFireMS(mario));
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
