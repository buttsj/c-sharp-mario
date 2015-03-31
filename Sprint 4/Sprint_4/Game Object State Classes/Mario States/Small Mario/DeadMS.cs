using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class DeadMS : IMarioState
    {
        Mario mario;
        IAnimatedSprite sprite;
       
        public DeadMS(Mario mario){
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.deadMario);
            this.mario = mario;
            Game1.GetInstance().gameState = new DeadGameState();
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            // null
        }
        public void Up()
        {
            // null
        }
        public void Down()
        {
            // null
        }
        public void GoLeft()
        {
            // null
        }
        public void GoRight()
        {
            // null
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
            
        }
        public void MakeDeadMario()
        {
            // null
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
