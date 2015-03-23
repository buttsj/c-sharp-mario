using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Sprint4
{
    public class Fireball
    {
        public IFireballState state;
        public bool left = true;
        public Vector2 position;
        public int fireballLifespan = 500;
        Game1 game;        

        public Fireball(Game1 game, Vector2 location)
        {            
            position = location;
            this.game = game;
            state = new FireballState(game);
        }

        public void GoLeft()
        {
            state.GoLeft(this);
            left = true;            
        }
        public void GoRight()
        {
            state.GoRight(this);
            left = false;            
        }
        
        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
            if (fireballLifespan != 0)
            {
                fireballLifespan--;
                if (left)
                {
                    state.GoLeft(this);
                }
                else
                {
                    state.GoRight(this);
                } 
            }
            position.Y++;       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (fireballLifespan != 0)
            {
                state.Draw(spriteBatch, position);
            }            
        }

        public Rectangle GetBoundingBox()
        {
            return state.GetBoundingBox(position);
        }
    }
}
