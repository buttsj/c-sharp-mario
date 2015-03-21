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
        public Vector2 position = new Vector2(0, 0);

        public enum BlockType { used, question, winged, exclamation, brick, pipe, ground, leftEdge, rightEdge}

        public Block(Game1 game, Block.BlockType type, Vector2 location)
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
            if (type == BlockType.leftEdge)
            {
                state = new LeftEdgeBlockState(game);
            }
            if (type == BlockType.rightEdge)
            {
                state = new RightEdgeBlockState(game);
            }

            position.X = location.X;
            position.Y = location.Y;
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
        }
        public Rectangle GetRectangle()
        {
            return state.GetRectangle(position);
        }
    }
}
