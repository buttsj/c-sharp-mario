using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Block
    {
        public IBlockState state;
        public Item prize;
        bool prizeSpawned = false;
        public Vector2 position = new Vector2(0, 0);
        Game1 game;

        public Block(Game1 game, Vector2 location, Item prize)
        {
            this.game = game;
            position = location;
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime, this);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
        public void Reaction()
        {
            state.Reaction(this);
            if (prize != null && !prizeSpawned)
            {
                prize.Spawn();
                prizeSpawned = true;
            }
        }
        public Rectangle GetBoundingBox()
        {
            return state.GetBoundingBox(position);
        }
    }
}
