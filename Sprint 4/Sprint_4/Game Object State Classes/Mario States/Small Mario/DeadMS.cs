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
        }
        public void Up()
        {
        }
        public void Down()
        {
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
        }
        public void Idle()
        {
        }
        public void Land()
        {
        }
        public void MakeBigMario()
        {
        }
        public void MakeSmallMario()
        {
        }
        public void MakeFireMario()
        {
        }
        public void MakeFireballMario()
        {
            
        }
        public void MakeDeadMario()
        {
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
