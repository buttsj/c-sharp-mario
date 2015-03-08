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
        Game1 game;
        IAnimatedSprite sprite;
       
        
        public DeadMS(Game1 game){
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.deadMario);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
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
            game.level.mario.state = new RightIdleBigMS(game);
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new RightIdleSmallMS(game);
        }
        public void MakeFireMario()
        {
            game.level.mario.state = new RightIdleFireMS(game);
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
