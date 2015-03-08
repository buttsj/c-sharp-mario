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
        public float xpos = 0, ypos = 0;

        public enum BlockType { used, question, winged, exclamation, brick, pipe, ground}

        public Block(Game1 game, Block.BlockType type, Vector2 position)
        {
            if (type == BlockType.used)
            {
                state = new UsedBlockState(game);
            }
            if (type == BlockType.question)
            {
                state = new QuestionBlockState(game);
            }
            if (type == BlockType.winged)
            {
                state = new WingedBlockState(game);
            }
            if (type == BlockType.exclamation)
            {
                state = new ExclamationBlockState(game);
            }
            if (type == BlockType.brick)
            {
                state = new BrickBlockState(game);
            }
            if (type == BlockType.pipe)
            {
                state = new PipeBlockState(game);
            }
            if (type == BlockType.ground)
            {
                state = new GroundBlockState(game);
            }
            xpos = position.X;
            ypos = position.Y;
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
        public void Reaction()
        {
            state.Reaction();
        }
        public Rectangle GetRectangle()
        {
            return state.GetRectangle(new Vector2(xpos, ypos));
        }
    }
}
