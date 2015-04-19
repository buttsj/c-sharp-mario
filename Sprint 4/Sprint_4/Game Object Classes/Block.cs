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
        public ICollectable prize;
        bool prizeSpawned = false;
        public Vector2 position = new Vector2(0, 0);
        int explosionTimer = 20;
        bool isExploding = false;

        public Block(Vector2 location, ICollectable prize, IBlockState state)
        {
            this.prize = prize;
            this.state = state;
            position = location;
        }

        public void Update(GameTime gameTime)
        {
            if (isExploding)
            {
                explosionTimer--;
            }
            if (explosionTimer < 0)
            {
                Game1.GetInstance().level.collision.destroyedBlocks.Add(this);
            }
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

        public void Explode()
        {
            state = new ExplodingBlockState();
            isExploding = true;
            Game1.GetInstance().gameHUD.Score += ValueHolder.brickBreakPoints;
            SoundManager.brickBreak.Play();
        }
    }
}
