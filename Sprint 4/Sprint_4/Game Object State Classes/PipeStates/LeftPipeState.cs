using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class LeftPipeState : IPipeState
    {
        IAnimatedSprite sprite;
        ISpriteFactory factory;
        Mario mario;
        
        public LeftPipeState()
        {
            factory = new SpriteFactory();
            this.sprite = factory.build(SpriteFactory.sprites.leftPipe);
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return sprite.GetBoundingBox(location);
        }

        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Eat(Mario mario, Pipe pipe)
        {
            Game1.GetInstance().gameState = new PipeTransitionGameState(PipeTransitionGameState.direction.goIn, pipe);
            this.mario = mario;
        }
        public void Puke(Mario mario, Pipe pipe)
        {
            Game1.GetInstance().gameState = new PipeTransitionGameState(PipeTransitionGameState.direction.comeOut, pipe);
            this.mario = mario;
        }
        public void Chew(Mario mario)
        {
            mario.position.X++;
        }
        public void Gag(Mario mario)
        {
            mario.position.X--;
        }

    }
}