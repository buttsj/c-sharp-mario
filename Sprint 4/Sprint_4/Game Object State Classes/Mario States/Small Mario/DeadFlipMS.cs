using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class DeadFlipMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }
       
        public DeadFlipMS(Mario mario){
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.deadMario);
            this.mario = mario;
            Game1.GetInstance().gameState = new DeadFlipGameState(mario);
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
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
        public void MakeNinjaMario()
        {

        }
        public void MakeDeadMario()
        {
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
